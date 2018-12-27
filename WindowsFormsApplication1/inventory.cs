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
    public partial class inventory : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public inventory(string username)
        {
            InitializeComponent();
            label2.Text = username;
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";

        }
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Application.Exit();
        }

        int count;
        private void Form2_Load(object sender, EventArgs e)
        {
            // מילוי של המגמות,שנה,מתנה על פי המגמות,שנה,מתנה שנרשמו כבר - נמשך מהדאטה

            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                string quary = "select  trands,year1,gift from students";
                command.CommandText = quary;

                OleDbDataReader reader = command.ExecuteReader(); // קריאב מתוך הדאטה 
                while (reader.Read())
                {
                    // reader.Read();
                    if (!comboBox_trand.Items.Contains(reader["trands"].ToString()))
                        comboBox_trand.Items.Add(reader["trands"].ToString());
                    if (!comboBox_year.Items.Contains(reader["year1"].ToString()))
                        comboBox_year.Items.Add(reader["year1"].ToString());
                    if (!comboBox_gift.Items.Contains(reader["gift"].ToString()))
                        comboBox_gift.Items.Add(reader["gift"].ToString());
                }


                connection.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // בודק מספר סטודנטים ממגמה, שנה, מתנה שנרשמו לאגודה
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select  fname,lname,trands,year1 from students where trands= '" + comboBox_trand.Text + "' and gift='" + comboBox_gift.Text + "'and year1='" + comboBox_year.Text + "'";

                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                //סופא מהטבלה ומציג
                count = 0;
                count = dataGridView1.RowCount;
                count--;
                label1.Text = "Total = " + count.ToString();
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
            // בודק מספר סטודנטים ממגמה, שנה (בלי מתנה) שנרשמו לאגודה

            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select  fname,lname,trands,year1 from students where trands= '" + comboBox_trand.Text + "'and year1='" + comboBox_year.Text + "'";
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;

                //סופר מהטבלה ומציג
                count = 0;
                count = dataGridView1.RowCount;
                count--;
                label1.Text = "Total = " + count.ToString();
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }

        }

        private void comboBox_trand_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button_back_Click(object sender, EventArgs e)
        {
            // חוזר אחורה וסוגר את הדף הנוכחי
            this.Hide();
            menu f3 = new menu(label2.Text);
            f3.ShowDialog();
            this.Close();
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //cheack invnetory
            /* try
             {
                 connection.Open();
                 OleDbCommand command = connection.CreateCommand();
                 command.Connection = connection;


                 OleDbDataReader dr;
                 command.CommandText = "Select fname,lname from students";
                 dr = command.ExecuteReader();
                 listBox1.Items.Clear();

                 while (dr.Read())
                 {
                     listBox1.Items.Add(dr[0].ToString()+ "          " + dr[1].ToString());

                 }
                 connection.Close();


             }
             catch (Exception err)
             {
                 MessageBox.Show(err.Message);
                 connection.Close();

             }
             connection.Close();*/
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //clear 
            // listBox1.Items.Clear();
        }

        private void dataGridView1_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            dataGridView1.DoDragDrop(dataGridView1.CurrentCell.Value.ToString(), DragDropEffects.Copy);
            //copy data select

        }

        private void listBox1_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Text))
            //    e.Effect = DragDropEffects.Copy;
            //else
            //    e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, DragEventArgs e)
        {
            //listBox1.Items.Add(e.Data.GetData(DataFormats.Text));
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button_print_Click(object sender, EventArgs e)
        {
            // מדפיס לפורמט פי.די.אף ושומר על המחשב את הקובץ

            if (textBox1.Text != "")// בדיקת ראש דף שלא ריק
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
            }
            else
            {
                MessageBox.Show("Heder Empty !!!");
            }

        }
        private void button5_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            all_student f3 = new all_student(label2.Text);
            f3.ShowDialog();
            this.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }
    }
}

