using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Test.Vistas;

namespace Test.Vistas
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            Clientes.Listar listaClientes = new Clientes.Listar();
            listaClientes.Show();
        }

        private void btnProductos_Click(object sender, EventArgs e)
        {
            Productos.Listar listaProductos = new Productos.Listar();
            listaProductos.Show();
        }

        private void btnVentas_Click(object sender, EventArgs e)
        {
            Ventas.Listar lista = new Ventas.Listar();
            lista.Show();
        }
    }
}
