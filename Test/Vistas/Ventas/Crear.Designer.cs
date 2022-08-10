namespace Test.Vistas.Ventas
{
    partial class Crear
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.dtVentasDet = new System.Windows.Forms.DataGridView();
            this.lblTituloCab = new System.Windows.Forms.Label();
            this.btnSelecCliente = new System.Windows.Forms.Button();
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.lblDetalle = new System.Windows.Forms.Label();
            this.btnSelecProductos = new System.Windows.Forms.Button();
            this.txtIdProducto = new System.Windows.Forms.TextBox();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.txtCant = new System.Windows.Forms.TextBox();
            this.lblCant = new System.Windows.Forms.Label();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.txtIdVentaCab = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtVentasDet)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.Location = new System.Drawing.Point(316, 9);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(294, 67);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABM Ventas";
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(325, 258);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(212, 36);
            this.btnEliminar.TabIndex = 1;
            this.btnEliminar.Text = "Eliminar Venta";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(96, 258);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(223, 36);
            this.btnGuardar.TabIndex = 2;
            this.btnGuardar.Text = "Guardar Venta";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // dtVentasDet
            // 
            this.dtVentasDet.AllowUserToAddRows = false;
            this.dtVentasDet.AllowUserToDeleteRows = false;
            this.dtVentasDet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtVentasDet.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtVentasDet.Location = new System.Drawing.Point(13, 310);
            this.dtVentasDet.Name = "dtVentasDet";
            this.dtVentasDet.ReadOnly = true;
            this.dtVentasDet.RowHeadersWidth = 51;
            this.dtVentasDet.Size = new System.Drawing.Size(1349, 373);
            this.dtVentasDet.TabIndex = 3;
            this.dtVentasDet.Text = "dataGridView1";
            this.dtVentasDet.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtVentasDet_CellClick);
            // 
            // lblTituloCab
            // 
            this.lblTituloCab.AutoSize = true;
            this.lblTituloCab.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTituloCab.Location = new System.Drawing.Point(13, 78);
            this.lblTituloCab.Name = "lblTituloCab";
            this.lblTituloCab.Size = new System.Drawing.Size(117, 35);
            this.lblTituloCab.TabIndex = 4;
            this.lblTituloCab.Text = "Cabezera";
            // 
            // btnSelecCliente
            // 
            this.btnSelecCliente.Location = new System.Drawing.Point(168, 78);
            this.btnSelecCliente.Name = "btnSelecCliente";
            this.btnSelecCliente.Size = new System.Drawing.Size(173, 35);
            this.btnSelecCliente.TabIndex = 5;
            this.btnSelecCliente.Text = "Selec. Cliente";
            this.btnSelecCliente.UseVisualStyleBackColor = true;
            this.btnSelecCliente.Click += new System.EventHandler(this.btnSelecCliente_Click);
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Location = new System.Drawing.Point(382, 86);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.PlaceholderText = "Id Cliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(228, 27);
            this.txtIdCliente.TabIndex = 6;
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Location = new System.Drawing.Point(653, 86);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.PlaceholderText = "Nombre Cliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(224, 27);
            this.txtNombreCliente.TabIndex = 7;
            // 
            // lblDetalle
            // 
            this.lblDetalle.AutoSize = true;
            this.lblDetalle.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblDetalle.Location = new System.Drawing.Point(13, 144);
            this.lblDetalle.Name = "lblDetalle";
            this.lblDetalle.Size = new System.Drawing.Size(92, 35);
            this.lblDetalle.TabIndex = 8;
            this.lblDetalle.Text = "Detalle";
            // 
            // btnSelecProductos
            // 
            this.btnSelecProductos.Location = new System.Drawing.Point(168, 144);
            this.btnSelecProductos.Name = "btnSelecProductos";
            this.btnSelecProductos.Size = new System.Drawing.Size(173, 35);
            this.btnSelecProductos.TabIndex = 9;
            this.btnSelecProductos.Text = "Selec. Productos";
            this.btnSelecProductos.UseVisualStyleBackColor = true;
            this.btnSelecProductos.Click += new System.EventHandler(this.btnSelecProductos_Click);
            // 
            // txtIdProducto
            // 
            this.txtIdProducto.Location = new System.Drawing.Point(382, 144);
            this.txtIdProducto.Name = "txtIdProducto";
            this.txtIdProducto.PlaceholderText = "Id Producto";
            this.txtIdProducto.ReadOnly = true;
            this.txtIdProducto.Size = new System.Drawing.Size(93, 27);
            this.txtIdProducto.TabIndex = 10;
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(496, 144);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.PlaceholderText = "Nombre Producto";
            this.txtNombreProducto.ReadOnly = true;
            this.txtNombreProducto.Size = new System.Drawing.Size(196, 27);
            this.txtNombreProducto.TabIndex = 11;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(710, 144);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.PlaceholderText = "Precio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(167, 27);
            this.txtPrecio.TabIndex = 12;
            this.txtPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(1196, 185);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(166, 42);
            this.btnAgregar.TabIndex = 13;
            this.btnAgregar.Text = "Agregar Producto";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // txtCant
            // 
            this.txtCant.Location = new System.Drawing.Point(982, 144);
            this.txtCant.Name = "txtCant";
            this.txtCant.PlaceholderText = "Cantidad a vender";
            this.txtCant.Size = new System.Drawing.Size(176, 27);
            this.txtCant.TabIndex = 14;
            this.txtCant.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCant.TextChanged += new System.EventHandler(this.txtCant_TextChanged);
            this.txtCant.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ComprobacionNumerico);
            // 
            // lblCant
            // 
            this.lblCant.AutoSize = true;
            this.lblCant.Location = new System.Drawing.Point(907, 147);
            this.lblCant.Name = "lblCant";
            this.lblCant.Size = new System.Drawing.Size(69, 20);
            this.lblCant.TabIndex = 15;
            this.lblCant.Text = "Cantidad";
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(1196, 144);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.PlaceholderText = "Sub Total";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(166, 27);
            this.txtSubTotal.TabIndex = 16;
            this.txtSubTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtIdVentaCab
            // 
            this.txtIdVentaCab.Location = new System.Drawing.Point(895, 86);
            this.txtIdVentaCab.Name = "txtIdVentaCab";
            this.txtIdVentaCab.PlaceholderText = "Id Venta Cab.";
            this.txtIdVentaCab.ReadOnly = true;
            this.txtIdVentaCab.Size = new System.Drawing.Size(244, 27);
            this.txtIdVentaCab.TabIndex = 17;
            // 
            // Crear
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1374, 695);
            this.Controls.Add(this.txtIdVentaCab);
            this.Controls.Add(this.txtSubTotal);
            this.Controls.Add(this.lblCant);
            this.Controls.Add(this.txtCant);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.txtNombreProducto);
            this.Controls.Add(this.txtIdProducto);
            this.Controls.Add(this.btnSelecProductos);
            this.Controls.Add(this.lblDetalle);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.btnSelecCliente);
            this.Controls.Add(this.lblTituloCab);
            this.Controls.Add(this.dtVentasDet);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.lblTitle);
            this.Name = "Crear";
            this.Text = "Crear";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.dtVentasDet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.DataGridView dtVentasDet;
        private System.Windows.Forms.Label lblTituloCab;
        private System.Windows.Forms.Button btnSelecCliente;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblDetalle;
        private System.Windows.Forms.Button btnSelecProductos;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.TextBox txtCant;
        private System.Windows.Forms.Label lblCant;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.TextBox txtIdVentaCab;
    }
}