namespace Test.Vistas.Productos
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.btnListar = new System.Windows.Forms.Button();
            this.dtProductos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(193, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(432, 67);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Lista de Productos";
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(31, 93);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(162, 29);
            this.btnCrear.TabIndex = 1;
            this.btnCrear.Text = "Crear Producto";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // btnListar
            // 
            this.btnListar.Location = new System.Drawing.Point(360, 93);
            this.btnListar.Name = "btnListar";
            this.btnListar.Size = new System.Drawing.Size(223, 29);
            this.btnListar.TabIndex = 2;
            this.btnListar.Text = "Listar";
            this.btnListar.UseVisualStyleBackColor = true;
            this.btnListar.Click += new System.EventHandler(this.btnListar_Click);
            // 
            // dtProductos
            // 
            this.dtProductos.AllowUserToAddRows = false;
            this.dtProductos.AllowUserToDeleteRows = false;
            this.dtProductos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProductos.Location = new System.Drawing.Point(12, 155);
            this.dtProductos.Name = "dtProductos";
            this.dtProductos.ReadOnly = true;
            this.dtProductos.RowHeadersWidth = 51;
            this.dtProductos.Size = new System.Drawing.Size(776, 283);
            this.dtProductos.TabIndex = 3;
            this.dtProductos.Text = "dataGridView1";
            this.dtProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellClick);
            // 
            // Listar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtProductos);
            this.Controls.Add(this.btnListar);
            this.Controls.Add(this.btnCrear);
            this.Controls.Add(this.lblTitulo);
            this.Name = "Listar";
            this.Text = "Listar";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnListar;
        private System.Windows.Forms.DataGridView dtProductos;
    }
}