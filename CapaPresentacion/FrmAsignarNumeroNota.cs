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
    public partial class FrmAsignarNumeroNota : Form
    {
        public FrmAsignarNumeroNota()
        {
            InitializeComponent();
        }

        private void txtBuscarPedido_TextChanged(object sender, EventArgs e)
        {
            try
            {
                // 1. Cargamos los datos limpios en la grilla
                this.dgvPedidos.DataSource = NPedido.BuscarConcepto(this.txtBuscarPedido.Text);

                // 2. Ocultamos TODAS las columnas primero
                foreach (DataGridViewColumn col in this.dgvPedidos.Columns)
                {
                    col.Visible = false;
                }

                // 3. Recorremos y ordenamos las columnas
                foreach (DataGridViewColumn col in this.dgvPedidos.Columns)
                {
                    string nombreColumna = col.Name.ToLower();

                    if (nombreColumna == "id_pedido")
                    {
                        col.Visible = true;
                        col.Width = 60;
                        col.HeaderText = "ID";
                        col.DisplayIndex = 0; // <-- QUEREMOS QUE SEA LA PRIMERA
                    }
                    else if (nombreColumna == "num_transaccion" || nombreColumna == "num_transaccion")
                    {
                        col.Visible = true;
                        col.Width = 110; // Le subí un toque el ancho para que no se corte el título
                        col.HeaderText = "N° Transacción";
                        col.DisplayIndex = 1; // <-- QUEREMOS QUE SEA LA SEGUNDA
                    }
                    else if (nombreColumna == "pedido")
                    {
                        col.Visible = true;
                        col.Width = 850;
                        col.HeaderText = "Concepto";
                        col.DisplayIndex = 2; // <-- QUEREMOS QUE SEA LA TERCERA
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al buscar el pedido: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAsignarNumeroNota_Click(object sender, EventArgs e)
        {
            try
            {
                // -----------------------------------------------------------------
                // PASO 1: VALIDACIÓN Y CONFIRMACIÓN DE LA FILA SELECCIONADA
                // -----------------------------------------------------------------
                // Intentamos sacar el ID usando el método seguro
                int? idPedidoSeleccionado = ObtenerIdPedidoSeleccionado();

                if (idPedidoSeleccionado == null)
                {
                    MessageBox.Show("Por favor, seleccione un pedido de la lista.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.dgvPedidos.Focus();
                    return;
                }

                int idPedido = idPedidoSeleccionado.Value;

                // Sacamos el texto descriptivo del pedido (usando "pedido" que es el nombre real del campo de la BD)
                string detallePedido = "";
                if (dgvPedidos.CurrentRow != null)
                {
                    var celdaPedido = dgvPedidos.Columns.Contains("pedido")
                        ? dgvPedidos.CurrentRow.Cells["pedido"]
                        : dgvPedidos.CurrentRow.Cells[2]; // Respaldo: tu columna de concepto estaba en el índice 2

                    if (celdaPedido != null && celdaPedido.Value != null)
                    {
                        detallePedido = celdaPedido.Value.ToString();
                    }
                }

                // PREGUNTA 1: ¿Es este el pedido que quiere modificar?
                string mensajePregunta1 = $"¿Es este el pedido al que desea asignarle la nota?\n\n" +
                                          $"ID Pedido: {idPedido}\n" +
                                          $"Pedido: {detallePedido}";

                DialogResult resPregunta1 = MessageBox.Show(mensajePregunta1, "Confirmar Pedido Seleccionado", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Si el usuario se da cuenta de que no es la fila correcta y pone NO
                if (resPregunta1 == DialogResult.No)
                {
                    this.dgvPedidos.Focus(); // Mandamos el foco de vuelta a la grilla
                    return; // Detenemos todo para que elija otra fila
                }


                // -----------------------------------------------------------------
                // PASO 2: VALIDACIÓN DE LA CAJA DE TEXTO (NÚMERO DE NOTA)
                // -----------------------------------------------------------------
                // Como el usuario ya confirmó que el pedido es el correcto, ahora miramos la nota
                if (string.IsNullOrWhiteSpace(this.txtNumeroNota.Text))
                {
                    MessageBox.Show("Por favor, ingrese el número de nota para el pedido seleccionado.", "Falta completar datos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    this.txtNumeroNota.Focus(); // Mandamos el foco a la caja de texto
                    return; // Detenemos la ejecución
                }

                string numeroNota = this.txtNumeroNota.Text.Trim();


                // -----------------------------------------------------------------
                // PASO 3: PREGUNTA FINAL DE SEGURIDAD (OPCIONAL) O ENVÍO DIRECTO
                // -----------------------------------------------------------------
                // Si querés una última confirmación antes del impacto en BD:
                string mensajePregunta2 = $"Se va a registrar la Nota N° '{numeroNota}' para el Pedido ID {idPedido}.\n¿Desea continuar con el guardado?";
                DialogResult resPregunta2 = MessageBox.Show(mensajePregunta2, "Confirmar Guardado", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (resPregunta2 == DialogResult.No)
                {
                    return; // Cancela el guardado final
                }


                // -----------------------------------------------------------------
                // PASO 4: ENVÍO A LAS CAPAS INFERIORES (NEGOCIO -> DATOS -> SQL)
                // -----------------------------------------------------------------
                string rpta = NPedido.AsignarNumeroNotaPedido(idPedido, numeroNota);

                if (rpta == "OK")
                {
                    MessageBox.Show("El número de nota se asignó correctamente al pedido.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtNumeroNota.Clear(); // Limpiamos la caja
                    this.txtBuscarPedido.Focus(); // Devolvemos el foco a la búsqueda general
                }
                else
                {
                    MessageBox.Show("No se pudo asignar la nota: " + rpta, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error inesperado en el programa: " + ex.Message, "Error General", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private int? ObtenerIdPedidoSeleccionado()
        {
            if (this.dgvPedidos.CurrentRow != null && this.dgvPedidos.CurrentRow.Index >= 0)
            {
                // Buscamos el valor de la celda "id_pedido" de la fila seleccionada
                var valor = this.dgvPedidos.CurrentRow.Cells["id_pedido"].Value;

                if (valor != null && valor != DBNull.Value)
                {
                    return Convert.ToInt32(valor);
                }
            }
            return null;
        }
    }
}
