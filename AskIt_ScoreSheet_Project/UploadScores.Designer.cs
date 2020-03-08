namespace AskIt_ScoreSheet_Project
{
    partial class UploadScores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UploadScores));
            this.studentList = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.currentClass = new System.Windows.Forms.ComboBox();
            this.studentListCaption = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.currentStudentGrpBox = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_saveToDb = new ButtonDesigner.ButtonModified();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txt_comment = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txt_teacherComment = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.toolTip2 = new System.Windows.Forms.ToolTip(this.components);
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            this.studentListCaption.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.currentStudentGrpBox.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // studentList
            // 
            this.studentList.BackColor = System.Drawing.Color.Cornsilk;
            this.studentList.Font = new System.Drawing.Font("News706 BT", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentList.ForeColor = System.Drawing.Color.Tomato;
            this.studentList.FormattingEnabled = true;
            this.studentList.ItemHeight = 19;
            this.studentList.Location = new System.Drawing.Point(8, 28);
            this.studentList.Name = "studentList";
            this.studentList.Size = new System.Drawing.Size(187, 289);
            this.studentList.Sorted = true;
            this.studentList.TabIndex = 0;
            this.studentList.SelectedIndexChanged += new System.EventHandler(this.studentList_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox1.Controls.Add(this.currentClass);
            this.groupBox1.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold);
            this.groupBox1.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.groupBox1.Location = new System.Drawing.Point(32, 86);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(179, 54);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Class Category";
            // 
            // currentClass
            // 
            this.currentClass.BackColor = System.Drawing.Color.White;
            this.currentClass.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentClass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.currentClass.FormattingEnabled = true;
            this.currentClass.Location = new System.Drawing.Point(26, 22);
            this.currentClass.Name = "currentClass";
            this.currentClass.Size = new System.Drawing.Size(128, 26);
            this.currentClass.TabIndex = 1;
            this.currentClass.SelectedIndexChanged += new System.EventHandler(this.currentClass_SelectedIndexChanged);
            // 
            // studentListCaption
            // 
            this.studentListCaption.BackColor = System.Drawing.Color.Cornsilk;
            this.studentListCaption.Controls.Add(this.studentList);
            this.studentListCaption.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.studentListCaption.Location = new System.Drawing.Point(26, 163);
            this.studentListCaption.Name = "studentListCaption";
            this.studentListCaption.Size = new System.Drawing.Size(202, 317);
            this.studentListCaption.TabIndex = 3;
            this.studentListCaption.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label7.Font = new System.Drawing.Font("Mistral", 15.75F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Red;
            this.label7.Location = new System.Drawing.Point(350, 664);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(94, 26);
            this.label7.TabIndex = 42;
            this.label7.Text = "Powered by";
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Peru;
            this.label8.Location = new System.Drawing.Point(0, 629);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(923, 72);
            this.label8.TabIndex = 40;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label9.Dock = System.Windows.Forms.DockStyle.Top;
            this.label9.Font = new System.Drawing.Font("Mistral", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.PeachPuff;
            this.label9.Location = new System.Drawing.Point(0, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(923, 71);
            this.label9.TabIndex = 43;
            this.label9.Text = "YETKEM HIGH SCHOOL";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label10.AutoSize = true;
            this.label10.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.label10.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Yellow;
            this.label10.Location = new System.Drawing.Point(731, 670);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(171, 19);
            this.label10.TabIndex = 44;
            this.label10.Text = "Designed By Abdulazeez";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.groupBox2.BackColor = System.Drawing.Color.Cornsilk;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.Black;
            this.groupBox2.Location = new System.Drawing.Point(429, 35);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 215);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Student Image";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Cornsilk;
            this.pictureBox1.Location = new System.Drawing.Point(15, 30);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(167, 166);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            // 
            // currentStudentGrpBox
            // 
            this.currentStudentGrpBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentStudentGrpBox.BackColor = System.Drawing.Color.Cornsilk;
            this.currentStudentGrpBox.Controls.Add(this.panel1);
            this.currentStudentGrpBox.Controls.Add(this.btn_saveToDb);
            this.currentStudentGrpBox.Controls.Add(this.groupBox3);
            this.currentStudentGrpBox.Controls.Add(this.tabControl1);
            this.currentStudentGrpBox.Controls.Add(this.groupBox2);
            this.currentStudentGrpBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.currentStudentGrpBox.Font = new System.Drawing.Font("Times New Roman", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentStudentGrpBox.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.currentStudentGrpBox.Location = new System.Drawing.Point(276, 83);
            this.currentStudentGrpBox.Name = "currentStudentGrpBox";
            this.currentStudentGrpBox.Size = new System.Drawing.Size(639, 543);
            this.currentStudentGrpBox.TabIndex = 2;
            this.currentStudentGrpBox.TabStop = false;
            this.currentStudentGrpBox.Text = "groupBox2";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Location = new System.Drawing.Point(565, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(20, 11);
            this.panel1.TabIndex = 0;
            this.panel1.Visible = false;
            // 
            // btn_saveToDb
            // 
            this.btn_saveToDb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_saveToDb.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.btn_saveToDb.FlatAppearance.BorderSize = 5;
            this.btn_saveToDb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_saveToDb.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_saveToDb.ForeColor = System.Drawing.Color.Snow;
            this.btn_saveToDb.Image = global::AskIt_ScoreSheet_Project.Properties.Resources.Save_icon;
            this.btn_saveToDb.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_saveToDb.Location = new System.Drawing.Point(202, 498);
            this.btn_saveToDb.Name = "btn_saveToDb";
            this.btn_saveToDb.Size = new System.Drawing.Size(96, 37);
            this.btn_saveToDb.TabIndex = 46;
            this.btn_saveToDb.Text = "S&ave";
            this.btn_saveToDb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolTip2.SetToolTip(this.btn_saveToDb, "Save Record\r\ninto DataBase");
            this.btn_saveToDb.UseVisualStyleBackColor = false;
            this.btn_saveToDb.Click += new System.EventHandler(this.btn_saveToDb_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(16, 45);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(381, 290);
            this.groupBox3.TabIndex = 31;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Subject(s) Offered";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(98, 358);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(433, 122);
            this.tabControl1.TabIndex = 30;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage1.Controls.Add(this.txt_comment);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage1.Location = new System.Drawing.Point(4, 27);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(425, 91);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Principal Comment";
            this.toolTip2.SetToolTip(this.tabPage1, "Principal\'s Comment Area");
            // 
            // txt_comment
            // 
            this.txt_comment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_comment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_comment.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_comment.Location = new System.Drawing.Point(88, 9);
            this.txt_comment.Margin = new System.Windows.Forms.Padding(4);
            this.txt_comment.MaxLength = 90;
            this.txt_comment.Multiline = true;
            this.txt_comment.Name = "txt_comment";
            this.txt_comment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_comment.Size = new System.Drawing.Size(324, 61);
            this.txt_comment.TabIndex = 30;
            this.toolTip1.SetToolTip(this.txt_comment, "Comment on Academic Performance.\r\nNote: Single and double quotes are not valid En" +
        "tries!");
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Peru;
            this.label11.Location = new System.Drawing.Point(5, 16);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(78, 19);
            this.label11.TabIndex = 29;
            this.label11.Text = "Comment:";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.Cornsilk;
            this.tabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.tabPage2.Controls.Add(this.txt_teacherComment);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Font = new System.Drawing.Font("Times New Roman", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabPage2.Location = new System.Drawing.Point(4, 27);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(425, 91);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Class Teacher Comment";
            this.toolTip2.SetToolTip(this.tabPage2, "Teacher\'s Comment Area");
            // 
            // txt_teacherComment
            // 
            this.txt_teacherComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txt_teacherComment.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_teacherComment.ForeColor = System.Drawing.Color.DarkSeaGreen;
            this.txt_teacherComment.Location = new System.Drawing.Point(88, 9);
            this.txt_teacherComment.Margin = new System.Windows.Forms.Padding(4);
            this.txt_teacherComment.MaxLength = 90;
            this.txt_teacherComment.Multiline = true;
            this.txt_teacherComment.Name = "txt_teacherComment";
            this.txt_teacherComment.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txt_teacherComment.Size = new System.Drawing.Size(324, 61);
            this.txt_teacherComment.TabIndex = 32;
            this.txt_teacherComment.Text = "a";
            this.toolTip1.SetToolTip(this.txt_teacherComment, "Comment on Academic Performance.\r\nNote: Single and double quotes are not valid En" +
        "tries!");
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.BackColor = System.Drawing.Color.Cornsilk;
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Peru;
            this.label12.Location = new System.Drawing.Point(5, 16);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(78, 19);
            this.label12.TabIndex = 31;
            this.label12.Text = "Comment:";
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 5000;
            this.toolTip1.AutoPopDelay = 50000;
            this.toolTip1.ForeColor = System.Drawing.Color.LawnGreen;
            this.toolTip1.InitialDelay = 20;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.ReshowDelay = 1000;
            this.toolTip1.ShowAlways = true;
            this.toolTip1.ToolTipTitle = "Entry Format";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.pictureBox2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.pictureBox2.Image = global::AskIt_ScoreSheet_Project.Properties.Resources.New_askit_logo;
            this.pictureBox2.Location = new System.Drawing.Point(470, 652);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(83, 38);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 41;
            this.pictureBox2.TabStop = false;
            // 
            // UploadScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Cornsilk;
            this.ClientSize = new System.Drawing.Size(923, 701);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.studentListCaption);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.currentStudentGrpBox);
            this.Controls.Add(this.label8);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UploadScores";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UploadScores";
            this.Load += new System.EventHandler(this.UploadScores_Load);
            this.SizeChanged += new System.EventHandler(this.UploadScores_SizeChanged);
            this.groupBox1.ResumeLayout(false);
            this.studentListCaption.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.currentStudentGrpBox.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox studentList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox currentClass;
        private System.Windows.Forms.GroupBox studentListCaption;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox currentStudentGrpBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txt_comment;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TextBox txt_teacherComment;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip2;
        private System.Windows.Forms.GroupBox groupBox3;
        private ButtonDesigner.ButtonModified btn_saveToDb;
        private System.Windows.Forms.Panel panel1;
    }
}