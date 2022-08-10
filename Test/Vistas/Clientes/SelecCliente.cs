using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Test.Vistas.Clientes
{
    public partial class SelecCliente : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";

        public int IdClienteSelec { get; set; } = 0;
        public string NombreClienteSelec { get; set; } = string.Empty;

        public SelecCliente()
        {
            InitializeComponent();
            ListarClientes();
        }

        private void dtCliente_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtClientes.Columns["btnSelec"].Index)
            {
                var idCliente = int.Parse(dtClientes.Rows[e.RowIndex].Cells[1].Value.ToString());
                var nombreCliente = dtClientes.Rows[e.RowIndex].Cells[2].Value.ToString();

                IdClienteSelec = idCliente;
                NombreClienteSelec = nombreCliente;
                
                this.DialogResult = DialogResult.OK;
            }
        }

        private void ListarClientes() 
        {
            dtClientes.DataSource = null;
            using var cnn = new OracleConnection(cnnStr);
            try
            {
                string query = "SELECT idcliente, nombrecompleto FROM SYSTEM.CLIENTES";
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

        private void InsertarBoton() 
        {
            if (dtClientes.Columns["btnSelec"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnSelec";
                columna.HeaderText = "Seleccionar";
                columna.Text = "Seleccionar cliente";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtClientes.Columns.Insert(dtClientes.Columns.Count, columna);
            }
        }
    }
}
