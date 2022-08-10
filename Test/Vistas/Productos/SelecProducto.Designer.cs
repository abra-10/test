namespace Test.Vistas.Productos
{
    partial class SelecProducto
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
            this.dtProductos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // dtProductos
            // 
            this.dtProductos.AllowUserToAddRows = false;
            this.dtProductos.AllowUserToDeleteRows = false;
            this.dtProductos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtProductos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtProductos.Location = new System.Drawing.Point(0, 0);
            this.dtProductos.Name = "dtProductos";
            this.dtProductos.ReadOnly = true;
            this.dtProductos.RowHeadersWidth = 51;
            this.dtProductos.Size = new System.Drawing.Size(800, 450);
            this.dtProductos.TabIndex = 0;
            this.dtProductos.Text = "dataGridView1";
            this.dtProductos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtProductos_CellClick);
            // 
            // SelecProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtProductos);
            this.Name = "SelecProducto";
            this.Text = "SelecProducto";
            ((System.ComponentModel.ISupportInitialize)(this.dtProductos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtProductos;
    }
}