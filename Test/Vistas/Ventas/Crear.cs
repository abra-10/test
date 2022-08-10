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
    public partial class Crear : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";
        public decimal PrecioSelec { get; set; } = 0;
        public int? IdVentaDetEdit { get; set; } = null;

        public List<int> IdEliminar = new List<int>();
        public Crear()
        {
            InitializeComponent();
            btnAgregar.Visible = false;
            InsertarBoton();
            ListarVentaDetalle(null);
            btnEliminar.Visible = false;
        }

        public Crear(int IdVenta)
        {
            InitializeComponent();
            btnAgregar.Visible = false;
            InsertarBoton();
            ObtenerCab(IdVenta);
            ListarVentaDetalle(IdVenta);
            txtIdVentaCab.Text = IdVenta.ToString();
            btnEliminar.Visible = true;
        }

        private void btnSelecCliente_Click(object sender, EventArgs e)
        {
            using Clientes.SelecCliente selec = new Clientes.SelecCliente();
            var result = selec.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selec.IdClienteSelec > 0)
                {
                    txtIdCliente.Text = selec.IdClienteSelec.ToString();
                    txtNombreCliente.Text = selec.NombreClienteSelec.ToString();
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dtVentasDet.DataSource;
            int idProducto = int.Parse(txtIdProducto.Text);
            decimal subTotal = decimal.Parse(txtSubTotal.Text);
            decimal cant = decimal.Parse(txtCant.Text);
            string nombreProducto = txtNombreProducto.Text;
            if (cant > 0)
            {
                bool existeProducto = false;
                foreach (DataRow item in dv.Table.Rows)
                {
                    int id = int.Parse(item["ID_PRODUCTO"].ToString());
                    if (id == idProducto && !IdVentaDetEdit.HasValue)
                        existeProducto = true;
                }
                if (!existeProducto)
                {
                    if (!IdVentaDetEdit.HasValue)
                    {
                        DataRow dr = dv.Table.NewRow();
                        if (IdVentaDetEdit.HasValue)
                        {
                            dr["ID_VENTA_DET"] = IdVentaDetEdit.Value;
                        }
                        else
                        {
                            dr["ID_VENTA_DET"] = DBNull.Value;
                        }
                        dr["ID_PRODUCTO"] = idProducto;
                        dr["PRODUCTO"] = nombreProducto;
                        dr["CANTIDAD"] = cant;
                        dr["SUB_TOTAL"] = subTotal;
                        dv.Table.Rows.Add(dr);
                    }
                    else 
                    {
                        foreach (DataRow item in dv.Table.Rows)
                        {
                            int idPro = int.Parse(item["ID_PRODUCTO"].ToString());

                            if (idProducto == idPro)
                            {
                                item["SUB_TOTAL"] = subTotal;
                                item["CANTIDAD"] = cant;
                            }
                        }
                    }
                    IdVentaDetEdit = null;
                    txtCant.Text = string.Empty;
                    txtIdProducto.Text = string.Empty;
                    txtNombreProducto.Text = string.Empty;
                    txtSubTotal.Text = string.Empty;
                    txtPrecio.Text = string.Empty;
                    PrecioSelec = 0;
                    btnAgregar.Visible = false;
                }
                else
                {
                    MessageBox.Show("Este producto ya se ha cargado", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Cantidad tiene que ser mayor a 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }                
            
        }

        private void btnSelecProductos_Click(object sender, EventArgs e)
        {
            using Productos.SelecProducto selec = new Productos.SelecProducto();
            var result = selec.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (selec.IdProductoSele > 0)
                {
                    txtIdProducto.Text = selec.IdProductoSele.ToString();
                    txtNombreProducto.Text = selec.NombreProductoSelec;
                    PrecioSelec = selec.PrecioProductoSelec;
                    txtPrecio.Text = selec.PrecioProductoSelec.ToString();
                    txtCant.Text = string.Empty;
                }
            }
        }

        //metodo para comprobacion de entrada de texto de tipo solo numerico
        private void ComprobacionNumerico(object sender, KeyPressEventArgs e)
        {
            //fuente: https://stackoverflow.com/a/463335
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && ((sender as TextBox).Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void txtCant_TextChanged(object sender, EventArgs e)
        {
            if (PrecioSelec > 0 && !string.IsNullOrWhiteSpace(txtCant.Text))
            {
                decimal cant = decimal.Parse(txtCant.Text);
                decimal subTotal = cant * PrecioSelec;
                txtSubTotal.Text = subTotal.ToString();
                btnAgregar.Visible = !string.IsNullOrWhiteSpace(txtIdProducto.Text);
            }
            else 
            { 
                txtSubTotal.Text = string.Empty;
                btnAgregar.Visible = false;
            }
        }

        private void dtVentasDet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idProducto = int.Parse(dtVentasDet.Rows[e.RowIndex].Cells[3].Value.ToString());
            if (e.ColumnIndex == dtVentasDet.Columns["btnEditar"].Index)
            {
                int? idVentaDet = 0;
                decimal cant = decimal.Parse(dtVentasDet.Rows[e.RowIndex].Cells[5].Value.ToString());
                string nombre = dtVentasDet.Rows[e.RowIndex].Cells[4].Value.ToString();
                decimal subTotal = decimal.Parse(dtVentasDet.Rows[e.RowIndex].Cells[6].Value.ToString());
                decimal precio = 0;
                if (!(dtVentasDet.Rows[e.RowIndex].Cells[2].Value == null || dtVentasDet.Rows[e.RowIndex].Cells[2].Value is DBNull))
                {
                    idVentaDet = int.Parse(dtVentasDet.Rows[e.RowIndex].Cells[2].Value.ToString());
                }
                IdVentaDetEdit = idVentaDet;
                txtIdProducto.Text = idProducto.ToString();
                txtNombreProducto.Text = nombre;
                txtSubTotal.Text = subTotal.ToString();

                string query = $@"SELECT precio FROM SYSTEM.PRODUCTOS WHERE IDPRODUCTO = {idProducto}";

                using var cnn = new OracleConnection(cnnStr);
                try
                {
                    cnn.Open();
                    var command = new OracleCommand();
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;
                    command.CommandText = query;

                    precio = decimal.Parse(command.ExecuteScalar().ToString());
                    txtPrecio.Text = precio.ToString();
                    PrecioSelec = precio;
                    txtCant.Text = cant.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            if (e.ColumnIndex == dtVentasDet.Columns["btnEliminar"].Index)
            {
                int? idVentaDet = null;
                if (!(dtVentasDet.Rows[e.RowIndex].Cells[2].Value == null || dtVentasDet.Rows[e.RowIndex].Cells[2].Value is DBNull))
                {
                    idVentaDet = int.Parse(dtVentasDet.Rows[e.RowIndex].Cells[2].Value.ToString());
                }

                if (idVentaDet.HasValue)
                {
                    IdEliminar.Add(idVentaDet.Value);
                }
                var dv = (DataView)dtVentasDet.DataSource;

                DataRow delete = null;
                foreach (DataRow item in dv.Table.Rows)
                {
                    int idPro = int.Parse(item["ID_PRODUCTO"].ToString());
                    bool comp = (!idVentaDet.HasValue && item["ID_VENTA_DET"] is DBNull);
                    int id = item["ID_VENTA_DET"] is DBNull ? 0 : int.Parse(item["ID_VENTA_DET"].ToString());
                    bool comp2 = id > 0 && idVentaDet.HasValue && id == idVentaDet.Value;
                    if ((comp || comp2)&& idProducto == idPro)
                    {
                        delete = item;
                    }
                }
                dv.Table.Rows.Remove(delete);
                dtVentasDet.DataSource = dv;
            }
        }

        private void InsertarBoton()
        {
            if (dtVentasDet.Columns["btnEditar"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnEditar";
                columna.HeaderText = "Editar";
                columna.Text = "Editar detalle";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtVentasDet.Columns.Insert(dtVentasDet.Columns.Count, columna);
            }

            if (dtVentasDet.Columns["btnEliminar"] == null)
            {
                DataGridViewButtonColumn columna = new DataGridViewButtonColumn();
                columna.Name = "btnEliminar";
                columna.HeaderText = "Eliminar";
                columna.Text = "Eliminar detalle";
                columna.UseColumnTextForButtonValue = true;
                columna.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                dtVentasDet.Columns.Insert(dtVentasDet.Columns.Count, columna);
            }
        }

        private void ListarVentaDetalle(int? IdVentaCab) 
        {
            string query = $@"SELECT 
                                vent_det.idventa_det AS ID_VENTA_DET,  
                                pro.idproducto AS ID_PRODUCTO,
                                pro.desproducto AS PRODUCTO,
                                vent_det.cantidad,
                                vent_det.sub_total
                            FROM SYSTEM.VENTAS_DET VENT_DET
                            LEFT JOIN SYSTEM.PRODUCTOS PRO ON PRO.IDPRODUCTO = VENT_DET.IDPRODUCTO
                            WHERE vent_det.idventa_cab = {IdVentaCab ?? 0}";

            dtVentasDet.DataSource = null;
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
                    dtVentasDet.DataSource = dataSet.Tables[0].DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DataView dv = (DataView)dtVentasDet.DataSource;
            if (dv.Table.Rows.Count > 0)
            {
                if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    int idCliente = int.Parse(txtIdCliente.Text);
                    using var cnn = new OracleConnection(cnnStr);
                    try
                    {
                        var filas = dv.Table.Rows;
                        cnn.Open();
                        var command = new OracleCommand();
                        command.Connection = cnn;
                        if (string.IsNullOrWhiteSpace(txtIdVentaCab.Text))
                        {
                            command.CommandText = $"INSERT INTO SYSTEM.VENTAS_CAB (IDCLIENTE, FECHA_VENTA) VALUES ({idCliente}, SYSDATE) returning IDVENTA_CAB into :new_id_cab";
                            command.Parameters.Add(new OracleParameter("new_id_cab", OracleDbType.Decimal, ParameterDirection.ReturnValue));
                            int result = command.ExecuteNonQuery();
                            if (result <= 0)
                                throw new Exception("No se ha creado la cabecera");
                            decimal idCab = Convert.ToDecimal(command.Parameters["new_id_cab"].Value.ToString());
                            if (idCab > 0)
                            {
                                foreach (DataRow fila in filas)
                                {
                                    int idProducto = int.Parse(fila["ID_PRODUCTO"].ToString());
                                    decimal cantidad = decimal.Parse(fila["CANTIDAD"].ToString());
                                    decimal subTotal = decimal.Parse(fila["SUB_TOTAL"].ToString());

                                    var cmdDet = new OracleCommand();
                                    cmdDet.Connection = cnn;
                                    cmdDet.CommandText = $@"INSERT INTO SYSTEM.VENTAS_DET 
                                                        (IDVENTA_CAB, IDPRODUCTO, CANTIDAD, SUB_TOTAL) VALUES 
                                                        ({idCab}, {idProducto}, {cantidad.ToString().Replace(",", ".")}, 
                                                        {subTotal.ToString().Replace(",", ".")}) returning IDVENTA_CAB into :new_id_det";
                                    cmdDet.Parameters.Add(new OracleParameter("new_id_det", OracleDbType.Decimal, ParameterDirection.ReturnValue));
                                    int resultDet = cmdDet.ExecuteNonQuery();
                                    if (resultDet <= 0)
                                        throw new Exception("No se ha creado el detalle");

                                    decimal idDet = decimal.Parse(cmdDet.Parameters["new_id_det"].Value.ToString());
                                    if (idDet <= 0)
                                        throw new Exception("No se ha obtenido el id Detalle");
                                }
                            }
                            else
                                throw new Exception("No se ha obtenido el idCab");
                        }
                        else 
                        {
                            int idCab = int.Parse(txtIdVentaCab.Text);
                            command.CommandText = $@"UPDATE SYSTEM.VENTAS_CAB SET idcliente = {idCliente}
                                                    WHERE IDVENTA_CAB = {idCab}";
                            int result = command.ExecuteNonQuery();
                            if (result <= 0)
                                throw new Exception("No se ha actualizado la cabecera");

                            foreach (int idDet in IdEliminar)
                            {
                                var cmdDelDet = new OracleCommand();
                                cmdDelDet.Connection = cnn;
                                cmdDelDet.CommandText = $@"DELETE FROM SYSTEM.VENTAS_DET WHERE 
                                                           IDVENTA_DET = {idDet} AND IDVENTA_CAB = {idCab}";
                                int resultDelete = cmdDelDet.ExecuteNonQuery();
                                if (resultDelete <= 0)
                                    throw new Exception("No se ha podido eliminar el detalle");
                            }

                            foreach (DataRow fila in filas)
                            {
                                int idProducto = int.Parse(fila["ID_PRODUCTO"].ToString());
                                decimal cantidad = decimal.Parse(fila["CANTIDAD"].ToString());
                                decimal subTotal = decimal.Parse(fila["SUB_TOTAL"].ToString());
                                if (fila["ID_VENTA_DET"] is DBNull)
                                {
                                    var cmdDet = new OracleCommand();
                                    cmdDet.Connection = cnn;
                                    cmdDet.CommandText = $@"INSERT INTO SYSTEM.VENTAS_DET 
                                                        (IDVENTA_CAB, IDPRODUCTO, CANTIDAD, SUB_TOTAL) VALUES 
                                                        ({idCab}, {idProducto}, {cantidad.ToString().Replace(",", ".")}, 
                                                        {subTotal.ToString().Replace(",", ".")}) returning IDVENTA_CAB into :new_id_det";
                                    cmdDet.Parameters.Add(new OracleParameter("new_id_det", OracleDbType.Decimal, ParameterDirection.ReturnValue));
                                    int resultDet = cmdDet.ExecuteNonQuery();
                                    if (resultDet <= 0)
                                        throw new Exception("No se ha creado el detalle");

                                    decimal idDet = decimal.Parse(cmdDet.Parameters["new_id_det"].Value.ToString());
                                    if (idDet <= 0)
                                        throw new Exception("No se ha obtenido el id Detalle");
                                } 
                                else 
                                { 
                                    int idDet = int.Parse(fila["ID_VENTA_DET"].ToString());
                                    var cmdDet = new OracleCommand();
                                    cmdDet.Connection = cnn;
                                    cmdDet.CommandText = $@"UPDATE SYSTEM.VENTAS_DET SET idproducto = {idProducto}, 
                                                            cantidad = {cantidad.ToString().Replace(",", ".")}, 
                                                            sub_total = {subTotal.ToString().Replace(",", ".")}
                                                            WHERE IDVENTA_CAB = {idCab} and IDVENTA_DET = {idDet}";

                                    int resultDet = cmdDet.ExecuteNonQuery();
                                    if (resultDet <= 0)
                                        throw new Exception("No se ha actualizado el detalle");
                                
                                }
                            }
                        }
                        MessageBox.Show("Se ha guardado la venta", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
                else 
                {
                    MessageBox.Show("No se ha seleccionado el cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 
            else
            {
                MessageBox.Show("No se puede guardar una venta sin detalles", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ObtenerCab(int idVentaCab) 
        {
            string query = $@"SELECT 
                                vent_cab.IDVENTA_CAB, cli.IDCLIENTE, cli.NOMBRECOMPLETO
                            FROM SYSTEM.VENTAS_CAB VENT_CAB
                            LEFT JOIN SYSTEM.CLIENTES CLI ON CLI.IDCLIENTE = vent_cab.idcliente
                            WHERE VENT_CAB.IDVENTA_CAB = {idVentaCab}";

            using var cnn = new OracleConnection(cnnStr);
            try
            {
                cnn.Open();
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
                    DataRow dr = dataSet.Tables[0].Rows[0];
                    txtIdVentaCab.Text = dr["IDVENTA_CAB"].ToString();
                    txtIdCliente.Text = dr["IDCLIENTE"].ToString();
                    txtNombreCliente.Text = dr["NOMBRECOMPLETO"].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrWhiteSpace(txtIdVentaCab.Text))
            {
                int idCab = int.Parse(txtIdVentaCab.Text);
                using var cnn = new OracleConnection(cnnStr);
                try
                {
                    cnn.Open();
                    var command = new OracleCommand();
                    command.Connection = cnn;
                    command.CommandText = $"DELETE FROM SYSTEM.VENTAS_DET WHERE IDVENTA_CAB = {idCab}";
                    var resultDet = command.ExecuteNonQuery();
                    if (resultDet <= 0)
                        throw new Exception("No se ha eliminado los detalles");

                    command.CommandText = $"DELETE FROM SYSTEM.VENTAS_CAB WHERE IDVENTA_CAB = {idCab}";
                    var resultCab = command.ExecuteNonQuery();
                    if (resultCab <= 0)
                        throw new Exception("No se ha eliminado la cabecera");

                    MessageBox.Show("Se ha eliminado la venta", "Hecho", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se puede eliminar sin el ID cab", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
