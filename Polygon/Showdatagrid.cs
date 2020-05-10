using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Polygon
{
    class Showdatagrid
    {
        string connectionString = "Provider = Microsoft.Jet.OLEDB.4.0;Data Source = Orders.mdb;";
        OleDbConnection myConnection;
        public Showdatagrid(DataGridView dt)
        {
            myConnection = new OleDbConnection(connectionString);
            string quary = "Select ID , Фамилия , Имя, Отчество , Email , НомерЗаказа , ДатаПринятия, ДатаЗавершения from Orders";
            myConnection.Open();
            OleDbDataAdapter Da = new OleDbDataAdapter(quary, myConnection);
            DataSet DS = new DataSet();
            Da.Fill(DS, "[Orders]");
            dt.DataSource = DS.Tables[0];
            myConnection.Close();
        }
    }
}
