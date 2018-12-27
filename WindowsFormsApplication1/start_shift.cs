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
    public partial class start_shift : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private string how; //משתנה כדי לדעת מי נרשם בכניסה
        public start_shift(string username)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=calendar.accdb;" + "Persist Security Info=False";
            how = username;
        }
       
        private void Form4_Load(object sender, EventArgs e)
        {
            // טעינת שעה ותאריך ללייבלים השונים 
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                string quary = "select * from " + DateTime.Now.ToString("MMMM") + ""; // בחירת החודש הנתון לפי החודש הנוכחי
                command.CommandText = quary;

                OleDbDataReader reader = command.ExecuteReader();
                reader.Read();
              
                // בדיקה האם השנה הנוכחית זהה לשנה שבטבלה לפי החודש
                if ((reader["year1"].ToString()) != DateTime.Now.ToString("yyyy") || (reader["year1"].ToString()) == "")
                {
                    button1.Enabled = false;
                    MessageBox.Show("Create New Calender Year !!!");
                }
                else
                {
                    button1.Visible = true;
                    button2.Visible = false;
                }
                connection.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }

            timer.Start();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            // סוגר פורום נוכחי
            this.Hide();
            this.Close();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick_1(object sender, EventArgs e)
        {
            // משיכת זמן ותאריך והצגתם 
            lbltimeall.Text = DateTime.Now.ToString("HH:mm");
            lbldataall.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblTime.Text = DateTime.Now.ToString("HH");
            lbtimemin.Text = DateTime.Now.ToString("mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("yyyy");
            lblDatemonth.Text = DateTime.Now.ToString("MMMM");
            lblDateday.Text = DateTime.Now.ToString("dd");
            lblDay.Text = DateTime.Now.ToString("dddd");
            lblSecond.Location = new Point(lbltimeall.Location.X + lbltimeall.Width - 5, lblSecond.Location.Y);// דואג שהשניות תמיד יהיו ליד השעה של השעון
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //הדפסת כניסה למערכת והכנסת הפרטים לטבלה 
            string enter = "Enter";
            try
            {
                
                connection.Open();

                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                
                //לקיחת החודש הנוכחי והכנסת הפרמטים לאותה טבלה
                command.CommandText = "insert into "+ DateTime.Now.ToString("MMMM")+" (hour1,minute1,second1,day1,month1,year1,timeall,dataall,enter_exit,how) values('" + lblTime.Text + "','" + lbtimemin.Text + "','" + lblSecond.Text + "','" + lblDateday.Text + "','" + lblDatemonth.Text + "', '" + lblDate.Text + "', '" + lbltimeall.Text + "','" + lbldataall.Text + "','" + enter + "','"+how+"')";
                command.ExecuteNonQuery();

                MessageBox.Show("Data save");
                button1.Enabled = false;
                connection.Close();
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
