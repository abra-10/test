namespace Test.Vistas.Clientes
{
    partial class SelecCliente
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
            this.dtClientes = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).BeginInit();
            this.SuspendLayout();
            // 
            // dtClientes
            // 
            this.dtClientes.AllowUserToAddRows = false;
            this.dtClientes.AllowUserToDeleteRows = false;
            this.dtClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtClientes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtClientes.Location = new System.Drawing.Point(0, 0);
            this.dtClientes.Name = "dtClientes";
            this.dtClientes.ReadOnly = true;
            this.dtClientes.RowHeadersWidth = 51;
            this.dtClientes.Size = new System.Drawing.Size(800, 450);
            this.dtClientes.TabIndex = 0;
            this.dtClientes.Text = "dataGridView1";
            this.dtClientes.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCliente_CellClick);
            // 
            // SelecCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dtClientes);
            this.Name = "SelecCliente";
            this.Text = "SelecCliente";
            ((System.ComponentModel.ISupportInitialize)(this.dtClientes)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtClientes;
    }
}