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
    public partial class Form1 : Form
    {
        string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Reg.mdb;";
        public OleDbConnection myConnection;
        public Form1()
        {
            InitializeComponent();
            myConnection = new OleDbConnection(connectString);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region
            string textexistspace = textBox1.Text;
            if (textexistspace.Length <= 4)
            {
                MessageBox.Show("Логин должен содержать более 4 символов"); goto l1;
            }
            for (int i = 0; i < textexistspace.Length; i++)
            {
                if (textexistspace[i] == ' ')
                {
                    MessageBox.Show("Логин не дожен содержать пробелы");
                    goto l1;
                }
            }
            #endregion
            #region
            string passexist = textBox2.Text;
            if (passexist.Length <= 4)
            {
                MessageBox.Show("Пароль должен быть больше 4 символов");goto l1;
            }
            else if (textBox2.Text == textBox3.Text)
            {
                goto l2;
            }
            else
            {
                MessageBox.Show("Не совпадающие пароли");
                goto l1;
            }
        #endregion
        l2:
            myConnection.Open();
            string quary = "INSERT INTO registr (login,pass) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')";
            OleDbCommand command = new OleDbCommand(quary, myConnection);
            try
            {
                command.ExecuteNonQuery();
            }
            catch (OleDbException)
            {
                MessageBox.Show("Такой логин уже существует"); goto l1;
            }
            Form2 f2 = new Form2();
            f2.Show();
            Hide();
        l1:
            myConnection.Close();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            RandomPass lapas = new RandomPass();
            string pass = lapas.Rass();
            string messeg = " Ваш пароль : ( " + pass + " )\n при нажатие кнопки 'OK'\n вы скопируете пароль";
            string dialog = "Внимание";
            textBox2.Text = pass;
            textBox3.Text = pass;
            DialogResult result = MessageBox.Show(messeg, dialog , MessageBoxButtons.OK);
            if (result == DialogResult.OK)
            {
                Clipboard.SetText(textBox2.Text);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            Hide();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
