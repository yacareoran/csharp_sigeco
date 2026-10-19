namespace CapaPresentacion
{
    partial class FrmGenerarExpedientes
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
            this.cmbOrganismoExpediente = new System.Windows.Forms.ComboBox();
            this.cmbSectorExpediente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTipoContratacion = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox5 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnGenerarExpediente = new System.Windows.Forms.Button();
            this.lblExpedienteInterno = new System.Windows.Forms.Label();
            this.btnBuscarFechas = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.dtpHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicial = new System.Windows.Forms.DateTimePicker();
            this.btnBuscarPedido = new System.Windows.Forms.Button();
            this.btnBuscarTransaccion = new System.Windows.Forms.Button();
            this.txtBuscarPedido = new System.Windows.Forms.TextBox();
            this.txtBuscarTransaccion = new System.Windows.Forms.TextBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.dgvPedidoExpedientes = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoExpedientes)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbOrganismoExpediente
            // 
            this.cmbOrganismoExpediente.FormattingEnabled = true;
            this.cmbOrganismoExpediente.Location = new System.Drawing.Point(45, 70);
            this.cmbOrganismoExpediente.Name = "cmbOrganismoExpediente";
            this.cmbOrganismoExpediente.Size = new System.Drawing.Size(258, 21);
            this.cmbOrganismoExpediente.TabIndex = 0;
            this.cmbOrganismoExpediente.SelectedIndexChanged += new System.EventHandler(this.cmbOrganismoExpediente_SelectedIndexChanged);
            // 
            // cmbSectorExpediente
            // 
            this.cmbSectorExpediente.FormattingEnabled = true;
            this.cmbSectorExpediente.Location = new System.Drawing.Point(324, 69);
            this.cmbSectorExpediente.Name = "cmbSectorExpediente";
            this.cmbSectorExpediente.Size = new System.Drawing.Size(273, 21);
            this.cmbSectorExpediente.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Organismo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Sector:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.cmbTipoContratacion);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(39, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1227, 85);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Seleccionar las categorías coeespondientes:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(899, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(123, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Tipo de Contratación:";
            // 
            // cmbTipoContratacion
            // 
            this.cmbTipoContratacion.FormattingEnabled = true;
            this.cmbTipoContratacion.Location = new System.Drawing.Point(902, 39);
            this.cmbTipoContratacion.Name = "cmbTipoContratacion";
            this.cmbTipoContratacion.Size = new System.Drawing.Size(307, 23);
            this.cmbTipoContratacion.TabIndex = 9;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(39, 140);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(1230, 117);
            this.textBox1.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 122);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Extracto:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(667, 40);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(221, 23);
            this.comboBox3.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(667, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Extracto:";
            // 
            // comboBox5
            // 
            this.comboBox5.FormattingEnabled = true;
            this.comboBox5.Location = new System.Drawing.Point(993, 306);
            this.comboBox5.Name = "comboBox5";
            this.comboBox5.Size = new System.Drawing.Size(273, 21);
            this.comboBox5.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(993, 288);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 15);
            this.label6.TabIndex = 12;
            this.label6.Text = "Estado del Pedido:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(39, 304);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(273, 20);
            this.textBox2.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(39, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(149, 15);
            this.label7.TabIndex = 14;
            this.label7.Text = "Ingresar Número de Nota:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(327, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 23);
            this.button1.TabIndex = 15;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnGenerarExpediente
            // 
            this.btnGenerarExpediente.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerarExpediente.Location = new System.Drawing.Point(39, 343);
            this.btnGenerarExpediente.Name = "btnGenerarExpediente";
            this.btnGenerarExpediente.Size = new System.Drawing.Size(273, 43);
            this.btnGenerarExpediente.TabIndex = 16;
            this.btnGenerarExpediente.Text = "Generar Expediente";
            this.btnGenerarExpediente.UseVisualStyleBackColor = true;
            this.btnGenerarExpediente.Click += new System.EventHandler(this.btnGenerarExpediente_Click);
            // 
            // lblExpedienteInterno
            // 
            this.lblExpedienteInterno.AutoSize = true;
            this.lblExpedienteInterno.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExpedienteInterno.ForeColor = System.Drawing.Color.Green;
            this.lblExpedienteInterno.Location = new System.Drawing.Point(323, 354);
            this.lblExpedienteInterno.Name = "lblExpedienteInterno";
            this.lblExpedienteInterno.Size = new System.Drawing.Size(117, 24);
            this.lblExpedienteInterno.TabIndex = 17;
            this.lblExpedienteInterno.Text = "Expediente";
            // 
            // btnBuscarFechas
            // 
            this.btnBuscarFechas.Location = new System.Drawing.Point(1101, 427);
            this.btnBuscarFechas.Name = "btnBuscarFechas";
            this.btnBuscarFechas.Size = new System.Drawing.Size(75, 23);
            this.btnBuscarFechas.TabIndex = 26;
            this.btnBuscarFechas.Text = "button3";
            this.btnBuscarFechas.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(917, 431);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 15);
            this.label8.TabIndex = 25;
            this.label8.Text = "Fecha final:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(727, 431);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 15);
            this.label9.TabIndex = 24;
            this.label9.Text = "Fecha inicial:";
            // 
            // dtpHoraFinal
            // 
            this.dtpHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraFinal.Location = new System.Drawing.Point(993, 428);
            this.dtpHoraFinal.Name = "dtpHoraFinal";
            this.dtpHoraFinal.Size = new System.Drawing.Size(102, 20);
            this.dtpHoraFinal.TabIndex = 23;
            // 
            // dtpHoraInicial
            // 
            this.dtpHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraInicial.Location = new System.Drawing.Point(812, 428);
            this.dtpHoraInicial.Name = "dtpHoraInicial";
            this.dtpHoraInicial.Size = new System.Drawing.Size(99, 20);
            this.dtpHoraInicial.TabIndex = 22;
            // 
            // btnBuscarPedido
            // 
            this.btnBuscarPedido.Location = new System.Drawing.Point(628, 428);
            this.btnBuscarPedido.Name = "btnBuscarPedido";
            this.btnBuscarPedido.Size = new System.Drawing.Size(82, 23);
            this.btnBuscarPedido.TabIndex = 21;
            this.btnBuscarPedido.Text = "button2";
            this.btnBuscarPedido.UseVisualStyleBackColor = true;
            // 
            // btnBuscarTransaccion
            // 
            this.btnBuscarTransaccion.Location = new System.Drawing.Point(206, 427);
            this.btnBuscarTransaccion.Name = "btnBuscarTransaccion";
            this.btnBuscarTransaccion.Size = new System.Drawing.Size(81, 23);
            this.btnBuscarTransaccion.TabIndex = 20;
            this.btnBuscarTransaccion.Text = "Buscar";
            this.btnBuscarTransaccion.UseVisualStyleBackColor = true;
            this.btnBuscarTransaccion.Click += new System.EventHandler(this.btnBuscarTransaccion_Click);
            // 
            // txtBuscarPedido
            // 
            this.txtBuscarPedido.Location = new System.Drawing.Point(293, 429);
            this.txtBuscarPedido.Name = "txtBuscarPedido";
            this.txtBuscarPedido.Size = new System.Drawing.Size(330, 20);
            this.txtBuscarPedido.TabIndex = 19;
            this.txtBuscarPedido.TextChanged += new System.EventHandler(this.txtBuscarPedido_TextChanged);
            // 
            // txtBuscarTransaccion
            // 
            this.txtBuscarTransaccion.Location = new System.Drawing.Point(23, 427);
            this.txtBuscarTransaccion.Name = "txtBuscarTransaccion";
            this.txtBuscarTransaccion.Size = new System.Drawing.Size(180, 20);
            this.txtBuscarTransaccion.TabIndex = 18;
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(23, 479);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(600, 205);
            this.dgvPedidos.TabIndex = 27;
            this.dgvPedidos.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvPedidos_KeyDown);
            // 
            // dgvPedidoExpedientes
            // 
            this.dgvPedidoExpedientes.AllowUserToAddRows = false;
            this.dgvPedidoExpedientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidoExpedientes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2});
            this.dgvPedidoExpedientes.Location = new System.Drawing.Point(643, 479);
            this.dgvPedidoExpedientes.Name = "dgvPedidoExpedientes";
            this.dgvPedidoExpedientes.Size = new System.Drawing.Size(626, 205);
            this.dgvPedidoExpedientes.TabIndex = 28;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Numero Transaccion";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Pedido";
            this.Column2.Name = "Column2";
            this.Column2.Width = 500;
            // 
            // FrmGenerarExpedientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 769);
            this.Controls.Add(this.dgvPedidoExpedientes);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.btnBuscarFechas);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.dtpHoraFinal);
            this.Controls.Add(this.dtpHoraInicial);
            this.Controls.Add(this.btnBuscarPedido);
            this.Controls.Add(this.btnBuscarTransaccion);
            this.Controls.Add(this.txtBuscarPedido);
            this.Controls.Add(this.txtBuscarTransaccion);
            this.Controls.Add(this.lblExpedienteInterno);
            this.Controls.Add(this.btnGenerarExpediente);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbSectorExpediente);
            this.Controls.Add(this.cmbOrganismoExpediente);
            this.Controls.Add(this.groupBox1);
            this.Name = "FrmGenerarExpedientes";
            this.Text = "Generar Expedientes";
            this.Load += new System.EventHandler(this.FrmGenerarExpedientes_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidoExpedientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbOrganismoExpediente;
        private System.Windows.Forms.ComboBox cmbSectorExpediente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbTipoContratacion;
        private System.Windows.Forms.ComboBox comboBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnGenerarExpediente;
        private System.Windows.Forms.Label lblExpedienteInterno;
        private System.Windows.Forms.Button btnBuscarFechas;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DateTimePicker dtpHoraFinal;
        private System.Windows.Forms.DateTimePicker dtpHoraInicial;
        private System.Windows.Forms.Button btnBuscarPedido;
        private System.Windows.Forms.Button btnBuscarTransaccion;
        private System.Windows.Forms.TextBox txtBuscarPedido;
        private System.Windows.Forms.TextBox txtBuscarTransaccion;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.DataGridView dgvPedidoExpedientes;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
    }
}