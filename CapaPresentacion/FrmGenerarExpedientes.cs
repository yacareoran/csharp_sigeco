using CapaDatos;
using CapaNegocio;
using iTextSharp.text;
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
    public partial class FrmGenerarExpedientes : Form
    {
        public FrmGenerarExpedientes()
        {
            InitializeComponent();

            // Hace que todas las celdas sean de solo lectura
            dgvPedidoExpedientes.ReadOnly = true;

            // Elimina la fila en blanco del final (evita que el usuario agregue filas)
            dgvPedidoExpedientes.AllowUserToAddRows = false;

            // Opcional: Evita que el usuario borre registros con la tecla Supr/Delete
            dgvPedidoExpedientes.AllowUserToDeleteRows = false;


        }

        private void FrmGenerarExpedientes_Load(object sender, EventArgs e)
        {
            this.LlenarComboOrganismo();
            this.LlenarComboTipoContratacion();
        }

        private List<DCargarPedidos> lst = new List<DCargarPedidos>();
        //Metodos llenar combobox

        private void LlenarComboOrganismo()
        {
           
            DataTable dt = NOrganismo.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbOrganismoExpediente.DataSource = dt;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbOrganismoExpediente.ValueMember = "id_organismo";
                this.cmbOrganismoExpediente.DisplayMember = "organismo";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbOrganismoExpediente.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbOrganismoExpediente.DataSource = null;
                this.cmbOrganismoExpediente.SelectedIndex = -1;
            }




        }

        private void LlenarComboTipoContratacion()
        {

            DataTable dt2 = NTipoContratacion.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbTipoContratacion.DataSource = dt2;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbTipoContratacion.ValueMember = "id_tipo_contratacion";
                this.cmbTipoContratacion.DisplayMember = "tipo_contratacion";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbTipoContratacion.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbTipoContratacion.DataSource = null;
                this.cmbTipoContratacion.SelectedIndex = -1;
            }




        }

        private void cmbOrganismoExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbOrganismoExpediente.SelectedValue != null && int.TryParse(cmbOrganismoExpediente.SelectedValue.ToString(), out int idOrganismo))
            {
                // Buscamos los subrubros de ese ID en específico
                //DataTable dtSubrubros = NSubrubro.BuscarSubrubroxRubro(idOrganismo);
                DataTable dtSectores = NSectores.BuscarSectoresxOrganismo(idOrganismo);

                cmbSectorExpediente.DataSource = dtSectores;
                cmbSectorExpediente.DisplayMember = "sector"; // Lo que el usuario VE
                cmbSectorExpediente.ValueMember = "id_sector";       // El ID oculto
            }
            else
            {
                // Si el usuario deselecciona el rubro, limpiamos los subrubros anteriores
                cmbSectorExpediente.DataSource = null;
            }
        }

        private void BuscarPedidoxNumeroTransaccion()
        {
            DataTable miDataTable = new DataTable();
            // 1. Guardamos el número en una variable para inspeccionarlo
            int numeroBuscado = Convert.ToInt32(this.txtBuscarTransaccion.Text);

            var listaPedidos = NPedido.BuscarxTransaccion(Convert.ToInt32(this.txtBuscarTransaccion.Text));
            //decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));
            List<DPedido> listaResumen = new List<DPedido>();
            //if (listaPedidos.Rows.Count <= 1)
            // 2. AGREGÁ ESTA LÍNEA TEMPORAL PARA DEPURALO:
            MessageBox.Show($"Buscando Transacción: {numeroBuscado} | Filas devueltas por SQL: {listaPedidos.Rows.Count}");

            // ¡CORREGIDO ACÁ! Cambiamos <= 1 por == 0
            if (listaPedidos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros");
                return;
            }

            foreach (DataRow row in listaPedidos.Rows)
            {
                Decimal SumaSubTotal = 0; Decimal Prueba = 0;
                Decimal CostoDetalles; Decimal CostoTotalDetalles = 0;
                //SumaSubTotal += listaResumen[i].Id_pedido;
                var listaCantidadDetalle = NDetalle.BuscarCantidadPrecio(Convert.ToInt32(row["id_pedido"]));
                MessageBox.Show(Convert.ToString(row["id_pedido"]));
                foreach (DataRow row1 in listaCantidadDetalle.Rows)
                {
                    CostoTotalDetalles += Convert.ToInt32(row1["cantidad"]) * Convert.ToDecimal(row1["precio"]);
                }
                Prueba = CostoTotalDetalles;

                listaResumen.Add(new DPedido
                {
                    Id_pedido = Convert.ToInt32(row["id_pedido"]),
                    Num_transaccion = Convert.ToInt32(row["num_transaccion"]),
                    Fecha_pedido = Convert.ToDateTime(row["fecha_pedido"]),
                    //Sectores_internos = row["sectores_internos"].ToString(),
                    //Extracto = row["extracto"].ToString(),
                    Caracter_pedido = row["caracter_pedido"].ToString(),
                    Pedido = row["pedido"].ToString(),
                    Estado = row["estado"].ToString(),
                    Costo_total = Prueba
                });

            }

            var datosfiltrados = listaResumen
               .Select(c => new
               {
                   Id_Pedido = c.Id_pedido,
                   Num_Transaccion = c.Num_transaccion,
                   FechaPedido = c.Fecha_pedido,
                   Sector = c.Sector,
                   CaracterPedido = c.Caracter_pedido,
                   Pedido = c.Pedido,
                   Estado = c.Estado,
                   costoTotal = c.Costo_total
               })
               .ToList();

            dgvPedidos.DataSource = datosfiltrados;
            // 2. Ocultamos la columna del ID (Sensible a mayúsculas/minúsculas)
            if (dgvPedidos.Columns["Id_Pedido"] != null)
            {
                dgvPedidos.Columns["Id_Pedido"].Visible = false;
            }
            // Las columnas se ajustan para mostrar todo el contenido del texto
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        //Inicio metodo LlenarGrilla
        private void LlenarGrilla()
        {//inicio metodo llenar grilla

            Decimal SumaSubTotal = 0; Decimal SumaIva = 0; Decimal SumaTotal = 0; decimal Subtotal = 0;
            dgvPedidoExpedientes.Rows.Clear();
            //contador = lst.Count;
            for (int i = 0; i < lst.Count; i++)
            //while (i <= lst.Count)
            {
                dgvPedidoExpedientes.Rows.Add();
                dgvPedidoExpedientes.Rows[i].Cells[0].Value = lst[i].Id_pedido;
                dgvPedidoExpedientes.Rows[i].Cells[1].Value = lst[i].Pedido;
                //dgvPedidoExpedientes.Rows[i].Cells[2].Value = lst[i].Descripcion_producto;
                //dgvPedidoExpedientes.Rows[i].Cells[3].Value = lst[i].Precio_producto;
                //dgvPedidoExpedientes.Rows[i].Cells[5].Value = lst[i].Stock;
                //Subtotal = Convert.ToDecimal(dataVentas.Rows[i].Cells[3].Value = lst[i].Precio_producto) * Convert.ToInt32(lst[i].Cantidad_producto);
                //Subtotal = Convert.ToDecimal(dataVentas.Rows[i].Cells[3].Value = lst[i].Precio_producto) * Convert.ToDecimal(lst[i].Cantidad_producto);
                //dataVentas.Rows[i].Cells[4].Value = Subtotal;

                
            }
           
            SumaTotal += SumaSubTotal;
            //this.labelTotal.Visible = true;
            //this.labelTotal.Text = Convert.ToString(Convert.ToDecimal(SumaTotal));
            
            dgvPedidoExpedientes.ClearSelection();


        }//fin metodo llenar grilla
        public void CargarVentasGrillaPedidos(int id_pedido, string pedido)
        {//inicio metdo cargar ventas desde Grilla Productos 08/11/21
                   
            //DFactura V = new DFactura();
            DCargarPedidos cargarPedidos = new DCargarPedidos();
            //DDetalle Detalle1 = new DDetalle();
            //decimal Subtotal = 0;
            //Esta instancia es para ver si se puede cargar desde el formulario frmGrillaProductos 02Noviembre 2021
            //frmGrillaProductos grillaProducto = new frmGrillaProductos();
            try
            {
                cargarPedidos.Id_pedido = id_pedido;
                //cargarPedidos.Num_transaccion = Convert.ToInt32(descripcion);
                cargarPedidos.Pedido = pedido;
                //cargarPedidos.Fecha_pedido = 
              
                //Ventas.Descripcion_producto = descripcion;
                //Ventas.Cantidad_producto = cantidad;
                //Ventas.Stock = stock;
                //Ventas.Id_factura = id_factura;
                //Ventas.Id_factura = Convert.ToInt32(grillaProducto.txtPrueba.Text);
                lst.Add(cargarPedidos);
                LlenarGrilla();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }


        }//fin metodo datagrid Ventas 

        private void btnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxNumeroTransaccion();
        }

        private void dgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            //FrmVenta ventas = Owner as FrmVenta;
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                CargarVentasGrillaPedidos(Convert.ToInt32(this.dgvPedidos.CurrentRow.Cells[0].Value.ToString()), this.dgvPedidos.CurrentRow.Cells[2].Value.ToString());


                /*if (MessageBox.Show("Esta seguro que esta bien seleccionado el producto?", "Ingrese cantidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //txtPrueba.BackColor = Color.Yellow;
                    //txtPrueba.Focus();
                    MessageBox.Show("Aqui se debe seleccionar la fila para cargar la otra greilla");
                    ventas.CargarVentasGrillaProductos(Convert.ToInt32(this.dataProductos.CurrentRow.Cells[0].Value.ToString()), this.dataProductos.CurrentRow.Cells[2].Value.ToString(), Convert.ToDecimal(this.txtPrueba.Text), Convert.ToDecimal(this.dataProductos.CurrentRow.Cells[5].Value.ToString()), 1097, Convert.ToDecimal(this.dataProductos.CurrentRow.Cells[3].Value.ToString()), Convert.ToDecimal(this.dataProductos.CurrentRow.Cells[4].Value.ToString()), Convert.ToInt32(this.dataProductos.CurrentRow.Cells[10].Value.ToString()));
                    this.Close();
                }*/

            }
        }

        private void txtBuscarPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);
                //this.lblStock.Text = "Stock: " + Convert.ToString(this.dataListadoProductos.CurrentRow.Cells["stock"].Value);
                this.dgvPedidos.Columns[0].Visible = false;
                this.dgvPedidos.Columns[1].Visible = false;
                this.dgvPedidos.Columns[6].Visible = false;
                this.dgvPedidos.Columns[8].Visible = false;
                this.dgvPedidos.Columns[9].Visible = false;
                this.dgvPedidos.Columns[10].Visible = false;
                this.dgvPedidos.Columns[2].Width = 250;
                this.dgvPedidos.Columns[3].Width = 80;
                this.dgvPedidos.Columns[4].Width = 80;
                this.dgvPedidos.Columns[5].Width = 80;
                this.dgvPedidos.Columns[7].Width = 100;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Los productos no coinciden con las letras ingresadas, vuelva a ingresar el nombre del producto o agreguelo desde el boton nuevo producto" + "" + ex);
            }
        }

        private void btnGenerarExpediente_Click(object sender, EventArgs e)
        {
            NPedido pedido = new NPedido();
            int numero = NPedido.BuscarMaximoNumeroExpediente();
            this.lblExpedienteInterno.Text = Convert.ToString("04") + "-" + Convert.ToString(numero); 
            MessageBox.Show("maximo numero para expedioentre interno " + " " + numero );
        }

        private void btnGuardarExpediente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("aqui se generan los numero de expediente");
        }
    }
}
