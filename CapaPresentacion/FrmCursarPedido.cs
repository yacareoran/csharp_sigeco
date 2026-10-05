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
using CapaDatos;
using System.Collections;



namespace CapaPresentacion
{
    public partial class FrmCursarPedido : Form
    {
        public FrmCursarPedido()
        {
            InitializeComponent();
        }

        private void FrmCursarPedido_Load(object sender, EventArgs e)
        {
            this.LlenarComboRubro();
            this.LlenarComboOrganismo();
            int anioactual = Convert.ToInt32(DateTime.Now.Year.ToString());
            int añoCorto = anioactual % 100;
            txtAnio.Text = Convert.ToString(añoCorto);
        }
        //metodos llenar combobox
        private void LlenarComboRubro()
        {
            this.cmbRubro.ValueMember = "id_rubro";
            this.cmbRubro.DisplayMember = "rubro";
            this.cmbRubro.DataSource = NRubro.Mostrar();
            //this.cmbRubro.SelectedIndex = 1;
            this.cmbRubro.SelectedIndex = 1;
        }

        private void LlenarComboOrganismo()
        {
            this.cmbOrganismo.ValueMember = "id_organismo";
            this.cmbOrganismo.DisplayMember = "organismo";
            this.cmbOrganismo.DataSource = NOrganismo.Mostrar();
            this.cmbOrganismo.SelectedIndex = 1;
        }


        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            NSubrubro nSubRubro = new NSubrubro();
            int id_rubro = Convert.ToInt32(this.cmbRubro.SelectedValue);
            cmbSubRubro.ValueMember = "id_subrubro";
            cmbSubRubro.DisplayMember = "subrubro";
            cmbSubRubro.DataSource = NSubrubro.BuscarSubrubroxRubro(id_rubro);
                 
        }

        private void cmbOrganismo_SelectedIndexChanged(object sender, EventArgs e)
        {
            NSectores nSectores = new NSectores();
            int id_organismo = Convert.ToInt32(this.cmbOrganismo.SelectedValue);
            cmbSectores.ValueMember = "id_sector";
            cmbSectores.DisplayMember = "sector";
            cmbSectores.DataSource = NSectores.BuscarSectoresxOrganismo(id_organismo);
            //cmbSectores.DataSource = NSectores.BuscarSectoresxOrganismo(Convert.ToInt32(1));
        }
    }
}
