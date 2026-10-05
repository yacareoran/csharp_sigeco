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
using System.Globalization;
using PdfiumViewer;
using System.IO;
using CapaPresentacion.Reporte.Formulario_Pedido;
//using iTextSharp.text.pdf;
using iTextSharp.text;


namespace CapaPresentacion
{
    public partial class FrmNotaPedido : Form
    {
        DPedido dPedido = new DPedido();
        DDetalle dDetalle = new DDetalle();
        ImprimirPedido iMprimirPedido = new ImprimirPedido();

        public FrmNotaPedido()
        {
            InitializeComponent();
            this.LlenarComboUnidadMedida();
            this.LlenarComboRubro();
            this.LlenarComboCaracterPedido();
            this.LlenarComboOrganismo();
            this.LlenarComboSectores();
        }

        private List<DVentas> lst = new List<DVentas>();
        
        //metodo mostrar
        private void MostrarUnidadMedida()
        {

           
            // Configurar la columna ComboBox
            /*DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
            comboBoxColumn.DataSource = NUnidadMedida.Mostrar(); // Fuente de datos del ComboBox
            comboBoxColumn.DisplayMember = "medida";    // Propiedad a mostrar en el desplegable
            comboBoxColumn.ValueMember = "id_unidad_medida";
            // Añadir la columna al DataGridView
            MessageBox.Show("Llenar combo");
            dgvAgregarNotaPedido.Columns.Add(comboBoxColumn);
            //dgvDatos.Rows[0].Cells[1].Value.ToString()*/


        }

        private void limpiarcomandos()
        {
            txtCantidad.Text = string.Empty;
            txtConcepto.Text = string.Empty;
            txtPrecioUnitario.Text = string.Empty;
            
        }
        //metodo cargar unidad medida
        private void CargarUnidad_Medida()
        {
            
                //inicio cargar clase lista
                //DFactura V = new DFactura();
                DPedido P = new DPedido();
                DVentas Ventas = new DVentas();
                DDetalle Detalle1 = new DDetalle();
                decimal Subtotal = 0;

                try
                {
                    Ventas.Cantidad = Convert.ToInt32(this.txtCantidad.Text);
                    
                    Ventas.Unidad = this.cmbUnidadMedida.Text;
                    
                    Ventas.Concepto = this.txtConcepto.Text;
                    Ventas.Precio_unitario = Convert.ToDecimal(this.txtPrecioUnitario.Text);
                    
                    
                    Ventas.Rubro = this.cmbRubro.Text;
                    Ventas.Subrubro = this.cmbSubrubro.Text;

                    Ventas.Rubro_id = Convert.ToInt32(this.cmbRubro.SelectedValue);
                    Ventas.Subrubro_id = Convert.ToInt32(this.cmbSubrubro.SelectedValue);

                    //MessageBox.Show("el valor del id del combo es: " + " " + Convert.ToInt32(this.cmbRubro.ValueMember));

                    //decimal valor = decimal.Parse(entrada, CultureInfo.InvariantCulture);
                    decimal precio = decimal.Parse(this.txtPrecioUnitario.Text, CultureInfo.InvariantCulture);
                    Ventas.Subtotal = (Convert.ToDecimal(precio) * (Convert.ToInt32(this.txtCantidad.Text)));


                

                    lst.Add(Ventas);
                    LlenarGrilla();
                MessageBox.Show("Paso sin errores, se comento LlenarGrilla()");
                }
                catch
                {
                    MessageBox.Show("Entro por el Catch");
                    //MessageBox.Show("el valor del id del combo es: " + " " + Convert.ToInt32(this.cmbRubro.ValueMember));
                }

                //fin cargar clase lista
            
        }

