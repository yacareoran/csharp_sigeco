using CapaDatos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data;
using System.Text; // <-- Agrega esta línea arriba
using System.Windows.Forms;

namespace CapaPresentacion.Reporte.Formulario_Pedido
{//inicio clase
    using CapaDatos;
    using iTextSharp.text.pdf;
    using iTextSharp.text;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Data;
    using System.Windows.Forms;

    public class ReporteImprimirPedido
    {
        public static MemoryStream RepPdfInternosVinculados(ImprimirPedido imprimirPedidox, DataTable pedidox, DataTable dDetallexPedido)
        {
            DPedido pedido = new DPedido();
            DReportes reportes = new DReportes();

            if (pedidox.Rows.Count > 0)
            {
                DataRow row = pedidox.Rows[0];

                reportes.Id_pedido = Convert.ToInt32(row["Id_pedido"]);
                reportes.Pedido = row["Pedido"].ToString();
                reportes.Fecha_pedido = Convert.ToDateTime(row["Fecha_pedido"]);
                reportes.Usuario_id = Convert.ToInt32(row["Usuario_id"]);
                reportes.Num_transaccion = Convert.ToInt32(row["Num_transaccion"]);
                reportes.Caracter_pedido_id = Convert.ToInt32(row["Caracter_pedido_id"]);
                reportes.Extracto = row["Extracto"].ToString();

                // NOTA MAESTRA: Aquí mapeamos el alias de texto que corregimos en tu base de datos para quitar el "0"
                reportes.Destino = row["Sector_destino"].ToString();
                //reportes.Sector = row["Origen"].ToString();
                reportes.Sector = row["Sectores_internos"].ToString();
                reportes.Caracter_pedido = row["Caracter_pedido"].ToString();
                reportes.Estado = row["Estado"].ToString();
                //reportes.Origen = row["Origen"].ToString();
            }

            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false;

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            //var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            //var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.TIMES_ROMAN, 12, BaseColor.BLACK);

            doc.Add(new Paragraph(" "));
                                    
            // =========================================================================
            // ENCABEZADO: LOGOTIPO Y TEXTO CENTRADOS (Modelo Oficial de la Imagen)
            // =========================================================================
            // 1. Ruta física hacia la imagen
            string rutaImagen = Path.Combine(Application.StartupPath, "Resources", "Img-reportes", "logo_spps2.png");

            // Validamos si la imagen existe antes de dibujar
            if (!File.Exists(rutaImagen))
            {
                MessageBox.Show("Falta el logotipo. Por favor, guarde la imagen 'logo_spps2.png' en la carpeta: \n" +
                                Path.Combine(Application.StartupPath, "Resources", "Img-reportes\\"),
                                "Aviso de Sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return ms;
            }

            // 2. Cargamos y convertimos la imagen para iTextSharp
            System.Drawing.Image logoImg = System.Drawing.Image.FromFile(rutaImagen);
            iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);

            // 3. Ajustamos el tamaño del logo (Ancho: 45f, Alto: 45f para que coincida con la proporción de la imagen)
            logo.ScaleAbsolute(45f, 45f);
            logo.Alignment = Element.ALIGN_CENTER; // Centrado dentro de su celda

            // 4. Creamos una mini-tabla de 1 sola columna para agrupar y centrar el bloque
            PdfPTable tablaLogoBloque = new PdfPTable(1);
            tablaLogoBloque.WidthPercentage = 40; // 40% le da el ancho perfecto para que el texto entre cómodo sin cortarse
            tablaLogoBloque.HorizontalAlignment = Element.ALIGN_LEFT; // Mantiene todo el bloque a la izquierda de la hoja
            tablaLogoBloque.DefaultCell.Border = Rectangle.NO_BORDER;

            // --- Fila 1: Añadimos el Logo (Se centrará automáticamente) ---
            PdfPCell celdaImagen = new PdfPCell(logo);
            celdaImagen.Border = Rectangle.NO_BORDER;
            celdaImagen.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaLogoBloque.AddCell(celdaImagen);

            // --- Fila 2: Añadimos el Texto en dos líneas compactas y perfectamente centradas ---
            // Usamos HELVETICA con tamaño 7.5f para lograr la tipografía fina y prolija de la imagen
            var fuenteMembrete = FontFactory.GetFont(FontFactory.HELVETICA, 7.5f, BaseColor.BLACK);
            Paragraph textoInstitucional = new Paragraph("SERVICIO PENITENCIARIO DE LA\nPROVINCIA DE SALTA", fuenteMembrete);

            textoInstitucional.Leading = 9f; // Mantiene las dos líneas bien juntas
            textoInstitucional.Alignment = Element.ALIGN_CENTER; // Centra el texto con respecto al logo

            PdfPCell celdaTextoCentrado = new PdfPCell(textoInstitucional);
            celdaTextoCentrado.Border = Rectangle.NO_BORDER;
            celdaTextoCentrado.HorizontalAlignment = Element.ALIGN_CENTER;
            celdaTextoCentrado.PaddingTop = 5f; // Separación justa entre el pie del escudo y las letras

            tablaLogoBloque.AddCell(celdaTextoCentrado);

            // 5. Agregamos el bloque unificado al documento
            doc.Add(tablaLogoBloque);

            // Un espacio controlado antes de que empiece la fecha
            doc.Add(new Paragraph(" ") { Leading = 5f });
            // =========================================================================

           
            //FIN UBICACION: ENCABEZADO CON LOGOTIPO
            // =========================================================================


            doc.Add(new Paragraph(" "));

            // 1. Fecha a la Derecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(fechaCompleta, fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });

            // 2. Línea Horizontal Separadora debajo de la fecha
            doc.Add(new Paragraph(" "));
            iTextSharp.text.pdf.draw.LineSeparator lineaSeparadora = new iTextSharp.text.pdf.draw.LineSeparator(1f, 100f, BaseColor.BLACK, Element.ALIGN_CENTER, 0);
            doc.Add(lineaSeparadora);
            doc.Add(new Paragraph(" "));

            // 3. Título Centrado "Nota de Pedido" justo abajo de la línea
            Paragraph titulo = new Paragraph("Nota de Pedido", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);
            doc.Add(new Paragraph(" "));

            // Cálculo matemático previo del precio estimado
            decimal precio_estimado = 0;
            foreach (DataRow filaDetalle in dDetallexPedido.Rows)
            {
                decimal preciounitario = Convert.ToDecimal(filaDetalle["cantidad"]) * Convert.ToDecimal(filaDetalle["precio"]);
                precio_estimado = precio_estimado + preciounitario;
            }

            // 4. Creación y llenado de la Tabla Principal de Productos
            PdfPTable tablaVinculos = new PdfPTable(6);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 0.5f, 0.5f, 0.5f, 2.2f, 0.8f, 0.8f });
            tablaVinculos.AddCell("Renglón");
            tablaVinculos.AddCell("Cantidad");
            tablaVinculos.AddCell("U.Medida");
            tablaVinculos.AddCell("Concepto");
            tablaVinculos.AddCell("Precio Unitario");
            tablaVinculos.AddCell("Subtotal");

