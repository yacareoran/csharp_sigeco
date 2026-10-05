namespace CapaPresentacion
{
    partial class FrmComprasNotaPedido
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtAnioActual = new System.Windows.Forms.TextBox();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarPedidos = new System.Windows.Forms.Button();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtNumeroTransaccion = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.dgvPedidosxConcepto = new System.Windows.Forms.DataGridView();
            this.label9 = new System.Windows.Forms.Label();
            this.txtBuscarConcepto = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnCursarPedido = new System.Windows.Forms.Button();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosxConcepto)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 660);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(360, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Aqui se ingresa haciendo click en Notas de PEdido Ingresadas por Modulo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(412, 660);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(295, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "En esta ventana se llama Mantenimiento de Notas de Pedido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 687);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(641, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "En este formulario se busca los pedidos generados en Procesamietno Intendencia e " +
    "Industriales y se busca por numero de transaccion";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(664, 687);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(389, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Una ves que se hace clic en el boton cursar pedido se genera el numero de nota";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label5.Location = new System.Drawing.Point(296, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(380, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mantenimiento de Notas de Pedido";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(40, 74);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1148, 498);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtAnioActual);
            this.tabPage1.Controls.Add(this.dtpFecha);
            this.tabPage1.Controls.Add(this.btnBuscarPedidos);
            this.tabPage1.Controls.Add(this.dgvPedidos);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.txtNumeroTransaccion);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1140, 472);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Filtrar por Transacción";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtAnioActual
            // 
            this.txtAnioActual.Location = new System.Drawing.Point(142, 37);
            this.txtAnioActual.Name = "txtAnioActual";
            this.txtAnioActual.Size = new System.Drawing.Size(100, 20);
            this.txtAnioActual.TabIndex = 9;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(458, 40);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(113, 21);
            this.dtpFecha.TabIndex = 8;
            // 
            // btnBuscarPedidos
            // 
            this.btnBuscarPedidos.BackColor = System.Drawing.Color.White;
            this.btnBuscarPedidos.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscarPedidos.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarPedidos.Location = new System.Drawing.Point(862, 38);
            this.btnBuscarPedidos.Name = "btnBuscarPedidos";
            this.btnBuscarPedidos.Size = new System.Drawing.Size(194, 23);
            this.btnBuscarPedidos.TabIndex = 7;
            this.btnBuscarPedidos.Text = "Buscar";
            this.btnBuscarPedidos.UseVisualStyleBackColor = false;
            this.btnBuscarPedidos.Click += new System.EventHandler(this.btnBuscarPedidos_Click);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(13, 84);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(1121, 337);
            this.dgvPedidos.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(151, 18);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 15);
            this.label7.TabIndex = 3;
            this.label7.Text = "Año:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 2;
            this.label6.Text = "Número:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(270, 36);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // txtNumeroTransaccion
            // 
            this.txtNumeroTransaccion.Location = new System.Drawing.Point(24, 37);
            this.txtNumeroTransaccion.Name = "txtNumeroTransaccion";
            this.txtNumeroTransaccion.Size = new System.Drawing.Size(100, 20);
            this.txtNumeroTransaccion.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.dgvPedidosxConcepto);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.txtBuscarConcepto);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1140, 472);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Filtrar por Concepto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // dgvPedidosxConcepto
            // 
            this.dgvPedidosxConcepto.BackgroundColor = System.Drawing.Color.White;
            this.dgvPedidosxConcepto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidosxConcepto.GridColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgvPedidosxConcepto.Location = new System.Drawing.Point(17, 78);
            this.dgvPedidosxConcepto.Name = "dgvPedidosxConcepto";
            this.dgvPedidosxConcepto.Size = new System.Drawing.Size(1047, 362);
            this.dgvPedidosxConcepto.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label9.Location = new System.Drawing.Point(142, 29);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(183, 20);
            this.label9.TabIndex = 1;
            this.label9.Text = "Buscar por Concepto:";
            // 
            // txtBuscarConcepto
            // 
            this.txtBuscarConcepto.Location = new System.Drawing.Point(331, 29);
            this.txtBuscarConcepto.Name = "txtBuscarConcepto";
            this.txtBuscarConcepto.Size = new System.Drawing.Size(351, 20);
            this.txtBuscarConcepto.TabIndex = 0;
            this.txtBuscarConcepto.TextChanged += new System.EventHandler(this.txtBuscarConcepto_TextChanged);
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(1140, 472);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Filtrar por Renglón";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnCursarPedido
            // 
            this.btnCursarPedido.BackColor = System.Drawing.Color.White;
            this.btnCursarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCursarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCursarPedido.Location = new System.Drawing.Point(350, 592);
            this.btnCursarPedido.Name = "btnCursarPedido";
            this.btnCursarPedido.Size = new System.Drawing.Size(219, 30);
            this.btnCursarPedido.TabIndex = 6;
            this.btnCursarPedido.Text = "Cursar Pedido";
            this.btnCursarPedido.UseVisualStyleBackColor = false;
            this.btnCursarPedido.Click += new System.EventHandler(this.btnCursarPedido_Click);
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.Color.White;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.Location = new System.Drawing.Point(609, 592);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(219, 30);
            this.btnVerDetalle.TabIndex = 7;
            this.btnVerDetalle.Text = "Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            // 
            // FrmComprasNotaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1215, 713);
            this.Controls.Add(this.btnVerDetalle);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnCursarPedido);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "FrmComprasNotaPedido";
            this.Text = "FrmComprasNotaPedido";
            this.Load += new System.EventHandler(this.FrmComprasNotaPedido_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidosxConcepto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox txtNumeroTransaccion;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Button btnBuscarPedidos;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBuscarConcepto;
        private System.Windows.Forms.DataGridView dgvPedidosxConcepto;
        private System.Windows.Forms.Button btnCursarPedido;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        public System.Windows.Forms.TextBox txtAnioActual;
    }
}