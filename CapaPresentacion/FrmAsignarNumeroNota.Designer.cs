namespace CapaPresentacion
{
    partial class FrmAsignarNumeroNota
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
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.txtBuscarPedido = new System.Windows.Forms.TextBox();
            this.dgvPedidos = new System.Windows.Forms.DataGridView();
            this.btnBuscarNumeroTransaccion = new System.Windows.Forms.Button();
            this.txtNumeroNota = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAsignarNumeroNota = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // txtBuscar
            // 
            this.txtBuscar.Location = new System.Drawing.Point(280, 73);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(150, 20);
            this.txtBuscar.TabIndex = 0;
            // 
            // txtBuscarPedido
            // 
            this.txtBuscarPedido.Location = new System.Drawing.Point(675, 72);
            this.txtBuscarPedido.Name = "txtBuscarPedido";
            this.txtBuscarPedido.Size = new System.Drawing.Size(416, 20);
            this.txtBuscarPedido.TabIndex = 1;
            this.txtBuscarPedido.TextChanged += new System.EventHandler(this.txtBuscarPedido_TextChanged);
            // 
            // dgvPedidos
            // 
            this.dgvPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPedidos.Location = new System.Drawing.Point(99, 117);
            this.dgvPedidos.Name = "dgvPedidos";
            this.dgvPedidos.Size = new System.Drawing.Size(992, 265);
            this.dgvPedidos.TabIndex = 2;
            // 
            // btnBuscarNumeroTransaccion
            // 
            this.btnBuscarNumeroTransaccion.Location = new System.Drawing.Point(436, 72);
            this.btnBuscarNumeroTransaccion.Name = "btnBuscarNumeroTransaccion";
            this.btnBuscarNumeroTransaccion.Size = new System.Drawing.Size(103, 23);
            this.btnBuscarNumeroTransaccion.TabIndex = 3;
            this.btnBuscarNumeroTransaccion.Text = "Buscar";
            this.btnBuscarNumeroTransaccion.UseVisualStyleBackColor = true;
            // 
            // txtNumeroNota
            // 
            this.txtNumeroNota.Location = new System.Drawing.Point(261, 419);
            this.txtNumeroNota.Name = "txtNumeroNota";
            this.txtNumeroNota.Size = new System.Drawing.Size(122, 20);
            this.txtNumeroNota.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(101, 420);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ingrese el número de nota:";
            // 
            // btnAsignarNumeroNota
            // 
            this.btnAsignarNumeroNota.Location = new System.Drawing.Point(500, 507);
            this.btnAsignarNumeroNota.Name = "btnAsignarNumeroNota";
            this.btnAsignarNumeroNota.Size = new System.Drawing.Size(230, 31);
            this.btnAsignarNumeroNota.TabIndex = 6;
            this.btnAsignarNumeroNota.Text = "Asignar Número de Nota";
            this.btnAsignarNumeroNota.UseVisualStyleBackColor = true;
            this.btnAsignarNumeroNota.Click += new System.EventHandler(this.btnAsignarNumeroNota_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(94, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 15);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ingrese número de transacción:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(545, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 8;
            this.label3.Text = "Buscar por Concepto:";
            // 
            // FrmAsignarNumeroNota
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1165, 570);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnAsignarNumeroNota);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNumeroNota);
            this.Controls.Add(this.btnBuscarNumeroTransaccion);
            this.Controls.Add(this.dgvPedidos);
            this.Controls.Add(this.txtBuscarPedido);
            this.Controls.Add(this.txtBuscar);
            this.Name = "FrmAsignarNumeroNota";
            this.Text = "FrmAsignarNumeroNota";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtBuscarPedido;
        private System.Windows.Forms.DataGridView dgvPedidos;
        private System.Windows.Forms.Button btnBuscarNumeroTransaccion;
        private System.Windows.Forms.TextBox txtNumeroNota;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAsignarNumeroNota;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}