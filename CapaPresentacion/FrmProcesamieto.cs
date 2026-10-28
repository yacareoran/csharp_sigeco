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
            // ==========================================
            // VALIDACIÓN PROFESIONAL DE SELECCIÓN
            // ==========================================
            if (this.dgvBuscarPedidos.CurrentRow == null || this.dgvBuscarPedidos.CurrentRow.Index < 0)
            {
                MessageBox.Show("Por favor, seleccione el pedido que desea editar de la lista.",
                                "Atención",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return; // Frenamos el método de forma segura. El programa ya no se cae.
            }

            // Si el programa llega aquí, es 100% seguro que hay una fila seleccionada.
            FrmEditarPedido editarPedido = new FrmEditarPedido();

            // NOTA: Limpié los Convert.ToString(this...Value.ToString()) que estaban redundantes
            editarPedido.txtNumeroTransaccion.Text = this.dgvBuscarPedidos.CurrentRow.Cells[1].Value?.ToString() ?? "";
            editarPedido.txtIdPedido.Text = this.dgvBuscarPedidos.CurrentRow.Cells[0].Value?.ToString() ?? "";
            editarPedido.txtPasarFechaPedido.Text = this.dgvBuscarPedidos.CurrentRow.Cells[2].Value?.ToString() ?? "";
            editarPedido.txtPasarObservaciones.Text = this.dgvBuscarPedidos.CurrentRow.Cells[5].Value?.ToString() ?? "";
            editarPedido.txtPrecioTotalEstimado.Text = this.dgvBuscarPedidos.CurrentRow.Cells[7].Value?.ToString() ?? "";
            editarPedido.txtLegajo.Text = this.txtLegajoUsuario.Text;

            int idCaracterPedidoGrid = Convert.ToInt32(1);

            DataTable miDataTable = new DataTable();
            List<DDetalle> listaResumen = new List<DDetalle>();

            // Capa de Negocio llamando al SP de la Capa de Datos de forma segura
            var listaCantidadDetalle = NDetalle.BuscarDetalles(Convert.ToInt32(this.dgvBuscarPedidos.CurrentRow.Cells[0].Value));

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
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Precio = Convert.ToDecimal(row["precio"]),
                });
            }

            // Configuración del DataGridView secundario
            editarPedido.dgvDetalles.AutoGenerateColumns = false;
            editarPedido.dgvDetalles.Columns.Clear();

            var colRenglon = new DataGridViewTextBoxColumn { DataPropertyName = "Renglon", HeaderText = "Renglón", Width = 80 };
            editarPedido.dgvDetalles.Columns.Add(colRenglon);

            var colId = new DataGridViewTextBoxColumn { DataPropertyName = "Id_detalle", HeaderText = "ID", Width = 50 };
            editarPedido.dgvDetalles.Columns.Add(colId);

            var colDetalle = new DataGridViewTextBoxColumn { DataPropertyName = "Detalle", HeaderText = "Producto/Detalle", Width = 800 };
            editarPedido.dgvDetalles.Columns.Add(colDetalle);

            var colCantidad = new DataGridViewTextBoxColumn { DataPropertyName = "Cantidad", HeaderText = "Cant.", Width = 80 };
            editarPedido.dgvDetalles.Columns.Add(colCantidad);

            var colPrecio = new DataGridViewTextBoxColumn { DataPropertyName = "Precio", HeaderText = "Precio Unit.", Width = 100 };
            colPrecio.DefaultCellStyle.Format = "N2";
            editarPedido.dgvDetalles.Columns.Add(colPrecio);

            var datosfiltrados = listaResumen.OrderBy(c => c.Detalle).ToList();
            editarPedido.dgvDetalles.DataSource = new BindingList<DDetalle>(datosfiltrados);

            editarPedido.dgvDetalles.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            editarPedido.ShowDialog();
        }

    }
}
