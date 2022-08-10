using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Test.Helpers;
using System.Data.OracleClient;
using Oracle.ManagedDataAccess.Client;

namespace Test.Vistas.Clientes
{
    public partial class Crear : Form
    {
        private string cnnStr = "Data Source=localhost; User Id=system;Password=123456789;";
        private readonly BindingList<KeyValuePair<int, string>> tiposDoc = new BindingList<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1, "C.I."),
            new KeyValuePair<int, string>(2, "RUC"),
        };
        private readonly BindingList<KeyValuePair<int, string>> tiposClientes = new BindingList<KeyValuePair<int, string>>
        {
            new KeyValuePair<int, string>(1, "FISICO"),
            new KeyValuePair<int, string>(2, "JURIDICO"),
        };

        public Crear()
        {
            InitializeComponent();
            CompletarComboBox();
            MostrarBotonEliminar();
        }

        public Crear(int IdCliente) 
        {
            InitializeComponent();
            CompletarComboBox();
            ObtenerCliente(IdCliente);
            MostrarBotonEliminar();
        }

        private void CompletarComboBox() 
        {
           

            
            cmbTiposDoc.DisplayMember = "Value";
            cmbTiposDoc.ValueMember = "Key";
            cmbTiposDoc.DataSource = tiposDoc;
            
            
            cmbTipoCliente.DisplayMember = "Value";
            cmbTipoCliente.ValueMember = "Key";
            cmbTipoCliente.DataSource = tiposClientes;
        }

        private void MostrarBotonEliminar() 
        {
            btnEliminar.Visible = !string.IsNullOrWhiteSpace(txtIdCliente.Text);
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            var nombre = txtNombre.Text;
            var tipoCliente = ((KeyValuePair<int, string>)cmbTipoCliente.SelectedItem).Key;
            var nroDoc = txtNroDoc.Text;
            var tipoDoc = ((KeyValuePair<int, string>)cmbTiposDoc.SelectedItem).Key;
            var tel = txtTel.Text;
            var email = txtEmail.Text;
            bool todoOk = true;

            using var cnn = new OracleConnection(cnnStr);
            try
            {
                cnn.Open();
                var command = new OracleCommand();
                command.Connection = cnn;
                //cree procedimientos almacenados para controlar los tipos de datos que inserto en las tablas.
                //si es nuevo se ejecuta el sp de insert
                if (string.IsNullOrWhiteSpace(txtIdCliente.Text))
                {
                    command.CommandText = "INSERT_CLIENTES";
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = nombre;
                    command.Parameters.Add("TIPOCLIENTE", OracleDbType.Decimal, ParameterDirection.Input).Value = tipoCliente;
                    command.Parameters.Add("NRODOC", OracleDbType.Varchar2, ParameterDirection.Input).Value = nroDoc;
                    command.Parameters.Add("TIPODOCUMENTO", OracleDbType.Decimal, ParameterDirection.Input).Value = tipoDoc;
                    command.Parameters.Add("TELEF", OracleDbType.Varchar2, ParameterDirection.Input).Value = tel;
                    command.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;

                    //command.ExecuteNonQuery();
                }
                else //si no se ejecutar el de actualizar
                {
                    int idCliente = int.Parse(txtIdCliente.Text);
                    
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "UPDATE_CLIENTES";
                    command.Parameters.Add("IDCLIENTEORIG", OracleDbType.Decimal, ParameterDirection.Input).Value = idCliente;
                    command.Parameters.Add("NOMBRE", OracleDbType.Varchar2, ParameterDirection.Input).Value = nombre;
                    command.Parameters.Add("TIPOCLIENTE", OracleDbType.Decimal, ParameterDirection.Input).Value = tipoCliente;
                    command.Parameters.Add("NRODOC", OracleDbType.Varchar2, ParameterDirection.Input).Value = nroDoc;
                    command.Parameters.Add("TIPODOCUMENTO", OracleDbType.Decimal, ParameterDirection.Input).Value = tipoDoc;
                    command.Parameters.Add("TELEF", OracleDbType.Varchar2, ParameterDirection.Input).Value = tel;
                    command.Parameters.Add("CORREO", OracleDbType.Varchar2, ParameterDirection.Input).Value = email;

                }
                var resultado = command.ExecuteNonQuery();
                if (!(resultado == -1))//controlo que hay impactado en la base de datos
                    throw new Exception("No se ha completado la acción");
            }
            catch (Exception ex)
            {
                todoOk = false;
                MessageBox.Show(ex.Message, "Error en Guardar Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            //var lista = ((Clientes.Listar)this.Parent);
            //lista.ListarClientes();

            if (todoOk)
            {
                MessageBox.Show("Acción completada de forma correcta", "Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIdCliente.Text))
            {
                using var cnn = new OracleConnection(cnnStr);
                cnn.Open();
                try
                {
                    int idCliente = int.Parse(txtIdCliente.Text);
                    var command = new OracleCommand();
                    command.Connection = cnn;
                    command.CommandType = CommandType.Text;

                    command.CommandText = $"DELETE FROM CLIENTES WHERE IDCLIENTE = {idCliente}";

                    if (command.ExecuteNonQuery() <= 0)
                        throw new Exception("No se ha eliminado ningun cliente");

                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error en Eliminar clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Crear_Load(object sender, EventArgs e)
        {

        }

        private void Crear_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void ObtenerCliente(int IdCliente) 
        {
            using var cnn = new OracleConnection(cnnStr);
            cnn.Open();
            try
            {
                var command = new OracleCommand();
                command.Connection = cnn;
                command.CommandText = $@"SELECT IDCLIENTE, NOMBRECOMPLETO, IDTIPOCLIENTE, NORDOCUMENTO, IDTIPODOCUMENTO, TELEFONO, EMAIL FROM CLIENTES WHERE IDCLIENTE = {IdCliente}";

                OracleDataAdapter oda = new OracleDataAdapter(command);
                DataSet data = new DataSet();
                oda.Fill(data);
                if (data.Tables.Count > 0)
                {
                    DataRow datarow = data.Tables[0].Rows[0];
                    var idCliente = int.Parse(datarow["IDCLIENTE"].ToString());
                    var nombre = datarow["NOMBRECOMPLETO"].ToString();
                    var nroDocumento = datarow["NORDOCUMENTO"].ToString();
                    object idTipoDocumento = int.Parse(datarow["IDTIPODOCUMENTO"].ToString());
                    object idTipoCliente = int.Parse(datarow["IDTIPOCLIENTE"].ToString());
                    var telef = datarow["TELEFONO"] == null || datarow["TELEFONO"] is DBNull ? string.Empty : datarow["TELEFONO"].ToString();
                    var email = datarow["EMAIL"] == null || datarow["EMAIL"] is DBNull ? string.Empty : datarow["EMAIL"].ToString();

                    txtEmail.Text = email;
                    txtNombre.Text = nombre;
                    txtIdCliente.Text = IdCliente.ToString();
                    txtNroDoc.Text = nroDocumento;
                    txtTel.Text = telef;
                    cmbTipoCliente.SelectedValue = idTipoCliente;
                    cmbTiposDoc.SelectedValue = idTipoDocumento;
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
