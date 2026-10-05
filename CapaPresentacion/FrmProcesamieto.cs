using CapaDatos;
using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmProcesamieto : Form
    {
        public FrmProcesamieto()
        {
            InitializeComponent();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            FrmNotaPedido notaPedido = new FrmNotaPedido();
            FrmPrincipal principal = new FrmPrincipal();
            notaPedido.txtUsuario.Text = this.txtUsuarioProcesamiento.Text;
            notaPedido.txtOrigen.Text = this.txtOrigenSector.Text;
            notaPedido.txtIdUsuario.Text = this.txtIdUsuario.Text;
            notaPedido.txtLegajo.Text = this.txtLegajoUsuario.Text;
            notaPedido.txtIdSectoresInternos.Text = this.txtIdSectoresInternos.Text;
            notaPedido.Show();
        }

        private void BuscarPedidoxFechas()
        {
            DataTable miDataTable = new DataTable();
            var listaPedidos = NPedido.BuscarxFechas(this.dtpHoraInicial.Value.ToString("yyyy-MM-dd"), this.dtpHoraFinal.Value.ToString("yyyy-MM-dd"), Convert.ToInt32(this.txtIdSectoresInternos.Text));
            //decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));
            List<DPedido> listaResumen = new List<DPedido>();

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
                    Sectores_internos = row["sectores_internos"].ToString(),
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

                dgvBuscarPedidos.DataSource = datosfiltrados;
                // Las columnas se ajustan para mostrar todo el contenido del texto
                dgvBuscarPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxFechas();
        }

        private void btnEditarPedido_Click(object sender, EventArgs e)
        {
            FrmEditarPedido editarPedido = new FrmEditarPedido();
            editarPedido.txtNumeroTransaccion.Text = Convert.ToString(this.dgvBuscarPedidos.CurrentRow.Cells[1].Value.ToString());
            editarPedido.txtIdPedido.Text = Convert.ToString(this.dgvBuscarPedidos.CurrentRow.Cells[0].Value.ToString());
            editarPedido.txtPasarFechaPedido.Text = Convert.ToString(this.dgvBuscarPedidos.CurrentRow.Cells[2].Value.ToString());
            editarPedido.txtPasarObservaciones.Text = Convert.ToString(this.dgvBuscarPedidos.CurrentRow.Cells[5].Value.ToString());
            editarPedido.txtPrecioTotalEstimado.Text = Convert.ToString(this.dgvBuscarPedidos.CurrentRow.Cells[7].Value.ToString());
            editarPedido.txtLegajo.Text = this.txtLegajoUsuario.Text;
            // 1. Obtener el ID de la fila seleccionada (suponiendo que está en la columna 0)
            //int idCaracterPedidoGrid = Convert.ToInt32(this.dgvBuscarPedidos.CurrentRow.Cells[4].Value);
            int idCaracterPedidoGrid = Convert.ToInt32(1);
            // 3. Pasar el valor a la propiedad pública
            //editarPedido.cmbCaracterPedido.SelectedIndex = idSexoGrid;
            //frm.IdSexoRecibido = idSexoGrid;


            DataTable miDataTable = new DataTable();
            List<DDetalle> listaResumen = new List<DDetalle>();

                
            var listaCantidadDetalle = NDetalle.BuscarDetalles(Convert.ToInt32(this.dgvBuscarPedidos.CurrentRow.Cells[0].Value.ToString()));
            // Suponiendo que tu DataTable se llama 'miDataTable'
            foreach (DataColumn columnna in listaCantidadDetalle.Columns)
            {
                columnna.ReadOnly = false;
            }
           
            foreach (DataRow row in listaCantidadDetalle.Rows)
                {
                listaResumen.Add(new DDetalle
                {
                    Renglon = Convert.ToInt32(row["renglon"]),
                    Id_detalle = Convert.ToInt32(row["id_Detalle"]),
                    Detalle = row["detalle"].ToString(),
                    //Detalle = Convert.ToString(row["detalle"]),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Precio = Convert.ToDecimal(row["precio"]),
                    
                    
                });

                }


            // 1. Evitas que el grid cree columnas por su cuenta
            editarPedido.dgvDetalles.AutoGenerateColumns = false;

            // 2. Limpias columnas existentes (por si acaso)
            editarPedido.dgvDetalles.Columns.Clear();

            // 3. Agregas manualmente solo las que necesitas
            //editarPedido.dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { 
            // DataPropertyName = "Id_detalle", HeaderText = "ID" 
            //});
            //var colId = new DataGridViewTextBoxColumn { DataPropertyName = "Id_detalle", HeaderText = "ID" };
            //colId.Width = 50; // Un ID suele ser pequeño
            //editarPedido.dgvDetalles.Columns.Add(colId);


            // 3. Creas y agregas cada columna UNA sola vez configurando sus propiedades
            var colRenglon = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Renglon",
                HeaderText = "Renglón",
                Width = 80
            };
            editarPedido.dgvDetalles.Columns.Add(colRenglon);

            var colId = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Id_detalle",
                HeaderText = "ID",
                Width = 50
            };
            editarPedido.dgvDetalles.Columns.Add(colId);






            //editarPedido.dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { 
            //    DataPropertyName = "Detalle", HeaderText = "Producto/Detalle" 
            //});
            //var colDetalle = new DataGridViewTextBoxColumn { DataPropertyName = "Detalle", HeaderText = "Producto/Detalle" };
            //colDetalle.Width = 250; // El detalle necesita más espacio
            //editarPedido.dgvDetalles.Columns.Add(colDetalle);
            var colDetalle = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Detalle",
                HeaderText = "Producto/Detalle",
                Width = 800
            };
            editarPedido.dgvDetalles.Columns.Add(colDetalle);

            //editarPedido.dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { 
            //DataPropertyName = "Cantidad", HeaderText = "Cant." 
            //});
            //var colCantidad = new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant." };
            //colCantidad.Width = 80;
            //editarPedido.dgvDetalles.Columns.Add(colCantidad);
            var colCantidad = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Cantidad",
                HeaderText = "Cant.",
                Width = 80
            };
            editarPedido.dgvDetalles.Columns.Add(colCantidad);

            //editarPedido.dgvDetalles.Columns.Add(new DataGridViewTextBoxColumn { 
            //DataPropertyName = "Precio", HeaderText = "Precio Unit." 
            //});
            //var colPrecio = new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio Unit." };
            //colPrecio.Width = 100;
            //editarPedido.dgvDetalles.Columns.Add(colPrecio);
            var colPrecio = new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Precio",
                HeaderText = "Precio Unit.",
                Width = 100
            };
            // Opcional: Formato de moneda para la columna precio
            colPrecio.DefaultCellStyle.Format = "N2";
            editarPedido.dgvDetalles.Columns.Add(colPrecio);

            // 4. Asignas los datos
            //editarPedido.dgvDetalles.DataSource = new BindingList<DDetalle>(datosfiltrados);


            // 1.Obtenés tu lista de objetos DPedido(como ya hacías)
            // ... (el foreach donde llenás listaResumen)

            // 2. En lugar de proyectar a un tipo anónimo, filtrá/ordená la lista original
            var datosfiltrados = listaResumen
            .OrderBy(c => c.Detalle) // Ejemplo de ordenamiento
            .ToList();

            // 3. Lo convertís a BindingList para que sea editable
            editarPedido.dgvDetalles.DataSource = new BindingList<DDetalle>(datosfiltrados);



            //dgvBuscarPedidos.DataSource = datosfiltrados;
            // Las columnas se ajustan para mostrar todo el contenido del texto

            //Esto funciona bien
            //editarPedido.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //editarPedido.ShowDialog();

            editarPedido.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            editarPedido.ShowDialog();


        }
    }
}
