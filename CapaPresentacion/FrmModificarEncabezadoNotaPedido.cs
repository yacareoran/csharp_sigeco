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
    public partial class FrmModificarEncabezadoNotaPedido : Form
    {
        public FrmModificarEncabezadoNotaPedido()
        {
            InitializeComponent();
        }

        private void btnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            this.dgvBuscarPedidos.DataSource = NPedido.BuscarxTransaccion(Convert.ToInt32(txtBuscarTransaccion.Text));

            //this.dataListado.DataSource = NProducto.Buscar(this.txtBuscar.Text);
        }
    }
}
