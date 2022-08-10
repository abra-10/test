using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Conectar() 
        {
            try
            {
                string conStr = "Data Source=XE; User Id=system;Password=123456789;";
                using (OracleConnection oda = new OracleConnection(conStr))
                {

                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}
