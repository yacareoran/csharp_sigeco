namespace CapaPresentacion
{
    partial class FrmModificarEncabezadoNotaPedido
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
            this.txtBuscarTransaccion = new System.Windows.Forms.TextBox();
            this.btnBuscarTransaccion = new System.Windows.Forms.Button();
            this.dgvBuscarPedidos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPedidos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.label1.Location = new System.Drawing.Point(302, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(448, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Modificar Encabezado de Nota de Pedido";
            // 
            // txtBuscarTransaccion
            // 
            this.txtBuscarTransaccion.Location = new System.Drawing.Point(307, 80);
            this.txtBuscarTransaccion.Name = "txtBuscarTransaccion";
            this.txtBuscarTransaccion.Size = new System.Drawing.Size(168, 20);
            this.txtBuscarTransaccion.TabIndex = 1;
            // 
            // btnBuscarTransaccion
            // 
            this.btnBuscarTransaccion.Location = new System.Drawing.Point(558, 78);
            this.btnBuscarTransaccion.Name = "btnBuscarTransaccion";
            this.btnBuscarTransaccion.Size = new System.Drawing.Size(192, 23);
            this.btnBuscarTransaccion.TabIndex = 2;
            this.btnBuscarTransaccion.Text = "button1";
            this.btnBuscarTransaccion.UseVisualStyleBackColor = true;
            this.btnBuscarTransaccion.Click += new System.EventHandler(this.btnBuscarTransaccion_Click);
            // 
            // dgvBuscarPedidos
            // 
            this.dgvBuscarPedidos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBuscarPedidos.Location = new System.Drawing.Point(115, 145);
            this.dgvBuscarPedidos.Name = "dgvBuscarPedidos";
            this.dgvBuscarPedidos.Size = new System.Drawing.Size(1037, 278);
            this.dgvBuscarPedidos.TabIndex = 3;
            // 
            // FrmModificarEncabezadoNotaPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1332, 576);
            this.Controls.Add(this.dgvBuscarPedidos);
            this.Controls.Add(this.btnBuscarTransaccion);
            this.Controls.Add(this.txtBuscarTransaccion);
            this.Controls.Add(this.label1);
            this.Name = "FrmModificarEncabezadoNotaPedido";
            this.Text = "FrmModificarEncabezadoNotaPedido";
            ((System.ComponentModel.ISupportInitialize)(this.dgvBuscarPedidos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBuscarTransaccion;
        private System.Windows.Forms.Button btnBuscarTransaccion;
        private System.Windows.Forms.DataGridView dgvBuscarPedidos;
    }
}