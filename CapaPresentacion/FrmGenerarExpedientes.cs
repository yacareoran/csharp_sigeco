using CapaDatos;
using CapaNegocio;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;//para validaciones
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class FrmGenerarExpedientes : Form
    {
        private decimal _totalGeneralAcumulado = 0;
        public FrmGenerarExpedientes()
        {
            InitializeComponent();
            // Sacamos el boton restaurar del formulario
            this.barraTituloRibbon1.MostrarMaximizar = false;

            // Sacamos el boton restaurar del formulario
            this.barraTituloRibbon1.MostrarMaximizar = false;

            // --- TU LÍNEA DE COLOR CONFIGURADA EN EL INICIO ---
            this.BackColor = Color.FromArgb(240, 244, 250);

            // --- BORDES ELEGANTES PARA TUS BOTONES ---
            Color colorGrisBorde = Color.FromArgb(160, 180, 210);

            // Botón Acceder
            this.btnBuscarNotaPedido.FlatStyle = FlatStyle.Flat;
            this.btnBuscarNotaPedido.FlatAppearance.BorderColor = colorGrisBorde;

            // Hace que todas las celdas sean de solo lectura
            dgvPedidoExpedientes.ReadOnly = true;

            // Elimina la fila en blanco del final (evita que el usuario agregue filas)
            dgvPedidoExpedientes.AllowUserToAddRows = false;

            // Opcional: Evita que el usuario borre registros con la tecla Supr/Delete
            dgvPedidoExpedientes.AllowUserToDeleteRows = false;


        }

        private void FrmGenerarExpedientes_Load(object sender, EventArgs e)
        {
            this.LlenarComboOrganismo();
            this.LlenarComboOrganismoDestino();
            this.LlenarComboTipoContratacion();
        }

        private List<DCargarPedidos> lst = new List<DCargarPedidos>();
        private List<DCargarDetalles> lsd = new List<DCargarDetalles>();
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

        private void LlenarComboOrganismoDestino()
        {

            DataTable dt = NOrganismo.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt != null && dt.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbOrganismoDestino.DataSource = dt;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbOrganismoDestino.ValueMember = "id_organismo";
                this.cmbOrganismoDestino.DisplayMember = "organismo";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbOrganismoDestino.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbOrganismoDestino.DataSource = null;
                this.cmbOrganismoDestino.SelectedIndex = -1;
            }
        }  
        private void LlenarComboTipoContratacion()
        {

            DataTable dt2 = NTipoContratacion.Mostrar();

            // 2. Validamos que la base de datos no haya devuelto algo vacío
            if (dt2 != null && dt2.Rows.Count > 0)
            {
                // 3. Asignamos primero la fuente de datos
                this.cmbTipoContratacion.DataSource = dt2;

                // 4. Mapeamos las columnas de tu tabla SQL
                this.cmbTipoContratacion.ValueMember = "id_tipo_contratacion";
                this.cmbTipoContratacion.DisplayMember = "tipo_contratacion";

                // 5. Arranca seleccionando el PRIMER elemento de la lista de forma segura
                this.cmbTipoContratacion.SelectedIndex = 0;
            }
            else
            {
                // Opcional: Si no hay rubros, puedes limpiar el combo o dejarlo vacío
                this.cmbTipoContratacion.DataSource = null;
                this.cmbTipoContratacion.SelectedIndex = -1;
            }




        }

        private void cmbOrganismoExpediente_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Limpiamos SIEMPRE el combo de sectores al inicio para borrar el organismo anterior
            cmbSectorIniciador.DataSource = null;

            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbOrganismoExpediente.SelectedValue != null && int.TryParse(cmbOrganismoExpediente.SelectedValue.ToString(), out int idOrganismo))
            {
                // Buscamos los sectores de ese ID en específico
                DataTable dtSectores = NSectores.BuscarSectoresxOrganismo(idOrganismo);

                // 2. Solo cargamos el combo si la base de datos realmente devolvió filas
                if (dtSectores != null && dtSectores.Rows.Count > 0)
                {
                    cmbSectorIniciador.DataSource = dtSectores;
                    cmbSectorIniciador.DisplayMember = "sector"; // Lo que el usuario VE
                    cmbSectorIniciador.ValueMember = "id_sector"; // El ID oculto

                    // Al no poner Index = -1, se preselecciona el primer sector automáticamente
                }
                // Si Rows.Count es 0, queda totalmente vacío y limpio
            }
        }

        private void BuscarPedidoxNumeroTransaccion()
        {
            DataTable miDataTable = new DataTable();
            // 1. Guardamos el número en una variable para inspeccionarlo
            int numeroBuscado = Convert.ToInt32(this.txtBuscarNotaPedido.Text);

            var listaPedidos = NPedido.BuscarxTransaccion(Convert.ToInt32(this.txtBuscarNotaPedido.Text));
            //decimal costoTotal = NDetalle.BuscarCostoTotal(Convert.ToInt32(1041));
            List<DPedido> listaResumen = new List<DPedido>();
            //if (listaPedidos.Rows.Count <= 1)
            // 2. AGREGÁ ESTA LÍNEA TEMPORAL PARA DEPURALO:
            MessageBox.Show($"Buscando Transacción: {numeroBuscado} | Filas devueltas por SQL: {listaPedidos.Rows.Count}");

            // ¡CORREGIDO ACÁ! Cambiamos <= 1 por == 0
            if (listaPedidos.Rows.Count == 0)
            {
                MessageBox.Show("No se encontraron registros");
                return;
            }

            foreach (DataRow row in listaPedidos.Rows)
            {
                Decimal SumaSubTotal = 0; Decimal Prueba = 0;
                Decimal CostoDetalles; Decimal CostoTotalDetalles = 0;
                //SumaSubTotal += listaResumen[i].Id_pedido;
                var listaCantidadDetalle = NDetalle.BuscarCantidadPrecio(Convert.ToInt32(row["id_pedido"]));
                MessageBox.Show(Convert.ToString(row["id_pedido"]));
                foreach (DataRow row1 in listaCantidadDetalle.Rows)
                {
                    CostoTotalDetalles += Convert.ToInt32(row1["cantidad"]) * Convert.ToDecimal(row1["precio"]);
                }
                Prueba = CostoTotalDetalles;

                listaResumen.Add(new DPedido
                {
                    Id_pedido = Convert.ToInt32(row["id_pedido"]),
                    Num_transaccion = Convert.ToInt32(row["num_transaccion"]),
                    Fecha_pedido = Convert.ToDateTime(row["fecha_pedido"]),
                    //Sectores_internos = row["sectores_internos"].ToString(),
                    //Extracto = row["extracto"].ToString(),
                    Caracter_pedido = row["caracter_pedido"].ToString(),
                    Pedido = row["pedido"].ToString(),
                    Estado = row["estado"].ToString(),
                    Costo_total = Prueba
                });

            }

            var datosfiltrados = listaResumen
               .Select(c => new
               {
                   Id_Pedido = c.Id_pedido,
                   Num_Transaccion = c.Num_transaccion,
                   FechaPedido = c.Fecha_pedido,
                   Sector = c.Sector,
                   CaracterPedido = c.Caracter_pedido,
                   Pedido = c.Pedido,
                   Estado = c.Estado,
                   costoTotal = c.Costo_total
               })
               .ToList();

            dgvPedidos.DataSource = datosfiltrados;
            // 2. Ocultamos la columna del ID (Sensible a mayúsculas/minúsculas)
            if (dgvPedidos.Columns["Id_Pedido"] != null)
            {
                dgvPedidos.Columns["Id_Pedido"].Visible = false;
            }
            // Las columnas se ajustan para mostrar todo el contenido del texto
            dgvPedidos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

        }

        //Inicio metodo LlenarGrilla
        private void LlenarGrilla()
        {//inicio metodo llenar grilla

            Decimal SumaSubTotal = 0; Decimal SumaIva = 0; Decimal SumaTotal = 0; decimal Subtotal = 0;
            dgvPedidoExpedientes.Rows.Clear();
            //contador = lst.Count;
            for (int i = 0; i < lst.Count; i++)
            //while (i <= lst.Count)
            {
                dgvPedidoExpedientes.Rows.Add();
                dgvPedidoExpedientes.Rows[i].Cells[0].Value = lst[i].Id_pedido;
                dgvPedidoExpedientes.Rows[i].Cells[1].Value = lst[i].Pedido;
                //dgvPedidoExpedientes.Rows[i].Cells[2].Value = lst[i].Descripcion_producto;
                //dgvPedidoExpedientes.Rows[i].Cells[3].Value = lst[i].Precio_producto;
                //dgvPedidoExpedientes.Rows[i].Cells[5].Value = lst[i].Stock;
                //Subtotal = Convert.ToDecimal(dataVentas.Rows[i].Cells[3].Value = lst[i].Precio_producto) * Convert.ToInt32(lst[i].Cantidad_producto);
                //Subtotal = Convert.ToDecimal(dataVentas.Rows[i].Cells[3].Value = lst[i].Precio_producto) * Convert.ToDecimal(lst[i].Cantidad_producto);
                //dataVentas.Rows[i].Cells[4].Value = Subtotal;

                
            }
           
            SumaTotal += SumaSubTotal;
            //this.labelTotal.Visible = true;
            //this.labelTotal.Text = Convert.ToString(Convert.ToDecimal(SumaTotal));
            
            dgvPedidoExpedientes.ClearSelection();


        }//fin metodo llenar grilla
        private void CargarVentasGrillaPedidos(string numTransaccion, string pedidoTexto, string numeroNota, int idPedido)
        {
            if (this.dgvPedidoExpedientes.Columns.Count < 4)
            {
                this.dgvPedidoExpedientes.Columns.Clear();
                //SI EL TEXTO DE PEDIDO SUPERA LA FILA SE AGREGA DEBAJO DE LA MISMA FILA
                this.dgvPedidoExpedientes.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                this.dgvPedidoExpedientes.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells; 
                //HASTA AQUI ESE CODIGO DE LA FILA
                this.dgvPedidoExpedientes.Columns.Add("num_transaccion", "N° Transacción");
                this.dgvPedidoExpedientes.Columns.Add("pedido", "Pedido");
                this.dgvPedidoExpedientes.Columns.Add("numero_nota", "N° Nota");
                this.dgvPedidoExpedientes.Columns.Add("id_pedido", "ID Pedido");

                this.dgvPedidoExpedientes.Columns["id_pedido"].Visible = false;

                // Ajustamos los anchos para que "Pedido" se expanda y muestre toda la descripción
                this.dgvPedidoExpedientes.Columns["num_transaccion"].Width = 110;
                this.dgvPedidoExpedientes.Columns["numero_nota"].Width = 100;
                this.dgvPedidoExpedientes.Columns["pedido"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            this.dgvPedidoExpedientes.Rows.Add(numTransaccion, pedidoTexto, numeroNota, idPedido);
        }



        private void txtBuscarNotaPedido_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir dígitos (0-9), tecla Borrar (Backspace) y la barra '/'
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Bloquea cualquier letra o símbolo raro
                return;
            }

            // Evitar que escriban '/' al principio o pongan más de una barra '/'
            if (e.KeyChar == '/')
            {
                TextBox txt = sender as TextBox;
                if (txt.Text.Length == 0 || txt.Text.Contains("/"))
                {
                    e.Handled = true;
                }
            }
        }

        private void QuitarPedidoDeExpediente()
        {
            // 1. Validamos que haya una fila válida seleccionada
            if (this.dgvPedidoExpedientes.CurrentRow == null || this.dgvPedidoExpedientes.CurrentRow.IsNewRow)
            {
                return;
            }

            DataGridViewRow filaSeleccionada = this.dgvPedidoExpedientes.CurrentRow;
            string numTransaccion = filaSeleccionada.Cells["num_transaccion"].Value?.ToString() ?? "";

            // 2. Pedimos confirmación al usuario
            DialogResult respuesta = MessageBox.Show(
                $"¿Desea quitar el pedido (Transacción N° {numTransaccion}) de este expediente?",
                "Quitar Pedido",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respuesta != DialogResult.Yes)
                return;

            try
            {
                // 3. Obtenemos el id_pedido oculto (columna 3) para consultar su monto y descontarlo
                int idPedido = Convert.ToInt32(filaSeleccionada.Cells["id_pedido"].Value);

                DPedido pedidoEntidad = new DPedido();
                pedidoEntidad.Id_pedido = idPedido;
                decimal montoARestar = NPedido.ObtenerTotalPedido(pedidoEntidad);

                // 4. Descontamos del acumulado general (asegurando que nunca quede negativo)
                _totalGeneralAcumulado -= montoARestar;
                if (_totalGeneralAcumulado < 0) _totalGeneralAcumulado = 0;

                this.lblTotalGralAcumulado.Text = _totalGeneralAcumulado.ToString("N2");

                // 5. Eliminamos la fila de la grilla
                this.dgvPedidoExpedientes.Rows.Remove(filaSeleccionada);

                // Si ya no quedan filas, limpiamos también el monto parcial del último pedido
                if (this.dgvPedidoExpedientes.Rows.Count == 0)
                {
                    this.lblMontoTotal.Text = "0,00";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al quitar el pedido: " + ex.Message,
                                "Error del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void btnBuscarTransaccion_Click(object sender, EventArgs e)
        {
            // 1. VALIDACIÓN: Evitar búsquedas vacías
            string numeroNota = this.txtBuscarNotaPedido.Text.Trim();

            if (string.IsNullOrWhiteSpace(numeroNota))
            {
                MessageBox.Show("Por favor, ingrese el número de nota que desea buscar (Ej: 285/25).",
                                "Campo Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.txtBuscarNotaPedido.Focus();
                return;
            }

            // 2. VALIDACIÓN DE FORMATO: Debe ser Número/Año (ej: 285/25 o 285/2026)
            if (!Regex.IsMatch(numeroNota, @"^[0-9]+/[0-9]{2,4}$"))
            {
                MessageBox.Show("El formato del número de nota no es válido.\nDebe ingresar Número/Año (por ejemplo: 285/25).",
                                "Formato Incorrecto",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.txtBuscarNotaPedido.SelectAll();
                this.txtBuscarNotaPedido.Focus();
                return;
            }

            try
            {
                // 2. LLAMADA A LA CAPA DE NEGOCIO
                DataTable dtResultados = NPedido.BuscarPedidoxNotaPedido(numeroNota);

                // Validar si hubo un error de conexión en la capa de datos
                if (dtResultados == null)
                {
                    MessageBox.Show("No se pudo conectar con la base de datos. Intente nuevamente.",
                                    "Error de Conexión",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }

                // 3. VALIDACIÓN: Verificar si se encontraron registros
                if (dtResultados.Rows.Count == 0)
                {
                    this.dgvPedidos.DataSource = null;
                    MessageBox.Show($"No se encontró ningún pedido con el número de nota '{numeroNota}'.",
                                    "Sin Resultados",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    this.txtBuscarNotaPedido.SelectAll();
                    this.txtBuscarNotaPedido.Focus();
                    return;
                }

                // 4. CARGAR LA GRILLA CON LOS RESULTADOS
                this.dgvPedidos.DataSource = dtResultados;

                // Ocultamos columnas internas que el usuario no necesita ver (pero que sirven al seleccionar fila)
                if (this.dgvPedidos.Columns.Contains("usuario_id"))
                    this.dgvPedidos.Columns["usuario_id"].Visible = false;

                if (this.dgvPedidos.Columns.Contains("estado_id"))
                    this.dgvPedidos.Columns["estado_id"].Visible = false;

                // Damos títulos prolijos a las columnas visibles
                if (this.dgvPedidos.Columns.Contains("num_transaccion"))
                    this.dgvPedidos.Columns["num_transaccion"].HeaderText = "N° Transacción";

                if (this.dgvPedidos.Columns.Contains("id_pedido"))
                    this.dgvPedidos.Columns["id_pedido"].HeaderText = "ID Pedido";

                if (this.dgvPedidos.Columns.Contains("numero_nota"))
                    this.dgvPedidos.Columns["numero_nota"].HeaderText = "N° Nota";

                if (this.dgvPedidos.Columns.Contains("fecha_pedido"))
                    this.dgvPedidos.Columns["fecha_pedido"].HeaderText = "Fecha";

                if (this.dgvPedidos.Columns.Contains("pedido"))
                    this.dgvPedidos.Columns["pedido"].HeaderText = "Detalle / Pedido";

                if (this.dgvPedidos.Columns.Contains("extracto"))
                    this.dgvPedidos.Columns["extracto"].HeaderText = "Extracto";

                if (this.dgvPedidos.Columns.Contains("estado"))
                    this.dgvPedidos.Columns["estado"].HeaderText = "Estado";

                this.dgvPedidos.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al realizar la búsqueda: " + ex.Message,
                                "Error del Sistema",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void dgvPedidos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;

                // 1. Validar que haya una fila seleccionada en dgvPedidos
                if (this.dgvPedidos.CurrentRow == null)
                {
                    MessageBox.Show("Selecciona un pedido válido en la grilla.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // 2. Leer los datos por el NOMBRE EXACTO de la columna en dgvPedidos (sin depender de índices)
                DataGridViewRow filaOrigen = this.dgvPedidos.CurrentRow;

                if (!int.TryParse(filaOrigen.Cells["id_pedido"].Value?.ToString(), out int idPedido))
                {
                    MessageBox.Show("Por favor, selecciona un ID de pedido numérico y válido.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string numTransaccion = filaOrigen.Cells["num_transaccion"].Value?.ToString() ?? "";
                string pedidoTexto = filaOrigen.Cells["pedido"].Value?.ToString() ?? "";
                string numeroNota = filaOrigen.Cells["numero_nota"].Value?.ToString() ?? "";

                // 3. VALIDACIÓN ANTI-DUPLICADOS EN dgvPedidoExpedientes (usando la columna oculta "id_pedido" o índice 3)
                foreach (DataGridViewRow fila in this.dgvPedidoExpedientes.Rows)
                {
                    if (fila.IsNewRow) continue;

                    // Comparamos contra la 4ta celda (índice 3) donde guardamos el idPedido oculto
                    //if (fila.Cells.Count > 3 && fila.Cells.Value != null && Convert.ToInt32(fila.Cells.Value) == idPedido)
                    // Comparamos contra la 4ta celda (índice 3) donde guardamos el idPedido oculto
                    if (fila.Cells.Count > 3 && fila.Cells[3].Value != null && Convert.ToInt32(fila.Cells[3].Value) == idPedido)
                    {
                        MessageBox.Show($"El pedido (Transacción N° {numTransaccion}) ya fue agregado a este expediente.",
                                        "Pedido Duplicado",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Warning);
                        return;
                    }
                }

                // 4. Agregamos la fila a dgvPedidoExpedientes con el orden exacto que necesitas
                CargarVentasGrillaPedidos(numTransaccion, pedidoTexto, numeroNota, idPedido);

                // 5. Calculamos y acumulamos el monto total del pedido
                try
                {
                    DPedido pedidoEntidad = new DPedido();
                    pedidoEntidad.Id_pedido = idPedido;

                    decimal totalGeneral = NPedido.ObtenerTotalPedido(pedidoEntidad);

                    this.lblMontoTotal.Text = totalGeneral.ToString("N2");

                    _totalGeneralAcumulado += totalGeneral;
                    this.lblTotalGralAcumulado.Text = _totalGeneralAcumulado.ToString("N2");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ocurrió un error al consultar los datos: {ex.Message}", "Error del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void txtBuscarPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);
                // 1. Primero traés los datos. Al hacer esto, el DataGridView genera automáticamente las columnas, [1], [2], etc.
                this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);

                // 2. Ahora que las columnas SÍ existen en memoria, las modificás y ocultás sin errores
                this.dgvPedidos.Columns[0].Width = 60;
                this.dgvPedidos.Columns[1].Visible = false;
                this.dgvPedidos.Columns[2].Width = 425;
                this.dgvPedidos.Columns[3].Visible = false;
                this.dgvPedidos.Columns[4].Visible = false;
                this.dgvPedidos.Columns[5].Width = 80;
                this.dgvPedidos.Columns[6].Visible = false;
                this.dgvPedidos.Columns[7].Visible = false;
                this.dgvPedidos.Columns[8].Visible = false;
                this.dgvPedidos.Columns[9].Visible = false;
                this.dgvPedidos.Columns[10].Visible = false;

                // Ojo: Recordá que tu procedimiento ahora devuelve más campos (hasta el índice 17).
                // Si querés ocultar TODOS los demás automáticamente para que no aparezcan al final, podés sumar este bucle:
                for (int i = 11; i < this.dgvPedidos.Columns.Count; i++)
                {
                    this.dgvPedidos.Columns[i].Visible = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Los productos no coinciden con las letras ingresadas, vuelva a ingresar el nombre del producto o agreguelo desde el boton nuevo producto" + "" + ex);
            }
        }

        private bool ValidarFormulario()
        {
            // 0. Validar que ya se haya generado el Número de Expediente Interno en lblExpedienteInterno
            string expInterno = this.lblExpedienteInterno.Text.Trim();
            if (string.IsNullOrWhiteSpace(expInterno) || expInterno == "0" || expInterno == "Expediente")
            {
                MessageBox.Show("Primero debe generar el Número de Expediente Interno antes de continuar.",
                                "Número de Expediente Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.btnGenerarExpediente.Focus(); // <-- Cambia por el nombre real de tu botón generador
                return false;
            }

            // 1. Validar que txtCaratula no esté vacío
            if (string.IsNullOrWhiteSpace(this.txtCaratula.Text))
            {
                MessageBox.Show("Por favor, ingrese la carátula o título del expediente.",
                                "Campo Obligatorio",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.txtCaratula.Focus();
                return false;
            }

            // 2. Validar cmbSectorIniciador (si está vacío, devolver el foco al combo padre cmbOrganismoExpediente)
            if (this.cmbSectorIniciador.SelectedIndex == -1 || this.cmbSectorIniciador.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un Organismo y un Sector Iniciador.",
                                "Sector Iniciador Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.cmbOrganismoExpediente.Focus();
                return false;
            }

            // 3. Validar cmbSectorDestino (si está vacío, devolver el foco al combo padre cmbOrganismoDestino)
            if (this.cmbSectorDestino.SelectedIndex == -1 || this.cmbSectorDestino.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione un Organismo y un Sector de Destino.",
                                "Sector Destino Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.cmbOrganismoDestino.Focus();
                return false;
            }

            // 4. Validar cmbTipoContratacion
            if (this.cmbTipoContratacion.SelectedIndex == -1 || this.cmbTipoContratacion.SelectedValue == null)
            {
                MessageBox.Show("Por favor, seleccione el Tipo de Contratación.",
                                "Tipo de Contratación Requerido",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.cmbTipoContratacion.Focus();
                return false;
            }

            // 5. Confirmación paso a paso de cada combo seleccionado
            // 5.1 Confirmar Sector Iniciador
            DialogResult respIniciador = MessageBox.Show(
                $"¿Confirma que el Sector Iniciador seleccionado es correcto?\n\nSector Iniciador: {this.cmbSectorIniciador.Text}",
                "Confirmar Sector Iniciador",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respIniciador == DialogResult.No)
            {
                this.cmbOrganismoExpediente.Focus();
                return false;
            }

            // 5.2 Confirmar Sector Destino
            DialogResult respDestino = MessageBox.Show(
                $"¿Confirma que el Sector de Destino seleccionado es correcto?\n\nSector Destino: {this.cmbSectorDestino.Text}",
                "Confirmar Sector Destino",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respDestino == DialogResult.No)
            {
                this.cmbOrganismoDestino.Focus();
                return false;
            }

            // 5.3 Confirmar Tipo de Contratación
            DialogResult respContratacion = MessageBox.Show(
                $"¿Confirma que el Tipo de Contratación seleccionado es correcto?\n\nTipo de Contratación: {this.cmbTipoContratacion.Text}",
                "Confirmar Tipo de Contratación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (respContratacion == DialogResult.No)
            {
                this.cmbTipoContratacion.Focus();
                return false;
            }

            // 6. Validar que haya al menos un pedido cargado en dgvPedidoExpedientes
            int cantidadPedidos = 0;
            foreach (DataGridViewRow fila in this.dgvPedidoExpedientes.Rows)
            {
                if (!fila.IsNewRow) cantidadPedidos++;
            }

            if (cantidadPedidos == 0)
            {
                MessageBox.Show("Debe agregar al menos un pedido a la lista antes de generar el expediente.",
                                "Sin Pedidos Vinculados",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                this.txtBuscarNotaPedido.Focus();
                return false;
            }

            return true; // Todo validado y confirmado correctamente
        }



        private void btnGenerarExpediente_Click(object sender, EventArgs e)
        {
            NPedido pedido = new NPedido();
            int numero = NPedido.BuscarMaximoNumeroExpediente();
            if (numero >= 0)
            {
                numero = numero + 1;
                this.lblExpedienteInterno.Text = Convert.ToString("04") + "-" + Convert.ToString(numero);
            }
            else
            {
                MessageBox.Show("maximo numero para expedioentre interno " + " " + numero);
            }  
        }

        private void btnGuardarExpediente_Click(object sender, EventArgs e)
        {
                // 1. Ejecutamos todas las validaciones y confirmaciones; si alguna falla, frenamos aquí
                if (!this.ValidarFormulario())
                {
                    return;
                }

                try
                {
                    // 2. Armamos el DataTable con la columna "pedido_id" que espera NExpedientes.Insertar
                    DataTable dtPedidos = new DataTable();
                    dtPedidos.Columns.Add("pedido_id", typeof(int));

                    foreach (DataGridViewRow fila in this.dgvPedidoExpedientes.Rows)
                    {
                        if (fila.IsNewRow) continue;

                        // Leemos la columna oculta "id_pedido" que guardamos al presionar Enter
                        int idPedido = Convert.ToInt32(fila.Cells["id_pedido"].Value);
                        dtPedidos.Rows.Add(idPedido);
                    }

                    // 3. Capturamos los datos de cabecera del expediente
                    string expedienteInterno = this.lblExpedienteInterno.Text.Trim();
                    string caratula = this.txtCaratula.Text.Trim();
                    DateTime fechaCreacion = DateTime.Now;
                    int sectorIniciador = Convert.ToInt32(this.cmbSectorIniciador.SelectedValue);
                    int sectorDestino = Convert.ToInt32(this.cmbSectorDestino.SelectedValue);
                    decimal montoTotal = _totalGeneralAcumulado;

                    // IMPORTANTE: Cambia esta variable por el nombre real de cómo guardas el ID del usuario logueado en este form
                    int usuarioIniciador = Convert.ToInt32(this.txtIdUsuario.Text.Trim());

                    // 4. Llamamos a la Capa de Negocio (guarda cabecera + todos los pedidos en una sola transacción)
                    string rpta = NExpedientes.Insertar(
                        expedienteInterno,
                        caratula,
                        fechaCreacion,
                        sectorIniciador,
                        sectorDestino,
                        montoTotal,
                        usuarioIniciador,
                        dtPedidos
                    );

                    // 5. Evaluamos el resultado
                    if (rpta.Equals("OK"))
                    {
                        MessageBox.Show($"El Expediente Interno N° {expedienteInterno} fue generado y guardado correctamente.",
                                        "Expediente Guardado",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);

                        // Limpiamos el formulario para cargar un nuevo expediente
                        this.LimpiarFormularioExpediente();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo guardar el expediente:\n" + rpta,
                                        "Error al Guardar",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado al guardar el expediente: " + ex.Message,
                                    "Error del Sistema",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
        }

        

        private void LimpiarFormularioExpediente()
        {
            this.lblExpedienteInterno.Text = "";
            this.txtCaratula.Clear();
            this.txtBuscarNotaPedido.Clear();
            this.dgvPedidoExpedientes.Rows.Clear();
            _totalGeneralAcumulado = 0;
            this.lblMontoTotal.Text = "0,00";
            this.lblTotalGralAcumulado.Text = "0,00";
            this.txtCaratula.Focus();
        }


        private void cmbSectorDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cmbOrganismoDestino_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. Limpiamos SIEMPRE el combo de sectores al inicio para borrar el organismo anterior
            cmbSectorDestino.DataSource = null;

            // Validamos que realmente haya un elemento seleccionado válido
            if (cmbOrganismoDestino.SelectedValue != null && int.TryParse(cmbOrganismoDestino.SelectedValue.ToString(), out int idOrganismo))
            {
                // Buscamos los sectores de ese ID en específico
                DataTable dtSectores = NSectores.BuscarSectoresxOrganismo(idOrganismo);

                // 2. Solo cargamos el combo si la base de datos realmente devolvió filas
                if (dtSectores != null && dtSectores.Rows.Count > 0)
                {
                    cmbSectorDestino.DataSource = dtSectores;
                    cmbSectorDestino.DisplayMember = "sector"; // Lo que el usuario VE
                    cmbSectorDestino.ValueMember = "id_sector"; // El ID oculto

                    // ¡AL SACAR EL INDEX -1, SE SELECCIONA EL PRIMER SECTOR AUTOMÁTICAMENTE ACÁ!
                }
                // Si Rows.Count es 0, no entra al IF y el combo permanece totalmente vacío
            }

        }

        private void txtBuscarNotaPedido_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            // 1. Permitir dígitos (0-9), tecla Borrar (Backspace) y la barra '/'
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '/')
            {
                e.Handled = true; // Bloquea la tecla
                MessageBox.Show("Teclas alfabéticas y símbolos bloqueados momentáneamente.\nPor favor, ingrese únicamente números y la barra '/' (Ej: 285/25).",
                                "Entrada no permitida",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Warning);
                return;
            }

            // 2. Evitar que escriban '/' al principio o pongan más de una barra '/'
            if (e.KeyChar == '/')
            {
                TextBox txt = sender as TextBox;
                if (txt.Text.Length == 0 || txt.Text.Contains("/"))
                {
                    e.Handled = true; // Bloquea la barra
                    MessageBox.Show("La barra '/' solo puede ingresarse una vez y después del número de nota (Ej: 285/25).",
                                    "Posición de barra incorrecta",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning);
                }
            }
        }

        private void dgvPedidoExpedientes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                QuitarPedidoDeExpediente();
            }
        }
    }
}
