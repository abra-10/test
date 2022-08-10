using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace Test.Vistas.Productos
{
    public partial class SelecProducto : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";

        public int IdProductoSele { get; set; } = 0;
        public string NombreProductoSelec { get; set; } = string.Empty;
        public decimal PrecioProductoSelec { get; set; } = 0;

        public SelecProducto()
        {
            InitializeComponent();
            ListarProductos();
        }

        private void dtProductos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtProductos.Columns["btnSelec"].Index)
            {
                var idProducto = int.Parse(dtProductos.Rows[e.RowIndex].Cells[1].Value.ToString());
                string nombreProducto = dtProductos.Rows[e.RowIndex].Cells[2].Value.ToString();
                decimal precio = decimal.Parse(dtProductos.Rows[e.RowIndex].Cells[3].Value.ToString());

                IdProductoSele = idProducto;
                NombreProductoSelec = nombreProducto;
                PrecioProductoSelec = precio;

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void ListarProductos()
        {
            dtProductos.DataSource = null;
            using var cnn = new OracleConnection(cnnStr);
            try
            {
                string query = "SELECT idproducto as ID_PRODUCTO, desproducto AS PRODUCTO, precio FROM SYSTEM.PRODUCTOS where cant_stock > 0";
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
            if (dtProductos.Columns["btnSelec"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnSelec";
                columna.HeaderText = "Selecionar";
                columna.Text = "Seleccionar producto";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtProductos.Columns.Insert(dtProductos.Columns.Count, columna);
            }

        }
    }
}
