using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test.Vistas.Clientes
{
    public partial class Listar : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";
        public Listar()
        {
            InitializeComponent();
            ListarClientes();
        }

        public void ListarClientes() 
        {
            dtClientes.DataSource = null;
            using var cnn = new OracleConnection(cnnStr);
            try
            {
                string query = "SELECT \"ID Cliente\", \"Nombre del Cliente\", telefono, email, \"NRO DOCUMENTO\", \"Tipo Documento\"  FROM CLIENTES_VISTA";
                var command = new OracleCommand();
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                OracleDataAdapter oda = new OracleDataAdapter(command);
                DataSet dataSet = new DataSet();
                oda.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    InsertarBoton();
                    dtClientes.DataSource = dataSet.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            Clientes.Crear nuevo = new Crear();
            nuevo.Show();
        }

        private void InsertarBoton() 
        {
            if (dtClientes.Columns["btnEditar"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnEditar";
                columna.HeaderText = "Editar";
                columna.Text = "Editar cliente";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtClientes.Columns.Insert(dtClientes.Columns.Count, columna);
            }

        }

        private void dtClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtClientes.Columns["btnEditar"].Index)
            {
                var valor = int.Parse(dtClientes.Rows[e.RowIndex].Cells[1].Value.ToString());
                Clientes.Crear editar = new Crear(valor);
                if (!editar.IsDisposed)
                {
                    editar.Show();
                }
            }
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarClientes();
        }

        public void ListarNuevosClientes() 
        {
            ListarClientes();
        }
    }
}
