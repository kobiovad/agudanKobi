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
    public partial class end_shift : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private string how;//משתנה כדי לדעת מי נרשם ביציאה

        public end_shift(string username)
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=calendar.accdb;" + "Persist Security Info=False";
            how = username;
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            button2.Visible = true;
            timer.Start();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            //הדפסת יציאה למערכת והכנסת הפרטים לטבלה
            string enter = "Exit";
            try
            {

                connection.Open();

                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;

                command.CommandText = "insert into " + DateTime.Now.ToString("MMMM") + " (hour1,minute1,second1,day1,month1,year1,timeall,dataall,enter_exit,how) values('" + lblTime.Text + "','" + lbtimemin.Text + "','" + lblSecond.Text + "','" + lblDateday.Text + "','" + lblDatemonth.Text + "', '" + lblDate.Text + "', '" + lbltimeall.Text + "','" + lbldataall.Text + "','" + enter + "','"+how+"')";
                command.ExecuteNonQuery();

                MessageBox.Show("Data save");
              
                connection.Close();


            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button_back_Click_1(object sender, EventArgs e)
        {
            //סגירת פורום
            this.Hide();
            this.Close();
        }

        private void button_exit_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
                // משיכת זמן ותאריך והצגתם
            {
                lbltimeall.Text = DateTime.Now.ToString("HH:mm");
                lbldataall.Text = DateTime.Now.ToString("MMM dd yyyy");
                lblTime.Text = DateTime.Now.ToString("HH");
                lbtimemin.Text = DateTime.Now.ToString("mm");
                lblSecond.Text = DateTime.Now.ToString("ss");
                lblDate.Text = DateTime.Now.ToString("yyyy");
                lblDatemonth.Text = DateTime.Now.ToString("MMMM");
                lblDateday.Text = DateTime.Now.ToString("dd");
                lblDay.Text = DateTime.Now.ToString("dddd");
                lblSecond.Location = new Point(lbltimeall.Location.X + lbltimeall.Width - 5, lblSecond.Location.Y);
            }
        }
    }
}
