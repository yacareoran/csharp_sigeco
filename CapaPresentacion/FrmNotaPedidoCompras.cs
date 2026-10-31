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
    public partial class FrmNotaPedidoCompras : Form
    {
        DPedido dPedido = new DPedido();
        DDetalle dDetalle = new DDetalle();
        ImprimirPedido iMprimirPedido = new ImprimirPedido();

        public FrmNotaPedidoCompras()
        {
            InitializeComponent();
            this.LlenarComboUnidadMedida();
            this.LlenarComboCaracterPedido();
            this.LlenarComboRubro();
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

                    Ventas.Unidad_id = Convert.ToInt32(this.cmbUnidadMedida.SelectedValue);

                    Ventas.Unidad = this.cmbUnidadMedida.Text;
                                        
                    Ventas.Concepto = this.txtConcepto.Text;
                    Ventas.Precio_unitario = Convert.ToDecimal(this.txtPrecioUnitario.Text);
                    //decimal valor = decimal.Parse(entrada, CultureInfo.InvariantCulture);
                    decimal precio = decimal.Parse(this.txtPrecioUnitario.Text, CultureInfo.InvariantCulture);
                    Ventas.Subtotal = (Convert.ToDecimal(precio) * (Convert.ToInt32(this.txtCantidad.Text)));
                    lst.Add(Ventas);
                    LlenarGrilla();
                }
                catch
                {

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



                MessageBox.Show("columna cero, que es la cantidad es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[0].Value);
                MessageBox.Show("columna uno, que es la unidad de medida es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[1].Value);
                MessageBox.Show("columna dos, que es el concepto es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[2].Value);
                MessageBox.Show("columna tres, que es el precio unitario es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[3].Value);
                //MessageBox.Show("columna cero, que es el rubro es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[4].Value);
                //MessageBox.Show("columna cero, que es el subrubro es: " + " " + dgvAgregarNotaPedido.Rows[i].Cells[5].Value);




                Subtotal = Convert.ToDecimal(lst[i].Precio_unitario) * Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[0].Value);
                dgvAgregarNotaPedido.Rows[i].Cells[4].Value = Subtotal;
                //SumaSubTotal += Convert.ToDecimal(dataVentas.Rows[i].Cells[4].Value);
                

                SumaSubTotal += Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[4].Value);

                dgvAgregarNotaPedido.Rows[i].Cells[5].Value = lst[i].Unidad_id;

            }
            limpiarcomandos();
            SumaTotal += SumaSubTotal;
            this.txtPrecioTotalEstimado.Text = Convert.ToString(Convert.ToDecimal(SumaTotal));
            //dgvAgregarNotaPedido.ClearSelection();


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
            this.cmbOrganismoPedido.ValueMember = "id_organismo";
            this.cmbOrganismoPedido.DisplayMember = "organismo";
            this.cmbOrganismoPedido.DataSource = NOrganismo.Mostrar();
            this.cmbOrganismoPedido.SelectedIndex = 1;
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

        // Evento que se dispara AUTOMÁTICAMENTE cuando el usuario selecciona un rubro
        private void cmbRubro_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Validamos que realmente haya un elemento seleccionado válido
            MessageBox.Show("Vedmos que sucede cuando cambiemos el rubro");
            /*if (cmbRubro.SelectedValue != null && int.TryParse(cmbRubro.SelectedValue.ToString(), out int idRubro))
            {
                // Buscamos los subrubros de ese ID en específico
                //DataTable dtSubrubros = objetoNegocio.ObtenerSubrubros(idRubro);
                DataTable dtSubrubros = NSubrubro.BuscarSubrubroxRubro(idRubro);

                cmbSubrubro.DataSource = dtSubrubros;
                cmbSubrubro.DisplayMember = "subrubro"; // Lo que el usuario VE
                cmbSubrubro.ValueMember = "id_subrubro";       // El ID oculto
            }*/
        }



        private void LlenarComboSectores()
        {
            this.cmbSector.ValueMember = "id_sector";
            this.cmbSector.DisplayMember = "sector";
            this.cmbSector.DataSource = NSectores.Mostrar();
            this.cmbSector.SelectedIndex = 1;
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
            {
                // ELIMINADO: Ya no calculamos el número de transacción desde C# porque lo hace el SP.
                // Pasamos un '0' en el parámetro correspondiente (el 6to parámetro) ya que el SP se encarga.
                rptaFactura = NPedido.Insertar(
                    500,
                    Convert.ToString(this.txtPedido.Text),
                    "12/10/2005",
                    1,
                    Convert.ToInt32(this.txtIdUsuario.Text),
                    0, // <-- Mandamos 0 aquí. El SP generará el número real.
                    Convert.ToInt32(this.cmbCaracterCompra.SelectedValue),
                    1,
                    Convert.ToInt32(this.cmbSector.SelectedValue),
                    Convert.ToInt32(this.txtIdUsuario.Text),
                    Convert.ToString(this.txtObservaciones.Text),
                    Convert.ToInt32(this.cmbSector.SelectedValue),
                    Convert.ToInt32(this.cmbOrganismoPedido.SelectedValue),
                    Convert.ToInt32(this.txtIdSectoresInternos.Text)
                );

                int legajo_usuario = Convert.ToInt32(this.txtLegajo.Text);

                rpta_bitacora = NBitacora.Insertar_bitacora(legajo_usuario, 1, "Insertar pedido desde Procesamiento de Datos. ID Generado: " + rptaFactura);

                if (rptaFactura != "no_insertado" && !rptaFactura.Contains("Exception"))
                {
                    int idPedidoGenerado = Convert.ToInt32(rptaFactura);
                    int renglon = 0;

                    for (int i = 0; i < dgvAgregarNotaPedido.Rows.Count; i++)
                    {
                        renglon++;

                        // Mapeo de celdas (Verificar índices de tu DataGridView)
                        string detalleProd = Convert.ToString(dgvAgregarNotaPedido.Rows[i].Cells[2].Value);
                        int cantidad = Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[0].Value);
                        int unidadMedida = Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[5].Value);
                        decimal precio = Convert.ToDecimal(dgvAgregarNotaPedido.Rows[i].Cells[3].Value);

                        int idArticulo = Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[0].Value);
                        int idExtra = Convert.ToInt32(dgvAgregarNotaPedido.Rows[i].Cells[0].Value);

                        rpta = NDetalle.Insertar(detalleProd, cantidad, unidadMedida, precio, idPedidoGenerado, renglon, idArticulo, idExtra);
                    }

                    //MessageBox.Show("Se realizó correctamente la venta del pedido N°: " + idPedidoGenerado);
                    //ImprimirPedido(idPedidoGenerado);
                    //LimpiarPedido();

                    // Forzamos la firma exacta de MessageBox.Show (Texto, Título, Botones, Icono)
                    DialogResult resultado = MessageBox.Show(
                        "Se cargó correctamente el pedido N°: " + idPedidoGenerado.ToString() + ".\n\n¿Desea imprimir el reporte del pedido?",
                        "Venta Exitosa",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Evaluamos de forma estricta que la respuesta haya sido "Yes"
                    if (resultado == DialogResult.Yes)
                    {
                        ImprimirPedido(idPedidoGenerado);
                    }

                    // Fuera del bloque IF para limpiar la pantalla después de la decisión
                    LimpiarPedido();



                }
                else
                {
                    MessageBox.Show("No se guardó el pedido. Error: " + rptaFactura);
                    LimpiarPedido();
                }
            }
            else
            {
                MessageBox.Show("No se cargó el pedido. Revise los datos cargados en los renglones.");
            }
        }

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
            //NSectores nSectores = new NSectores();
            //int id_organismo = Convert.ToInt32(this.cmbOrganismoPedido.SelectedValue);
            //cmbSector.ValueMember = "id_sector";
            //cmbSector.DisplayMember = "sector";
            //cmbSector.DataSource = NSectores.BuscarSectoresxOrganismo(id_organismo);
            
        }

        private void cmbSector_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbRubro_SelectedIndexChanged_1(object sender, EventArgs e)
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

