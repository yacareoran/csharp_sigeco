namespace CapaPresentacion
{
    partial class FrmNotaPedido
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNotaPedido));
            this.label1 = new System.Windows.Forms.Label();
            this.dgvAgregarNotaPedido = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtObservaciones = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOrigen = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrecioTotalEstimado = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbCaracterCompra = new System.Windows.Forms.ComboBox();
            this.btnRegistrarPedido = new System.Windows.Forms.Button();
            this.cmbUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCargarUnidadMedida = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.txtPrecioUnitario = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtPedido = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.txtIdUsuario = new System.Windows.Forms.TextBox();
            this.btnQuitarRenglon = new System.Windows.Forms.Button();
            this.cmbOrganismoPedido = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cmbSector = new System.Windows.Forms.ComboBox();
            this.txtIdSectoresInternos = new System.Windows.Forms.TextBox();
            this.txtSectores_id = new System.Windows.Forms.TextBox();
            this.txtOrganismos_id = new System.Windows.Forms.TextBox();
            this.cmbRubro = new System.Windows.Forms.ComboBox();
            this.cmbSubrubro = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgregarNotaPedido)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(589, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar Nota de Pedido";
            // 
            // dgvAgregarNotaPedido
            // 
            this.dgvAgregarNotaPedido.AllowUserToAddRows = false;
            this.dgvAgregarNotaPedido.AllowUserToDeleteRows = false;
            this.dgvAgregarNotaPedido.BackgroundColor = System.Drawing.Color.White;
            this.dgvAgregarNotaPedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAgregarNotaPedido.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column7,
            this.Column5,
            this.Column8,
            this.Column9});
            this.dgvAgregarNotaPedido.GridColor = System.Drawing.Color.Black;
            this.dgvAgregarNotaPedido.Location = new System.Drawing.Point(25, 170);
            this.dgvAgregarNotaPedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dgvAgregarNotaPedido.Name = "dgvAgregarNotaPedido";
            this.dgvAgregarNotaPedido.Size = new System.Drawing.Size(1552, 376);
            this.dgvAgregarNotaPedido.TabIndex = 1;
            this.dgvAgregarNotaPedido.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgregarNotaPedido_CellContentClick);
            this.dgvAgregarNotaPedido.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAgregarNotaPedido_CellValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 555);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 19);
            this.label2.TabIndex = 2;
            this.label2.Text = "Observaciones:";
            // 
            // txtObservaciones
            // 
            this.txtObservaciones.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtObservaciones.Location = new System.Drawing.Point(35, 582);
            this.txtObservaciones.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtObservaciones.Multiline = true;
            this.txtObservaciones.Name = "txtObservaciones";
            this.txtObservaciones.Size = new System.Drawing.Size(237, 65);
            this.txtObservaciones.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(245, 707);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 19);
            this.label3.TabIndex = 4;
            this.label3.Text = "Origen:";
            // 
            // txtOrigen
            // 
            this.txtOrigen.Location = new System.Drawing.Point(304, 707);
            this.txtOrigen.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtOrigen.Name = "txtOrigen";
            this.txtOrigen.Size = new System.Drawing.Size(238, 20);
            this.txtOrigen.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(21, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 19);
            this.label4.TabIndex = 6;
            this.label4.Text = "Precio Total Estimado:";
            // 
            // txtPrecioTotalEstimado
            // 
            this.txtPrecioTotalEstimado.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioTotalEstimado.Location = new System.Drawing.Point(205, 16);
            this.txtPrecioTotalEstimado.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecioTotalEstimado.Name = "txtPrecioTotalEstimado";
            this.txtPrecioTotalEstimado.Size = new System.Drawing.Size(249, 21);
            this.txtPrecioTotalEstimado.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(284, 625);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(130, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "Carácter Compra:";
            // 
            // cmbCaracterCompra
            // 
            this.cmbCaracterCompra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCaracterCompra.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCaracterCompra.FormattingEnabled = true;
            this.cmbCaracterCompra.Location = new System.Drawing.Point(424, 624);
            this.cmbCaracterCompra.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbCaracterCompra.Name = "cmbCaracterCompra";
            this.cmbCaracterCompra.Size = new System.Drawing.Size(330, 23);
            this.cmbCaracterCompra.TabIndex = 9;
            // 
            // btnRegistrarPedido
            // 
            this.btnRegistrarPedido.BackColor = System.Drawing.Color.White;
            this.btnRegistrarPedido.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRegistrarPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarPedido.Image = ((System.Drawing.Image)(resources.GetObject("btnRegistrarPedido.Image")));
            this.btnRegistrarPedido.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRegistrarPedido.Location = new System.Drawing.Point(638, 706);
            this.btnRegistrarPedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnRegistrarPedido.Name = "btnRegistrarPedido";
            this.btnRegistrarPedido.Size = new System.Drawing.Size(215, 37);
            this.btnRegistrarPedido.TabIndex = 10;
            this.btnRegistrarPedido.Text = "    Registrar Pedido";
            this.btnRegistrarPedido.UseVisualStyleBackColor = false;
            this.btnRegistrarPedido.Click += new System.EventHandler(this.btnRegistrarPedido_Click);
            // 
            // cmbUnidadMedida
            // 
            this.cmbUnidadMedida.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbUnidadMedida.FormattingEnabled = true;
            this.cmbUnidadMedida.Location = new System.Drawing.Point(386, 70);
            this.cmbUnidadMedida.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbUnidadMedida.Name = "cmbUnidadMedida";
            this.cmbUnidadMedida.Size = new System.Drawing.Size(205, 24);
            this.cmbUnidadMedida.TabIndex = 11;
            this.cmbUnidadMedida.TextChanged += new System.EventHandler(this.cmbUnidadMedida_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(241, 75);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(137, 19);
            this.label6.TabIndex = 12;
            this.label6.Text = "Unidad de Medida:";
            // 
            // btnCargarUnidadMedida
            // 
            this.btnCargarUnidadMedida.BackColor = System.Drawing.Color.White;
            this.btnCargarUnidadMedida.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCargarUnidadMedida.Image = ((System.Drawing.Image)(resources.GetObject("btnCargarUnidadMedida.Image")));
            this.btnCargarUnidadMedida.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCargarUnidadMedida.Location = new System.Drawing.Point(532, 114);
            this.btnCargarUnidadMedida.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCargarUnidadMedida.Name = "btnCargarUnidadMedida";
            this.btnCargarUnidadMedida.Size = new System.Drawing.Size(215, 35);
            this.btnCargarUnidadMedida.TabIndex = 13;
            this.btnCargarUnidadMedida.Text = "Agregar Renglón";
            this.btnCargarUnidadMedida.UseVisualStyleBackColor = false;
            this.btnCargarUnidadMedida.Click += new System.EventHandler(this.btnCargarUnidadMedida_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(30, 707);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 19);
            this.label7.TabIndex = 14;
            this.label7.Text = "Usuario:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(95, 706);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(147, 21);
            this.txtUsuario.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(787, 553);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
            this.label8.TabIndex = 16;
            this.label8.Text = "Organismo:";
            // 
            // txtConcepto
            // 
            this.txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.Location = new System.Drawing.Point(696, 71);
            this.txtConcepto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(340, 22);
            this.txtConcepto.TabIndex = 18;
            // 
            // txtPrecioUnitario
            // 
            this.txtPrecioUnitario.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecioUnitario.Location = new System.Drawing.Point(1191, 69);
            this.txtPrecioUnitario.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPrecioUnitario.Name = "txtPrecioUnitario";
            this.txtPrecioUnitario.Size = new System.Drawing.Size(173, 22);
            this.txtPrecioUnitario.TabIndex = 19;
            // 
            // txtCantidad
            // 
            this.txtCantidad.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidad.Location = new System.Drawing.Point(101, 72);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(124, 22);
            this.txtCantidad.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(613, 72);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 19);
            this.label9.TabIndex = 21;
            this.label9.Text = "Concepto:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1069, 72);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(114, 19);
            this.label10.TabIndex = 22;
            this.label10.Text = "Precio Unitario:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(13, 75);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 19);
            this.label11.TabIndex = 23;
            this.label11.Text = "Cantidad:";
            // 
            // txtPedido
            // 
            this.txtPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPedido.Location = new System.Drawing.Point(279, 583);
            this.txtPedido.Name = "txtPedido";
            this.txtPedido.Size = new System.Drawing.Size(475, 21);
            this.txtPedido.TabIndex = 24;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(284, 555);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 19);
            this.label12.TabIndex = 25;
            this.label12.Text = "Pedido:";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtPrecioTotalEstimado);
            this.panel1.Location = new System.Drawing.Point(880, 696);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 48);
            this.panel1.TabIndex = 26;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.txtLegajo);
            this.panel2.Controls.Add(this.txtIdUsuario);
            this.panel2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.panel2.Location = new System.Drawing.Point(25, 696);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 47);
            this.panel2.TabIndex = 27;
            // 
            // txtLegajo
            // 
            this.txtLegajo.Location = new System.Drawing.Point(548, 11);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(13, 20);
            this.txtLegajo.TabIndex = 1;
            // 
            // txtIdUsuario
            // 
            this.txtIdUsuario.Location = new System.Drawing.Point(525, 11);
            this.txtIdUsuario.Name = "txtIdUsuario";
            this.txtIdUsuario.Size = new System.Drawing.Size(19, 20);
            this.txtIdUsuario.TabIndex = 0;
            // 
            // btnQuitarRenglon
            // 
            this.btnQuitarRenglon.BackColor = System.Drawing.Color.White;
            this.btnQuitarRenglon.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQuitarRenglon.Image = ((System.Drawing.Image)(resources.GetObject("btnQuitarRenglon.Image")));
            this.btnQuitarRenglon.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnQuitarRenglon.Location = new System.Drawing.Point(755, 114);
            this.btnQuitarRenglon.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnQuitarRenglon.Name = "btnQuitarRenglon";
            this.btnQuitarRenglon.Size = new System.Drawing.Size(215, 35);
            this.btnQuitarRenglon.TabIndex = 28;
            this.btnQuitarRenglon.Text = "Quitar Renglón";
            this.btnQuitarRenglon.UseVisualStyleBackColor = false;
            this.btnQuitarRenglon.Click += new System.EventHandler(this.btnQuitarRenglon_Click);
            // 
            // cmbOrganismoPedido
            // 
            this.cmbOrganismoPedido.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrganismoPedido.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbOrganismoPedido.FormattingEnabled = true;
            this.cmbOrganismoPedido.Location = new System.Drawing.Point(789, 581);
            this.cmbOrganismoPedido.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cmbOrganismoPedido.Name = "cmbOrganismoPedido";
            this.cmbOrganismoPedido.Size = new System.Drawing.Size(247, 23);
            this.cmbOrganismoPedido.TabIndex = 29;
            this.cmbOrganismoPedido.SelectedIndexChanged += new System.EventHandler(this.cmbOrganismoPedido_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1083, 553);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 19);
            this.label13.TabIndex = 30;
            this.label13.Text = "Sector:";
            // 
            // cmbSector
            // 
            this.cmbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSector.FormattingEnabled = true;
            this.cmbSector.Location = new System.Drawing.Point(1087, 581);
            this.cmbSector.Name = "cmbSector";
            this.cmbSector.Size = new System.Drawing.Size(291, 21);
            this.cmbSector.TabIndex = 31;
            this.cmbSector.SelectedIndexChanged += new System.EventHandler(this.cmbSector_SelectedIndexChanged);
            // 
            // txtIdSectoresInternos
            // 
            this.txtIdSectoresInternos.Location = new System.Drawing.Point(1403, 580);
            this.txtIdSectoresInternos.Name = "txtIdSectoresInternos";
            this.txtIdSectoresInternos.Size = new System.Drawing.Size(100, 20);
            this.txtIdSectoresInternos.TabIndex = 32;
            // 
            // txtSectores_id
            // 
            this.txtSectores_id.Location = new System.Drawing.Point(1442, 708);
            this.txtSectores_id.Name = "txtSectores_id";
            this.txtSectores_id.Size = new System.Drawing.Size(32, 20);
            this.txtSectores_id.TabIndex = 33;
            // 
            // txtOrganismos_id
            // 
            this.txtOrganismos_id.Location = new System.Drawing.Point(1480, 708);
            this.txtOrganismos_id.Name = "txtOrganismos_id";
            this.txtOrganismos_id.Size = new System.Drawing.Size(23, 20);
            this.txtOrganismos_id.TabIndex = 34;
            // 
            // cmbRubro
            // 
            this.cmbRubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRubro.FormattingEnabled = true;
            this.cmbRubro.Location = new System.Drawing.Point(791, 625);
            this.cmbRubro.Name = "cmbRubro";
            this.cmbRubro.Size = new System.Drawing.Size(245, 21);
            this.cmbRubro.TabIndex = 35;
            this.cmbRubro.SelectedIndexChanged += new System.EventHandler(this.cmbRubro_SelectedIndexChanged);
            // 
            // cmbSubrubro
            // 
            this.cmbSubrubro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSubrubro.FormattingEnabled = true;
            this.cmbSubrubro.Location = new System.Drawing.Point(1087, 624);
            this.cmbSubrubro.Name = "cmbSubrubro";
            this.cmbSubrubro.Size = new System.Drawing.Size(291, 21);
            this.cmbSubrubro.TabIndex = 36;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(788, 607);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 13);
            this.label14.TabIndex = 37;
            this.label14.Text = "Rubro";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1084, 608);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(58, 13);
            this.label15.TabIndex = 38;
            this.label15.Text = "Subrubro";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Cantidad";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Unidad";
            this.Column2.Name = "Column2";
            this.Column2.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Concepto";
            this.Column3.Name = "Column3";
            this.Column3.Width = 600;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Precio Unitario";
            this.Column4.Name = "Column4";
            this.Column4.Width = 120;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Rubro";
            this.Column6.Name = "Column6";
            this.Column6.Width = 180;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Subrubro";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Sub Total";
            this.Column5.Name = "Column5";
            this.Column5.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Rubro_id";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Subrubro_id";
            this.Column9.Name = "Column9";
            // 
            // FrmNotaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1590, 749);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.cmbSubrubro);
            this.Controls.Add(this.cmbRubro);
            this.Controls.Add(this.txtOrganismos_id);
            this.Controls.Add(this.txtSectores_id);
            this.Controls.Add(this.txtIdSectoresInternos);
            this.Controls.Add(this.cmbSector);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cmbOrganismoPedido);
            this.Controls.Add(this.btnQuitarRenglon);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtPedido);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cmbUnidadMedida);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtPrecioUnitario);
            this.Controls.Add(this.txtConcepto);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnCargarUnidadMedida);
            this.Controls.Add(this.btnRegistrarPedido);
            this.Controls.Add(this.cmbCaracterCompra);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtOrigen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtObservaciones);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvAgregarNotaPedido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "FrmNotaPedido";
            this.Text = "Agregar Nota de Pedido";
            this.Load += new System.EventHandler(this.FrmNotaPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAgregarNotaPedido)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvAgregarNotaPedido;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtObservaciones;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrecioTotalEstimado;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbCaracterCompra;
        private System.Windows.Forms.Button btnRegistrarPedido;
        private System.Windows.Forms.ComboBox cmbUnidadMedida;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCargarUnidadMedida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.TextBox txtPrecioUnitario;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        public System.Windows.Forms.TextBox txtUsuario;
        public System.Windows.Forms.TextBox txtOrigen;
        private System.Windows.Forms.TextBox txtPedido;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnQuitarRenglon;
        public System.Windows.Forms.TextBox txtIdUsuario;
        public System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.ComboBox cmbOrganismoPedido;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cmbSector;
        private System.Windows.Forms.TextBox txtOrganismos_id;
        public System.Windows.Forms.TextBox txtSectores_id;
        public System.Windows.Forms.TextBox txtIdSectoresInternos;
        private System.Windows.Forms.ComboBox cmbRubro;
        private System.Windows.Forms.ComboBox cmbSubrubro;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
    }
}