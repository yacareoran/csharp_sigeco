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
        public FrmEditarPedido()
        {
            InitializeComponent();
            this.LlenarComboCaracterPedido();
            this.LlenarComboEstado();
        }
        
        private void FrmEditarPedido_Load(object sender, EventArgs e)
        {
            
        }

        /*private void LlenarComboCaracterPedido()
        {
            this.cmbCaracterPedido.DataSource = NCaracterPedido.Mostrar();
            this.cmbCaracterPedido.ValueMember = "id_caracter_pedido";
            this.cmbCaracterPedido.DisplayMember = "caracter_pedido";
            this.cmbCaracterPedido.SelectedIndex = 1;
        }

        private void LlenarComboEstado()
        {
            this.cmbEstadoPedido.DataSource = NEstado.Mostrar();
            this.cmbEstadoPedido.ValueMember = "id_estado";
            this.cmbEstadoPedido.DisplayMember = "estado";
            this.cmbEstadoPedido.SelectedIndex = 1;
        }
        */
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

            // Diagnóstico temporal: verifica qué IDs están enviando tus combos (bórralo cuando funcione)
            MessageBox.Show("Enviando -> Estado ID: " + cmbEstadoPedido.SelectedValue + " | Carácter ID: " + cmbCaracterPedido.SelectedValue);

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

                for (int i = 0; i <= dgvDetalles.Rows.Count - 1; i++)
                {
                    // Evita procesar la fila nueva vacía si está habilitada
                    if (dgvDetalles.Rows[i].IsNewRow) continue;

                    rpta = NDetalle.EditarDetallexIdDetalle(
                        Convert.ToInt32(dgvDetalles.Rows[i].Cells[1].Value),
                        Convert.ToString(dgvDetalles.Rows[i].Cells[2].Value),
                        Convert.ToInt32(dgvDetalles.Rows[i].Cells[3].Value),
                        Convert.ToDecimal(dgvDetalles.Rows[i].Cells[4].Value)
                    );

                    // Acepta tanto "OK" como el mensaje de éxito que devuelve tu capa de datos
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
                    MessageBox.Show("Error al actualizar detalle:\n" + mensajeErrorDetalle, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("No se realizó la edición, póngase en contacto con el Administrador de base de datos de Procesamiento de Datos.\nDetalle: " + rptaPedido, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        
       
    }
}
