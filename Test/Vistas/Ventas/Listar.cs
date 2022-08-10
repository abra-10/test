using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Test.Vistas.Ventas
{
    public partial class Listar : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";
        public Listar()
        {
            InitializeComponent();
            ListarVentas();
        }

        private void btnListar_Click(object sender, EventArgs e)
        {
            ListarVentas();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            Crear crear = new Crear();
            crear.Show();
        }

        private void ListarVentas() 
        {
            string query = $@"SELECT vent_cab.idventa_cab AS ID_VENTA_CAB, vent_cab.fecha_venta, cli.idcliente ID_CLIENTE, 
                            cli.nombrecompleto AS NOMBRE_COMPLETO FROM SYSTEM.VENTAS_CAB VENT_CAB
                            LEFT JOIN SYSTEM.CLIENTES CLI ON CLI.IDCLIENTE = vent_cab.idcliente";

            dtVentas.DataSource = null;
            using var cnn = new OracleConnection(cnnStr);
            try
            {
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
                    dtVentas.DataSource = dataSet.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void InsertarBoton()
        {
            if (dtVentas.Columns["btnEditar"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnEditar";
                columna.HeaderText = "Editar";
                columna.Text = "Editar venta";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtVentas.Columns.Insert(dtVentas.Columns.Count, columna);
            }

        }

        private void dtVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dtVentas.Columns["btnEditar"].Index)
            {
                var valor = int.Parse(dtVentas.Rows[e.RowIndex].Cells[1].Value.ToString());
                Crear editar = new Crear(valor);
                if (!editar.IsDisposed)
                {
                    editar.Show();
                }
            }
        }
    }
}