            foreach (DataRow fila in dDetallexPedido.Rows)
            {
                tablaVinculos.AddCell(fila["renglon"].ToString());
                tablaVinculos.AddCell(fila["cantidad"].ToString());
                tablaVinculos.AddCell(fila["medida"].ToString());
                tablaVinculos.AddCell(fila["detalle"].ToString());
                tablaVinculos.AddCell(fila["precio"].ToString());

                decimal totalFila = Convert.ToDecimal(fila["cantidad"]) * Convert.ToDecimal(fila["precio"]);
                tablaVinculos.AddCell(totalFila.ToString("F2"));
            }

            // Añadimos la tabla de productos al documento
            doc.Add(tablaVinculos);

            // =========================================================================
            // EL BLOQUE INFERIOR DE DATOS SE MANTIENE DEBAJO DE LA TABLA (CORREGIDO)
            // =========================================================================
            PdfPTable tablaDatosInferior = new PdfPTable(2);
            tablaDatosInferior.WidthPercentage = 100;
            tablaDatosInferior.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaDatosInferior.SpacingBefore = 15f;

            // 1. PORCIÓN DE CÓDIGO 1: Cambiamos a 55% y 45% para dar más ancho al precio
            float[] anchosColumnasInferior = new float[] { 55f, 45f };
            tablaDatosInferior.SetWidths(anchosColumnasInferior);

            // Celda Izquierda: Datos del Pedido agrupados limpiamente
            Paragraph datosPedido = new Paragraph();
            datosPedido.Add(new Chunk("Carácter de la Compra: " + reportes.Caracter_pedido + "\n", fuenteNormal));
            datosPedido.Add(new Chunk("Origen del Pedido: " + reportes.Sector + "\n", fuenteNormal));
            datosPedido.Add(new Chunk("Destino: " + reportes.Destino, fuenteNormal));

            PdfPCell celdaIzquierda = new PdfPCell(datosPedido);
            celdaIzquierda.Border = Rectangle.NO_BORDER;
            celdaIzquierda.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaDatosInferior.AddCell(celdaIzquierda);

