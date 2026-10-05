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
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void Mostrar()
        {

            this.dataUsuarios.DataSource = NUsuario.Mostrar();
            int total =  Convert.ToInt32(dataUsuarios.Rows.Count);
            lblTotal.Text = "Total Usuarios: " + (total - 1);
            //this.OcultarColumnas();
            //lblTotal.Text = "Total Usuarios: " + Convert.ToString(dataUsuarios.Rows.Count);
        }

        //metodo Buscar Usuarios
        private void BuscarUsuarios()
        {
            this.dataUsuarios.DataSource = NUsuario.Buscar(this.txtBuscar.Text);

        }
        private void FrmUsuario_Load(object sender, EventArgs e)
        {
            //MessageBox.Show("Formulario");
            this.Mostrar();
            //this.dataUsuarios.DataSource = NUsuario.Mostrar();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarUsuarios();
        }
    }
}
