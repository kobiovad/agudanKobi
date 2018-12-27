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
    public partial class report : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public report()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";

        }
        string table = "reports";

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button_back_Click(object sender, EventArgs e)
        {
            // חוזר אחורה וסוגר את הדף הנוכחי
            this.Hide();
           
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // שומר את כל השדות טקסט 
            try
            {
                connection.Open();

                OleDbCommand command = connection.CreateCommand();

                    command.Connection = connection;
                    command.CommandText = "insert into reports (name_report,date_event,strat_time,end_time,event_description,purpose_event,expect_people,event_requires,how_to_do_it,officials,Conclusions,year1) values('" + textBox1.Text + "','" + dateTimePicker1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + richTextBox2.Text + "', '" + richTextBox3.Text + "','" + textBox4.Text + "','" + richTextBox1.Text + "','" + richTextBox5.Text + "','" + richTextBox4.Text + "','" + richTextBox6.Text + "','" + DateTime.Now.ToString("yyyy") + "')";
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

        private void button3_Click(object sender, EventArgs e)
        {
            //ממלא את הטבלה בדוחות
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from reports ";

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
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            //מילוי נתונים בלחיצה על משבצת בטבלה
            textBox5.Visible = true;
            label14.Visible = true;
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
                textBox5.Text = row.Cells[1].Value.ToString();
                dateTimePicker1.Text = row.Cells[2].Value.ToString();
                textBox2.Text = row.Cells[3].Value.ToString();
                textBox3.Text = row.Cells[4].Value.ToString();
                richTextBox2.Text = row.Cells[5].Value.ToString();
                richTextBox3.Text = row.Cells[6].Value.ToString();
                textBox4.Text = row.Cells[7].Value.ToString();
                richTextBox1.Text = row.Cells[8].Value.ToString();
                richTextBox5.Text = row.Cells[9].Value.ToString();
                richTextBox4.Text = row.Cells[10].Value.ToString();
                richTextBox6.Text = row.Cells[11].Value.ToString();



            }
    }

        private void button_exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void report_Load(object sender, EventArgs e)
        {
            textBox5.Text = DateTime.Now.ToString("yyyy");
            checkBox1.Checked = true;
            richTextBox6.Enabled = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // עדכון דוח
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;

                string quary = "update reports set date_event='" + dateTimePicker1.Text + "',strat_time='" + textBox2.Text + "',end_time='" + textBox3.Text + "',event_description='" + richTextBox2.Text + "',purpose_event='" + richTextBox3.Text + "',expect_people='" + textBox4.Text + "',event_requires='" + richTextBox1.Text + "',how_to_do_it='" + richTextBox5.Text + "',officials='" + richTextBox4.Text + "',Conclusions='" + richTextBox6.Text + "' where name_report='" + textBox1.Text + "' and year1='" + textBox5.Text + "' ; ";
                command.CommandText = quary;
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

        private void button1_Click(object sender, EventArgs e)
        {
            // חיפוש אירוע לפי שם ושנה
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from reports where name_report='" + textBox1.Text + "' and year1='" + textBox5.Text + "' ; ";
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                dateTimePicker1.Text = (reader["date_event"].ToString());
                textBox2.Text = (reader["strat_time"].ToString());
                textBox3.Text = (reader["end_time"].ToString());
                richTextBox2.Text = (reader["event_description"].ToString());
                richTextBox3.Text = (reader["purpose_event"].ToString());
                textBox4.Text = (reader["expect_people"].ToString());
                richTextBox1.Text = (reader["event_requires"].ToString());
                richTextBox5.Text = (reader["how_to_do_it"].ToString());
                richTextBox2.Text = (reader["event_description"].ToString());
                richTextBox4.Text = (reader["officials"].ToString());
                richTextBox6.Text = (reader["Conclusions"].ToString());
           
                connection.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();

            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
            if (checkBox1.Checked == true)
            {
                checkBox1.Checked = true;
                richTextBox6.Enabled = false;
                label13.Visible = true;
            }
            else
            {
                checkBox1.Checked = false;
                richTextBox6.Enabled = true;
                label13.Visible = false;
            }
        }

        private void label13_MouseClick(object sender, MouseEventArgs e)
        {
           
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            //מחיקת תאים
            dateTimePicker1.Value = DateTime.Now;
            textBox2.Clear();
           textBox3.Clear();
            richTextBox2.Clear();
            richTextBox3.Clear();
            textBox4.Clear();
            richTextBox1.Clear();
            richTextBox5.Clear();
            richTextBox4.Clear();
            richTextBox6.Clear();
            textBox1.Clear();
            textBox5.Clear();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                DialogResult result = MessageBox.Show("Do you want to delelet?", "Alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string quary = "delete from reports where name_report='" + textBox1.Text + "' and year1='"+textBox5.Text+"'; ";
                   
                    command.CommandText = quary;
                    command.ExecuteNonQuery();
                    MessageBox.Show("Delete seccessful");

                    Refresh db = new Refresh(table);
                    dataGridView1.DataSource = db.refreshdata1();

                    connection.Close();
                }
                else
                {
                    MessageBox.Show("Not deleled", "Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void button_print_Click(object sender, EventArgs e)
        {
            // מדפיס לפורמט פי.די.אף ושומר על המחשב את הקובץ
            {
                DGVPrinter printer = new DGVPrinter();
                //DGVPrinter 
                printer.Title = textBox1.Text +"  "+textBox5.Text;//header
                printer.SubTitle = string.Format("Date:", DateTime.Now);
                printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
                printer.PageNumbers = true;
                printer.PageNumberInHeader = false;
                printer.PorportionalColumns = true;
                printer.HeaderCellAlignment = StringAlignment.Near;
                printer.Footer = "";//footer
                printer.FooterSpacing = 15;
                printer.PrintDataGridView(dataGridView1);

            }
        }
    }
}
