using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmEditarPedido : Form
    {
        private List<int> idsDetallesEliminados = new List<int>();
        public FrmEditarPedido()
        {
            InitializeComponent();
            // Sacamos el boton restaurar del formulario
            this.barraTituloRibbon1.MostrarMaximizar = false;

            // --- TU LÍNEA DE COLOR CONFIGURADA EN EL INICIO ---
            this.BackColor = Color.FromArgb(240, 244, 250);

            // --- BORDES ELEGANTES PARA TUS BOTONES ---
            Color colorGrisBorde = Color.FromArgb(160, 180, 210);

            // Botón Agregar renglón
            this.btnAgregarRenglon.FlatStyle = FlatStyle.Flat;
            this.btnAgregarRenglon.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Eliminar renglón
            this.btnEliminarRenglon.FlatStyle = FlatStyle.Flat;
            this.btnEliminarRenglon.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Modificar pedido
            this.btnModificarPedido.FlatStyle = FlatStyle.Flat;
            this.btnModificarPedido.FlatAppearance.BorderColor = colorGrisBorde;

            this.LlenarComboCaracterPedido();
            this.LlenarComboEstado();
        }
        
        private void FrmEditarPedido_Load(object sender, EventArgs e)
        {
            
        }

        private void LlenarComboCaracterPedido()
        {
            this.cmbCaracterPedido.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCaracterPedido.DisplayMember = "caracter_pedido";
            this.cmbCaracterPedido.ValueMember = "id_caracter_pedido";
            this.cmbCaracterPedido.DataSource = NCaracterPedido.Mostrar();
        }
        
        private void LlenarComboEstado()
        {
            this.cmbEstadoPedido.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbEstadoPedido.DisplayMember = "estado";
            this.cmbEstadoPedido.ValueMember = "id_estado";
            this.cmbEstadoPedido.DataSource = NEstado.Mostrar();
        }

        private void CalcularTotalEstimado()
        {
            // Forzamos a la grilla a cerrar cualquier edición pendiente
            dgvDetalles.EndEdit();

            if (dgvDetalles.DataSource is BindingList<DDetalle> listaDetalles)
            {
                // Suma ultra rápida en memoria RAM (eficiencia pura)
                decimal totalGeneral = listaDetalles.Sum(item => item.Cantidad * item.Precio);

                // Mostramos el resultado en la caja de texto
                txtPrecioTotalEstimado.Text = totalGeneral.ToString("N2");
            }
        }

        // 1. Este evento detecta el cambio apenas el usuario escribe o edita la celda
        private void dgvDetalles_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            // Si la celda actual está en estado "sucia" (modificada), confirmamos el cambio inmediatamente
            if (dgvDetalles.IsCurrentCellDirty)
            {
                dgvDetalles.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        // 2. Al hacer el CommitEdit arriba, este evento se va a disparar AL TOQUE
        private void dgvDetalles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que el cambio sea en las columnas de Cantidad (3) o Precio (4)
            if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
            {
                // Llamamos a tu método centralizado
                this.CalcularTotalEstimado();
            }
        }

        private void btnModificarPedido_Click(object sender, EventArgs e)
        {
            string rptaPedido = "";
            string rpta = "";
            bool detallesOk = true;
            string mensajeErrorDetalle = "";

            rptaPedido = NPedido.EditarPedido(
                Convert.ToInt32(this.txtIdPedido.Text),
                Convert.ToString(this.txtPasarObservaciones.Text),
                Convert.ToInt32(this.cmbEstadoPedido.SelectedValue),
                Convert.ToInt32(this.cmbCaracterPedido.SelectedValue)
            );

            if (rptaPedido == "OK")
            {
                // Confirma cualquier edición que haya quedado abierta en la última celda de la grilla
                dgvDetalles.EndEdit();

                // Obtenemos la lista tipada directamente desde el DataSource de la grilla
                var listaDetalles = (BindingList<DDetalle>)dgvDetalles.DataSource;
                int idPedidoActual = Convert.ToInt32(this.txtIdPedido.Text);

                // Eliminar en SQL Server los renglones quitados
                foreach (int idEliminar in idsDetallesEliminados)
                {
                    rpta = NDetalle.Eliminar(idEliminar); // <-- Usa aquí el nombre exacto de tu método en NDetalle
                    if (rpta != "OK")
                    {
                        detallesOk = false;
                        mensajeErrorDetalle = rpta;
                        break;
                    }
                }

                foreach (DDetalle item in listaDetalles)
                {
                    if (item.Id_detalle > 0)
                    {
                        // RENGLÓN EXISTENTE: Actualiza en SQL Server
                        rpta = NDetalle.EditarDetallexIdDetalle(
                            item.Id_detalle,
                            item.Detalle,
                            item.Cantidad,
                            item.Precio
                        );
                    }
                    else
                    {
                        // RENGLÓN NUEVO (Id_detalle == 0): Inserta en SQL Server con tus 8 parámetros
                        rpta = NDetalle.Insertar(
                            item.Detalle,
                            item.Cantidad,
                            item.Unidad_medida_id,
                            item.Precio,
                            idPedidoActual,
                            item.Renglon,
                            item.Rubro_id,
                            item.Subrubro_id
                        );
                    }

                    if (rpta != "OK" && rpta != "Detalle actualizado correctamente")
                    {
                        detallesOk = false;
                        mensajeErrorDetalle = rpta;
                        break;
                    }
                }

                if (detallesOk)
                {
                    MessageBox.Show("Pedido modificado correctamente", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Error al procesar detalle:\n" + mensajeErrorDetalle, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se realizó la edición, póngase en contacto con el Administrador de base de datos de Procesamiento de Datos.\nDetalle: " + rptaPedido, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RecalcularTotalEstimado()
        {
            if (dgvDetalles.DataSource is BindingList<DDetalle> listaActual)
            {
                decimal totalGeneral = 0;

                foreach (DDetalle item in listaActual)
                {
                    totalGeneral += item.Cantidad * item.Precio;
                }

                // Lo mostramos con formato numérico de 2 decimales (ej: 15.450,00)
                this.txtPrecioTotalEstimado.Text = totalGeneral.ToString("N2");
            }
            //Un detalle extra sobre el formato
            //Fíjate que usamos .ToString("N2") (que formatea con miles y dos decimales, igual que
            //tu columna de precio unitario en la grilla). Si en otra parte de FrmEditarPedido lees
            //txtPrecioTotalEstimado.Text para convertirlo a decimal, asegúrate de usar
            //decimal.Parse(txtPrecioTotalEstimado.Text) sin miedo, porque C# reconoce el formato
            //"N2" local de Argentina automáticamente.
        }

        private void dgvDetalles_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // Validar que no sea el encabezado de la fila
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = dgvDetalles.Rows[e.RowIndex];
                // Obtener datos de una celda específica (por ejemplo, columna "Nombre")
                string detalle = fila.Cells["detalle"].Value.ToString();
                string cantidad = fila.Cells["cantidad"].Value.ToString();
                string precio = fila.Cells["precio"].Value.ToString();
                string id_detalle = fila.Cells["id_detalle"].Value.ToString();
            }
        }

        private void btnAgregarRenglon_Click(object sender, EventArgs e)
        {
            //FrmAgregarRenglon agregarRenglon = new FrmAgregarRenglon();
            //agregarRenglon.ShowDialog();
            using (FrmAgregarRenglon frmNuevo = new FrmAgregarRenglon())
            {
                // Abre la ventanita y espera a que el usuario presione "Agregar"
                if (frmNuevo.ShowDialog() == DialogResult.OK)
                {
                    // Recuperamos la lista actual enlazada a la grilla
                    var listaActual = (BindingList<DDetalle>)dgvDetalles.DataSource;

                    // Calculamos el número de renglón siguiente automáticamente
                    int siguienteRenglon = listaActual.Count > 0 ? listaActual.Max(x => x.Renglon) + 1 : 1;
                    frmNuevo.NuevoDetalle.Renglon = siguienteRenglon;

                    // Lo agregamos a la lista (al ser BindingList, aparece solo en la grilla al instante)
                    listaActual.Add(frmNuevo.NuevoDetalle);
                    RecalcularTotalEstimado(); // <-- Actualiza el total al instante

                    // Opcional: Recalcular el total estimado del pedido aquí
                }
            }
        }

        private void dgvDetalles_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            RecalcularTotalEstimado();
        }

        private void btnEliminarRenglon_Click(object sender, EventArgs e)
        {
            if (dgvDetalles.CurrentRow == null || dgvDetalles.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, seleccione el renglón que desea eliminar.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DDetalle itemSeleccionado = (DDetalle)dgvDetalles.CurrentRow.DataBoundItem;

            DialogResult confirmacion = MessageBox.Show(
                $"¿Está seguro que desea quitar el renglón '{itemSeleccionado.Detalle}'?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                // 1. Si el registro ya existía en SQL Server (Id > 0), guardamos su ID para borrarlo al guardar
                if (itemSeleccionado.Id_detalle > 0)
                {
                    idsDetallesEliminados.Add(itemSeleccionado.Id_detalle);
                }

                // 2. Lo quitamos de la grilla al instante
                var listaActual = (BindingList<DDetalle>)dgvDetalles.DataSource;
                listaActual.Remove(itemSeleccionado);

                // 3. Renumeramos los renglones (1, 2, 3...) para que no queden huecos
                int numRenglon = 1;
                foreach (DDetalle item in listaActual)
                {
                    item.Renglon = numRenglon++;
                }
                dgvDetalles.Refresh();

                // 4. Descontamos el monto del Precio Total Estimado
                RecalcularTotalEstimado();
            }
        }
    }
}
