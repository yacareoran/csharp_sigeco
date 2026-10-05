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

        private void LlenarComboCaracterPedido()
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
        private void CalcularTotalEstimado()
        {
            decimal totalGeneral = 0;

            foreach (DataGridViewRow fila in dgvDetalles.Rows)
            {
                // Ignoramos la fila vacía del final si la grilla permite agregar filas manualmente
                if (fila.IsNewRow) continue;

                // Reemplaza "Cant." y "Precio Unit." por los nombres reales (Name) de tus columnas
                if (fila.Cells[2].Value != null && fila.Cells[3].Value != null)
                {
                    // Usamos decimal.TryParse por seguridad para evitar caídas si el usuario escribe letras
                   
                    decimal.TryParse(fila.Cells[2].Value.ToString(), out decimal cantidad);
                    decimal.TryParse(fila.Cells[3].Value.ToString(), out decimal precioUnitario);

                    // Sumamos el subtotal de esta fila al total general
                    totalGeneral += (cantidad * precioUnitario);
                }
            }

            // Mostramos el resultado en tu TextBox con formato de dos decimales
            txtPrecioTotalEstimado.Text = totalGeneral.ToString("F2");
        }

        private void btnModificarPedido_Click(object sender, EventArgs e)
        {
            string rptaPedido = "";
            string rpta = "";
            MessageBox.Show("Este formulario es para editar pedidos");
            rptaPedido = NPedido.EditarPedido(Convert.ToInt32(this.txtIdPedido.Text), Convert.ToString(this.txtPasarObservaciones.Text), Convert.ToInt32(this.cmbEstadoPedido.SelectedValue), Convert.ToInt32(this.cmbCaracterPedido.SelectedValue));
            //if (rptaPedido != "no_insertado")
            if (rptaPedido == "OK")
            {
                MessageBox.Show("Revisar la tabla en sql server");
                
                //productos p = new productos();

                 for (int i = 0; i <= dgvDetalles.Rows.Count - 1; i++)
                 {
                    MessageBox.Show("el id de detalle es: " + " " + Convert.ToInt32(dgvDetalles.Rows[i].Cells[1].Value));
                    
                    rpta = NDetalle.EditarDetallexIdDetalle(Convert.ToInt32(dgvDetalles.Rows[i].Cells[1].Value), Convert.ToString(dgvDetalles.Rows[i].Cells[2].Value), Convert.ToInt32(dgvDetalles.Rows[i].Cells[3].Value), Convert.ToDecimal(dgvDetalles.Rows[i].Cells[4].Value));
                    //MessageBox.Show("Valor del parametro i: " + " " + i + " " + "la respuesta detalle es: " + " " + rpta + " " + "El ide detalle es: " + " " + dgvDetalles.Rows[i].Cells[1].Value);
                    MessageBox.Show("El valor que devuelve el parametro del procedimiento almacenado es: " + " " + rpta);
                 }

                MessageBox.Show("Se realizó correctamente la edicion de datos." + Convert.ToString(rptaPedido));

                
            }

            else
            {
                MessageBox.Show("No se realizo la edicion, pongase en contacto con el Administrador de base de datos de Procesamiento de Datos.");
                MessageBox.Show("Se muestra la respuesta de la edicion d epedido: " + " " + rptaPedido);
                //LimpiarPedido();
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
                this.txtModificarDetelle.Text = detalle;
                this.txtModificarCantidad.Text = cantidad;
                this.txtModificarPrecio.Text = precio;
                this.txtModificarIdDetalle.Text = id_detalle;
                //MessageBox.Show("Seleccionaste: " + valor);
            }
        }
        
        private void btnModificarDetalle_Click(object sender, EventArgs e)
        {
             // Asegurar selección de fila completa (se puede hacer en el diseñador)
            dgvDetalles.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            MessageBox.Show("Aqui se editan los datos");
            if (dgvDetalles.SelectedRows.Count > 0) // Validar que hay una fila seleccionada [13]
            {
                // Obtener la fila seleccionada
                DataGridViewRow fila = dgvDetalles.CurrentRow;

                string rptaDetalle = "";
                string rpta = "";
                MessageBox.Show("Este formulario es para editar pedidos");
                rptaDetalle = NDetalle.EditarDetallexIdDetalle(Convert.ToInt32(this.txtModificarIdDetalle.Text), Convert.ToString(this.txtModificarDetelle.Text), Convert.ToInt32(this.txtModificarCantidad.Text), Convert.ToDecimal(this.txtModificarPrecio.Text));
                //rptaDetalle = NDetalle.EditarDetallexIdDetalle(1142, "revisar", 5, 4500);
                //if (rptaDetalle == "no_se_edito_detalle")
                if (rptaDetalle == "OK")
                {

                    //MessageBox.Show("El id de detalle es:  " + " " + Convert.ToInt32(this.txtModificarIdDetalle.Text) + " " + Convert.ToString(this.txtModificarDetelle.Text) + " " + Convert.ToInt32(this.txtModificarCantidad.Text) + " " + Convert.ToDecimal(this.txtModificarPrecio.Text));
                    MessageBox.Show("Se realizo correctamente la edicion de la tabla Detalle." + Convert.ToInt32(rptaDetalle));

                    // LimpiarPedido();
                }

                else
                {
                    //MessageBox.Show("No se cargó la venta, pongase en contacto con el Administrador de base de datos de Procesamiento de Datos.");
                    MessageBox.Show("Se realizó correctamente la venta." + Convert.ToInt32(rptaDetalle));
                    //LimpiarPedido();
                }



            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila.");
            }
        }

        private void dgvDetalles_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Validamos que el cambio haya sido en las columnas de Cantidad o Precio
            // Reemplaza por el índice o el nombre de tus columnas
            if (e.ColumnIndex == 2 || e.ColumnIndex == 3)
            {
                CalcularTotalEstimado();
            }
             
        }
    }
}
