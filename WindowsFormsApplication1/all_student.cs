using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.OleDb;
using DGVPrinterHelper;

namespace WindowsFormsApplication1
{
    public partial class all_student : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public all_student(string admin1)
        {
            InitializeComponent();
        connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
            label6.Text = admin1;
        }

        private void Refresh_Click(object sender, EventArgs e)
        {
            // מדפיס לפורמט פי.די.אף ושומר על המחשב את הקובץ
            if (textBox1.Text != "")  // בדיקת ראש דף שלא ריק
            {
                DGVPrinter printer = new DGVPrinter(); // בנאי
                //DGVPrinter 
                printer.Title = textBox1.Text;//header
                printer.SubTitle = string.Format("Date: {0}", DateTime.Now.Date);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = textBox2.Text;//footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);
                //printer.ImbeddedImageList
                // pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }
            else
            {
                MessageBox.Show("Heder Empty !!!");
            }


        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // טעינת טבלת רשת של כל הסטודנטים שרשומים 
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select id as ID,fname as First_Name,lname as Last_Name,trands as Trand,tel as Phone,email as Email from students ";

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

        private void button_back_Click(object sender, EventArgs e)
        {
            // חוזר אחורה וסוגר את הדף הנוכחי
            this.Hide();
            inventory f3 = new inventory(label6.Text);
            f3.ShowDialog();
            this.Close();
        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}
