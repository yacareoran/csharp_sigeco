namespace CapaPresentacion
{
    partial class FrmCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnNotasPedido = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIngresarNotasPedido = new System.Windows.Forms.Button();
            this.btnModificarNotaPedido = new System.Windows.Forms.Button();
            this.btnSeguimientoPedidos = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnModificarPedidoCompras = new System.Windows.Forms.Button();
            this.btnModificarEncabezadoNotaPedido = new System.Windows.Forms.Button();
            this.btnNotasIngresadasModulo = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtSector = new System.Windows.Forms.TextBox();
            this.txtSectoresInternos = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtLegajoUsuario = new System.Windows.Forms.TextBox();
            this.btnGenerarExpediente = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNotasPedido
            // 
            this.btnNotasPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotasPedido.Location = new System.Drawing.Point(70, 2);
            this.btnNotasPedido.Name = "btnNotasPedido";
            this.btnNotasPedido.Size = new System.Drawing.Size(339, 23);
            this.btnNotasPedido.TabIndex = 0;
            this.btnNotasPedido.Text = "Notas de Pedido";
            this.btnNotasPedido.UseVisualStyleBackColor = true;
            this.btnNotasPedido.Click += new System.EventHandler(this.btnNotasPedido_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(50, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(362, 29);
            this.panel1.TabIndex = 1;
            // 
            // btnIngresarNotasPedido
            // 
            this.btnIngresarNotasPedido.Location = new System.Drawing.Point(120, 36);
            this.btnIngresarNotasPedido.Name = "btnIngresarNotasPedido";
            this.btnIngresarNotasPedido.Size = new System.Drawing.Size(289, 23);
            this.btnIngresarNotasPedido.TabIndex = 2;
            this.btnIngresarNotasPedido.Text = "Ingresar Nota de Pedido";
            this.btnIngresarNotasPedido.UseVisualStyleBackColor = true;
            this.btnIngresarNotasPedido.Visible = false;
            this.btnIngresarNotasPedido.Click += new System.EventHandler(this.btnIngresarNotasPedido_Click);
            // 
            // btnModificarNotaPedido
            // 
            this.btnModificarNotaPedido.Location = new System.Drawing.Point(120, 138);
            this.btnModificarNotaPedido.Name = "btnModificarNotaPedido";
            this.btnModificarNotaPedido.Size = new System.Drawing.Size(289, 23);
            this.btnModificarNotaPedido.TabIndex = 3;
            this.btnModificarNotaPedido.Text = "Modificar Detalle de Notas de Pedido";
            this.btnModificarNotaPedido.UseVisualStyleBackColor = true;
            this.btnModificarNotaPedido.Visible = false;
            this.btnModificarNotaPedido.Click += new System.EventHandler(this.btnModificarNotaPedido_Click);
            // 
            // btnSeguimientoPedidos
            // 
            this.btnSeguimientoPedidos.Location = new System.Drawing.Point(120, 163);
            this.btnSeguimientoPedidos.Name = "btnSeguimientoPedidos";
            this.btnSeguimientoPedidos.Size = new System.Drawing.Size(289, 23);
            this.btnSeguimientoPedidos.TabIndex = 4;
            this.btnSeguimientoPedidos.Text = "Seguimiento de Pedidos";
            this.btnSeguimientoPedidos.UseVisualStyleBackColor = true;
            this.btnSeguimientoPedidos.Visible = false;
            this.btnSeguimientoPedidos.Click += new System.EventHandler(this.btnSeguimientoPedidos_Click);
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btnGenerarExpediente);
            this.panel2.Controls.Add(this.btnModificarPedidoCompras);
            this.panel2.Controls.Add(this.btnModificarEncabezadoNotaPedido);
            this.panel2.Controls.Add(this.btnNotasIngresadasModulo);
            this.panel2.Location = new System.Drawing.Point(70, 31);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(342, 214);
            this.panel2.TabIndex = 5;
            this.panel2.Visible = false;
            // 
            // btnModificarPedidoCompras
            // 
            this.btnModificarPedidoCompras.Location = new System.Drawing.Point(50, 56);
            this.btnModificarPedidoCompras.Name = "btnModificarPedidoCompras";
            this.btnModificarPedidoCompras.Size = new System.Drawing.Size(289, 23);
            this.btnModificarPedidoCompras.TabIndex = 13;
            this.btnModificarPedidoCompras.Text = "Modificar Notas de Pedido";
            this.btnModificarPedidoCompras.UseVisualStyleBackColor = true;
            this.btnModificarPedidoCompras.Click += new System.EventHandler(this.btnModificarPedidoCompras_Click);
            // 
            // btnModificarEncabezadoNotaPedido
            // 
            this.btnModificarEncabezadoNotaPedido.Location = new System.Drawing.Point(49, 80);
            this.btnModificarEncabezadoNotaPedido.Name = "btnModificarEncabezadoNotaPedido";
            this.btnModificarEncabezadoNotaPedido.Size = new System.Drawing.Size(289, 23);
            this.btnModificarEncabezadoNotaPedido.TabIndex = 12;
            this.btnModificarEncabezadoNotaPedido.Text = "Modificar Encabezado de Notas de Pedido";
            this.btnModificarEncabezadoNotaPedido.UseVisualStyleBackColor = true;
            this.btnModificarEncabezadoNotaPedido.Visible = false;
            this.btnModificarEncabezadoNotaPedido.Click += new System.EventHandler(this.btnModificarEncabezadoNotaPedido_Click);
            // 
            // btnNotasIngresadasModulo
            // 
            this.btnNotasIngresadasModulo.Location = new System.Drawing.Point(50, 29);
            this.btnNotasIngresadasModulo.Name = "btnNotasIngresadasModulo";
            this.btnNotasIngresadasModulo.Size = new System.Drawing.Size(288, 24);
            this.btnNotasIngresadasModulo.TabIndex = 12;
            this.btnNotasIngresadasModulo.Text = "Notas de Pedido ingresadas por modulo";
            this.btnNotasIngresadasModulo.UseVisualStyleBackColor = true;
            this.btnNotasIngresadasModulo.Visible = false;
            this.btnNotasIngresadasModulo.Click += new System.EventHandler(this.btnNotasIngresadasModulo_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(488, 91);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(258, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "button5";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(488, 63);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(258, 23);
            this.button6.TabIndex = 9;
            this.button6.Text = "button6";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(488, 36);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(258, 23);
            this.button7.TabIndex = 8;
            this.button7.Text = "button7";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Visible = false;
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(446, 2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(302, 23);
            this.button8.TabIndex = 6;
            this.button8.Text = "button8";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Location = new System.Drawing.Point(418, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 29);
            this.panel3.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.button1);
            this.panel4.Location = new System.Drawing.Point(436, 32);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(313, 109);
            this.panel4.TabIndex = 11;
            this.panel4.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(258, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            // 
            // txtUsuario
            // 
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(3, 561);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(157, 20);
            this.txtUsuario.TabIndex = 12;
            // 
            // txtSector
            // 
            this.txtSector.Enabled = false;
            this.txtSector.Location = new System.Drawing.Point(166, 561);
            this.txtSector.Name = "txtSector";
            this.txtSector.Size = new System.Drawing.Size(174, 20);
            this.txtSector.TabIndex = 13;
            // 
            // txtSectoresInternos
            // 
            this.txtSectoresInternos.Location = new System.Drawing.Point(346, 561);
            this.txtSectoresInternos.Name = "txtSectoresInternos";
            this.txtSectoresInternos.Size = new System.Drawing.Size(166, 20);
            this.txtSectoresInternos.TabIndex = 14;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(518, 561);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(24, 20);
            this.txtIdUsuario.TabIndex = 15;
            // 
            // txtLegajoUsuario
            // 
            this.txtLegajoUsuario.Location = new System.Drawing.Point(548, 561);
            this.txtLegajoUsuario.Name = "txtLegajoUsuario";
            this.txtLegajoUsuario.Size = new System.Drawing.Size(19, 20);
            this.txtLegajoUsuario.TabIndex = 16;
            // 
            // btnGenerarExpediente
            // 
            this.btnGenerarExpediente.Location = new System.Drawing.Point(49, 157);
            this.btnGenerarExpediente.Name = "btnGenerarExpediente";
            this.btnGenerarExpediente.Size = new System.Drawing.Size(289, 23);
            this.btnGenerarExpediente.TabIndex = 14;
            this.btnGenerarExpediente.Text = "Generar Expedientes";
            this.btnGenerarExpediente.UseVisualStyleBackColor = true;
            this.btnGenerarExpediente.Visible = false;
            this.btnGenerarExpediente.Click += new System.EventHandler(this.btnGenerarExpediente_Click);
            // 
            // FrmCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1325, 583);
            this.Controls.Add(this.txtLegajoUsuario);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.txtSectoresInternos);
            this.Controls.Add(this.txtSector);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.btnSeguimientoPedidos);
            this.Controls.Add(this.btnModificarNotaPedido);
            this.Controls.Add(this.btnIngresarNotasPedido);
            this.Controls.Add(this.btnNotasPedido);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Name = "FrmCompras";
            this.Text = "CIGECO";
            this.Load += new System.EventHandler(this.FrmCompras_Load);
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnNotasPedido;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnIngresarNotasPedido;
        private System.Windows.Forms.Button btnModificarNotaPedido;
        private System.Windows.Forms.Button btnSeguimientoPedidos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnNotasIngresadasModulo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModificarEncabezadoNotaPedido;
        private System.Windows.Forms.Button btnModificarPedidoCompras;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtSector;
        public System.Windows.Forms.TextBox txtSectoresInternos;
        public System.Windows.Forms.TextBox txtIdUsuario;
        public System.Windows.Forms.TextBox txtLegajoUsuario;
        private System.Windows.Forms.Button btnGenerarExpediente;
    }
}