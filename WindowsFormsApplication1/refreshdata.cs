using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace WindowsFormsApplication1
{
   // בנאי לרפרש את הטבלת רשת
    class Refresh
    {

        private DataTable dt;
        private OleDbConnection connection = new OleDbConnection();
        private int a;
        private string table1;


        public Refresh(string table)
        {
            dt = new DataTable();
            connection = new OleDbConnection();
            table1 = table;
        }
        
        public DataTable refreshdata1()
        {
            string strDb;
            strDb = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
            OleDbConnection conn1 = new OleDbConnection(strDb);
            conn1.Open();
            OleDbCommand cmd = conn1.CreateCommand();
            cmd.CommandText = "select * from " + table1 + " ";
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(dt);
            conn1.Close();
            return dt;
        }
        
    }
 }