            // 2. PORCIÓN DE CÓDIGO 2: Agregamos el signo '$' y activamos el 'NoWrap'
            PdfPCell celdaDerechaPrecio = new PdfPCell(new Paragraph("Precio Total Estimado: $" + precio_estimado.ToString("F2"), fuenteNormal));
            celdaDerechaPrecio.Border = Rectangle.NO_BORDER;
            celdaDerechaPrecio.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaDerechaPrecio.VerticalAlignment = Element.ALIGN_TOP;

            // Forzamos a iTextSharp a mantener todo el precio estrictamente en una sola fila
            celdaDerechaPrecio.NoWrap = true;

            tablaDatosInferior.AddCell(celdaDerechaPrecio);

            // Agregamos la estructura inferior debajo de la tabla principal
            doc.Add(tablaDatosInferior);
            // =========================================================================

            // =========================================================================
            // NUEVO BLOQUE: EXTRACTO AL PIE DEL REPORTE
            // =========================================================================
            if (!string.IsNullOrWhiteSpace(reportes.Extracto))
            {
                Paragraph parrafoExtracto = new Paragraph();
                parrafoExtracto.SpacingBefore = 15f; // Separación prolija debajo de Carácter/Origen/Destino
                parrafoExtracto.Alignment = Element.ALIGN_JUSTIFIED; // Alineación justificada por si el extracto es largo

                // Etiqueta en negrita + contenido en fuente normal
                var fuenteNegrita = FontFactory.GetFont(FontFactory.TIMES_BOLD, 12, BaseColor.BLACK);
                parrafoExtracto.Add(new Chunk("Extracto: ", fuenteNegrita));
                parrafoExtracto.Add(new Chunk(reportes.Extracto, fuenteNormal));

                doc.Add(parrafoExtracto);
            }
            // =========================================================================


