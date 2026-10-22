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
        private List<DCargarDetalles> lsd = new List<DCargarDetalles>();
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
            int numeroBuscado = Convert.ToInt32(this.txtBuscarNotaPedido.Text);

            var listaPedidos = NPedido.BuscarxTransaccion(Convert.ToInt32(this.txtBuscarNotaPedido.Text));
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
                   
            
            DCargarPedidos cargarPedidos = new DCargarPedidos();
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
            try
            {
                
                // 1. Primero traés los datos. Al hacer esto, el DataGridView genera automáticamente las columnas, [1], [2], etc.
                this.dgvPedidos.DataSource = NPedido.BuscarNotaPedido(this.txtBuscarNotaPedido.Text);

                // 2. Ahora que las columnas SÍ existen en memoria, las modificás y ocultás sin errores
                this.dgvPedidos.Columns[0].Width = 60;
                this.dgvPedidos.Columns[1].Visible = false;
                this.dgvPedidos.Columns[2].Width = 400;
                this.dgvPedidos.Columns[3].Visible = false;
                this.dgvPedidos.Columns[4].Visible = false;
                this.dgvPedidos.Columns[5].Visible = false;
                this.dgvPedidos.Columns[6].Width = 80;
                this.dgvPedidos.Columns[7].Visible = false;
                this.dgvPedidos.Columns[8].Visible = false;
                this.dgvPedidos.Columns[9].Visible = false;
                this.dgvPedidos.Columns[10].Visible = false;

                // Ojo: Recordá que tu procedimiento ahora devuelve más campos (hasta el índice 17).
                // Si querés ocultar TODOS los demás automáticamente para que no aparezcan al final, podés sumar este bucle:
                for (int i = 11; i < this.dgvPedidos.Columns.Count; i++)
                {
                    this.dgvPedidos.Columns[i].Visible = false;
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Los productos no coinciden con las letras ingresadas, vuelva a ingresar el nombre del producto o agreguelo desde el boton nuevo producto" + "" + ex);
            }
        }

        private void dgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            //FrmVenta ventas = Owner as FrmVenta;
            if (e.KeyCode == Keys.Enter)
            {
                
                decimal monto_total = 0;
                e.SuppressKeyPress = true;


                CargarVentasGrillaPedidos(Convert.ToInt32(this.dgvPedidos.CurrentRow.Cells[0].Value.ToString()), this.dgvPedidos.CurrentRow.Cells[2].Value.ToString());
                MessageBox.Show("El id_pedido es: " + " " + this.dgvPedidos.CurrentRow.Cells[1].Value.ToString());
                
                // 1. Validar que el usuario haya ingresado un número válido
                if (!int.TryParse(this.dgvPedidos.CurrentRow.Cells[0].Value.ToString(), out int idPedido))
                {
                    MessageBox.Show("Por favor, ingresa un ID de pedido numérico y válido.",
                                    "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                
                try
                {
                    // 2. Llamar a la Capa de Negocio pasando el ID limpio
                    // Nota: Reemplaza 'N_Pedido' por el nombre real de tu clase de la Capa de Negocio
                    DataTable dtDetalles = NPedido.BuscarDetallesxId(idPedido);
                    //Decimal SumaSubTotall = 0; //Decimal Prueba = 0;
                    Decimal CostoDetalless; Decimal CostoTotalDetalless = 0;


                    //var listaCantidadDetalles = NPedido.BuscarDetallesxId(idPedido);
                    //MessageBox.Show(Convert.ToString(row["id_pedido"]));
                    //foreach (DataRow row1 in listaCantidadDetalles.Rows)
                    //{
                    //    SumaSubTotall += Convert.ToInt32(row1["cantidad"]) * Convert.ToDecimal(row1["precio"]);
                    //}
                    //Prueba = CostoTotalDetalles;

                    // 1. OBLIGATORIO: Declarar e inicializar la variable como decimal antes del bucle
                    decimal SumaSubTotall = 0;

                    var listaCantidadDetalles = NPedido.BuscarDetallesxId(idPedido);

                    // Verificamos que traiga datos para evitar un NullReferenceException
                    if (listaCantidadDetalles != null)
                    {
                        foreach (DataRow row1 in listaCantidadDetalles.Rows)
                        {
                            MessageBox.Show("La cantidad es:" + " " + row1["cantidad"]);
                            // 2. Controlamos que los campos no sean NULL en la Base de Datos
                            if (row1["cantidad"] != DBNull.Value && row1["precio"] != DBNull.Value)
                            {
                                // 3. Multiplicamos y sumamos a nuestra variable decimal
                                SumaSubTotall += Convert.ToInt32(row1["cantidad"]) * Convert.ToDecimal(row1["precio"]);
                                MessageBox.Show("En el foreach de detalles el subtotal es:" + " " + SumaSubTotall);
                            }
                        }
                        MessageBox.Show("afuera del foreach el subtrotal es: " + " " + SumaSubTotall);
                        this.lblMontoTotal.Text = Convert.ToString(SumaSubTotall);
                    }

                    



                    else
                    {
                        //dgvDetalles.DataSource = null; // Limpiamos el grid si no hay datos
                        MessageBox.Show("No se encontraron detalles para el ID de pedido ingresado.",
                                        "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // 4. Capturar el error que escaló desde la Capa de Datos y mostrarlo amigablemente
                    MessageBox.Show($"Ocurrió un error al consultar los datos: {ex.Message}",
                                    "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                


            }
        }

        private void txtBuscarPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);
                // 1. Primero traés los datos. Al hacer esto, el DataGridView genera automáticamente las columnas, [1], [2], etc.
                this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);

                // 2. Ahora que las columnas SÍ existen en memoria, las modificás y ocultás sin errores
                this.dgvPedidos.Columns[0].Width = 60;
                this.dgvPedidos.Columns[1].Visible = false;
                this.dgvPedidos.Columns[2].Width = 425;
                this.dgvPedidos.Columns[3].Visible = false;
                this.dgvPedidos.Columns[4].Visible = false;
                this.dgvPedidos.Columns[5].Width = 80;
                this.dgvPedidos.Columns[6].Visible = false;
                this.dgvPedidos.Columns[7].Visible = false;
                this.dgvPedidos.Columns[8].Visible = false;
                this.dgvPedidos.Columns[9].Visible = false;
                this.dgvPedidos.Columns[10].Visible = false;

                // Ojo: Recordá que tu procedimiento ahora devuelve más campos (hasta el índice 17).
                // Si querés ocultar TODOS los demás automáticamente para que no aparezcan al final, podés sumar este bucle:
                for (int i = 11; i < this.dgvPedidos.Columns.Count; i++)
                {
                    this.dgvPedidos.Columns[i].Visible = false;
                }

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
            if (numero >= 0)
            {
                numero = numero + 1;
                this.lblExpedienteInterno.Text = Convert.ToString("04") + "-" + Convert.ToString(numero);
            }
            else
            {
                MessageBox.Show("maximo numero para expedioentre interno " + " " + numero);
            }  
        }

        private void btnGuardarExpediente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("debe generar nuevamente en número de expediente o pongase en contacto con un administrador");
        }
    }
}
