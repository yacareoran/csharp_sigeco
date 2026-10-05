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
    public partial class FrmSeguimientoPedidoCompras : Form
    {
        public FrmSeguimientoPedidoCompras()
        {
            InitializeComponent();
        }

        private void FrmSeguimientoPedidoCompras_Load(object sender, EventArgs e)
        {
            this.LlenarComboSectoresInternos();
        }

        private void BuscarPedidoxNumeroTransaccion()
        {
            DataTable miDataTable = new DataTable();
            var listaPedidos = NPedido.BuscarxTransaccion(Convert.ToInt32(this.txtBuscarTransaccion.Text));
            //decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));
            List<DPedido> listaResumen = new List<DPedido>();
            if (listaPedidos.Rows.Count <= 1)
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

        private void BuscarPedidoxPedido()
        {
            DataTable miDataTable = new DataTable();
            var listaPedidos = NPedido.BuscarConcepto(Convert.ToString(this.txtBuscarPedido.Text));
            //decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));
            List<DPedido> listaResumen = new List<DPedido>();
            if (listaPedidos.Rows.Count <= 1)
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

                dgvPedidos.DataSource = datosfiltrados;
                // 2. Ocultamos la columna del ID (Sensible a mayúsculas/minúsculas)
                if (dgvPedidos.Columns["Id_Pedido"] != null)
                {
                    dgvPedidos.Columns["Id_Pedido"].Visible = false;
                }
                // Las columnas se ajustan para mostrar todo el contenido del texto
                dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        private void LlenarComboSectoresInternos()
        {
                this.cmbSectoresInternos.DataSource = NSectoresInternos.Mostrar();
                this.cmbSectoresInternos.ValueMember = "id_sectores_internos";
                this.cmbSectoresInternos.DisplayMember = "sectores_internos";
                this.cmbSectoresInternos.SelectedIndex = 1;
        }

        private void btnBuscarFechas_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxFechas();
        }

        private void btnBuscarPedido_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxPedido();
        }

        private void btnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxNumeroTransaccion();
        }
    }
}
