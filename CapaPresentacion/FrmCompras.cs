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
    public partial class FrmCompras : Form
    {
        public FrmCompras()
        {
            InitializeComponent();
        }

        private void btnNotasPedido_Click(object sender, EventArgs e)
        {
            if (panel2.Visible == true)
            {
                panel2.Visible = false;
                btnIngresarNotasPedido.Visible = false;
                btnModificarNotaPedido.Visible = false;
                btnSeguimientoPedidos.Visible = false;
                btnNotasIngresadasModulo.Visible = false;
                btnModificarEncabezadoNotaPedido.Visible = false;
            }
            else 
            { 
                panel2.Visible = true;
                btnIngresarNotasPedido.Visible = true;
                btnModificarNotaPedido.Visible = true;
                btnSeguimientoPedidos.Visible = true;
                btnNotasIngresadasModulo.Visible = true;
                btnModificarEncabezadoNotaPedido.Visible = true;
            }
        }

        private void FrmCompras_Load(object sender, EventArgs e)
        {

        }

        private void btnNotasIngresadasModulo_Click(object sender, EventArgs e)
        {
            FrmComprasNotaPedido notaPedido = new FrmComprasNotaPedido();
            notaPedido.Show();
        }

        private void btnModificarEncabezadoNotaPedido_Click(object sender, EventArgs e)
        {
            FrmModificarEncabezadoNotaPedido modificarEncabezadoNotaPedido = new FrmModificarEncabezadoNotaPedido();
            modificarEncabezadoNotaPedido.Show();
        }

        private void btnModificarNotaPedido_Click(object sender, EventArgs e)
        {
            FrmModificarDetalleNotaPedido modificarDetalleNotaPedido = new FrmModificarDetalleNotaPedido();
            modificarDetalleNotaPedido.Show();

        }

        private void btnIngresarNotasPedido_Click(object sender, EventArgs e)
        {
            FrmNotaPedidoCompras notaPedido = new FrmNotaPedidoCompras();
            notaPedido.txtUsuario.Text = this.txtUsuario.Text;
            notaPedido.txtIdUsuario.Text = this.txtIdUsuario.Text;
            notaPedido.txtLegajo.Text = this.txtLegajoUsuario.Text;
            notaPedido.txtOrigen.Text = this.txtSector.Text;
            notaPedido.txtIdSectoresInternos.Text = this.txtSectoresInternos.Text;
            notaPedido.Show();
        }

        private void btnModificarPedidoCompras_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("Revisar que muestra este boton");
            FrmEditarNotaPedidoCompras modificarCompras = new FrmEditarNotaPedidoCompras();
            modificarCompras.Show();
        }

        private void btnSeguimientoPedidos_Click(object sender, EventArgs e)
        {
            FrmSeguimientoPedidoCompras seguimiento = new FrmSeguimientoPedidoCompras();
            seguimiento.txtUsuario.Text = this.txtUsuario.Text;
            seguimiento.txtIdUsuario.Text = this.txtIdUsuario.Text;
            seguimiento.txtLegajo.Text = this.txtLegajoUsuario.Text;
            seguimiento.txtOrigen.Text = this.txtSector.Text;
            seguimiento.txtIdSectoresInternos.Text = this.txtSectoresInternos.Text;
            seguimiento.Show();
        }
    }
}
