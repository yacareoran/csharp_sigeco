using CapaDatos;
//using CommonCache;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Printing;
//using System.Drawing;
using System.Xml.Linq;
using System.Data;

namespace CapaPresentacion.Reporte.Formulario_Pedido
{
    public class ReporteImprimirPedido
    {//inicio clase
        //VINCULOS DE LA VISITA         
        //public static MemoryStream RepPdfInternosVinculados(DPedido pedidox, List<DVisitaInterno> listaVinculos)
        public static MemoryStream RepPdfInternosVinculados(ImprimirPedido imprimirPedidox,  DataTable pedidox, DataTable dDetallexPedido)
        {
            DPedido pedido = new DPedido();
            DReportes reportes = new DReportes();

            
            /*if (pedidox.Rows.Count > 0)
            {
                DataRow row = pedidox.Rows[0];
                               

                pedido.Id_pedido = Convert.ToInt32(row["Id_pedido"]);
                pedido.Pedido = row["Pedido"].ToString();
                pedido.Fecha_pedido = Convert.ToDateTime(row["Fecha_pedido"]);
                //pedido.Num_seguimiento = Convert.ToInt32(row["Num_seguimiento"]);
                pedido.Usuario_id = Convert.ToInt32(row["Usuario_id"]);
                pedido.Num_transaccion = Convert.ToInt32(row["Num_transaccion"]);
                pedido.Caracter_pedido_id = Convert.ToInt32(row["Caracter_pedido_id"]);
                //pedido.Estado_pedido_id = Convert.ToInt32(row["Estado_pedido_id"]);
                pedido.Destino_id = Convert.ToInt32(row["Destino_id"]);
                //pedido.Emisor_id = Convert.ToInt32(row["Emisor_id"]);
                pedido.Origen_id = Convert.ToInt32(row["Origen_id"]);
                pedido.Extracto = row["Extracto"].ToString();
                //pedido.Expediente_interno = row["Expediente_interno"].ToString();
                //pedido.Expediente_externo = row["Expediente_externo"].ToString();
                //pedido.Numero_nota = row["Numero_nota"].ToString();
                pedido.Sector = row["Sector"].ToString();
                pedido.Caracter_pedido = row["Caracter_pedido"].ToString();
                //pedido.Estado_id = Convert.ToInt32(row["Estado_id"]);
                //pedido.Origen = row["Origen"].ToString();
                pedido.Estado = row["Estado"].ToString();
                //pedido.Costo_total = Convert.ToDecimal(row["Costo_total"]);

            }*/



            if (pedidox.Rows.Count > 0)
            {
                DataRow row = pedidox.Rows[0];


                reportes.Id_pedido = Convert.ToInt32(row["Id_pedido"]);
                reportes.Pedido = row["Pedido"].ToString();
                reportes.Fecha_pedido = Convert.ToDateTime(row["Fecha_pedido"]);
                //pedido.Num_seguimiento = Convert.ToInt32(row["Num_seguimiento"]);
                reportes.Usuario_id = Convert.ToInt32(row["Usuario_id"]);
                reportes.Num_transaccion = Convert.ToInt32(row["Num_transaccion"]);
                reportes.Caracter_pedido_id = Convert.ToInt32(row["Caracter_pedido_id"]);
                //pedido.Estado_pedido_id = Convert.ToInt32(row["Estado_pedido_id"]);
                //reportes.Destino_id = Convert.ToInt32(row["Sector_id"]);
                //pedido.Emisor_id = Convert.ToInt32(row["Emisor_id"]);
                //reportes.Origen_id = Convert.ToInt32(row["Origen_id"]);
                reportes.Extracto = row["Extracto"].ToString();
                //pedido.Expediente_interno = row["Expediente_interno"].ToString();
                //pedido.Expediente_externo = row["Expediente_externo"].ToString();
                //pedido.Numero_nota = row["Numero_nota"].ToString();
                reportes.Sector = row["Sector"].ToString();
                reportes.Caracter_pedido = row["Caracter_pedido"].ToString();
                //pedido.Estado_id = Convert.ToInt32(row["Estado_id"]);
                //pedido.Origen = row["Origen"].ToString();
                reportes.Estado = row["Estado"].ToString();
                reportes.Origen = row["Origen"].ToString();
                //pedido.Costo_total = Convert.ToDecimal(row["Costo_total"]);

            }


            MemoryStream ms = new MemoryStream();
            Document doc = new Document(PageSize.A4, 50, 50, 50, 50);

            PdfWriter writer = PdfWriter.GetInstance(doc, ms);
            writer.CloseStream = false; // evita cerrar el MemoryStream al cerrar el documento

            doc.Open();

            var fuenteLogo = FontFactory.GetFont(FontFactory.TIMES, 9, BaseColor.BLACK);
            var fuenteOrganismo = FontFactory.GetFont(FontFactory.TIMES, 10, BaseColor.BLACK);
            var fuenteTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12, BaseColor.BLACK);
            var fuenteNormal = FontFactory.GetFont(FontFactory.HELVETICA, 11, BaseColor.BLACK);

            //logo encabezado
            //string rutaImagen = Path.Combine(Application.StartupPath, "Resources/Img-reportes/", "logo_spps2.png");
            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(rutaImagen);

            // Cargar directamente desde Resources
            //System.Drawing.Image logoImg = Properties.Resources.logo_spps2;
            // Convertir a iTextSharp Image
            //iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(logoImg, System.Drawing.Imaging.ImageFormat.Png);
            //string organismo = CurrentUser.Instance.organismo.ToUpper();
            //logo.ScaleAbsolute(40, 40);
            //logo.SetAbsolutePosition(150, 770);
            //doc.Add(logo);
            doc.Add(new Paragraph(" "));

