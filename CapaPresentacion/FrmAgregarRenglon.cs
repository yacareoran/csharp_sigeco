using CapaDatos;
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
    public partial class FrmAgregarRenglon : Form
    {
        // Aquí guardaremos el renglón listo para devolvérselo a FrmEditarPedido
        public DDetalle NuevoDetalle { get; private set; }

        public FrmAgregarRenglon()
        {

            InitializeComponent();
            // Sacamos el boton restaurar del formulario
            this.barraTituloRibbon1.MostrarMaximizar = false;

            // --- TU LÍNEA DE COLOR CONFIGURADA EN EL INICIO ---
            this.BackColor = Color.FromArgb(240, 244, 250);

            // --- BORDES ELEGANTES PARA TUS BOTONES ---
            Color colorGrisBorde = Color.FromArgb(160, 180, 210);

            this.LlenarComboUnidadMedida();
            this.LlenarComboRubro();
        }

        private void barraTituloRibbon1_Paint(object sender, PaintEventArgs e)
        {

        }

        //metodos llenar combobox
        private void LlenarComboUnidadMedida()
        {
            this.cmbUnidadMedida.DataSource = NUnidadMedida.Mostrar();
            this.cmbUnidadMedida.ValueMember = "id_unidad_medida";
            this.cmbUnidadMedida.DisplayMember = "medida";
            this.cmbUnidadMedida.SelectedIndex = 1;
        }

        private void LlenarComboRubro()
        {

            DataTable dt = NRubro.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbRubro.DataSource = dt;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbRubro.ValueMember = "id_rubro";
                this.cmbRubro.DisplayMember = "rubro";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbRubro.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbRubro.DataSource = null;
                this.cmbRubro.SelectedIndex = -1;
            }
        }

        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbRubro.SelectedValue != null && int.TryParse(cmbRubro.SelectedValue.ToString(), out int idRubro))
            {
                // Buscamos los subrubros de ese ID en específico
                DataTable dtSubrubros = NSubrubro.BuscarSubrubroxRubro(idRubro);

                cmbSubrubro.DataSource = dtSubrubros;
                cmbSubrubro.DisplayMember = "subrubro"; // Lo que el usuario VE
                cmbSubrubro.ValueMember = "id_subrubro";       // El ID oculto
            }
            else
            {
                // Si el usuario deselecciona el rubro, limpiamos los subrubros anteriores
                cmbSubrubro.DataSource = null;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(txtConcepto.Text) ||
                string.IsNullOrWhiteSpace(txtCantidad.Text) ||
                string.IsNullOrWhiteSpace(txtPrecioUnitario.Text))
            {
                MessageBox.Show("Complete todos los campos del renglón.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Creamos el objeto detalle con Id_detalle = 0 (eso le avisará a FrmEditarPedido que es NUEVO)
            NuevoDetalle = new DDetalle
            {
                Id_detalle = 0,
                Detalle = txtConcepto.Text.Trim(),
                Cantidad = Convert.ToInt32(txtCantidad.Text.Trim()),
                Precio = Convert.ToDecimal(txtPrecioUnitario.Text.Trim())
                // Si necesitas Unidad, Rubro_id o Subrubro_id, también los asignas aquí
            };

            // Indicamos que todo salió bien y cerramos la ventanita
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
