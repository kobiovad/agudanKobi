using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class loadingbar : Form
    {
        public loadingbar(string username)
        {
            InitializeComponent();
            label4.Text = username;
        }
        
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            rectangleShape2.Width += 5;
               // progressBar1.Increment(1);
            if (rectangleShape2.Width >= 256)
            {
                this.Hide();
                timer1.Stop();
                menu log = new menu(label4.Text);
                log.ShowDialog();
                this.Close();
            }
        }
    }
}
