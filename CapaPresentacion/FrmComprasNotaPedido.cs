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
    public partial class FrmComprasNotaPedido : Form
    {
        public FrmComprasNotaPedido()
        {
            InitializeComponent();
        }

        private List<DPedidoCompra> lst = new List<DPedidoCompra>();
        //metodo BuscarPedido

        private void BuscarPedidoxTransaccion()
        {
            DataTable miDataTable = new DataTable();
            var listaPedidos = NPedido.BuscarxTransaccion(Convert.ToInt32(this.txtNumeroTransaccion.Text));
            decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));



            MessageBox.Show("El numero de id del pedido es: " + " " + costoTotal);
            List<DPedido> listaResumen = new List<DPedido>();




            foreach (DataRow row in listaPedidos.Rows)
            {
                listaResumen.Add(new DPedido
                {
                    Id_pedido = Convert.ToInt32(row["id_pedido"]),
                    Num_transaccion = Convert.ToInt32(row["num_transaccion"]),
                    Fecha_pedido = Convert.ToDateTime(row["fecha_pedido"]),
                    Sector = row["sector"].ToString(),
                    //Extracto = row["extracto"].ToString(),
                    Caracter_pedido = row["caracter_pedido"].ToString(),
                    Pedido = row["pedido"].ToString(),
                    Estado = row["estado"].ToString(),
                    Costo_total = costoTotal
                });
            }

            Decimal SumaSubTotal = 0; Decimal CostoTotalDetalles = 0;
            for (int i = 0; i < listaResumen.Count; i++)
            {
                Decimal CostoDetalles;
                SumaSubTotal += listaResumen[i].Id_pedido;
                var listaCantidadDetalle = NDetalle.BuscarCantidadPrecio(Convert.ToInt32(SumaSubTotal));
                foreach (DataRow row in listaCantidadDetalle.Rows)
                {
                    CostoTotalDetalles += Convert.ToInt32(row["cantidad"]) * Convert.ToDecimal(row["precio"]); 
                }
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
                    costoTotal = CostoTotalDetalles
            
                })
                .ToList();

            dgvPedidos.DataSource = datosfiltrados;
            // Las columnas se ajustan para mostrar todo el contenido del texto
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }
        private void BuscarPedidoxCocepto()
        {

            DataTable miDataTable = new DataTable();
            var listaPedidos = NPedido.BuscarConcepto(Convert.ToString(this.txtBuscarConcepto.Text));
            
            List<DPedido> listaResumen = new List<DPedido>();
            

            foreach (DataRow row in listaPedidos.Rows)
            {
                listaResumen.Add(new DPedido
                {
                    Num_transaccion = Convert.ToInt32(row["num_transaccion"]),
                    Fecha_pedido = Convert.ToDateTime(row["fecha_pedido"]),
                    Sector = row["sector"].ToString(),
                    //Extracto = row["extracto"].ToString(),
                    Caracter_pedido = row["caracter_pedido"].ToString(),
                    Pedido = row["pedido"].ToString(),
                    Estado = row["estado"].ToString()

                });
            }

            var datosfiltrados = listaResumen
                .Select(c => new
                {
                    Num_Transaccion  = c.Num_transaccion,
                    FechaPedido = c.Fecha_pedido,
                    Sector = c.Sector,
                    CaracterPedido = c.Caracter_pedido,
                    Pedido = c.Pedido,
                    Estado = c.Estado
                  
                })
                .ToList();

            dgvPedidosxConcepto.DataSource = datosfiltrados;
            // Las columnas se ajustan para mostrar todo el contenido del texto
            dgvPedidosxConcepto.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }
        

        private void btnBuscarPedidos_Click(object sender, EventArgs e)
        {
            this.BuscarPedidoxTransaccion();
        }

        private void txtBuscarConcepto_TextChanged(object sender, EventArgs e)
        {
            this.BuscarPedidoxCocepto();
        }

        private void btnCursarPedido_Click(object sender, EventArgs e)
        {
            FrmCursarPedido cursarPedido = new FrmCursarPedido();
            cursarPedido.txtNumTransaccion.Text = Convert.ToString(this.dgvPedidos.CurrentRow.Cells[0].Value.ToString());
            cursarPedido.txtOrigen.Text = Convert.ToString(this.dgvPedidos.CurrentRow.Cells[2].Value.ToString());
            cursarPedido.txtFecha.Text = Convert.ToString(this.dgvPedidos.CurrentRow.Cells[1].Value.ToString());
            cursarPedido.txtTotal.Text = Convert.ToString(this.dgvPedidos.CurrentRow.Cells[7].Value.ToString());
            cursarPedido.ShowDialog();

        }

        private void FrmComprasNotaPedido_Load(object sender, EventArgs e)
        {
            //txtAnioActual.Text = Convert.ToString(NPedido.BuscarAnioActual());
        }
    }
}
