namespace CapaPresentacion
{
    partial class FrmEditarPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEditarPedido));
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.Label();
            this.txtCaracterPedido = new System.Windows.Forms.Label();
            this.txtFechaPedido = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEstadoPedido = new System.Windows.Forms.ComboBox();
            this.cmbCaracterPedido = new System.Windows.Forms.ComboBox();
            this.txtPasarObservaciones = new System.Windows.Forms.TextBox();
            this.txtPasarFechaPedido = new System.Windows.Forms.TextBox();
            this.txtNumeroTransaccion = new System.Windows.Forms.TextBox();
            this.btnModificarPedido = new System.Windows.Forms.Button();
            this.dgvDetalles = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtModificarIdDetalle = new System.Windows.Forms.TextBox();
            this.btnModificarDetalle = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtModificarPrecio = new System.Windows.Forms.TextBox();
            this.txtModificarCantidad = new System.Windows.Forms.TextBox();
            this.txtModificarDetelle = new System.Windows.Forms.TextBox();
            this.txtIdPedido = new System.Windows.Forms.TextBox();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPrecioTotalEstimado = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(467, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Nota de Pedido";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.txtEstado);
            this.groupBox1.Controls.Add(this.txtObservaciones);
            this.groupBox1.Controls.Add(this.txtCaracterPedido);
            this.groupBox1.Controls.Add(this.txtFechaPedido);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbEstadoPedido);
            this.groupBox1.Controls.Add(this.cmbCaracterPedido);
            this.groupBox1.Controls.Add(this.txtPasarObservaciones);
            this.groupBox1.Controls.Add(this.txtPasarFechaPedido);
            this.groupBox1.Controls.Add(this.txtNumeroTransaccion);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 37);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1310, 149);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Modificar Encabezado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(-1, 84);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Extracto:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(2, 103);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1068, 21);
            this.textBox1.TabIndex = 10;
            // 
            // txtEstado
            // 
            this.txtEstado.AutoSize = true;
            this.txtEstado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstado.Location = new System.Drawing.Point(1073, 27);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(53, 16);
            this.txtEstado.TabIndex = 9;
            this.txtEstado.Text = "Estado:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.AutoSize = true;
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(543, 28);
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(54, 16);
            this.txtObservaciones.TabIndex = 8;
            this.txtObservaciones.Text = "Pedido:";
            // 
            // txtCaracterPedido
            // 
            this.txtCaracterPedido.AutoSize = true;
            this.txtCaracterPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCaracterPedido.Location = new System.Drawing.Point(333, 27);
            this.txtCaracterPedido.Name = "txtCaracterPedido";
            this.txtCaracterPedido.Size = new System.Drawing.Size(61, 16);
            this.txtCaracterPedido.TabIndex = 7;
            this.txtCaracterPedido.Text = "Carácter:";
            // 
            // txtFechaPedido
            // 
            this.txtFechaPedido.AutoSize = true;
            this.txtFechaPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFechaPedido.Location = new System.Drawing.Point(184, 28);
            this.txtFechaPedido.Name = "txtFechaPedido";
            this.txtFechaPedido.Size = new System.Drawing.Size(92, 16);
            this.txtFechaPedido.TabIndex = 6;
            this.txtFechaPedido.Text = "Fecha Peddo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Número de Transacción;";
            // 
            // cmbEstadoPedido
            // 
            this.cmbEstadoPedido.FormattingEnabled = true;
            this.cmbEstadoPedido.Location = new System.Drawing.Point(1076, 46);
            this.cmbEstadoPedido.Name = "cmbEstadoPedido";
            this.cmbEstadoPedido.Size = new System.Drawing.Size(151, 23);
            this.cmbEstadoPedido.TabIndex = 4;
            // 
            // cmbCaracterPedido
            // 
            this.cmbCaracterPedido.FormattingEnabled = true;
            this.cmbCaracterPedido.Location = new System.Drawing.Point(336, 45);
            this.cmbCaracterPedido.Name = "cmbCaracterPedido";
            this.cmbCaracterPedido.Size = new System.Drawing.Size(199, 23);
            this.cmbCaracterPedido.TabIndex = 3;
            // 
            // txtPasarObservaciones
            // 
            this.txtPasarObservaciones.Location = new System.Drawing.Point(546, 46);
            this.txtPasarObservaciones.Name = "txtPasarObservaciones";
            this.txtPasarObservaciones.Size = new System.Drawing.Size(524, 21);
            this.txtPasarObservaciones.TabIndex = 2;
            // 
            // txtPasarFechaPedido
            // 
            this.txtPasarFechaPedido.Location = new System.Drawing.Point(187, 46);
            this.txtPasarFechaPedido.Name = "txtPasarFechaPedido";
            this.txtPasarFechaPedido.Size = new System.Drawing.Size(136, 21);
            this.txtPasarFechaPedido.TabIndex = 1;
            // 
            // txtNumeroTransaccion
            // 
            this.txtNumeroTransaccion.Location = new System.Drawing.Point(2, 46);
            this.txtNumeroTransaccion.Name = "txtNumeroTransaccion";
            this.txtNumeroTransaccion.Size = new System.Drawing.Size(174, 21);
            this.txtNumeroTransaccion.TabIndex = 0;
            // 
            // btnModificarPedido
            // 
            this.btnModificarPedido.BackColor = System.Drawing.Color.White;
            this.btnModificarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnModificarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarPedido.Image")));
            this.btnModificarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarPedido.Location = new System.Drawing.Point(546, 538);
            this.btnModificarPedido.Name = "btnModificarPedido";
            this.btnModificarPedido.Size = new System.Drawing.Size(208, 40);
            this.btnModificarPedido.TabIndex = 1;
            this.btnModificarPedido.Text = "Modificar Pedido";
            this.btnModificarPedido.UseVisualStyleBackColor = false;
            this.btnModificarPedido.Click += new System.EventHandler(this.btnModificarPedido_Click);
            // 
            // dgvDetalles
            // 
            this.dgvDetalles.BackgroundColor = System.Drawing.Color.White;
            this.dgvDetalles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalles.Location = new System.Drawing.Point(6, 21);
            this.dgvDetalles.Name = "dgvDetalles";
            this.dgvDetalles.Size = new System.Drawing.Size(1173, 342);
            this.dgvDetalles.TabIndex = 3;
            this.dgvDetalles.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellContentDoubleClick);
            this.dgvDetalles.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalles_CellValueChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtUsuario);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtModificarIdDetalle);
            this.groupBox2.Controls.Add(this.btnModificarDetalle);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtModificarPrecio);
            this.groupBox2.Controls.Add(this.txtModificarCantidad);
            this.groupBox2.Controls.Add(this.txtModificarDetelle);
            this.groupBox2.Controls.Add(this.txtIdPedido);
            this.groupBox2.Controls.Add(this.txtLegajo);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtPrecioTotalEstimado);
            this.groupBox2.Controls.Add(this.dgvDetalles);
            this.groupBox2.Controls.Add(this.btnModificarPedido);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(12, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1310, 599);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalle Nota de Pedido";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(986, 388);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 16);
            this.label8.TabIndex = 17;
            this.label8.Text = "0";
            // 
            // txtModificarIdDetalle
            // 
            this.txtModificarIdDetalle.Location = new System.Drawing.Point(989, 408);
            this.txtModificarIdDetalle.Name = "txtModificarIdDetalle";
            this.txtModificarIdDetalle.ReadOnly = true;
            this.txtModificarIdDetalle.Size = new System.Drawing.Size(180, 22);
            this.txtModificarIdDetalle.TabIndex = 16;
            // 
            // btnModificarDetalle
            // 
            this.btnModificarDetalle.BackColor = System.Drawing.Color.White;
            this.btnModificarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificarDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificarDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnModificarDetalle.Image")));
            this.btnModificarDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnModificarDetalle.Location = new System.Drawing.Point(546, 440);
            this.btnModificarDetalle.Name = "btnModificarDetalle";
            this.btnModificarDetalle.Size = new System.Drawing.Size(208, 38);
            this.btnModificarDetalle.TabIndex = 15;
            this.btnModificarDetalle.Text = "         Modificar Detalle";
            this.btnModificarDetalle.UseVisualStyleBackColor = false;
            this.btnModificarDetalle.Click += new System.EventHandler(this.btnModificarDetalle_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(825, 388);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 16);
            this.label7.TabIndex = 14;
            this.label7.Text = "Precio:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(656, 388);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Cantidad:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 388);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Modificar el detalle:";
            // 
            // txtModificarPrecio
            // 
            this.txtModificarPrecio.Location = new System.Drawing.Point(828, 407);
            this.txtModificarPrecio.Name = "txtModificarPrecio";
            this.txtModificarPrecio.Size = new System.Drawing.Size(154, 22);
            this.txtModificarPrecio.TabIndex = 11;
            // 
            // txtModificarCantidad
            // 
            this.txtModificarCantidad.Location = new System.Drawing.Point(659, 407);
            this.txtModificarCantidad.Name = "txtModificarCantidad";
            this.txtModificarCantidad.Size = new System.Drawing.Size(161, 22);
            this.txtModificarCantidad.TabIndex = 10;
            // 
            // txtModificarDetelle
            // 
            this.txtModificarDetelle.Location = new System.Drawing.Point(6, 407);
            this.txtModificarDetelle.Name = "txtModificarDetelle";
            this.txtModificarDetelle.Size = new System.Drawing.Size(648, 22);
            this.txtModificarDetelle.TabIndex = 9;
            // 
            // txtIdPedido
            // 
            this.txtIdPedido.Location = new System.Drawing.Point(8, 544);
            this.txtIdPedido.Name = "txtIdPedido";
            this.txtIdPedido.Size = new System.Drawing.Size(147, 22);
            this.txtIdPedido.TabIndex = 8;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(7, 495);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(148, 22);
            this.txtLegajo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(812, 502);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Percio Total Estimado:";
            // 
            // txtPrecioTotalEstimado
            // 
            this.txtPrecioTotalEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioTotalEstimado.Location = new System.Drawing.Point(961, 493);
            this.txtPrecioTotalEstimado.Name = "txtPrecioTotalEstimado";
            this.txtPrecioTotalEstimado.Size = new System.Drawing.Size(208, 29);
            this.txtPrecioTotalEstimado.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(6, 369);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1173, 118);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Modificar Detalle";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(7, 519);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(148, 22);
            this.txtUsuario.TabIndex = 19;
            // 
            // FrmEditarPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1284, 803);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Name = "FrmEditarPedido";
            this.Text = "Formulario Editar Pedidos";
            this.Load += new System.EventHandler(this.FrmEditarPedido_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalles)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label txtCaracterPedido;
        private System.Windows.Forms.Label txtFechaPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label txtEstado;
        private System.Windows.Forms.Label txtObservaciones;
        private System.Windows.Forms.Button btnModificarPedido;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox txtPasarFechaPedido;
        public System.Windows.Forms.TextBox txtNumeroTransaccion;
        public System.Windows.Forms.TextBox txtPasarObservaciones;
        public System.Windows.Forms.TextBox txtPrecioTotalEstimado;
        public System.Windows.Forms.ComboBox cmbEstadoPedido;
        public System.Windows.Forms.ComboBox cmbCaracterPedido;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox textBox1;
        public System.Windows.Forms.DataGridView dgvDetalles;
        public System.Windows.Forms.TextBox txtLegajo;
        public System.Windows.Forms.TextBox txtIdPedido;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtModificarPrecio;
        private System.Windows.Forms.TextBox txtModificarCantidad;
        private System.Windows.Forms.TextBox txtModificarDetelle;
        private System.Windows.Forms.Button btnModificarDetalle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtModificarIdDetalle;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox txtUsuario;
    }
}