        //Imprimir Pedido
        private void ImprimirPedido(int id_pedido)
        {//inicio Método imprimir pedido
            //NPedido nPedido = new NPedido();
            NReportes nReportes = new NReportes();
            //DPedido dPedido = new DPedido();
            DReportes dPedido = new DReportes();
            DDetalle dDetalle = new DDetalle();

            //DataTable pedidoxId = NPedido.BuscarxId(id_pedido);
            DataTable pedidoxId = NReportes.BuscarxId(id_pedido);
            DataTable nDetalle = NDetalle.BuscarDetalles(id_pedido);

            //MessageBox.Show("El caracacter de la compra es: " ) + " " + pedidoxId.Columns[1]


            // Generar PDF en memoria
            MemoryStream msOriginal = ReporteImprimirPedido.RepPdfInternosVinculados(iMprimirPedido, pedidoxId, nDetalle);

            // Clonar el stream para que PdfiumViewer pueda cerrarlo sin afectar el original
            MemoryStream ms = new MemoryStream(msOriginal.ToArray());

            PdfDocument pdfDocument = null;

            try
            {
                pdfDocument = PdfDocument.Load(ms);

                Form formVisor = new Form
                {
                    Text = "Vista previa PDF",
                    Width = 800,
                    Height = 600
                };

                PdfViewer pdfViewer = new PdfViewer
                {
                    Dock = DockStyle.Fill,
                    Document = pdfDocument
                };

                formVisor.Controls.Add(pdfViewer);

                formVisor.FormClosed += (s, args) =>
                {
                    // Liberar recursos al cerrar el visor
                    pdfViewer.Document.Dispose();
                    pdfViewer.Dispose();
                    formVisor.Dispose();
                    ms.Dispose();
                    pdfDocument = null;
                };

                formVisor.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al mostrar PDF: " + ex.Message);
                ms.Dispose();
                pdfDocument?.Dispose();
            }
        }//fin metodo improimir pedido

        //Inicio metodo LlenarGrilla
        private void LlenarGrilla()
        {//inicio metodo llenar grilla
            
            Decimal SumaSubTotal = 0; Decimal SumaTotal = 0; Decimal SumaIva = 0; decimal Subtotal = 0;
            dgvAgregarNotaPedido.Rows.Clear();
            //contador = lst.Count;
            for (int i = 0; i < lst.Count; i++)
            //while (i <= lst.Count)
            {


                

                dgvAgregarNotaPedido.Rows.Add();
                dgvAgregarNotaPedido.Rows[i].Cells[0].Value = lst[i].Cantidad;
                dgvAgregarNotaPedido.Rows[i].Cells[1].Value = lst[i].Unidad;
                dgvAgregarNotaPedido.Rows[i].Cells[2].Value = lst[i].Concepto;
                dgvAgregarNotaPedido.Rows[i].Cells[3].Value = lst[i].Precio_unitario;
                dgvAgregarNotaPedido.Rows[i].Cells[4].Value = lst[i].Rubro;
                dgvAgregarNotaPedido.Rows[i].Cells[5].Value = lst[i].Subrubro;
                dgvAgregarNotaPedido.Rows[i].Cells[7].Value = lst[i].Rubro_id;
                dgvAgregarNotaPedido.Rows[i].Cells[8].Value = lst[i].Subrubro_id;
                //dgvAgregarNotaPedido.Rows[i].Cells[5].Value = lst[i].Subtotal;
                Subtotal = Convert.ToDecimal(lst[i].Precio_unitario) * Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[0].Value);
                dgvAgregarNotaPedido.Rows[i].Cells[6].Value = Subtotal;
                //SumaSubTotal += Convert.ToDecimal(dataVentas.Rows[i].Cells[4].Value);
                

                SumaSubTotal += Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[6].Value);
         

            }
            
            limpiarcomandos();
            SumaTotal += SumaSubTotal;
            this.txtPrecioTotalEstimado.Text = Convert.ToString(Convert.ToDecimal(SumaTotal));
            //dgvAgregarNotaPedido.ClearSelection();

     



