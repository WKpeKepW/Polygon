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
    public partial class Delete : Form
    {
        public DataGridView grid;
        int id;
        string ConnectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = Orders.mdb;";
        OleDbConnection myConnect;
        public Delete(int id)
        {
            InitializeComponent();
            label1.Text = "Вы действительно хотите удалить строку под " + id + " ID";
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            myConnect = new OleDbConnection(ConnectionString);
            myConnect.Open();
            string quary = "DELETE FROM Orders WHERE ID = " + id + ";";
            OleDbCommand cmd = new OleDbCommand(quary, myConnect);
            cmd.ExecuteNonQuery();
            myConnect.Close();
            Showdatagrid sgd = new Showdatagrid(grid);
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Hide();
        }
    }
}
