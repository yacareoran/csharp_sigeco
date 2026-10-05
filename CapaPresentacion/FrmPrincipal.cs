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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            //int dni = FrmLogin.usuario.getDni();
            //int tipo_usuario = FrmLogin.usuario.getId_tipo_usuario();
            //MessageBox.Show("dni: " + dni + " tipo usuario: " + tipo_usuario);
            //FrmLogin FUsuarios = new FrmLogin();
            //FUsuarios.Show();
            FrmUsuarios FUsuarios = new FrmUsuarios();
            FUsuarios.Show();
        }

        private void btnProcesamiento_Click(object sender, EventArgs e)
        {
            FrmProcesamieto procesamieto = new FrmProcesamieto();
            procesamieto.txtUsuarioProcesamiento.Text = this.txtUsuario.Text;
            procesamieto.txtOrigenSector.Text = this.txtSector.Text;
            procesamieto.txtIdUsuario.Text = this.txtIdUsuario.Text;
            procesamieto.txtLegajoUsuario.Text = this.txtLegajoUsuario.Text;
            procesamieto.txtIdSectoresInternos.Text = this.txtIdSectoresInternos.Text;
            //if (Convert.ToInt32(this.txtIdSectoresInternos.Text) == 3)
            //{
            //    procesamieto.lblNombreFormulario.Text = "Formulario Division Compras";
            //}

            switch (Convert.ToInt32(this.txtIdSectoresInternos.Text))
            {
                case 16:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos Sección Comunicaciones";
                    procesamieto.Text = "Formulario cargar pedosos División Comunicaciones";
                    break; // El 'break' es obligatorio para salir del switch

                case 15:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos Procesamiento de Datos";
                    break;

                case 17:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos División Intendencia";
                    break;
                case 18:
                    procesamieto.lblNombreFormulario.Text ="Formulario cargar pedidos División Transporte";
                    break;
                case 19:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos Dirección Industriales";
                    break;

                default: // Esto se ejecuta si no coincide con ningún caso anterior
                    Console.WriteLine("Sector no reconocido. Acceso denegado.");
                    break;
            }



            procesamieto.Show();
        }

        private void btnCompras_Click(object sender, EventArgs e)
        {
            FrmCompras compras = new FrmCompras();
            compras.txtUsuario.Text = this.txtUsuario.Text;
            compras.txtSector.Text = this.txtSector.Text;
            compras.txtIdUsuario.Text = this.txtIdUsuario.Text;
            compras.txtLegajoUsuario.Text = this.txtLegajoUsuario.Text;
            compras.txtSectoresInternos.Text = this.txtIdSectoresInternos.Text;
            compras.Show();
        }

        private void btnIntendencia_Click(object sender, EventArgs e)
        {
            FrmIntendencia intendencia = new FrmIntendencia();
            intendencia.txtUsuarioIntendencia.Text = this.txtUsuario.Text;
            intendencia.txtOrigenSectorIntendencia.Text = this.txtSector.Text;
            intendencia.txtIdUsuario.Text = this.txtIdUsuario.Text;
            intendencia.txtLegajoUsuario.Text = this.txtLegajoUsuario.Text;
            intendencia.Show();
        }

        private void btnIndustriales_Click(object sender, EventArgs e)
        {
            FrmProcesamieto procesamieto = new FrmProcesamieto();
            procesamieto.txtUsuarioProcesamiento.Text = this.txtUsuario.Text;
            procesamieto.txtOrigenSector.Text = this.txtSector.Text;
            procesamieto.txtIdUsuario.Text = this.txtIdUsuario.Text;
            procesamieto.txtLegajoUsuario.Text = this.txtLegajoUsuario.Text;
            procesamieto.txtIdSectoresInternos.Text = this.txtIdSectoresInternos.Text;
            //if (Convert.ToInt32(this.txtIdSectoresInternos.Text) == 3)
            //{
            //    procesamieto.lblNombreFormulario.Text = "Formulario Division Compras";
            //}

            switch (Convert.ToInt32(this.txtIdSectoresInternos.Text))
            {
                case 16:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos División Comunicaciones";
                    break; // El 'break' es obligatorio para salir del switch

                case 15:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos Procesamiento de Datos";
                    break;

                case 17:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos División Intendencia";
                    break;
                case 18:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos División Transporte";
                    break;
                case 19:
                    procesamieto.lblNombreFormulario.Text = "Formulario cargar pedidos Dirección Industriales";
                    break;

                default: // Esto se ejecuta si no coincide con ningún caso anterior
                    Console.WriteLine("Sector no reconocido. Acceso denegado.");
                    break;
            }



            procesamieto.Show();
        }
    }
}
