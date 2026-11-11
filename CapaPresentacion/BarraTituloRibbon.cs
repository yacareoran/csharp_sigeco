using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public class BarraTituloRibbon : Panel
    {
        // Declaramos los 3 botones de control de ventana
        private Button btnMinimizar;
        private Button btnMaximizar;
        private Button btnCerrar;

        // Propiedad privada para controlar la visibilidad del botón Maximizar
        private bool _mostrarMaximizar = true;

        // Propiedad pública que aparecerá en la ventana de Propiedades del Diseñador
        [System.ComponentModel.Category("Apariencia Barra")]
        [System.ComponentModel.Description("Indica si se muestra el botón de Maximizar/Restaurar.")]
        [System.ComponentModel.DefaultValue(true)]
        public bool MostrarMaximizar
        {
            get { return _mostrarMaximizar; }
            set
            {
                _mostrarMaximizar = value;
                if (btnMaximizar != null)
                {
                    btnMaximizar.Visible = _mostrarMaximizar;
                    PosicionarBotones();
                }
            }
        }

        public BarraTituloRibbon()
        {
            this.DoubleBuffered = true;
            this.Dock = DockStyle.Top;
            this.Height = 58;

            InicializarBotonesControl();
        }

        private void InicializarBotonesControl()
        {
            Color colorFondoBarra = Color.FromArgb(193, 216, 251);
            Color colorIcono = Color.FromArgb(45, 65, 95);

            // 1. Botón Cerrar (X)
            btnCerrar = CrearBotonBarra("✕", colorFondoBarra, colorIcono, Color.FromArgb(232, 17, 35), Color.White);
            btnCerrar.Click += (s, e) =>
            {
                Form frm = this.FindForm();
                if (frm != null) frm.Close();
            };

            // 2. Botón Maximizar / Restaurar (□)
            btnMaximizar = CrearBotonBarra("□", colorFondoBarra, colorIcono, Color.FromArgb(165, 195, 240), colorIcono);
            btnMaximizar.Click += (s, e) =>
            {
                Form frm = this.FindForm();
                if (frm != null)
                {
                    if (frm.WindowState == FormWindowState.Maximized)
                    {
                        frm.WindowState = FormWindowState.Normal;
                        btnMaximizar.Text = "□";
                    }
                    else
                    {
                        frm.WindowState = FormWindowState.Maximized;
                        btnMaximizar.Text = "❐";
                    }
                }
            };

            // 3. Botón Minimizar (—)
            btnMinimizar = CrearBotonBarra("—", colorFondoBarra, colorIcono, Color.FromArgb(165, 195, 240), colorIcono);
            btnMinimizar.Click += (s, e) =>
            {
                Form frm = this.FindForm();
                if (frm != null) frm.WindowState = FormWindowState.Minimized;
            };

            this.Controls.Add(btnCerrar);
            this.Controls.Add(btnMaximizar);
            this.Controls.Add(btnMinimizar);

            PosicionarBotones();
        }

        private Button CrearBotonBarra(string texto, Color fondoNormal, Color textoNormal, Color fondoHover, Color textoHover)
        {
            Button btn = new Button();
            btn.Text = texto;
            btn.Size = new Size(36, 35);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = fondoNormal;
            btn.ForeColor = textoNormal;
            btn.Font = new Font("Segoe UI", 9.5f, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;
            btn.TabStop = false;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = fondoHover;
                btn.ForeColor = textoHover;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = fondoNormal;
                btn.ForeColor = textoNormal;
            };

            return btn;
        }

        private void PosicionarBotones()
        {
            if (btnCerrar == null || btnMaximizar == null || btnMinimizar == null) return;

            // El botón Cerrar siempre va pegado al borde derecho
            btnCerrar.Location = new Point(this.Width - btnCerrar.Width, 0);

            if (_mostrarMaximizar)
            {
                // Muestra los tres botones: [ — ] [ □ ] [ ✕ ]
                btnMaximizar.Visible = true;
                btnMaximizar.Location = new Point(this.Width - (btnCerrar.Width * 2), 0);
                btnMinimizar.Location = new Point(this.Width - (btnCerrar.Width * 3), 0);
            }
            else
            {
                // Oculta Maximizar y corre Minimizar al lado de Cerrar: [ — ] [ ✕ ]
                btnMaximizar.Visible = false;
                btnMinimizar.Location = new Point(this.Width - (btnCerrar.Width * 2), 0);
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            if (this.Height != 58)
            {
                this.Height = 58;
            }
            PosicionarBotones();
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Color colorFondoAzul = Color.FromArgb(193, 216, 251);
            Color colorBordeGris = Color.FromArgb(160, 180, 210);

            int diametroBoton = 48;
            int botonX = 14;
            int botonY = 2;
            int altoBarra = 36;

            int margenCurva = 3;
            int diametroArco = diametroBoton + (margenCurva * 2);
            int arcoX = botonX - margenCurva;
            int arcoY = botonY - margenCurva;

            double radioArco = diametroArco / 2.0;
            double centroArcoY = arcoY + radioArco;
            double dy = altoBarra - centroArcoY;

            float anguloCruce = (float)(Math.Asin(dy / radioArco) * (180.0 / Math.PI));
            float anguloInicio = anguloCruce;
            float barridoAngulo = 180f - (2f * anguloCruce);

            GraphicsPath pathBarra = new GraphicsPath();
            pathBarra.AddLine(0, 0, this.Width, 0);
            pathBarra.AddLine(this.Width, 0, this.Width, altoBarra);
            pathBarra.AddArc(arcoX, arcoY, diametroArco, diametroArco, anguloInicio, barridoAngulo);
            pathBarra.AddLine(0, altoBarra, 0, 0);
            pathBarra.CloseFigure();

            this.Region = new Region(pathBarra);

            using (SolidBrush brushAzul = new SolidBrush(colorFondoAzul))
            {
                g.FillPath(brushAzul, pathBarra);
            }

            using (Pen penBorde = new Pen(colorBordeGris, 1.3f))
            {
                float puntoUnionDerX = (float)(arcoX + radioArco + radioArco * Math.Cos(anguloInicio * Math.PI / 180.0));
                float puntoUnionIzqX = (float)(arcoX + radioArco - radioArco * Math.Cos(anguloInicio * Math.PI / 180.0));

                g.DrawLine(penBorde, this.Width, altoBarra, puntoUnionDerX, altoBarra);
                g.DrawArc(penBorde, arcoX, arcoY, diametroArco, diametroArco, anguloInicio, barridoAngulo);
                g.DrawLine(penBorde, puntoUnionIzqX, altoBarra, 0, altoBarra);
            }

            string textoTitulo = "SGC Nuevo Sistema SIGECO";
            using (System.Drawing.Font fuenteTitulo = new System.Drawing.Font("Segoe UI", 10.5f, FontStyle.Bold))
            using (SolidBrush brushTexto = new SolidBrush(Color.FromArgb(45, 65, 95)))
            {
                StringFormat formatoCentrado = new StringFormat();
                formatoCentrado.Alignment = StringAlignment.Center;
                formatoCentrado.LineAlignment = StringAlignment.Center;

                Rectangle rectanguloBarra = new Rectangle(0, 0, this.Width, altoBarra);
                g.DrawString(textoTitulo, fuenteTitulo, brushTexto, rectanguloBarra, formatoCentrado);
            }

            using (LinearGradientBrush gradienteBoton = new LinearGradientBrush(
                new Point(botonX, botonY),
                new Point(botonX, botonY + diametroBoton),
                Color.FromArgb(240, 248, 255),
                Color.FromArgb(70, 130, 180)))
            {
                g.FillEllipse(gradienteBoton, botonX, botonY, diametroBoton, diametroBoton);
            }

            using (Pen penBotonMarco = new Pen(Color.FromArgb(140, 160, 190), 1.5f))
            {
                g.DrawEllipse(penBotonMarco, botonX, botonY, diametroBoton, diametroBoton);
            }

            string rutaLogo = Path.Combine(Application.StartupPath, "Resources", "Img-reportes", "logo_spps2.png");
            if (File.Exists(rutaLogo))
            {
                using (System.Drawing.Image imgLogo = System.Drawing.Image.FromFile(rutaLogo))
                {
                    int tamLogo = 46;
                    int logoX = botonX + (diametroBoton / 2) - (tamLogo / 2);
                    int logoY = botonY + (diametroBoton / 2) - (tamLogo / 2);
                    g.DrawImage(imgLogo, logoX, logoY, tamLogo, tamLogo);
                }
            }
        }

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
