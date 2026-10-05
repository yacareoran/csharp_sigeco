namespace CapaPresentacion
{
    partial class FrmSeguimientoPedidoCompras
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
            this.txtBuscarTransaccion = new System.Windows.Forms.TextBox();
            this.txtBuscarPedido = new System.Windows.Forms.TextBox();
            this.btnBuscarTransaccion = new System.Windows.Forms.Button();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.dtpHoraInicial = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBuscarFechas = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.cmbSectoresInternos = new System.Windows.Forms.ComboBox();
            this.txtComentario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.txtIdSectoresInternos = new System.Windows.Forms.TextBox();
            this.txtBuscarProspecto = new System.Windows.Forms.TextBox();
            this.btnBuscarProspecto = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscarTransaccion
            // 
            this.txtBuscarTransaccion.Location = new System.Drawing.Point(36, 64);
            this.txtBuscarTransaccion.Name = "txtBuscarTransaccion";
            this.txtBuscarTransaccion.Size = new System.Drawing.Size(180, 20);
            this.txtBuscarTransaccion.TabIndex = 0;
            // 
            // txtBuscarPedido
            // 
            this.txtBuscarPedido.Location = new System.Drawing.Point(321, 66);
            this.txtBuscarPedido.Name = "txtBuscarPedido";
            this.txtBuscarPedido.Size = new System.Drawing.Size(369, 20);
            this.txtBuscarPedido.TabIndex = 1;
            // 
            // btnBuscarTransaccion
            // 
            this.btnBuscarTransaccion.Location = new System.Drawing.Point(219, 64);
            this.btnBuscarTransaccion.Name = "btnBuscarTransaccion";
            this.btnBuscarTransaccion.Size = new System.Drawing.Size(96, 23);
            this.btnBuscarTransaccion.TabIndex = 2;
            this.btnBuscarTransaccion.Text = "Buscar";
            this.btnBuscarTransaccion.UseVisualStyleBackColor = true;
            this.btnBuscarTransaccion.Click += new System.EventHandler(this.btnBuscarTransaccion_Click);
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Location = new System.Drawing.Point(695, 63);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(94, 23);
            this.btnBuscarPedido.TabIndex = 3;
            this.btnBuscarPedido.Text = "button2";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            this.btnBuscarPedido.Click += new System.EventHandler(this.btnBuscarPedido_Click);
            // 
            // dtpHoraInicial
            // 
            this.dtpHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraInicial.Location = new System.Drawing.Point(880, 65);
            this.dtpHoraInicial.Name = "dtpHoraInicial";
            this.dtpHoraInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpHoraInicial.TabIndex = 4;
            // 
            // dtpHoraFinal
            // 
            this.dtpHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraFinal.Location = new System.Drawing.Point(1061, 65);
            this.dtpHoraFinal.Name = "dtpHoraFinal";
            this.dtpHoraFinal.Size = new System.Drawing.Size(102, 20);
            this.dtpHoraFinal.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(795, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "Fecha inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(985, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Fecha final:";
            // 
            // btnBuscarFechas
            // 
            this.btnBuscarFechas.Location = new System.Drawing.Point(1169, 64);
            this.btnBuscarFechas.Name = "btnBuscarFechas";
            this.btnBuscarFechas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarFechas.TabIndex = 8;
            this.btnBuscarFechas.Text = "button3";
            this.btnBuscarFechas.UseVisualStyleBackColor = true;
            this.btnBuscarFechas.Click += new System.EventHandler(this.btnBuscarFechas_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(35, 149);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(1209, 280);
            this.dgvPedidos.TabIndex = 9;
            // 
            // cmbSectoresInternos
            // 
            this.cmbSectoresInternos.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSectoresInternos.FormattingEnabled = true;
            this.cmbSectoresInternos.Location = new System.Drawing.Point(852, 457);
            this.cmbSectoresInternos.Name = "cmbSectoresInternos";
            this.cmbSectoresInternos.Size = new System.Drawing.Size(392, 21);
            this.cmbSectoresInternos.TabIndex = 10;
            // 
            // txtComentario
            // 
            this.txtComentario.Location = new System.Drawing.Point(35, 457);
            this.txtComentario.Multiline = true;
            this.txtComentario.Name = "txtComentario";
            this.txtComentario.Size = new System.Drawing.Size(633, 212);
            this.txtComentario.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 432);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Ingresar Observciones:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(850, 438);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Seleccionar Sector:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(36, 688);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtUsuario.TabIndex = 14;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(156, 688);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(100, 20);
            this.txtIdUsuario.TabIndex = 15;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(274, 688);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(100, 20);
            this.txtLegajo.TabIndex = 16;
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(389, 688);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(100, 20);
            this.txtOrigen.TabIndex = 17;
            // 
            // txtIdSectoresInternos
            // 
            this.txtIdSectoresInternos.Location = new System.Drawing.Point(508, 687);
            this.txtIdSectoresInternos.Name = "txtIdSectoresInternos";
            this.txtIdSectoresInternos.Size = new System.Drawing.Size(100, 20);
            this.txtIdSectoresInternos.TabIndex = 18;
            // 
            // txtBuscarProspecto
            // 
            this.txtBuscarProspecto.Location = new System.Drawing.Point(35, 106);
            this.txtBuscarProspecto.Name = "txtBuscarProspecto";
            this.txtBuscarProspecto.Size = new System.Drawing.Size(655, 20);
            this.txtBuscarProspecto.TabIndex = 19;
            // 
            // btnBuscarProspecto
            // 
            this.btnBuscarProspecto.Location = new System.Drawing.Point(695, 106);
            this.btnBuscarProspecto.Name = "btnBuscarProspecto";
            this.btnBuscarProspecto.Size = new System.Drawing.Size(94, 23);
            this.btnBuscarProspecto.TabIndex = 20;
            this.btnBuscarProspecto.Text = "button2";
            this.btnBuscarProspecto.UseVisualStyleBackColor = true;
            // 
            // FrmSeguimientoPedidoCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 709);
            this.Controls.Add(this.btnBuscarProspecto);
            this.Controls.Add(this.txtBuscarProspecto);
            this.Controls.Add(this.txtIdSectoresInternos);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.txtLegajo);
            this.Controls.Add(this.txtIdUsuario);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtComentario);
            this.Controls.Add(this.cmbSectoresInternos);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnBuscarFechas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpHoraFinal);
            this.Controls.Add(this.dtpHoraInicial);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.btnBuscarTransaccion);
            this.Controls.Add(this.txtBuscarPedido);
            this.Controls.Add(this.txtBuscarTransaccion);
            this.Name = "FrmSeguimientoPedidoCompras";
            this.Text = "Seguimiento de Pedidos:";
            this.Load += new System.EventHandler(this.FrmSeguimientoPedidoCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscarTransaccion;
        private System.Windows.Forms.TextBox txtBuscarPedido;
        private System.Windows.Forms.Button btnBuscarTransaccion;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.DateTimePicker dtpHoraInicial;
        private System.Windows.Forms.DateTimePicker dtpHoraFinal;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnBuscarFechas;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.ComboBox cmbSectoresInternos;
        private System.Windows.Forms.TextBox txtComentario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtIdUsuario;
        public System.Windows.Forms.TextBox txtLegajo;
        public System.Windows.Forms.TextBox txtOrigen;
        public System.Windows.Forms.TextBox txtIdSectoresInternos;
        private System.Windows.Forms.TextBox txtBuscarProspecto;
        private System.Windows.Forms.Button btnBuscarProspecto;
    }
}