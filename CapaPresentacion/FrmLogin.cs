using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using CapaNegocio;
using static System.Collections.Specialized.BitVector32;
using static CapaPresentacion.FrmLogin;
using CapaDatos;




namespace CapaPresentacion
{
    public partial class FrmLogin : Form
    {
        //public static User usuario;
        //public static Sesion ses;

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnAcceder_Click(object sender, EventArgs e)
        {//inicio login
            {
                DUsuario usuario = new DUsuario();
                try
                {
                    DataTable Datos = NUsuario.Login(this.txtUsuario.Text, this.txtPasword.Text);
                    if (Datos.Rows.Count == 0)
                    {
                        MessageBox.Show("El Usuario no existe o los datos estan mal ingresados", "Sistema Ventas - Dirección Industriales S.P.P.S", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        this.txtUsuario.Text = String.Empty;
                        this.txtPasword.Text = String.Empty;
                    }
                    else
                    {
                        //instancia del formulario principal
                        FrmPrincipal principal = new FrmPrincipal();
                        principal.txtUsuario.Text = Datos.Rows[0]["nombre_usuario"].ToString();
                        principal.txtSector.Text = Datos.Rows[0]["sector"].ToString();
                        principal.txtIdUsuario.Text = Datos.Rows[0]["id_usuario"].ToString();
                        principal.txtLegajoUsuario.Text = Datos.Rows[0]["legajo"].ToString();
                        principal.txtIdSectoresInternos.Text = Datos.Rows[0]["sectores_internos_id"].ToString();
                        int miSectoresInternos = Datos.Rows[0].Field<int>("sectores_internos_id");
                        MessageBox.Show(Convert.ToString(miSectoresInternos));

                        /*int idSectoresInternos = Datos.Rows[0].Field<int>("sectores_internos_id");

                        switch (idSectoresInternos)
                        {
                            case 15:
                                MessageBox.Show("Ingreso por porcesamiento de datos");
                                principal.btnCompras.Enabled = false;
                                principal.btnTransporte.Enabled = false;
                                principal.btnContable.Enabled = false;
                                principal.btnIndustriales.Enabled = false;
                                principal.btnComunicaciones.Enabled = false;
                                principal.btnIntendencia.Enabled = false;
                                break;

                            case 16:
                                MessageBox.Show("Ingreso por Comunicaciones");
                                
                                break;

                            case 17:
                                MessageBox.Show("Ingreso por intendencia");
                                principal.btnCompras.Enabled = false;
                                principal.btnTransporte.Enabled = false;
                                principal.btnContable.Enabled = false;
                                principal.btnIndustriales.Enabled = false;
                                principal.btnComunicaciones.Enabled = false;
                                principal.btnProcesamiento.Enabled = false;
                                break;
                            
                            case 18:
                                MessageBox.Show("Ingreso por Transporte");
                                principal.btnCompras.Enabled = false;
                                principal.btnIntendencia.Enabled = false;
                                principal.btnContable.Enabled = false;
                                principal.btnIndustriales.Enabled = false;
                                principal.btnComunicaciones.Enabled = false;
                                principal.btnProcesamiento.Enabled = false;
                                break;

                            case 19:
                                MessageBox.Show("Ingreso por Industriales");
                                principal.btnCompras.Enabled = false;
                                principal.btnTransporte.Enabled = false;
                                principal.btnContable.Enabled = false;
                                principal.btnIndustriales.Enabled = false;
                                principal.btnComunicaciones.Enabled = false;
                                principal.btnProcesamiento.Enabled = false;
                                break;

                            default: // El "si no es ninguno de los anteriores"
                                MessageBox.Show("Estado desconocido.");
                                break;
                        }*/




                        principal.Show();
                        this.Hide();
                    }
                    
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Falla en la conexion de red" + ex.Message);
                    MessageBox.Show("El usuario es: " + " " + Convert.ToString(this.txtUsuario.Text) + " " + Convert.ToString(this.txtPasword.Text));
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
