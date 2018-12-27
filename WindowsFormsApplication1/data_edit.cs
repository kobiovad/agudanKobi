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
using DGVPrinterHelper;

namespace WindowsFormsApplication1
{
    public partial class data_edit : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public data_edit(string username)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=calendar.accdb;" + "Persist Security Info=False";
            label1.Text = username;// משתנה גלובלי של היוזר 
            
        }
        
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

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

        private void button_day_Click(object sender, EventArgs e)
        {
            // בחירה מתוך היומן יום,חודש,שנה,יוזר והכנסת הפרטים לטבלת רשת 
            // הצגת יום ספציפי כניסה ויציאה
            try
            {
                connection.Open();
            OleDbCommand command = connection.CreateCommand();
            command.Connection = connection;
            command.CommandText = "select enter_exit as Shift1,timeall as Time1,dataall as Data1 from " + comboBox_month.Text+" where day1='" + comboBox_day.Text+ "' and month1= '"+comboBox_month.Text+"' and year1= '" + comboBox_year.Text+ "' and how= '" + comboBox_user.Text + "';";

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_month_Click(object sender, EventArgs e)
        {
            // בחירה מתוך היומן חודש'שנה ויוזר והכנסת הפרטים לטבלת רשת 
            // הצגת כל החודש שנבחר כניסה ויציאה
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select enter_exit as Shift1,timeall as Time1,dataall as Data1 from " + comboBox_month.Text + " where month1= '" + comboBox_month.Text + "' and year1= '" + comboBox_year.Text + "' and how= '" + comboBox_user.Text + "';";

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

        private void Refresh_Click(object sender, EventArgs e)
        {
            // מדפיס לפורמט פי.די.אף ושומר על המחשב את הקובץ
            {
                DGVPrinter printer = new DGVPrinter();
                //DGVPrinter 
                printer.Title = "נוכחות";//header
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "Comments: " + textBox1.Text;//footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
     
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            string strDb;
            strDb = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
            OleDbConnection conn1 = new OleDbConnection(strDb);
            conn1.Open();
            OleDbCommand cmd = conn1.CreateCommand();
            cmd.CommandText = "select username1 from login ";
  
            OleDbDataReader reader = cmd.ExecuteReader();
            while(reader.Read())
            {
                comboBox_user.Items.Add(reader["username1"].ToString());
            }
            conn1.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //יצירת טבלאות בתוך האקסס ע"י בחירת חודש ושנה 
            if (!(string.IsNullOrEmpty(comboBox2.Text))) // בדיקה שהתיבה אינה ריקה
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = connection.CreateCommand();
                    command.Connection = connection;
                    command.CommandText = "create table " + comboBox1.Text + " (count1 autoincrement,hour1 varchar(25), minute1 varchar(25), second1 varchar(25),day1 varchar(25),month1 varchar(25),year1 varchar(25),timeall varchar(25),dataall varchar(25),enter_exit varchar(25))";
                    command.ExecuteNonQuery();
                    
                    //הכנסת ערך קריטי לצורך בדיקת שנה בהמשך 
                    command.CommandText = "insert into " + comboBox1.Text + " (year1)  values('" + comboBox2.Text + "')";
                    command.ExecuteNonQuery();
                    MessageBox.Show("Table " + comboBox1.Text + " Create");
                    connection.Close();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                    connection.Close();
                }
            }
            else
            {
                MessageBox.Show("Fill Year !!!");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label8_MouseClick(object sender, MouseEventArgs e)
        {
            label8.Visible = false;

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label8.Visible = false;
        }

        private void label7_MouseClick(object sender, MouseEventArgs e)
        {
            label7.Visible = false;
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label7.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // מחיקת טבלה 
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                
                // בדיקה האם באמת רוצים למחוק את הטבלה 
                DialogResult result = MessageBox.Show("Do you want to Delelet " + comboBox1.Text + " ?", "Alert Delelet", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    command.CommandText = "drop table " + comboBox1.Text + "";
                    command.ExecuteNonQuery();

                    MessageBox.Show("Table " + comboBox1.Text + " Deleted !!!");
                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Not Deleled", "Alert Delelet", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
