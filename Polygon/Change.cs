using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Polygon
{
    public partial class Change : Form
    {
        public DataGridView grid;
        public string stringnamebd;
        string stringvaluebd;
        public string stringid_shnek;
        string stringConnect = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source = Orders.mdb;";
        OleDbConnection myConnection;
        public Change()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(stringConnect);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            stringvaluebd = textBox1.Text;
            string quary = "UPDATE Orders SET "+stringnamebd+" = '"+stringvaluebd+"' WHERE ID = "+stringid_shnek+";";
            myConnection.Open();
            OleDbCommand command = new OleDbCommand(quary,myConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");
            }
            myConnection.Close();
        }

        private void Change_FormClosing(object sender, FormClosingEventArgs e)
        {
            Showdatagrid sgd = new Showdatagrid(grid);
            Hide();
        }
    }
}
