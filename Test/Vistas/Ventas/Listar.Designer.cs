namespace Test.Vistas.Ventas
{
    partial class Listar
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.dtVentas = new System.Windows.Forms.DataGridView();
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(226, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(356, 67);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Lista de Ventas";
            // 
            // dtVentas
            // 
            this.dtVentas.AllowUserToAddRows = false;
            this.dtVentas.AllowUserToDeleteRows = false;
            this.dtVentas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVentas.Location = new System.Drawing.Point(12, 170);
            this.dtVentas.Name = "dtVentas";
            this.dtVentas.ReadOnly = true;
            this.dtVentas.RowHeadersWidth = 51;
            this.dtVentas.Size = new System.Drawing.Size(776, 268);
            this.dtVentas.TabIndex = 1;
            this.dtVentas.Text = "dataGridView1";
            this.dtVentas.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtVentas_CellClick);
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(12, 108);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(221, 29);
            this.btnCrear.TabIndex = 2;
            this.btnCrear.Text = "Crear Venta";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(512, 108);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(276, 29);
            this.btnListar.TabIndex = 3;
            this.btnListar.Text = "Listar Ventas";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.dtVentas);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Listar";
            this.Text = "Listar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView dtVentas;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnListar;
    }
}