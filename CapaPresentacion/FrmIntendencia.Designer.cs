namespace CapaPresentacion
{
    partial class FrmIntendencia
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIntendencia));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtLegajoUsuario = new System.Windows.Forms.TextBox();
            this.btnEditarPedido = new System.Windows.Forms.Button();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.txtUsuarioIntendencia = new System.Windows.Forms.TextBox();
            this.txtOrigenSectorIntendencia = new System.Windows.Forms.TextBox();
            this.btnVerDetalle = new System.Windows.Forms.Button();
            this.btnAgregarPedido = new System.Windows.Forms.Button();
            this.dgvBuscarPedidos = new System.Windows.Forms.DataGridView();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpHoraFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraInicial = new System.Windows.Forms.DateTimePicker();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPedidos)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.groupBox2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1082, 54);
            this.panel1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(4, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(858, 82);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(383, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(402, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Notas de Pedido Procesamiento de Datos ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLegajoUsuario);
            this.groupBox1.Controls.Add(this.btnEditarPedido);
            this.groupBox1.Controls.Add(this.txtIdUsuario);
            this.groupBox1.Controls.Add(this.txtUsuarioIntendencia);
            this.groupBox1.Controls.Add(this.txtOrigenSectorIntendencia);
            this.groupBox1.Controls.Add(this.btnVerDetalle);
            this.groupBox1.Controls.Add(this.btnAgregarPedido);
            this.groupBox1.Controls.Add(this.dgvBuscarPedidos);
            this.groupBox1.Location = new System.Drawing.Point(4, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1090, 344);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Notas de Pedido";
            // 
            // txtLegajoUsuario
            // 
            this.txtLegajoUsuario.Location = new System.Drawing.Point(826, 305);
            this.txtLegajoUsuario.Name = "txtLegajoUsuario";
            this.txtLegajoUsuario.Size = new System.Drawing.Size(32, 20);
            this.txtLegajoUsuario.TabIndex = 7;
            // 
            // btnEditarPedido
            // 
            this.btnEditarPedido.BackColor = System.Drawing.Color.White;
            this.btnEditarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEditarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnEditarPedido.Image")));
            this.btnEditarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEditarPedido.Location = new System.Drawing.Point(445, 295);
            this.btnEditarPedido.Name = "btnEditarPedido";
            this.btnEditarPedido.Size = new System.Drawing.Size(162, 38);
            this.btnEditarPedido.TabIndex = 6;
            this.btnEditarPedido.Text = "        Modificar Pedido";
            this.btnEditarPedido.UseVisualStyleBackColor = false;
            this.btnEditarPedido.Click += new System.EventHandler(this.btnEditarPedido_Click);
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Enabled = false;
            this.txtIdUsuario.Location = new System.Drawing.Point(789, 305);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(31, 20);
            this.txtIdUsuario.TabIndex = 5;
            // 
            // txtUsuarioIntendencia
            // 
            this.txtUsuarioIntendencia.Enabled = false;
            this.txtUsuarioIntendencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioIntendencia.ForeColor = System.Drawing.Color.Black;
            this.txtUsuarioIntendencia.Location = new System.Drawing.Point(42, 283);
            this.txtUsuarioIntendencia.Name = "txtUsuarioIntendencia";
            this.txtUsuarioIntendencia.Size = new System.Drawing.Size(206, 21);
            this.txtUsuarioIntendencia.TabIndex = 4;
            // 
            // txtOrigenSectorIntendencia
            // 
            this.txtOrigenSectorIntendencia.Enabled = false;
            this.txtOrigenSectorIntendencia.Font = new System.Drawing.Font("Times New Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrigenSectorIntendencia.ForeColor = System.Drawing.Color.Black;
            this.txtOrigenSectorIntendencia.Location = new System.Drawing.Point(42, 309);
            this.txtOrigenSectorIntendencia.Name = "txtOrigenSectorIntendencia";
            this.txtOrigenSectorIntendencia.Size = new System.Drawing.Size(206, 21);
            this.txtOrigenSectorIntendencia.TabIndex = 3;
            // 
            // btnVerDetalle
            // 
            this.btnVerDetalle.BackColor = System.Drawing.Color.White;
            this.btnVerDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnVerDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerDetalle.Image = ((System.Drawing.Image)(resources.GetObject("btnVerDetalle.Image")));
            this.btnVerDetalle.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnVerDetalle.Location = new System.Drawing.Point(613, 295);
            this.btnVerDetalle.Name = "btnVerDetalle";
            this.btnVerDetalle.Size = new System.Drawing.Size(155, 38);
            this.btnVerDetalle.TabIndex = 2;
            this.btnVerDetalle.Text = "    Ver Detalle";
            this.btnVerDetalle.UseVisualStyleBackColor = false;
            // 
            // btnAgregarPedido
            // 
            this.btnAgregarPedido.BackColor = System.Drawing.Color.White;
            this.btnAgregarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAgregarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnAgregarPedido.Image")));
            this.btnAgregarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAgregarPedido.Location = new System.Drawing.Point(281, 295);
            this.btnAgregarPedido.Name = "btnAgregarPedido";
            this.btnAgregarPedido.Size = new System.Drawing.Size(155, 38);
            this.btnAgregarPedido.TabIndex = 1;
            this.btnAgregarPedido.Text = "    Agregar Pedido";
            this.btnAgregarPedido.UseVisualStyleBackColor = false;
            this.btnAgregarPedido.Click += new System.EventHandler(this.btnAgregarPedido_Click);
            // 
            // dgvBuscarPedidos
            // 
            this.dgvBuscarPedidos.BackgroundColor = System.Drawing.Color.White;
            this.dgvBuscarPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarPedidos.Location = new System.Drawing.Point(6, 19);
            this.dgvBuscarPedidos.Name = "dgvBuscarPedidos";
            this.dgvBuscarPedidos.Size = new System.Drawing.Size(1072, 255);
            this.dgvBuscarPedidos.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.groupBox3.Controls.Add(this.btnBuscar);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.dtpHoraFinal);
            this.groupBox3.Controls.Add(this.dtpHoraInicial);
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox3.Location = new System.Drawing.Point(5, 60);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1077, 92);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filtrar busquedas de notas de pedidos";
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.White;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBuscar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.Image = ((System.Drawing.Image)(resources.GetObject("btnBuscar.Image")));
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(717, 36);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(105, 33);
            this.btnBuscar.TabIndex = 4;
            this.btnBuscar.Text = "       Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(479, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Fecha final:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(233, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha inicial:";
            // 
            // dtpHoraFinal
            // 
            this.dtpHoraFinal.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraFinal.Location = new System.Drawing.Point(554, 42);
            this.dtpHoraFinal.Name = "dtpHoraFinal";
            this.dtpHoraFinal.Size = new System.Drawing.Size(116, 20);
            this.dtpHoraFinal.TabIndex = 1;
            // 
            // dtpHoraInicial
            // 
            this.dtpHoraInicial.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHoraInicial.Location = new System.Drawing.Point(321, 42);
            this.dtpHoraInicial.Name = "dtpHoraInicial";
            this.dtpHoraInicial.Size = new System.Drawing.Size(116, 20);
            this.dtpHoraInicial.TabIndex = 0;
            // 
            // FrmIntendencia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1091, 550);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "FrmIntendencia";
            this.Text = "Formulario cargar pedidos Procesamiento de Datos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPedidos)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvBuscarPedidos;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpHoraFinal;
        private System.Windows.Forms.DateTimePicker dtpHoraInicial;
        private System.Windows.Forms.Button btnVerDetalle;
        private System.Windows.Forms.Button btnAgregarPedido;
        public System.Windows.Forms.TextBox txtUsuarioIntendencia;
        public System.Windows.Forms.TextBox txtOrigenSectorIntendencia;
        public System.Windows.Forms.TextBox txtIdUsuario;
        private System.Windows.Forms.Button btnEditarPedido;
        public System.Windows.Forms.TextBox txtLegajoUsuario;
    }
}