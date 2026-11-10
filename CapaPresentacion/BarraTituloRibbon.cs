using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class BarraTituloRibbon : Panel
    {
        public BarraTituloRibbon()
        {
            this.DoubleBuffered = true; // Evita el parpadeo de gráficos
            this.Dock = DockStyle.Top;
            this.Height = 45; // Alto de la barra superior
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias; // Bordes suaves de alta calidad

            // 1. Paleta de colores oficial CrossChex
            Color colorFondoAzul = Color.FromArgb(193, 216, 251);
            Color colorBordeGris = Color.FromArgb(160, 180, 210);

            int altoBarraAzul = 36;

            // 2. Pintamos la barra de fondo azul base completo (Ahora limpia sin rectángulo blanco)
            using (SolidBrush brushAzul = new SolidBrush(colorFondoAzul))
            {
                g.FillRectangle(brushAzul, 0, 0, this.Width, this.Height);
            }

            // =========================================================================
            // 3. DIBUJO DE LÍNEAS DIVISORIAS METÁLICAS
            // =========================================================================
            //using (Pen penBorde = new Pen(colorBordeGris, 1f))
            //{
            // Línea horizontal gris que cruza limpia toda la pantalla
            //    g.DrawLine(penBorde, 0, altoBarraAzul, this.Width, altoBarraAzul);

            // Línea inferior de cierre de toda la barra de herramientas (al ras del panel)
            //    g.DrawLine(penBorde, 0, this.Height - 1, this.Width, this.Height - 1);
            //}

            // =========================================================================
            // 3. DIBUJO DE LÍNEA DIVISORIA METÁLICA (RETOQUE DE BORDE LIMPIO)
            // =========================================================================
            using (Pen penBorde = new Pen(colorBordeGris, 1f))
            {
                // Pintamos una única línea horizontal metálica sólida justo en el borde inferior del panel
                // Usamos (this.Height - 1) para que tape cualquier imperfección con el fondo del formulario
                g.DrawLine(penBorde, 0, this.Height - 1, this.Width, this.Height - 1);
            }

            // =========================================================================
            // NUEVO RECUADRO: RENDERIZADO DEL TÍTULO CENTRAL DEL SISTEMA
            // =========================================================================
            string textoTitulo = "CGC Nuevo Sistema SIGECO";

            // Usamos Segoe UI Bold tamaño 10.5 para una estética moderna y limpia
            using (System.Drawing.Font fuenteTitulo = new System.Drawing.Font("Segoe UI", 10.5f, FontStyle.Bold))
            // Usamos un color azul oscuro corporativo para un contraste óptimo con el fondo celeste
            using (SolidBrush brushTexto = new SolidBrush(Color.FromArgb(45, 65, 95)))
            {
                StringFormat formatoCentrado = new StringFormat();
                formatoCentrado.Alignment = StringAlignment.Center;     // Centrado horizontal
                formatoCentrado.LineAlignment = StringAlignment.Center;  // Centrado vertical

                // Creamos el contenedor que ocupa toda la extensión útil de la barra azul
                Rectangle rectanguloBarra = new Rectangle(0, 0, this.Width, altoBarraAzul);

                // Dibujamos el texto matemáticamente en el medio de la pantalla
                g.DrawString(textoTitulo, fuenteTitulo, brushTexto, rectanguloBarra, formatoCentrado);
            }
            // =========================================================================

            // =========================================================================
            // 4. RETOQUE 1: BOTÓN CIRCULAR PRINCIPAL AGRANDADO
            // =========================================================================
            int diametroBoton = 48;
            int botonX = 15;
            int botonY = (this.Height / 2) - (diametroBoton / 2) - 1; // Ajuste de centrado vertical

            // Dibujamos el círculo base con degradado azul metálico
            using (LinearGradientBrush gradienteBoton = new LinearGradientBrush(
                new Point(botonX, botonY),
                new Point(botonX, botonY + diametroBoton),
                Color.FromArgb(240, 248, 255), // Brillo blanco/azul superior
                Color.FromArgb(70, 130, 180)))  // Azul acero inferior
            {
                g.FillEllipse(gradienteBoton, botonX, botonY, diametroBoton, diametroBoton);
            }

            // Dibujamos el contorno doble del botón circular para darle efecto 3D
            using (Pen penBotonMarcor = new Pen(Color.FromArgb(140, 160, 190), 1.5f))
            {
                g.DrawEllipse(penBotonMarcor, botonX, botonY, diametroBoton, diametroBoton);
            }

            // =========================================================================
            // 5. RENDERIZADO DEL LOGOTIPO MÁS GRANDE (Con transparencia)
            // =========================================================================
            string rutaLogo = Path.Combine(Application.StartupPath, "Resources", "Img-reportes", "logo_spps2.png");

            if (File.Exists(rutaLogo))
            {
                using (System.Drawing.Image imgLogo = System.Drawing.Image.FromFile(rutaLogo))
                {
                    int tamLogo = 34;
                    int logoX = botonX + (diametroBoton / 2) - (tamLogo / 2);
                    int logoY = botonY + (diametroBoton / 2) - (tamLogo / 2);

                    g.DrawImage(imgLogo, logoX, logoY, tamLogo, tamLogo);
                }
            }
        }

        // Permitir arrastrar el formulario libremente haciendo clic en la barra azul
        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButtons.Left)
            {
                Capture = false;
                Message msg = Message.Create(this.FindForm().Handle, 0xA1, new IntPtr(2), IntPtr.Zero);
                base.WndProc(ref msg);
            }
        }
    }
}

