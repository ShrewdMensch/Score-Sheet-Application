using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing.Drawing2D;

using ButtonDesigner;



namespace AskIt_ScoreSheet_Project
{
    partial class MainMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMenu));
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.newRec = new ButtonDesigner.ButtonModified();
            this.existingRec = new ButtonDesigner.ButtonModified();
            this.results_btn = new ButtonDesigner.ButtonModified();
            this.passwordmgt_btn = new ButtonDesigner.ButtonModified();
            this.uploadScores_btn = new ButtonDesigner.ButtonModified();
            this.logOut = new ButtonDesigner.ButtonModified();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lbl_time = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(14, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(697, 60);
            this.label1.TabIndex = 0;
            this.label1.Text = "Hello";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Firebrick;
            this.label8.Font = new System.Drawing.Font("Mistral", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.YellowGreen;
            this.label8.Location = new System.Drawing.Point(244, 5);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(281, 49);
            this.label8.TabIndex = 29;
            this.label8.Text = "MAIN MENU";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label8.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Firebrick;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Peru;
            this.label3.Location = new System.Drawing.Point(-3, 439);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(760, 76);
            this.label3.TabIndex = 33;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Firebrick;
            this.button1.FlatAppearance.BorderSize = 3;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(701, 10);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 35);
            this.button1.TabIndex = 34;
            this.toolTip1.SetToolTip(this.button1, "Close");
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // newRec
            // 
            this.newRec.BackColor = System.Drawing.SystemColors.GrayText;
            this.newRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.newRec.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newRec.ForeColor = System.Drawing.Color.SkyBlue;
            this.newRec.Image = global::AskIt_ScoreSheet_Project.Properties.Resources.Misc_New_Database_icon;
            this.newRec.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.newRec.Location = new System.Drawing.Point(27, 145);
            this.newRec.Name = "newRec";
            this.newRec.Size = new System.Drawing.Size(209, 122);
            this.newRec.TabIndex = 43;
            this.newRec.Text = "New\r\nRecord";
            this.newRec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.newRec, "New Record");
            this.newRec.UseVisualStyleBackColor = false;
            this.newRec.Click += new System.EventHandler(this.newRec_Click);
            this.newRec.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // existingRec
            // 
            this.existingRec.BackColor = System.Drawing.Color.YellowGreen;
            this.existingRec.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.existingRec.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.existingRec.ForeColor = System.Drawing.Color.RoyalBlue;
            this.existingRec.Image = ((System.Drawing.Image)(resources.GetObject("existingRec.Image")));
            this.existingRec.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.existingRec.Location = new System.Drawing.Point(266, 145);
            this.existingRec.Name = "existingRec";
            this.existingRec.Size = new System.Drawing.Size(209, 122);
            this.existingRec.TabIndex = 43;
            this.existingRec.Text = "Existing\r\nRecords";
            this.existingRec.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.existingRec, "Existing Records");
            this.existingRec.UseVisualStyleBackColor = false;
            this.existingRec.Click += new System.EventHandler(this.existingRec_Click);
            this.existingRec.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // results_btn
            // 
            this.results_btn.BackColor = System.Drawing.SystemColors.GrayText;
            this.results_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.results_btn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.results_btn.ForeColor = System.Drawing.Color.SkyBlue;
            this.results_btn.Image = ((System.Drawing.Image)(resources.GetObject("results_btn.Image")));
            this.results_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.results_btn.Location = new System.Drawing.Point(502, 296);
            this.results_btn.Name = "results_btn";
            this.results_btn.Size = new System.Drawing.Size(209, 122);
            this.results_btn.TabIndex = 43;
            this.results_btn.Text = "Populate\r\nResults";
            this.results_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.results_btn, "Populate\r\nResults");
            this.results_btn.UseVisualStyleBackColor = false;
            this.results_btn.Click += new System.EventHandler(this.results_btn_Click);
            this.results_btn.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // passwordmgt_btn
            // 
            this.passwordmgt_btn.BackColor = System.Drawing.Color.IndianRed;
            this.passwordmgt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.passwordmgt_btn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordmgt_btn.ForeColor = System.Drawing.Color.SandyBrown;
            this.passwordmgt_btn.Image = global::AskIt_ScoreSheet_Project.Properties.Resources.Apps_preferences_desktop_use_password_icon;
            this.passwordmgt_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.passwordmgt_btn.Location = new System.Drawing.Point(266, 296);
            this.passwordmgt_btn.Name = "passwordmgt_btn";
            this.passwordmgt_btn.Size = new System.Drawing.Size(209, 122);
            this.passwordmgt_btn.TabIndex = 43;
            this.passwordmgt_btn.Text = "Manage\r\nPassword";
            this.passwordmgt_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.passwordmgt_btn, "Manage\r\nPassword");
            this.passwordmgt_btn.UseVisualStyleBackColor = false;
            this.passwordmgt_btn.Click += new System.EventHandler(this.passwordmgt_btn_Click);
            this.passwordmgt_btn.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // uploadScores_btn
            // 
            this.uploadScores_btn.BackColor = System.Drawing.Color.YellowGreen;
            this.uploadScores_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.uploadScores_btn.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uploadScores_btn.ForeColor = System.Drawing.Color.RoyalBlue;
            this.uploadScores_btn.Image = ((System.Drawing.Image)(resources.GetObject("uploadScores_btn.Image")));
            this.uploadScores_btn.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.uploadScores_btn.Location = new System.Drawing.Point(27, 296);
            this.uploadScores_btn.Name = "uploadScores_btn";
            this.uploadScores_btn.Size = new System.Drawing.Size(209, 122);
            this.uploadScores_btn.TabIndex = 43;
            this.uploadScores_btn.Text = "Upload\r\nScores";
            this.uploadScores_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.uploadScores_btn, "Upload Scores");
            this.uploadScores_btn.UseVisualStyleBackColor = false;
            this.uploadScores_btn.Click += new System.EventHandler(this.uploadScores_btn_Click);
            this.uploadScores_btn.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // logOut
            // 
            this.logOut.BackColor = System.Drawing.Color.IndianRed;
            this.logOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logOut.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold);
            this.logOut.ForeColor = System.Drawing.Color.SandyBrown;
            this.logOut.Image = global::AskIt_ScoreSheet_Project.Properties.Resources.logout_icon;
            this.logOut.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.logOut.Location = new System.Drawing.Point(502, 145);
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(209, 122);
            this.logOut.TabIndex = 42;
            this.logOut.Text = "Log\r\nOut";
            this.logOut.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.toolTip1.SetToolTip(this.logOut, "Log Out");
            this.logOut.UseVisualStyleBackColor = false;
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            this.logOut.MouseEnter += new System.EventHandler(this.speakWhenControlAreaEntered);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lbl_time
            // 
            this.lbl_time.Font = new System.Drawing.Font("DigifaceWide", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_time.ForeColor = System.Drawing.Color.SandyBrown;
            this.lbl_time.Location = new System.Drawing.Point(481, 179);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(10, 29);
            this.lbl_time.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Firebrick;
            this.label4.Font = new System.Drawing.Font("Mistral", 15.75F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.YellowGreen;
            this.label4.Location = new System.Drawing.Point(273, 465);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 26);
            this.label4.TabIndex = 39;
            this.label4.Text = "Powered by";
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Firebrick;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(393, 453);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 38;
            this.pictureBox2.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Firebrick;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(-6, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(745, 57);
            this.panel1.TabIndex = 44;
            this.panel1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(737, 514);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.newRec);
            this.Controls.Add(this.existingRec);
            this.Controls.Add(this.results_btn);
            this.Controls.Add(this.passwordmgt_btn);
            this.Controls.Add(this.uploadScores_btn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.logOut);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainMenu";
            this.Load += new System.EventHandler(this.MainMenu_Load);
            this.MouseHover += new System.EventHandler(this.MainMenu_MouseHover);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private ButtonModified logOut;
        private ButtonModified uploadScores_btn;
        private ButtonModified newRec;
        private ButtonModified existingRec;
        private ButtonModified passwordmgt_btn;
        private ButtonModified results_btn;
        private Panel panel1;

        public const int WM = 0xA1;
        public const int HT = 0x2;
        [DllImport ("User32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hwnd, int msg, int wParam, int lParam);

    }

    

}