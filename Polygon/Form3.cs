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
using System.Diagnostics;
using System.Net.Mail;

namespace Polygon
{
    public partial class Form3 : Form
    {
        string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source = Orders.mdb;";
        OleDbConnection myConnection;
        OleDbCommand command;
        OleDbDataReader reader;
        string quary2;
        Change ch;
        int id;
        Create cr;
        Delete del;
        Mail mail;
        public Form3()
        {
            InitializeComponent();
            Showdatagrid sdg = new Showdatagrid(dataGridView1);
            comboBox1.SelectedIndex = 1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            myConnection = new OleDbConnection(connectionString);
            myConnection.Open();
            string quary = "Select ID , Фамилия , Имя, Отчество , Email ,НомерЗаказа , ДатаПринятия, ДатаЗавершения " +
                "from Orders where " + comboBox1.Text + " like '%" + textBox1.Text + "%' ";
            OleDbDataAdapter Da = new OleDbDataAdapter(quary, myConnection);
            DataSet DS = new DataSet();
            Da.Fill(DS, "[Orders]");
            dataGridView1.DataSource = DS.Tables[0];
            myConnection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cr = new Create();
            cr.Show();
            cr.grid = dataGridView1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ch = new Change();
            if (groupBox1.BackColor == Color.RoyalBlue)
            {
                ch.stringnamebd = "Жалобы";
                ch.stringid_shnek = Convert.ToString(id);
            }
            else if (groupBox2.BackColor == Color.RoyalBlue)
            {
                ch.stringnamebd = "РезультатДиагностики";
                ch.stringid_shnek = Convert.ToString(id);
            }
            else if (groupBox3.BackColor == Color.RoyalBlue)
            {
                ch.stringnamebd = "РезультатРаботы";
                ch.stringid_shnek = Convert.ToString(id);
            }
            else
            {
                ch.stringnamebd = dataGridView1.CurrentCell.OwningColumn.Name.ToString();
                ch.stringid_shnek = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString();
            }
            ch.Show();
            ch.grid = dataGridView1;
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region Перекрашивание
            groupBox1.BackColor = Color.Transparent; groupBox1.ForeColor = Color.Black;
            groupBox2.BackColor = Color.Transparent; groupBox2.ForeColor = Color.Black;
            groupBox3.BackColor = Color.Transparent; groupBox3.ForeColor = Color.Black;
            label1.BackColor = Color.Transparent; label1.ForeColor = Color.Black;
            label2.BackColor = Color.Transparent; label2.ForeColor = Color.Black;
            label3.BackColor = Color.Transparent; label3.ForeColor = Color.Black;
            #endregion Перекрашивание
            id = int.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[0].Value.ToString());
            myConnection = new OleDbConnection(connectionString);
            quary2 = "Select Жалобы , РезультатДиагностики, РезультатРаботы From Orders where ID = " + id + "";
            myConnection.Open();
            command = new OleDbCommand(quary2, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                label1.Text = reader[0].ToString();
                label2.Text = reader[1].ToString();
                label3.Text = reader[2].ToString();
            }
            myConnection.Close();
            reader.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            #region Перекрашивание
            groupBox1.BackColor = Color.RoyalBlue; groupBox1.ForeColor = Color.White;
            groupBox2.BackColor = Color.Transparent; groupBox2.ForeColor = Color.Black;
            groupBox3.BackColor = Color.Transparent; groupBox3.ForeColor = Color.Black;
            label1.BackColor = Color.RoyalBlue; label1.ForeColor = Color.White;
            label2.BackColor = Color.Transparent; label2.ForeColor = Color.Black;
            label3.BackColor = Color.Transparent; label3.ForeColor = Color.Black;
            dataGridView1.ClearSelection();
            #endregion 
        }

        private void label2_Click(object sender, EventArgs e)
        {
            #region Перекрашивание
            groupBox1.BackColor = Color.Transparent; groupBox1.ForeColor = Color.Black;
            groupBox2.BackColor = Color.RoyalBlue; groupBox2.ForeColor = Color.White;
            groupBox3.BackColor = Color.Transparent; groupBox3.ForeColor = Color.Black;
            label1.BackColor = Color.Transparent; label1.ForeColor = Color.Black;
            label2.BackColor = Color.RoyalBlue; label2.ForeColor = Color.White;
            label3.BackColor = Color.Transparent; label3.ForeColor = Color.Black;
            dataGridView1.ClearSelection();
            #endregion
        }

        private void label3_Click(object sender, EventArgs e)
        {
            #region Перекрашивание
            groupBox1.BackColor = Color.Transparent; groupBox1.ForeColor = Color.Black;
            groupBox2.BackColor = Color.Transparent; groupBox2.ForeColor = Color.Black;
            groupBox3.BackColor = Color.RoyalBlue; groupBox3.ForeColor = Color.White;
            label1.BackColor = Color.Transparent; label1.ForeColor = Color.Black;
            label2.BackColor = Color.Transparent; label2.ForeColor = Color.Black;
            label3.BackColor = Color.RoyalBlue; label3.ForeColor = Color.White;
            dataGridView1.ClearSelection();
            #endregion
        }

        private void button3_Click(object sender, EventArgs e)
        {
            del = new Delete(id);
            del.Show();
            del.grid = dataGridView1;
        }
        private void Form3_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Process.Start("https://www.google.com/search?q="+label1.Text+"&oq="+ label1.Text + "");
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            mail = new Mail(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[4].Value.ToString());
            mail.Show();
        }
    }
}
