using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test.Vistas.Productos
{
    public partial class Listar : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";

        public Listar()
        {
            InitializeComponent();
            ListarProductos();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Crear crear = new Crear();
            crear.Show();
        }

        private void dtProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtProductos.Columns["btnEditar"].Index)
            {
                var valor = int.Parse(dtProductos.Rows[e.RowIndex].Cells[1].Value.ToString());
                Crear editar = new Crear(valor);
                if (!editar.IsDisposed)
                {
                    editar.Show();
                }
            }
        }

        private void ListarProductos() 
        {
            dtProductos.DataSource = null;
            using var cnn = new OracleConnection(cnnStr);
            try
            {
                string query = "SELECT idproducto as ID_PRODUCTO, desproducto AS PRODUCTO, precio, cant_stock AS CANTIDAD FROM SYSTEM.PRODUCTOS";
                var command = new OracleCommand();
                command.Connection = cnn;
                command.CommandType = CommandType.Text;
                command.CommandText = query;

                OracleDataAdapter oda = new OracleDataAdapter();
                oda.AcceptChangesDuringFill = true;
                oda.SelectCommand = command;
                DataSet dataSet = new DataSet();
                oda.Fill(dataSet);
                if (dataSet.Tables.Count > 0)
                {
                    InsertarBoton();
                    dtProductos.DataSource = dataSet.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarBoton()
        {
            if (dtProductos.Columns["btnEditar"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnEditar";
                columna.HeaderText = "Editar";
                columna.Text = "Editar producto";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtProductos.Columns.Insert(dtProductos.Columns.Count, columna);
            }

        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarProductos();
        }
    }
}
