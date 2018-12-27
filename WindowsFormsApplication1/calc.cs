using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class calc : Form
    {
        public calc()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try 
            {
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                    double a, b, c;
                   // button1.BackColor = Color.Yellow;
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = a * b;
                    label1.Text = c.ToString();
                    label2.Text = "*";
                }
            else
                MessageBox.Show("Fill Numbers in text");
            }
            catch (Exception err)
            {
                MessageBox.Show("Fill Numbers in text");

            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                    double a, b, c;
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = a / b;
                    label1.Text = c.ToString();
                    label2.Text = "/";
                }
                else
                    MessageBox.Show("Fill Numbers in text");
        }
            catch (Exception err)
            {
                MessageBox.Show("Fill Numbers in text");

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                    double a, b, c;
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = a + b;
                    label1.Text = c.ToString();
                    label2.Text = "+";
                }
                else
                    MessageBox.Show("Fill Numbers in text");
}
            catch (Exception err)
            {
                MessageBox.Show("Fill Numbers in text");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text != "" || textBox2.Text != "")
                {
                    double a, b, c;
                    a = double.Parse(textBox1.Text);
                    b = double.Parse(textBox2.Text);
                    c = a - b;
                    label1.Text = c.ToString();
                    label2.Text = "-";
                } else
                    MessageBox.Show("Fill Numbers in text");
     
                // else
            }
            catch (Exception )
            {
                    MessageBox.Show("Fill Numbers in text");
              //  MessageBox.Show(err.Message);
               
            }
        }

        private void textBox1_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void textBox2_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void label4_MouseClick(object sender, MouseEventArgs e)
        {
            label4.Visible = false;
        }

        private void label5_MouseClick(object sender, MouseEventArgs e)
        {
            label5.Visible = false;
        }

        private void calc_Load(object sender, EventArgs e)
        {
            
        }
    }
}
