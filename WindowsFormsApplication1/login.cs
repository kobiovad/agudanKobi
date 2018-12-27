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
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class login : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public login()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
        }
        private void login_FormClosed(object sender, FormClosedEventArgs e)
        {
      
        }
        private void login_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                checkconnection.Text = "Conncetion Good Press Login To Enter";
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void checkconnection_Click(object sender, EventArgs e)
        {

        }

        private void button_login_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from login where username1='" + tex_username.Text +"' and password1='"+tex_password.Text+"'";
            OleDbDataReader reader =  command.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count++;
            }
            if (count == 1)
            {
               // MessageBox.Show("Username and Password is correct");
                connection.Close();
                connection.Dispose();
                this.Hide();
                loadingbar f2 = new loadingbar(tex_username.Text);
                f2.ShowDialog();
                this.Close();
               // this.FormClosed +=
                //new System.Windows.Forms.FormClosedEventHandler(this.login_FormClosed);
            }
            else if (count > 1)
                MessageBox.Show("duplicate Username and Password");
            else
                MessageBox.Show(" Username and Password Not correct");

            connection.Close();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
