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
    public partial class Create : Form
    {
        public DataGridView grid;
        string connectstring = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Orders.mdb;";
        OleDbConnection myConnection;
        OleDbCommand cmd;
        public Create()
        {
            myConnection = new OleDbConnection(connectstring);
            InitializeComponent();
            myConnection.Open();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            string quary = "INSERT INTO Orders (`Фамилия` , `Имя` , `Отчество` , `Email` , `НомерЗаказа` , `ДатаПринятия`,`ДатаЗавершения`, `Жалобы` , `РезультатДиагностики` , `РезультатРаботы` ) VALUES ('" + textBox5.Text+"','"+textBox6.Text+"','"+textBox7.Text+"','"+textBox8.Text+"','"+textBox4.Text+"','"+textBox9.Text+"','"+textBox10.Text+"','"+textBox1.Text+"','"+textBox2.Text+"','"+textBox3.Text+"')";
            cmd = new OleDbCommand(quary, myConnection);
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {
                MessageBox.Show("Что-то пошло не так");goto l1;
            }
            MessageBox.Show("Успешно созданно");
            myConnection.Close();
        l1:
            ;
        }

        private void Create_FormClosing(object sender, FormClosingEventArgs e)
        {
                Showdatagrid sgd = new Showdatagrid(grid);
                Hide();       
        }
    }
}