            // Crear tabla con 1 columnas
            PdfPTable tablaEncabezado = new PdfPTable(1);
            tablaEncabezado.WidthPercentage = 50; // ocupa la mitad de la página
            tablaEncabezado.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda

            // Centrar contenido de todas las celdas
            tablaEncabezado.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;
            tablaEncabezado.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaEncabezado.DefaultCell.Border = Rectangle.NO_BORDER;

            // Agregar celdas
            tablaEncabezado.AddCell(new Paragraph("  SERVICIO PENITENCIARIO DE LA PROVINCIA DE SALTA", fuenteLogo));
            //tablaEncabezado.AddCell(new Paragraph(organismo, fuenteOrganismo));

            // Agregar tabla al documento
            doc.Add(tablaEncabezado);
            //fin logo encabezado.....................................

            //fecha
            DateTime fechaHoy = DateTime.Now;
            CultureInfo cultura = new CultureInfo("es-ES");

            // "d 'de' MMMM 'de' yyyy" → ejemplo: "9 de septiembre de 2025"
            string fechaCompleta = "Salta, " + fechaHoy.ToString("d 'de' MMMM 'de' yyyy", cultura);

            doc.Add(new Paragraph(" "));
            doc.Add(new Paragraph(fechaCompleta, fuenteNormal)
            {
                Alignment = Element.ALIGN_RIGHT
            });
            //fin fecha.............................

            doc.Add(new Paragraph(" "));

            decimal precio_estimado = 0;
            foreach (DataRow filaDetalle in dDetallexPedido.Rows)
            {
                // Acceder por nombre de columna
                //string valor = fila["NombreColumna"].ToString();

                // O acceder por índice
                // var valor = fila[0];
                decimal preciounitario = Convert.ToDecimal(filaDetalle["cantidad"]) * Convert.ToDecimal(filaDetalle["precio"]);

                precio_estimado = precio_estimado + preciounitario;
                //Console.WriteLine(valor);
            }
            //datos ciudadano
            //doc.Add(new Paragraph(" Carácter de la Compra: " + pedido.Num_transaccion + " " + pedido.Anio_actual, fuenteNormal));
            //doc.Add(new Paragraph(" Apellido y nombre: " + listaPedidos.Num_transaccion + " " + pedidox.Pedido, fuenteNormal));
            doc.Add(new Paragraph(" Carácter de la Compra: " + reportes.Caracter_pedido, fuenteNormal));
            //doc.Add(new Paragraph(" DNI: " + pedidox.Sector, fuenteNormal));
            doc.Add(new Paragraph(" Origen del Pedido: " + reportes.Sector, fuenteNormal));
            PdfPTable tablaDatos = new PdfPTable(2);
            tablaDatos.WidthPercentage = 60;
            tablaDatos.HorizontalAlignment = Element.ALIGN_LEFT; // tabla a la izquierda
            tablaDatos.DefaultCell.Border = Rectangle.NO_BORDER;
            tablaDatos.AddCell(new Paragraph("Destino: " + reportes.Destino_id, fuenteNormal));
            tablaDatos.AddCell(new Paragraph("Precio Estimado: " + precio_estimado, fuenteNormal));
            doc.Add(tablaDatos);
            //fin datos ciudadano


            doc.Add(new Paragraph(" "));

            Paragraph titulo = new Paragraph("Nota de Pedido", fuenteTitulo);
            titulo.Alignment = Element.ALIGN_CENTER;
            doc.Add(titulo);


            doc.Add(new Paragraph(" "));

            PdfPTable tablaVinculos = new PdfPTable(5);
            tablaVinculos.WidthPercentage = 100;
            tablaVinculos.SetWidths(new float[] { 0.6f, 0.6f, 2.2f, 0.8f, 0.8f });
            tablaVinculos.AddCell("Renglón");
            tablaVinculos.AddCell("Cantidad");
            tablaVinculos.AddCell("Concepto");
            tablaVinculos.AddCell("Precio Unitario");
            tablaVinculos.AddCell("Precio Total");

            // Filas dinámicas
            //foreach (var vinculo in listaVinculos)
            //foreach (var vinculo in listaPedidos)
            //{
            /*tablaVinculos.AddCell(new Paragraph(vinculo.interno.apellido.ToString() + " " + vinculo.interno.nombre.ToString(), fuenteNormal));
            tablaVinculos.AddCell(new Paragraph(vinculo.parentesco.parentesco, fuenteNormal));
            tablaVinculos.AddCell(new Paragraph(vinculo.interno.organismo.organismo.ToString(), fuenteNormal));
            tablaVinculos.AddCell(new Paragraph(vinculo.vigente ? "SI" : "NO", fuenteNormal));*/
            //}
            
            // Ejemplo de recorrido de DataTable
            foreach (DataRow fila in dDetallexPedido.Rows)
            {
                // Acceder por nombre de columna
                //string valor = fila["NombreColumna"].ToString();

                // O acceder por índice
                // var valor = fila[0];
                tablaVinculos.AddCell(new Paragraph(fila["renglon"].ToString(), fuenteNormal));
                decimal preciounitario = Convert.ToDecimal(fila["cantidad"]) * Convert.ToDecimal(fila["precio"]);
                tablaVinculos.AddCell(new Paragraph(fila["cantidad"].ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(fila["detalle"].ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(fila["precio"].ToString().ToString(), fuenteNormal));
                tablaVinculos.AddCell(new Paragraph(preciounitario.ToString(), fuenteNormal));
                //precio_estimado = precio_estimado + preciounitario;
                //Console.WriteLine(valor);
            }




            doc.Add(tablaVinculos);

            doc.Close(); // Cierra el documento pero NO el MemoryStream
            ms.Position = 0;

            return ms;
        }

    }//fin clase
}



