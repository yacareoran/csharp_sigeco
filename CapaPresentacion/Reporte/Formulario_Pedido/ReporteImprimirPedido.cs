using CapaDatos;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Data;
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
                reportes.Sector = row["Origen"].ToString();
                reportes.Caracter_pedido = row["Caracter_pedido"].ToString();
                reportes.Estado = row["Estado"].ToString();
                reportes.Origen = row["Origen"].ToString();
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
            // ENCABEZADO CON LOGOTIPO COMPAÑÍA (Texto debajo del Logo) - CORREGIDO Y LIMPIO
            // =========================================================================
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
            PdfPTable tablaVinculos = new PdfPTable(5);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 0.6f, 0.6f, 2.2f, 0.8f, 0.8f });
            tablaVinculos.AddCell("Renglón");
            tablaVinculos.AddCell("Cantidad");
            tablaVinculos.AddCell("Concepto");
            tablaVinculos.AddCell("Precio Unitario");
            tablaVinculos.AddCell("Subtotal");

            foreach (DataRow fila in dDetallexPedido.Rows)
            {
                tablaVinculos.AddCell(fila["renglon"].ToString());
                tablaVinculos.AddCell(fila["cantidad"].ToString());
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

            doc.Close();
            return ms;
        }
    }
}
