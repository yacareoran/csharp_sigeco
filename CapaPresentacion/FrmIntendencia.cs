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
    public partial class FrmIntendencia : Form
    {
        public FrmIntendencia()
        {
            InitializeComponent();
        }

        private void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            FrmNotaPedido notaPedido = new FrmNotaPedido();
            FrmPrincipal principal = new FrmPrincipal();
            notaPedido.txtUsuario.Text = this.txtUsuarioIntendencia.Text;
            notaPedido.txtOrigen.Text = this.txtOrigenSectorIntendencia.Text;
            notaPedido.txtIdUsuario.Text = this.txtIdUsuario.Text;
            notaPedido.txtLegajo.Text = this.txtLegajoUsuario.Text;
            notaPedido.Show();
        }

        private void BuscarPedidoxFechas()
        {
           
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
                    Id_detalle = Convert.ToInt32(row["id_Detalle"]),
                    Detalle = row["detalle"].ToString(),
                    Cantidad = Convert.ToInt32(row["cantidad"]),
                    Precio = Convert.ToDecimal(row["precio"]),
                    
                });

                }
                

                var datosfiltrados = listaResumen
                .Select(c => new
                {
                    Id_Detalle = c.Id_detalle,
                    Detalle = c.Detalle,
                    Cantidad = c.Cantidad,
                    Precio = c.Precio
                
                })
                .ToList();
                //listaResumen.Fill(datosfiltrados);
                editarPedido.dgvDetalles.DataSource = datosfiltrados;
                // Las columnas se ajustan para mostrar todo el contenido del texto
                dgvBuscarPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                editarPedido.ShowDialog();

            // Permitir edición en el Grid
            editarPedido.dgvDetalles.ReadOnly = false;

            // Opcional: Asegurar que las celdas sean editables individualmente
            editarPedido.dgvDetalles.Columns["detalle"].ReadOnly = false;
            editarPedido.dgvDetalles.Columns["cantidad"].ReadOnly = false;
            editarPedido.dgvDetalles.Columns["precio"].ReadOnly = false;

            // Después de llenar tu DataTable (ej. da.Fill(dt))
            foreach (DataColumn dc in miDataTable.Columns)
            {
                editarPedido.dgvDetalles.ReadOnly = false; // Permite la edición en el origen de datos
            }



        }
    }
}
