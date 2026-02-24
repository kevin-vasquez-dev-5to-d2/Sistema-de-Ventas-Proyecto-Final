namespace CapaPresentacion
{
    partial class FormFacturacion
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnVerFactura = new System.Windows.Forms.Button();
            this.txtIdOcultoFactura = new System.Windows.Forms.TextBox();
            this.txtEstadoOcultoFactura = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 26F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(292, 64);
            this.label1.TabIndex = 1;
            this.label1.Text = "Facturacion:";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(21, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 50;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(857, 299);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnVerFactura
            // 
            this.btnVerFactura.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerFactura.Location = new System.Drawing.Point(348, 429);
            this.btnVerFactura.Name = "btnVerFactura";
            this.btnVerFactura.Size = new System.Drawing.Size(200, 36);
            this.btnVerFactura.TabIndex = 3;
            this.btnVerFactura.Text = "Ver Factura";
            this.btnVerFactura.UseVisualStyleBackColor = true;
            this.btnVerFactura.Click += new System.EventHandler(this.btnVerFactura_Click);
            // 
            // txtIdOcultoFactura
            // 
            this.txtIdOcultoFactura.Enabled = false;
            this.txtIdOcultoFactura.Location = new System.Drawing.Point(10, 10);
            this.txtIdOcultoFactura.Name = "txtIdOcultoFactura";
            this.txtIdOcultoFactura.Size = new System.Drawing.Size(10, 26);
            this.txtIdOcultoFactura.TabIndex = 0;
            this.txtIdOcultoFactura.Visible = false;
            // 
            // txtEstadoOcultoFactura
            // 
            this.txtEstadoOcultoFactura.Enabled = false;
            this.txtEstadoOcultoFactura.Location = new System.Drawing.Point(10, 10);
            this.txtEstadoOcultoFactura.Name = "txtEstadoOcultoFactura";
            this.txtEstadoOcultoFactura.Size = new System.Drawing.Size(10, 26);
            this.txtEstadoOcultoFactura.TabIndex = 0;
            this.txtEstadoOcultoFactura.Visible = false;
            // 
            // FormFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(947, 650);
            this.Controls.Add(this.btnVerFactura);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label1);
            this.Name = "FormFacturacion";
            this.Text = "FormFacturacion";
            this.Load += new System.EventHandler(this.FormFacturacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnVerFactura;
        private System.Windows.Forms.TextBox txtIdOcultoFactura;
        private System.Windows.Forms.TextBox txtEstadoOcultoFactura;
    }
}