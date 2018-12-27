namespace WindowsFormsApplication1
{
    partial class end_shift
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(end_shift));
            this.lblSecond = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lblDate = new System.Windows.Forms.Label();
            this.lblDay = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.lblDatemonth = new System.Windows.Forms.Label();
            this.lblDateday = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbtimemin = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button_exit = new System.Windows.Forms.Button();
            this.button_back = new System.Windows.Forms.Button();
            this.lbltimeall = new System.Windows.Forms.Label();
            this.lbldataall = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSecond
            // 
            this.lblSecond.AutoSize = true;
            this.lblSecond.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSecond.Font = new System.Drawing.Font("DS-Digital", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSecond.ForeColor = System.Drawing.Color.White;
            this.lblSecond.Location = new System.Drawing.Point(346, 95);
            this.lblSecond.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSecond.Name = "lblSecond";
            this.lblSecond.Size = new System.Drawing.Size(70, 49);
            this.lblSecond.TabIndex = 34;
            this.lblSecond.Text = "22";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Turquoise;
            this.button1.Font = new System.Drawing.Font("Modern No. 20", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(38, 136);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(317, 93);
            this.button1.TabIndex = 41;
            this.button1.Text = "Goog Morninig";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDate.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.White;
            this.lblDate.Location = new System.Drawing.Point(374, 44);
            this.lblDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(42, 19);
            this.lblDate.TabIndex = 36;
            this.lblDate.Text = "2016";
            this.lblDate.Visible = false;
            // 
            // lblDay
            // 
            this.lblDay.AutoSize = true;
            this.lblDay.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDay.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDay.ForeColor = System.Drawing.Color.White;
            this.lblDay.Location = new System.Drawing.Point(423, 34);
            this.lblDay.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDay.Name = "lblDay";
            this.lblDay.Size = new System.Drawing.Size(275, 61);
            this.lblDay.TabIndex = 35;
            this.lblDay.Text = "SATURDAY";
            // 
            // lblTime
            // 
            this.lblTime.AutoSize = true;
            this.lblTime.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTime.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.ForeColor = System.Drawing.Color.White;
            this.lblTime.Location = new System.Drawing.Point(388, 25);
            this.lblTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(28, 19);
            this.lblTime.TabIndex = 33;
            this.lblTime.Text = "HH";
            this.lblTime.Visible = false;
            // 
            // timer
            // 
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // lblDatemonth
            // 
            this.lblDatemonth.AutoSize = true;
            this.lblDatemonth.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDatemonth.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDatemonth.ForeColor = System.Drawing.Color.White;
            this.lblDatemonth.Location = new System.Drawing.Point(413, 44);
            this.lblDatemonth.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDatemonth.Name = "lblDatemonth";
            this.lblDatemonth.Size = new System.Drawing.Size(50, 19);
            this.lblDatemonth.TabIndex = 45;
            this.lblDatemonth.Text = "JUNE ";
            this.lblDatemonth.Visible = false;
            // 
            // lblDateday
            // 
            this.lblDateday.AutoSize = true;
            this.lblDateday.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblDateday.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDateday.ForeColor = System.Drawing.Color.White;
            this.lblDateday.Location = new System.Drawing.Point(461, 44);
            this.lblDateday.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDateday.Name = "lblDateday";
            this.lblDateday.Size = new System.Drawing.Size(28, 19);
            this.lblDateday.TabIndex = 44;
            this.lblDateday.Text = "25";
            this.lblDateday.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(413, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 19);
            this.label1.TabIndex = 43;
            this.label1.Text = ":";
            this.label1.Visible = false;
            // 
            // lbtimemin
            // 
            this.lbtimemin.AutoSize = true;
            this.lbtimemin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbtimemin.Font = new System.Drawing.Font("DS-Digital", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbtimemin.ForeColor = System.Drawing.Color.White;
            this.lbtimemin.Location = new System.Drawing.Point(423, 25);
            this.lbtimemin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbtimemin.Name = "lbtimemin";
            this.lbtimemin.Size = new System.Drawing.Size(28, 19);
            this.lbtimemin.TabIndex = 42;
            this.lbtimemin.Text = "MM";
            this.lbtimemin.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(72, 231);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(324, 22);
            this.label3.TabIndex = 39;
            this.label3.Text = "All rights reserved to Kobi Ovadia ";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.Font = new System.Drawing.Font("Modern No. 20", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(38, 136);
            this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(317, 93);
            this.button2.TabIndex = 46;
            this.button2.Text = "Good Bye";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(41, 231);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(35, 17);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 40;
            this.pictureBox3.TabStop = false;
            // 
            // button_exit
            // 
            this.button_exit.BackColor = System.Drawing.Color.Turquoise;
            this.button_exit.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_exit.ForeColor = System.Drawing.Color.Red;
            this.button_exit.Image = ((System.Drawing.Image)(resources.GetObject("button_exit.Image")));
            this.button_exit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_exit.Location = new System.Drawing.Point(581, 188);
            this.button_exit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_exit.Name = "button_exit";
            this.button_exit.Size = new System.Drawing.Size(130, 41);
            this.button_exit.TabIndex = 38;
            this.button_exit.Text = "Exit";
            this.button_exit.UseVisualStyleBackColor = false;
            this.button_exit.Click += new System.EventHandler(this.button_exit_Click_1);
            // 
            // button_back
            // 
            this.button_back.BackColor = System.Drawing.Color.Turquoise;
            this.button_back.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_back.ForeColor = System.Drawing.Color.Blue;
            this.button_back.Image = ((System.Drawing.Image)(resources.GetObject("button_back.Image")));
            this.button_back.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button_back.Location = new System.Drawing.Point(424, 188);
            this.button_back.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.button_back.Name = "button_back";
            this.button_back.Size = new System.Drawing.Size(130, 41);
            this.button_back.TabIndex = 37;
            this.button_back.Text = "Back";
            this.button_back.UseVisualStyleBackColor = false;
            this.button_back.Click += new System.EventHandler(this.button_back_Click_1);
            // 
            // lbltimeall
            // 
            this.lbltimeall.AutoSize = true;
            this.lbltimeall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbltimeall.Font = new System.Drawing.Font("DS-Digital", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltimeall.ForeColor = System.Drawing.Color.White;
            this.lbltimeall.Location = new System.Drawing.Point(41, 9);
            this.lbltimeall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbltimeall.Name = "lbltimeall";
            this.lbltimeall.Size = new System.Drawing.Size(323, 120);
            this.lbltimeall.TabIndex = 47;
            this.lbltimeall.Text = "HH:MM";
            // 
            // lbldataall
            // 
            this.lbldataall.AutoSize = true;
            this.lbldataall.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbldataall.Font = new System.Drawing.Font("DS-Digital", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldataall.ForeColor = System.Drawing.Color.White;
            this.lbldataall.Location = new System.Drawing.Point(424, 95);
            this.lbldataall.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbldataall.Name = "lbldataall";
            this.lbldataall.Size = new System.Drawing.Size(351, 61);
            this.lbldataall.TabIndex = 48;
            this.lbldataall.Text = "2016 june 25";
            // 
            // end_shift
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(835, 270);
            this.Controls.Add(this.lblDay);
            this.Controls.Add(this.lblDateday);
            this.Controls.Add(this.lblSecond);
            this.Controls.Add(this.lblDate);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblDatemonth);
            this.Controls.Add(this.lbtimemin);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.button_exit);
            this.Controls.Add(this.button_back);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbldataall);
            this.Controls.Add(this.lbltimeall);
            this.Font = new System.Drawing.Font("DS-Digital", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "end_shift";
            this.Text = "end_shift";
            this.Load += new System.EventHandler(this.Form5_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSecond;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Label lblDay;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label lblDatemonth;
        private System.Windows.Forms.Label lblDateday;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbtimemin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button button_exit;
        private System.Windows.Forms.Button button_back;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbltimeall;
        private System.Windows.Forms.Label lbldataall;
    }
}