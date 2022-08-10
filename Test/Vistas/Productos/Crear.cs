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
    public partial class Crear : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=SYSTEM; Password=123456789;";

        public Crear()
        {
            InitializeComponent();
        }

        public Crear(int IdProducto)
        {
            InitializeComponent();
            ObtenerProducto(IdProducto);
            btnEliminar.Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            using var cnn = new OracleConnection(cnnStr);
            cnn.Open();
            try
            {
                var nombre = txtNombre.Text;
                decimal precio = !string.IsNullOrWhiteSpace(txtPrecio.Text) ? decimal.Parse(txtPrecio.Text) : (decimal)0;
                decimal cant = !string.IsNullOrWhiteSpace(txtCant.Text) ? decimal.Parse(txtCant.Text) : (decimal)0;
                if (precio <= 0)
                    new Exception("El precio tiene que ser mayor a 0");
                
                string query = string.Empty;
                var command = new OracleCommand();
                command.CommandType = CommandType.Text;
                command.Connection = cnn;
                if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
                {
                    query = $@"INSERT INTO SYSTEM.productos (DESPRODUCTO, PRECIO, CANT_STOCK) VALUES
                            ('{nombre}', {precio.ToString().Replace(",", ".")}, {cant.ToString().Replace(",", ".")})";
                } else {
                    int IdProducto = int.Parse(txtIdProducto.Text);
                    query = $@"UPDATE SYSTEM.PRODUCTOS SET DESPRODUCTO = '{nombre}', 
                                PRECIO = {precio.ToString().Replace(",", ".")}, CANT_STOCK = {cant.ToString().Replace(",", ".")}
                                WHERE IDPRODUCTO = {IdProducto}";
                }
                command.CommandText = query;
                var result = command.ExecuteNonQuery();
                if (result <= 0)
                    new Exception("No se ha podido guardar el producto");

                cnn.Close();
                MessageBox.Show("Se ha guardado el producto", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            var idProducto = int.Parse(txtIdProducto.Text);
            string query = $"delete from system.productos where idproducto = {idProducto}";

            using var cnn = new OracleConnection(cnnStr);
            cnn.Open();
            try
            {
                var command = new OracleCommand();
                command.CommandType = CommandType.Text;
                command.Connection = cnn;
                command.CommandText = query;
                var result = command.ExecuteNonQuery();
                if (result <= 0)
                    new Exception("No se ha podido eliminar el producto");

                cnn.Close();
                MessageBox.Show("Se ha eliminado correctamente", "Completado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void ObtenerProducto(int IdProducto) 
        {
            using var cnn = new OracleConnection(cnnStr);
            cnn.Open();
            try
            {
                var command = new OracleCommand();
                command.Connection = cnn;
                command.CommandText = $@"SELECT IDPRODUCTO, DESPRODUCTO, PRECIO, CANT_STOCK FROM SYSTEM.PRODUCTOS WHERE IDPRODUCTO = {IdProducto}";

                OracleDataAdapter oda = new OracleDataAdapter(command);
                DataSet data = new DataSet();
                oda.Fill(data);
                if (data.Tables.Count > 0)
                {
                    DataRow datarow = data.Tables[0].Rows[0];
                    var nombre = datarow["DESPRODUCTO"].ToString();
                    decimal precio = decimal.Parse(datarow["PRECIO"].ToString());
                    decimal cant = decimal.Parse(datarow["CANT_STOCK"].ToString());

                    txtIdProducto.Text = IdProducto.ToString();
                    txtPrecio.Text = precio.ToString();
                    txtCant.Text = cant.ToString();
                    txtNombre.Text = nombre;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error al Obtener datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            cnn.Close();
        }
    }
}