            doc.Close();
            return ms;
            

        }

        // =========================================================================
        // AQUÍ DEBAJO PEGAS EL MÉTODO NUEVO ExportarPedidoExcel
        // =========================================================================
        public static void ExportarPedidoExcel(DataTable pedidox, DataTable dDetallexPedido)
        {
            string caracterPedido = "";
            string sectorOrigen = "";
            string sectorDestino = "";
            string numTransaccion = "0";
            string extracto = ""; // <-- Agregamos esta variable

            if (pedidox.Rows.Count > 0)
            {
                DataRow row = pedidox.Rows[0];
                numTransaccion = row["Num_transaccion"].ToString();
                sectorDestino = row["Sector_destino"].ToString();
                sectorOrigen = row["Sectores_internos"].ToString();
                caracterPedido = row["Caracter_pedido"].ToString();
                extracto = row["Extracto"].ToString(); // <-- 2. Lee el dato desde la consulta
            }

            // Abrimos cuadro de diálogo para que el usuario elija dónde guardar el Excel
            SaveFileDialog guardarDialogo = new SaveFileDialog();
            guardarDialogo.Filter = "Archivo de Excel (*.xls)|*.xls";
            guardarDialogo.Title = "Exportar Nota de Pedido a Excel";
            guardarDialogo.FileName = $"Nota_Pedido_{numTransaccion}_{DateTime.Now:yyyyMMdd}.xls";

            if (guardarDialogo.ShowDialog() != DialogResult.OK)
                return;

            CultureInfo cultura = new CultureInfo("es-ES");
            string fechaCompleta = "Salta, " + DateTime.Now.ToString("d 'de' MMMM 'de' yyyy", cultura);

            decimal precioEstimado = 0;
            StringBuilder sb = new StringBuilder();

            // Estructura HTML nativa para Microsoft Excel con estilos idénticos a tu PDF
            sb.AppendLine("<html xmlns:o='urn:schemas-microsoft-com:office:office' xmlns:x='urn:schemas-microsoft-com:office:excel' xmlns='http://w3.org'>");
            sb.AppendLine("<head><meta charset='utf-8'>");
            sb.AppendLine("<style>");
            sb.AppendLine("body { font-family: 'Times New Roman', serif; font-size: 12pt; }");
            sb.AppendLine(".membrete { font-family: Arial, sans-serif; font-size: 8pt; font-weight: bold; text-align: center; }");
            sb.AppendLine(".fecha { text-align: right; font-size: 11pt; }");
            sb.AppendLine(".titulo { text-align: center; font-size: 14pt; font-weight: bold; text-decoration: underline; }");
            sb.AppendLine(".tabla-detalles { border-collapse: collapse; width: 100%; }");
            sb.AppendLine(".tabla-detalles th, .tabla-detalles td { border: 1px solid #000000; padding: 6px; }");
            sb.AppendLine(".tabla-detalles th { background-color: #E8ECEF; font-weight: bold; text-align: center; }");
            sb.AppendLine(".num { text-align: center; }");
            sb.AppendLine(".moneda { text-align: right; mso-number-format:'\"$\"#,##0.00'; }");
            sb.AppendLine(".pie-izq { text-align: left; vertical-align: top; border: none; }");
            sb.AppendLine(".pie-der { text-align: right; vertical-align: top; font-weight: bold; border: none; }");
            sb.AppendLine("</style></head><body>");

            // 1. Membrete Institucional (Columna A y B combinadas a la izquierda)
            sb.AppendLine("<table>");
            sb.AppendLine("<tr><td colspan='2' class='membrete'>SERVICIO PENITENCIARIO DE LA<br/>PROVINCIA DE SALTA</td><td colspan='3'></td></tr>");
            sb.AppendLine("<tr><td colspan='5'></td></tr>");

            // 2. Fecha alineada a la derecha
            sb.AppendLine($"<tr><td colspan='5' class='fecha'>{fechaCompleta}</td></tr>");
            sb.AppendLine("<tr><td colspan='5' style='border-bottom: 1px solid #000000;'></td></tr>");
            sb.AppendLine("<tr><td colspan='5'></td></tr>");

            // 3. Título centrado "Nota de Pedido"
            sb.AppendLine("<tr><td colspan='5' class='titulo'>Nota de Pedido</td></tr>");
            sb.AppendLine("<tr><td colspan='5'></td></tr>");
            sb.AppendLine("</table>");

            // 4. Tabla Principal de 5 Columnas (idéntica al PDF)
            sb.AppendLine("<table class='tabla-detalles'>");
            sb.AppendLine("<tr>");
            sb.AppendLine("<th style='width: 70px;'>Renglón</th>");
            sb.AppendLine("<th style='width: 80px;'>Cantidad</th>");
            sb.AppendLine("<th style='width: 350px;'>Concepto</th>");
            sb.AppendLine("<th style='width: 120px;'>Precio Unitario</th>");
            sb.AppendLine("<th style='width: 120px;'>Subtotal</th>");
            sb.AppendLine("</tr>");

            foreach (DataRow fila in dDetallexPedido.Rows)
            {
                int renglon = Convert.ToInt32(fila["renglon"]);
                int cantidad = Convert.ToInt32(fila["cantidad"]);
                string concepto = fila["detalle"].ToString();
                decimal precioUnitario = Convert.ToDecimal(fila["precio"]);
                decimal totalFila = cantidad * precioUnitario;

                precioEstimado += totalFila;

                sb.AppendLine("<tr>");
                sb.AppendLine($"<td class='num'>{renglon}</td>");
                sb.AppendLine($"<td class='num'>{cantidad}</td>");
                sb.AppendLine($"<td>{concepto}</td>");
                sb.AppendLine($"<td class='moneda'>{precioUnitario.ToString("F2", CultureInfo.InvariantCulture)}</td>");
                sb.AppendLine($"<td class='moneda'>{totalFila.ToString("F2", CultureInfo.InvariantCulture)}</td>");
                sb.AppendLine("</tr>");
            }
            sb.AppendLine("</table>");

            // 5. Bloque Inferior de Datos (Carácter, Origen, Destino, Total Estimado y Extracto)
            sb.AppendLine("<br/><table>");
            sb.AppendLine("<tr>");
            sb.AppendLine($"<td colspan='3' class='pie-izq'><b>Carácter de la Compra:</b> {caracterPedido}<br/>");
            sb.AppendLine($"<b>Origen del Pedido:</b> {sectorOrigen}<br/>");
            sb.AppendLine($"<b>Destino:</b> {sectorDestino}</td>");
            sb.AppendLine($"<td colspan='2' class='pie-der'>Precio Total Estimado: $ {precioEstimado.ToString("N2")}</td>");
            sb.AppendLine("</tr>");

            // =========================================================================
            // NUEVO: Extracto al pie del Excel (igual que en el PDF)
            // =========================================================================
            if (!string.IsNullOrWhiteSpace(extracto))
            {
                sb.AppendLine("<tr><td colspan='5'></td></tr>");
                sb.AppendLine($"<tr><td colspan='5' style='text-align: left; border: none;'><b>Extracto:</b> {extracto}</td></tr>");
            }
            // =========================================================================

            sb.AppendLine("</table>");

            sb.AppendLine("</body></html>");

            // Guardamos con UTF8 con BOM para que Excel reconozca acentos y la letra ñ perfectamente
            File.WriteAllText(guardarDialogo.FileName, sb.ToString(), new UTF8Encoding(true));

            DialogResult abrir = MessageBox.Show("Archivo Excel generado con éxito.\n¿Desea abrirlo ahora?", "Exportación Completada", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (abrir == DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(guardarDialogo.FileName);
            }
        }


    }
}
