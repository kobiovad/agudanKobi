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


namespace WindowsFormsApplication1
{
    
    public partial class menu : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        private string table = "students";
        public menu(string username)
        {
            InitializeComponent(); 
            label5.Text =username;

            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=students.accdb;" + "Persist Security Info=False";
     }
        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
           // this.Close();
        }
        string gender, gift;
        int countgift,flag=2;
        int ch = 1;
        Image File;
        string add="add";
        string edit= "edit";
        string delete= "delete";
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {

        }

        private void City_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //הוספת סטודנט
            try
            {
                connection.Open();

                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                
                command.CommandText = "insert into students (id,fname,lname,tel,email,trands,year1,gander,picture,gift,how_pay) values('" + double.Parse(txtID.Text) + "','" + txtFirstName.Text + "','" + txtLastName.Text + "','" + txtTel.Text + "','" + txtEmail.Text + "', '" + trand_comboBox.Text + "','" + year_comboBox.Text + "','" + gender + "','" + textBoximage_path.Text + "','" + gift + "','" + comboBox_cash.Text + "')";
                command.ExecuteNonQuery();
                 
                //בדיקה מה התקבל במתנה וגריעה מהמלאי
                if (flag == 1)
                {
                    command.CommandText = "update gift set bag= " + countgift.ToString() + ";";
                    command.ExecuteNonQuery();
                    label3.Text = countgift.ToString();
                    flag = 2;
                    
                }
                else if (flag == 0)
                {
                    command.CommandText = "update gift set speaker= " + countgift.ToString() + ";";
                    command.ExecuteNonQuery();
                    label4.Text = countgift.ToString();
                    flag = 2;
                }

                        MessageBox.Show("Data save");

                Refresh db = new Refresh(table);
                dataGridView1.DataSource = db.refreshdata1();

                //מחיקת תאים
                txtID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtTel.Clear();
                txtEmail.Clear();
                male_radioButton.Checked = false;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                textBox_edit.Clear();
                textBoximage_path.Clear();
                pictureBox1.Visible = false;
                year_comboBox.SelectedIndex = -1;
                trand_comboBox.SelectedIndex = -1;

                connection.Close();
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void male_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            gender = "male";

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            gender = "female";
        }

        private void txtTel_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, EventArgs e)
        {

        }

        private void year_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void browse_Click(object sender, EventArgs e)
        {
            //add picrut from folder to access table smartphones
            openFileDialog1.Title = "view picture";
            openFileDialog1.InitialDirectory = @"C:\Users\Kobi\Desktop\csharp\WindowsFormsApplication1\WindowsFormsApplication1\bin\x64\Debug";
            openFileDialog1.Filter = "picture files |*.jpg| all files |*.*";
            openFileDialog1.FilterIndex = 1;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
            pictureBox1.Visible = true;
                textBoximage_path.Text = deleteshash(openFileDialog1.FileName);
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
            }


        }
        private string deleteshash(string str)
        {
            //fonction for text pictur
            string str_new = "";
            int mikum = str.LastIndexOf('\\');
            str_new = str.Substring(mikum + 1);
            return str_new;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
           
        }

        private void button_edit_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                if (label5.Text == "kobi")
                {
                    string quary = "update students set id='"+txtID.Text+"',fname='" + txtFirstName.Text + "',lname='" + txtLastName.Text + "',tel='" + txtTel.Text + "',email='" + txtEmail.Text + "',trands='" + trand_comboBox.Text + "',year1='"+year_comboBox.Text+ "',how_pay='"+comboBox_cash.Text+ "',gander='"+gender+"',picture='"+textBoximage_path.Text+ "',gift='" + gift + "' where id=" + int.Parse(textBox_edit.Text) + "; ";
                    command.CommandText = quary;

                }
                else
                {
                    string quary = "update students set fname='" + txtFirstName.Text + "',lname='" + txtLastName.Text + "',tel='" + txtTel.Text + "',email='" + txtEmail.Text + "' where id=" + int.Parse(textBox_edit.Text) + "; ";
                    command.CommandText = quary;

                }

                command.ExecuteNonQuery();
                MessageBox.Show("Data Edit seccessful");

                Refresh db = new Refresh(table);
                dataGridView1.DataSource = db.refreshdata1();

                txtID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtTel.Clear();
                txtEmail.Clear();
                male_radioButton.Checked = false;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                textBox_edit.Clear();
                year_comboBox.SelectedIndex = -1;
                trand_comboBox.SelectedIndex = -1;
                pictureBox1.Visible = false;
                textBoximage_path.Clear();
                connection.Close();
               
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void button_delete_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                DialogResult result = MessageBox.Show("Do you want to delelet?", "alert", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    string quary = "delete from students where id=" + int.Parse(textBox_edit.Text) + "; ";
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

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Hide();
            inventory f2 = new inventory(label5.Text);
             f2.ShowDialog();
           
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
            // בדיקה האם המשתמש אדמין אם כן נפתח פאנל ניהול
            if (label5.Text == "kobi")
            {
                aDMINToolStripMenuItem.Visible = true;
                sUBADMINToolStripMenuItem.Visible = true;
                button2.Visible = true;
                button6.Visible = true;
                button_delete.Visible = true;
            }
            if (label5.Text == "maria") // בדיקה בשביל סאב אדמין
            {
                sUBADMINToolStripMenuItem.Visible = true;
                button2.Visible = true;
                button_delete.Visible = true;
            }

            try // הצגת מלאי של המתנות
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from gift ";

                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    label3.Text= (reader["bag"].ToString());
                    label4.Text = (reader["speaker"].ToString());
                    
                }

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }
        
        // חיסור מלאי מתנות בהתאם לבחירה
        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            gift = "bag";
            flag = 1;
            countgift = int.Parse(label3.Text)-1;
         
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            gift = "speaker";
            flag = 0;
            countgift = int.Parse(label4.Text) - 1;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            gift = "not received";
            flag = 2;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // קריאה למילוי טבלת רשת לפי שורות ועמודות
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
                textBox_edit.Text = row.Cells[0].Value.ToString();
                txtFirstName.Text = row.Cells[1].Value.ToString();
                txtLastName.Text = row.Cells[2].Value.ToString();
                txtTel.Text = row.Cells[3].Value.ToString();
                txtEmail.Text = row.Cells[4].Value.ToString();
                trand_comboBox.Text = row.Cells[5].Value.ToString();
                year_comboBox.Text = row.Cells[6].Value.ToString();
                string strfemale = row.Cells[7].Value.ToString();
                textBoximage_path.Text = row.Cells[8].Value.ToString();
                string strgift = row.Cells[9].Value.ToString();
                txtID.Text = textBox_edit.Text;
                comboBox_cash.Text = row.Cells[10].Value.ToString();

                try // בדיקה אם תיבה ריקה במקום ששמור לתמונה 
                {
                    pictureBox1.Visible = true;
                    pictureBox1.Image = Image.FromFile(row.Cells[8].Value.ToString());
                }
                catch
                {
                    pictureBox1.Visible = false;
                }
               
                //הצגת כפתורים בהתאם לטבלה 
                if (strgift == "bag")
                {
                    radioButton3.Checked = true;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                }
                else if (strgift == "speaker")
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = true;
                    radioButton5.Checked = false;
                }
                else if (strgift == "not received")
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = true;
                }
                else
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                }

                if (strfemale == "male")
                {
                    radioButton1.Checked = false;
                    male_radioButton.Checked = true;
                }
                else if (strfemale == "female")
                {
                    radioButton1.Checked = true;
                    male_radioButton.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    male_radioButton.Checked = false;
                }

                // אם יוזר הוא מנהל הכל יהיה ניתן לעריכה
                if (label5.Text != "kobi")
                {
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton5.Enabled = false;
                    radioButton1.Enabled = false;
                    male_radioButton.Enabled = false;
                    comboBox_cash.Enabled = false;
                    txtID.Enabled = false;
                    trand_comboBox.Enabled = false;
                    year_comboBox.Enabled = false;
                    comboBox_cash.Enabled = false;
                    browse.Enabled = false;
                }
                else
                {
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton1.Enabled = true;
                    male_radioButton.Enabled = true;
                    comboBox_cash.Enabled = true;
                    txtID.Enabled = true;
                    trand_comboBox.Enabled = true;
                    year_comboBox.Enabled = true;
                    comboBox_cash.Enabled = true;
                    browse.Enabled = true;
                }
            }
        }

        private void textBox_edit_TextChanged(object sender, EventArgs e)
        {
            label9.Visible = false;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBoximage_path_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_checkid_Click(object sender, EventArgs e)
        {
            // בדיקת תקינות ת.ז לפי בנאי
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from students where id=" + int.Parse(txtID.Text) + "";

                id i = new id(txtID.Text);

                if (i.goodid())
                {
                    button4.Visible = true;
                    button5.Visible = false;
                    button_checkid.Visible = false;

                    MessageBox.Show("id good !");
                    connection.Close();
                }
                else
                {
                    button4.Visible = false;
                    button5.Visible = true;
                    button_checkid.Visible = false;
                    MessageBox.Show("id incorrect !");
                    connection.Close();
                }
                
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();

            }
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            // פותח פורם חדש וסוגר את הנוכחי
            this.Hide();
            inventory f2 = new inventory(label2.Text);
            f2.ShowDialog();
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // יציאה מהתוכנה 
            Application.Exit();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //החלפת כפתורי אייקון
            button_checkid.Visible = true;
            button4.Visible = false;
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
           
        }

        private void button_clear_Click(object sender, EventArgs e)
        {
            //מחיקת כל התאים והחזרה למצב רגיל 
            label9.Visible = true;
            txtID.Enabled = true;
            trand_comboBox.Enabled = true;
            year_comboBox.Enabled = true;
            comboBox_cash.Enabled = true;
            browse.Enabled = true;
            txtID.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtTel.Clear();
            txtEmail.Clear();
            male_radioButton.Checked = false;
            radioButton1.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            textBox_edit.Clear();
            textBoximage_path.Clear();
            pictureBox1.Visible = false;
            year_comboBox.SelectedIndex = -1;
            trand_comboBox.SelectedIndex = -1;
            comboBox_cash.SelectedIndex = -1;
            male_radioButton.Enabled = true;
            radioButton1.Enabled = true;
            radioButton3.Enabled = true;
            radioButton4.Enabled = true;
            radioButton5.Enabled = true;
        }

        private void studentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // בדיקת סטודנט לפי ת.ז בלבד והצגה בכל הפרמטרים
            pictureBox1.Visible = true;
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from students where id=" + int.Parse(textBox_edit.Text) + "";
                OleDbDataReader reader = command.ExecuteReader();

                reader.Read();

                txtID.Text = (reader["id"].ToString());
                txtFirstName.Text = (reader["fname"].ToString());
                txtLastName.Text = (reader["lname"].ToString());
                txtTel.Text = (reader["tel"].ToString());
                txtEmail.Text = (reader["email"].ToString());
                trand_comboBox.Text = (reader["trands"].ToString());
                comboBox_cash.Text = (reader["how_pay"].ToString());
                year_comboBox.Text = (reader["year1"].ToString());
                string strfemale = (reader["gander"].ToString());
                string strgift = (reader["gift"].ToString());
                //label8.Text = strgift;
                try
                {
                    // בדיקה אם יש תמונה נציג אחרת לא
                    pictureBox1.Image = Image.FromFile(reader["picture"].ToString());
                    connection.Close();
                }
                catch
                {
                    pictureBox1.Visible=false;
                }

                // אם משתמש אדמין יכול לערוך הכל 
                if (label5.Text != "kobi")
                {
                    radioButton3.Enabled = false;
                    radioButton4.Enabled = false;
                    radioButton5.Enabled = false;
                    radioButton1.Enabled = false;
                    male_radioButton.Enabled = false;
                    comboBox_cash.Enabled = false;
                    txtID.Enabled = false;
                    trand_comboBox.Enabled = false;
                    year_comboBox.Enabled = false;
                    comboBox_cash.Enabled = false;
                    browse.Enabled = false;
                }
                else
                {
                    radioButton3.Enabled = true;
                    radioButton4.Enabled = true;
                    radioButton5.Enabled = true;
                    radioButton1.Enabled = true;
                    male_radioButton.Enabled = true;
                    comboBox_cash.Enabled = true;
                    txtID.Enabled = true;
                    trand_comboBox.Enabled = true;
                    year_comboBox.Enabled = true;
                    comboBox_cash.Enabled = true;
                    browse.Enabled = true;
                }

                if (strgift=="bag")
                {
                    radioButton3.Checked = true;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                }
                else if(strgift=="speaker")
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = true;
                    radioButton5.Checked = false;
                }
                else if(strgift== "not received")
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = true;

                }
                else
                {
                    radioButton3.Checked = false;
                    radioButton4.Checked = false;
                    radioButton5.Checked = false;
                }
                if (strfemale=="female")
                {
                    radioButton1.Checked = true;
                    male_radioButton.Checked = false;
                }
                else
                {
                    radioButton1.Checked = false;
                    male_radioButton.Checked = true;
                }
                
                connection.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();

            }
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label9_MouseClick(object sender, MouseEventArgs e)
        {
            label9.Visible = false;
        }

        private void textBox_edit_MouseClick(object sender, MouseEventArgs e)
        {
            label9.Visible = false;
        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void enterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // פותח פורם חדש וסוגר את הנוכחי
            start_shift f3 = new start_shift(label5.Text);
            f3.ShowDialog();
           
        }

        private void logutTimeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // פותח פורם חדש 
            end_shift f3 = new end_shift(label5.Text);
            f3.ShowDialog();
        }

        private void editDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void aDMINToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //לחיצה על כפתור אדמין במניו-בר יפתח כפתורים חדשים אשר היו חסומים
            // לחיצה חוזרת תחביא אותם שוב
            if (ch == 2)
            {
                button2.Visible = true;
                button_delete.Visible = true;
                button6.Visible = true;
                ch = 1;
            }
            else
            {
                button2.Visible = false;
                button_delete.Visible = false;
                button6.Visible = false;
                ch = 2;
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            // פותח פורם חדש 
            data_edit f3 = new data_edit(label5.Text);
            f3.ShowDialog();
        }

        private void editDataToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // פותח פורם חדש 
            data_edit f3 = new data_edit(label5.Text);
            f3.ShowDialog();
        }

        private void inventoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // פותח פורם של מלאי
            this.Hide();
            inventory f2 = new inventory(label5.Text);
            f2.ShowDialog();
        }

        private void creaeteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void deleteUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_user m1 = new manage_user(delete);
            m1.ShowDialog();
        }

        private void newUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_user m1 = new manage_user(add);
            m1.ShowDialog();


        }

        private void editUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            manage_user m1 = new manage_user(edit);
            m1.ShowDialog();

        }

        private void reportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            report f3 = new report();
            f3.ShowDialog();
            
        }

        private void button_calc_Click(object sender, EventArgs e)
        {
            calc cal1 = new calc();
            cal1.ShowDialog();
        }

        private void logoffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            login f2 = new login();
            f2.ShowDialog();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button_checkid.Visible = true;
            button5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // מילוי של הטבלת רשת
            try
            {
                connection.Open();
                OleDbCommand command = connection.CreateCommand();
                command.Connection = connection;
                command.CommandText = "select * from students ";
              
                
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
               
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                txtID.Clear();
                txtFirstName.Clear();
                txtLastName.Clear();
                txtTel.Clear();
                txtEmail.Clear();
                male_radioButton.Checked = false;
                radioButton1.Checked = false;
                radioButton3.Checked = false;
                radioButton4.Checked = false;
                radioButton5.Checked = false;
                textBox_edit.Clear();
                year_comboBox.SelectedIndex = -1;
                trand_comboBox.SelectedIndex = -1;
                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                connection.Close();
            }
        }
    }
}