        MessageBox.Show("Ingreso al metodo LlenarGrilla()");
        }//fin metodo llenar grilla
        private void FrmNotaPedido_Load(object sender, EventArgs e)
        {
            this.LlenarComboOrganismo();
           
        }

        //metodos llenar combobox
        private void LlenarComboUnidadMedida()
        {
            this.cmbUnidadMedida.DataSource = NUnidadMedida.Mostrar();
            this.cmbUnidadMedida.ValueMember = "id_unidad_medida";
            this.cmbUnidadMedida.DisplayMember = "medida";
            this.cmbUnidadMedida.SelectedIndex = 1;
        }

        private void LlenarComboCaracterPedido()
        {
            this.cmbCaracterCompra.DataSource = NCaracterPedido.Mostrar();
            this.cmbCaracterCompra.ValueMember = "id_caracter_pedido";
            this.cmbCaracterCompra.DisplayMember = "caracter_pedido";
            this.cmbCaracterCompra.SelectedIndex = 1;
        }

        private void LlenarComboOrganismo()
        {
            //this.cmbOrganismoPedido.ValueMember = "id_organismo";
            //this.cmbOrganismoPedido.DisplayMember = "organismo";
            //this.cmbOrganismoPedido.DataSource = NOrganismo.Mostrar();
            //this.cmbOrganismoPedido.SelectedIndex = 1;

            DataTable dt = NOrganismo.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbOrganismoPedido.DataSource = dt;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbOrganismoPedido.ValueMember = "id_organismo";
                this.cmbOrganismoPedido.DisplayMember = "organismo";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbOrganismoPedido.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbOrganismoPedido.DataSource = null;
                this.cmbOrganismoPedido.SelectedIndex = -1;
            }




        }

        private void LlenarComboSectores()
        {
            this.cmbSector.ValueMember = "id_sector";
            this.cmbSector.DisplayMember = "sector";
            this.cmbSector.DataSource = NSectores.Mostrar();
            this.cmbSector.SelectedIndex = 1;
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

        private void dgvAgregarNotaPedido_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void LimpiarPedido()
        {
            // dataCliente.Rows.Clear();
            txtObservaciones.Text = string.Empty;
            txtPedido.Clear();
            txtPrecioTotalEstimado.Clear();
            dgvAgregarNotaPedido.Rows.Clear();
            this.lst.Clear();
        }
        private void btnRegistrarPedido_Click(object sender, EventArgs e)
        {//inicio boton registrar pedido 
            
            ArrayList productos_cantidades = new ArrayList();
            int posicion;
            int l = 0;
            int mostrarArraylist = 0;
            int claveventa = 0;
            string rpta = "";
            int habilitado = 1;
            int tipo_pago = 0;
            string rpta_stock = "";
            string rpta_bitacora = "";
            string rptaFactura = "";
            int k = 0;



            if (dgvAgregarNotaPedido.Rows.Count > 0)
            {//boton productos

                
                DateTime fechaEspecifica = new DateTime(2025, 12, 25); // Año, mes, día
                string id_pedido;
                int numero_transaccion_maxima = NPedido.BuscarNumeroTransaccion(); 
                int numero_transaccion = numero_transaccion_maxima;
                numero_transaccion = numero_transaccion_maxima + 1;
                //int renglon = 1;
                MessageBox.Show("numero maximo de transaccion es: " + " " + numero_transaccion_maxima);
                if (dgvAgregarNotaPedido.Rows.Count < 0)
                {
                    MessageBox.Show("No se cargó el pedido, Revise los datos cargados en los renglones.");
                    //LimpiarPedido();
                }
                else
                {
                    id_pedido = Convert.ToString(this.txtPedido.Text);
                    rptaFactura = NPedido.Insertar(500, Convert.ToString(this.txtPedido.Text), "12/10/2005", 1, Convert.ToInt32(this.txtIdUsuario.Text), Convert.ToInt32(numero_transaccion), Convert.ToInt32(this.cmbCaracterCompra.SelectedValue), 1, Convert.ToInt32(this.cmbSector.SelectedValue), Convert.ToInt32(this.txtIdUsuario.Text), Convert.ToString(this.txtObservaciones.Text), Convert.ToInt32(this.cmbOrganismoPedido.SelectedValue), Convert.ToInt32(this.cmbSector.SelectedValue), Convert.ToInt32(this.txtIdSectoresInternos.Text));
                    int legajo_usuario = Convert.ToInt32(this.txtLegajo.Text);
                    MessageBox.Show("El id del sector es: " + " " + Convert.ToInt32(this.cmbSector.SelectedValue));
                    MessageBox.Show("La repuesta factura es : " + " " + rptaFactura);
                    rpta_bitacora = NBitacora.Insertar_bitacora(legajo_usuario, 1, "Insertar pedido desde Procesamiento de Datos" + " " + rptaFactura);
                    MessageBox.Show("La repuesta bitacora es : " + " " + rptaFactura);
                    //int legajo_usuario = FrmLogin.usuario.Legajo;
                    //rpta_bitacora = NBitacora.Insertar_bitacora(legajo_usuario, 1, "Insertar nueva venta");
                    if (rptaFactura != "no_insertado")
                    {
                        //crearTicket ticket = new crearTicket();
                        //productos p = new productos();
                        int renglon = 0;
                        for (int i = 0; i <= dgvAgregarNotaPedido.Rows.Count - 1; i++)
                        {
                            renglon = renglon + 1;
                            rpta = NDetalle.Insertar(Convert.ToString(dgvAgregarNotaPedido.Rows[i].Cells[2].Value), Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[0].Value), 1, Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[3].Value), Convert.ToInt32(rptaFactura), Convert.ToInt32(renglon), Convert.ToInt32(renglon), Convert.ToInt32(renglon));
                            MessageBox.Show("Valor del parametro i: " + " " + i);
                            MessageBox.Show("Valor del renglon: " + " " + renglon);
                            MessageBox.Show("Valor del parametro rubro en este caso detalle: " + " " + Convert.ToString(dgvAgregarNotaPedido.Rows[i].Cells[2].Value));
                            MessageBox.Show("Valor del subrubro en este caso cantidad: " + " " + Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[0].Value));

                        }

                        MessageBox.Show("Se realizó correctamente la venta." + Convert.ToInt32(rptaFactura));

                        LimpiarPedido();
                        ImprimirPedido(Convert.ToInt32(rptaFactura));
                    }

                    else
                    {
                        MessageBox.Show("No se guardo el pedido, pongase en contacto con el Administrador de base de datos de Procesamiento de Datos.");
                        LimpiarPedido();
                    }
                    //}//fin ciclo for

                }

            }//boton productos

            else
            {
                MessageBox.Show("Debe ingresar nuevamente la clave de Vendedor");
              
            }


        }//fin boton registrar pedido

        private void cmbUnidadMedida_TextChanged(object sender, EventArgs e)
        {
            //this.CargarUnidad_Medida();
        }

        private void btnCargarUnidadMedida_Click(object sender, EventArgs e)
        {
            this.CargarUnidad_Medida();
        }

        private void dgvAgregarNotaPedido_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void btnQuitarRenglon_Click(object sender, EventArgs e)
        {
            if (dgvAgregarNotaPedido.Rows.Count > 0)
            {
                if (dgvAgregarNotaPedido.Rows[dgvAgregarNotaPedido.CurrentRow.Index].Selected == true)
                {
                    if (Convert.ToString(dgvAgregarNotaPedido.CurrentRow.Cells[2].Value) != "")
                    {
                        lst.RemoveAt(dgvAgregarNotaPedido.CurrentRow.Index);
                        dgvAgregarNotaPedido.Rows.RemoveAt(dgvAgregarNotaPedido.CurrentRow.Index);
                        //lst.RemoveAt(dataVentas.CurrentRow.Index);
                        LlenarGrilla();
                        //DevComponents.DotNetBar.MessageBoxEx.Show("Producto Eliminado de la Lista Ok.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        MessageBox.Show("Producto Eliminado de la Lista Ok.", "Sistema de Ventas Industriales SPPS.");
                    }
                    else
                    {
                        //DevComponents.DotNetBar.MessageBoxEx.Show("No Existe Ningun Elemento en la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        MessageBox.Show("No Existe Ningun Elemento en la Lista.", "Sistema de Ventas Industriales SPPS.");
                        dgvAgregarNotaPedido.ClearSelection();
                    }
                }
                else
                {
                    //DevComponents.DotNetBar.MessageBoxEx.Show("Por Favor Seleccione Item a Eliminar de la Lista.", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    MessageBox.Show("Por Favor Seleccione Item a Eliminar de la Lista.", "Sistema de Ventas Industriales SPPS.");
                }
            }
            else
            {
                //DevComponents.DotNetBar.MessageBoxEx.Show("No Existe Ningun Elemento en la Lista", "Sistema de Ventas.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("No Existe Ningun Elemento en la Lista", "Sistema de Ventas Industriales SPPS.");
            }
        }

        private void btnImprimirComprobante_Click(object sender, EventArgs e)
        {
            
        }

        private void cmbOrganismoPedido_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbOrganismoPedido.SelectedValue != null && int.TryParse(cmbOrganismoPedido.SelectedValue.ToString(), out int idOrganismo))
            {
                // Buscamos los subrubros de ese ID en específico
                //DataTable dtSubrubros = NSubrubro.BuscarSubrubroxRubro(idOrganismo);
                DataTable dtSectores = NSectores.BuscarSectoresxOrganismo(idOrganismo);

                cmbSector.DataSource = dtSectores;
                cmbSector.DisplayMember = "sector"; // Lo que el usuario VE
                cmbSector.ValueMember = "id_sector";       // El ID oculto
            }
            else
            {
                // Si el usuario deselecciona el rubro, limpiamos los subrubros anteriores
                cmbSubrubro.DataSource = null;
            }
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
           
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
    }
    
}

