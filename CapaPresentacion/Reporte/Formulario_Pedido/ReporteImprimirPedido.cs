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
{
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
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            doc.Add(new Paragraph(" "));

            // Encabezado del Servicio Penitenciario
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 50;
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT;
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaEncabezado.AddCell(new Paragraph("  SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA", fuenteLogo));
            doc.Add(tablaEncabezado);

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
            tablaVinculos.AddCell("Precio Total");

            foreach (DataRow fila in dDetallexPedido.Rows)
            {
                // Carga de celdas iterativas del grid de productos
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
            // NUEVA UBICACIÓN: EL BLOQUE INFERIOR DE DATOS SE PEGA JUSTO AQUÍ DEBAJO
            // =========================================================================
            PdfPTable tablaDatosInferior = new PdfPTable(2);
            tablaDatosInferior.WidthPercentage = 100;
            tablaDatosInferior.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaDatosInferior.SpacingBefore = 15f; // Espaciado con respecto a la tabla de productos

            float[] anchosColumnasInferior = new float[] { 65f, 35f };
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

            // Celda Derecha: Precio Estimado alineado al ras derecho
            PdfPCell celdaDerechaPrecio = new PdfPCell(new Paragraph("Precio Estimado: " + precio_estimado.ToString("F2"), fuenteNormal));
            celdaDerechaPrecio.Border = Rectangle.NO_BORDER;
            celdaDerechaPrecio.HorizontalAlignment = Element.ALIGN_RIGHT;
            celdaDerechaPrecio.VerticalAlignment = Element.ALIGN_TOP;
            tablaDatosInferior.AddCell(celdaDerechaPrecio);

            // Agregamos la estructura inferior debajo de la tabla principal
            doc.Add(tablaDatosInferior);
            // =========================================================================

            doc.Close();
            return ms;
        }
    }
}
