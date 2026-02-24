namespace CapaPresentacion
{
    partial class FInicio
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
            this.FormCategoria = new System.Windows.Forms.Button();
            this.FormProductos = new System.Windows.Forms.Button();
            this.FormClientes = new System.Windows.Forms.Button();
            this.FormVentas = new System.Windows.Forms.Button();
            this.FormDetalleVentas = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panelTop = new System.Windows.Forms.Panel();
            this.panelButtons = new System.Windows.Forms.Panel();
            this.panelTop.SuspendLayout();
            this.panelButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // FormCategoria
            // 
            this.FormCategoria.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.FormCategoria.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormCategoria.ForeColor = System.Drawing.Color.White;
            this.FormCategoria.Location = new System.Drawing.Point(83, 50);
            this.FormCategoria.Name = "FormCategoria";
            this.FormCategoria.Size = new System.Drawing.Size(271, 183);
            this.FormCategoria.TabIndex = 0;
            this.FormCategoria.Text = "📁 CATEGORÍAS";
            this.FormCategoria.UseVisualStyleBackColor = false;
            this.FormCategoria.Click += new System.EventHandler(this.FormCategoria_Click);
            this.FormCategoria.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FormCategoria.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // FormProductos
            // 
            this.FormProductos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.FormProductos.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormProductos.ForeColor = System.Drawing.Color.White;
            this.FormProductos.Location = new System.Drawing.Point(543, 50);
            this.FormProductos.Name = "FormProductos";
            this.FormProductos.Size = new System.Drawing.Size(264, 183);
            this.FormProductos.TabIndex = 1;
            this.FormProductos.Text = "📦 PRODUCTOS";
            this.FormProductos.UseVisualStyleBackColor = false;
            this.FormProductos.Click += new System.EventHandler(this.FormProductos_Click);
            this.FormProductos.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FormProductos.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // FormClientes
            // 
            this.FormClientes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(126)))), ((int)(((byte)(34)))));
            this.FormClientes.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormClientes.ForeColor = System.Drawing.Color.White;
            this.FormClientes.Location = new System.Drawing.Point(964, 50);
            this.FormClientes.Name = "FormClientes";
            this.FormClientes.Size = new System.Drawing.Size(221, 183);
            this.FormClientes.TabIndex = 2;
            this.FormClientes.Text = "👥 CLIENTES";
            this.FormClientes.UseVisualStyleBackColor = false;
            this.FormClientes.Click += new System.EventHandler(this.FormClientes_Click);
            this.FormClientes.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FormClientes.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // FormVentas
            // 
            this.FormVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.FormVentas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormVentas.ForeColor = System.Drawing.Color.White;
            this.FormVentas.Location = new System.Drawing.Point(83, 306);
            this.FormVentas.Name = "FormVentas";
            this.FormVentas.Size = new System.Drawing.Size(271, 202);
            this.FormVentas.TabIndex = 3;
            this.FormVentas.Text = "💳 VENTAS";
            this.FormVentas.UseVisualStyleBackColor = false;
            this.FormVentas.Click += new System.EventHandler(this.FormVentas_Click);
            this.FormVentas.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FormVentas.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // FormDetalleVentas
            // 
            this.FormDetalleVentas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(196)))), ((int)(((byte)(15)))));
            this.FormDetalleVentas.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormDetalleVentas.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.FormDetalleVentas.Location = new System.Drawing.Point(543, 315);
            this.FormDetalleVentas.Name = "FormDetalleVentas";
            this.FormDetalleVentas.Size = new System.Drawing.Size(264, 193);
            this.FormDetalleVentas.TabIndex = 4;
            this.FormDetalleVentas.Text = "📄 FACTURAS";
            this.FormDetalleVentas.UseVisualStyleBackColor = false;
            this.FormDetalleVentas.Click += new System.EventHandler(this.FormDetalleVentas_Click);
            this.FormDetalleVentas.MouseEnter += new System.EventHandler(this.Button_MouseEnter);
            this.FormDetalleVentas.MouseLeave += new System.EventHandler(this.Button_MouseLeave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(37, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(802, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sistema de Gestión de Ventas";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(45, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(350, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Gestiona tu negocio de forma eficiente";
            // 
            // panelTop
            // 
            this.panelTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.panelTop.Controls.Add(this.label1);
            this.panelTop.Controls.Add(this.label2);
            this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTop.Location = new System.Drawing.Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new System.Drawing.Size(1320, 120);
            this.panelTop.TabIndex = 5;
            // 
            // panelButtons
            // 
            this.panelButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(240)))), ((int)(((byte)(241)))));
            this.panelButtons.Controls.Add(this.FormCategoria);
            this.panelButtons.Controls.Add(this.FormProductos);
            this.panelButtons.Controls.Add(this.FormClientes);
            this.panelButtons.Controls.Add(this.FormVentas);
            this.panelButtons.Controls.Add(this.FormDetalleVentas);
            this.panelButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelButtons.Location = new System.Drawing.Point(0, 120);
            this.panelButtons.Name = "panelButtons";
            this.panelButtons.Size = new System.Drawing.Size(1320, 520);
            this.panelButtons.TabIndex = 6;
            // 
            // FInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1320, 640);
            this.Controls.Add(this.panelButtons);
            this.Controls.Add(this.panelTop);
            this.Name = "FInicio";
            this.Text = "Sistema de Gestión de Ventas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FInicio_Load);
            this.panelTop.ResumeLayout(false);
            this.panelTop.PerformLayout();
            this.panelButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FormCategoria;
        private System.Windows.Forms.Button FormProductos;
        private System.Windows.Forms.Button FormClientes;
        private System.Windows.Forms.Button FormVentas;
        private System.Windows.Forms.Button FormDetalleVentas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panelTop;
        private System.Windows.Forms.Panel panelButtons;
    }
}