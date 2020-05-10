using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Polygon
{
    public partial class Form2 : Form
    {
       string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Reg.mdb;";
       OleDbConnection myConnection;

        public Form2()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectionString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string quary = "Select * from registr where login = '" + textBox1.Text + "' and pass = '" + textBox2.Text + "';";
            myConnection.Open();
            OleDbCommand command = new OleDbCommand(quary,myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            bool check = false;
            while (reader.Read())
            {
                check = true;
                break;
            }
            if (check == true)
            {

                Form3 f3 = new Form3();
                f3.Show();
            }
            else
            {
                MessageBox.Show("Такого пользователя не существует"); myConnection.Close();
                goto st;
            }
            reader.Close();
            myConnection.Close();
            Hide();
        st:
            ;
        }

        
        private void button2_Click(object sender, EventArgs e)
        {
            myConnection.Close();
            Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
            Environment.Exit(0);
        }
    }
}
