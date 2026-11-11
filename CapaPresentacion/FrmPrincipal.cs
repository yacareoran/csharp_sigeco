using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
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
            // Sacamos el boton restaurar del formulario
            this.barraTituloRibbon1.MostrarMaximizar = false;

            // --- TU LÍNEA DE COLOR CONFIGURADA EN EL INICIO ---
            this.BackColor = Color.FromArgb(240, 244, 250);

            // --- BORDES ELEGANTES PARA TUS BOTONES ---
            Color colorGrisBorde = Color.FromArgb(160, 180, 210);

            // Botón Usuarios
            this.btnUsuarios.FlatStyle = FlatStyle.Flat;
            this.btnUsuarios.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Compras
            this.btnCompras.FlatStyle = FlatStyle.Flat;
            this.btnCompras.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Cargar Pedidos
            this.btnUsuarios.FlatStyle = FlatStyle.Flat;
            this.btnUsuarios.FlatAppearance.BorderColor = colorGrisBorde;
            
            // Botón Cargar Pedidos Industriales
            this.btnIndustriales.FlatStyle = FlatStyle.Flat;
            this.btnIndustriales.FlatAppearance.BorderColor = colorGrisBorde;
            
            // Botón Cargar Pedidos Intendencia
            this.btnIntendencia.FlatStyle = FlatStyle.Flat;
            this.btnIntendencia.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Cargar Pedidos Procesamiento
            this.btnProcesamiento.FlatStyle = FlatStyle.Flat;
            this.btnProcesamiento.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Contable
            this.btnContable.FlatStyle = FlatStyle.Flat;
            this.btnContable.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Cargar Pedidos Transporte
            this.btnTransporte.FlatStyle = FlatStyle.Flat;
            this.btnTransporte.FlatAppearance.BorderColor = colorGrisBorde;

            // Botón Cargar Pedidos Comunicaciones
            this.btnComunicaciones.FlatStyle = FlatStyle.Flat;
            this.btnComunicaciones.FlatAppearance.BorderColor = colorGrisBorde;

            // (Repite estas dos líneas para cada botón de tu menú principal...)

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
