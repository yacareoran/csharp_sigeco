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
    public partial class FrmGenerarExpedientes : Form
    {
        public FrmGenerarExpedientes()
        {
            InitializeComponent();
        }

        private void FrmGenerarExpedientes_Load(object sender, EventArgs e)
        {
            this.LlenarComboOrganismo();
        }

        //Metodos llenar combobox

        private void LlenarComboOrganismo()
        {
           
            DataTable dt = NOrganismo.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbOrganismoExpediente.DataSource = dt;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbOrganismoExpediente.ValueMember = "id_organismo";
                this.cmbOrganismoExpediente.DisplayMember = "organismo";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbOrganismoExpediente.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbOrganismoExpediente.DataSource = null;
                this.cmbOrganismoExpediente.SelectedIndex = -1;
            }




        }

        private void cmbOrganismoExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbOrganismoExpediente.SelectedValue != null && int.TryParse(cmbOrganismoExpediente.SelectedValue.ToString(), out int idOrganismo))
            {
                // Buscamos los subrubros de ese ID en específico
                //DataTable dtSubrubros = NSubrubro.BuscarSubrubroxRubro(idOrganismo);
                DataTable dtSectores = NSectores.BuscarSectoresxOrganismo(idOrganismo);

                cmbSectorExpediente.DataSource = dtSectores;
                cmbSectorExpediente.DisplayMember = "sector"; // Lo que el usuario VE
                cmbSectorExpediente.ValueMember = "id_sector";       // El ID oculto
            }
            else
            {
                // Si el usuario deselecciona el rubro, limpiamos los subrubros anteriores
                cmbSectorExpediente.DataSource = null;
            }
        }
    }
}
