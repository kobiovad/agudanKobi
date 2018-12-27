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


namespace WindowsFormsApplication1
{
    public partial class manage_user : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private string flag1, table = "login";
        public manage_user(string flag)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
            flag1 = flag;
        }
            
        
        private void manage_user_Load(object sender, EventArgs e)
        {
            if(flag1== "add")
            {
                button_adduser.Visible = true;
                button_edituser.Visible = false;
                button_deleteuser.Visible = false;
               // dataGridView1.Visible = false;
            }
            else if(flag1== "edit")
            {
                button_adduser.Visible = false;
                button_edituser.Visible = true;
                button_deleteuser.Visible = false;
            }
            else if (flag1 == "delete")
            {
                button_adduser.Visible = false;
                button_edituser.Visible = false;
                button_deleteuser.Visible = true;
                textBox3.Visible = true;
                textBox1.Enabled = false;
                textBox2.Enabled = false;
               
            }

            // טעינת טבלת רשת של כל היוזרים שרשומים 
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from login ";

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();

                da.Fill(dt);
                dataGridView1.DataSource = dt;

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button_adduser_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "insert into login (username1,password1) values('" + textBox1.Text + "','" + textBox2.Text + "')";
                command.ExecuteNonQuery();
                MessageBox.Show("Data Save");

                Refresh db = new Refresh(table);
                dataGridView1.DataSource = db.refreshdata1();

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }

}

        private void button_edituser_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "update login set username1='" + textBox1.Text + "', password1='" + textBox2.Text + "' where username1='"+textBox3.Text+"'; ";
                command.ExecuteNonQuery();
                MessageBox.Show("Data Edit seccessful");

                Refresh db = new Refresh(table);
                dataGridView1.DataSource = db.refreshdata1();

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button_deleteuser_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                DialogResult result = MessageBox.Show("Do you want to delelet?", "alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string quary = "delete from login where username1='" + textBox3.Text + "'; ";
                    //MessageBox.Show(quary);
                    command.CommandText = quary;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Delete seccessful");

                    Refresh db = new Refresh(table);
                    dataGridView1.DataSource = db.refreshdata1();

                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Not deleled", "alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            // סגירת פורום נוכחי
            this.Hide();
            this.Close();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cell = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cell = selectedCell;
                break;
            }
            if (cell != null)
            {
                DataGridViewRow row = cell.OwningRow;
                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                textBox3.Text = row.Cells[0].Value.ToString();
            }
            
        }
    }
}
