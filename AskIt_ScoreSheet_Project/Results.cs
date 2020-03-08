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
using System.Data.SQLite;
using System.IO;


namespace AskIt_ScoreSheet_Project
{
    public partial class Results : Form
    {
        /*--------------------------------GLOBAL VARIABLES DECLARATION------------*/
        //GlobalVariables Declarations
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_reader;
        private SQLiteDataAdapter numberInClassCommand;
        
        //Create a Global Instance of SubjectOffered Form , so as to be usable at all scope
        SubjectOffered subjectForm = new SubjectOffered();

        //Create a Local Data Table to hold the content of Acces DataBase
        DataTable LocalDataTable = new DataTable();
        int printNumber = 0;

        public Results()
        {
            InitializeComponent();

            DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");


        }

        private void Results_Load(object sender, EventArgs e)
        {
            string schoolName = null;
            string schoolAddress = null;

            //Read School Details from DataBase
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            sqlite_cmd = DBConnection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * from SessionDetails where  id= 1 ";

             sqlite_reader = sqlite_cmd.ExecuteReader();

             while (sqlite_reader.Read())
             {
                 schoolName = sqlite_reader["SchoolName"].ToString();
                 schoolAddress = sqlite_reader["Address"].ToString();
             }

             label9.Text = schoolName.ToUpper();
             address_lbl.Text = schoolAddress;

             LoadSubjects();
            LoadClasseFromDBToForm();
            if (currentClass.Items.Count > 0)
                currentClass.SelectedIndex = 0;
            if (studentList.Items.Count > 0)
            {
                studentList.SelectedIndex = 0;
                studentList.Select();

            }

            if (studentList.Items.Count == 0)
            {
                printout_btn.Enabled = false;
                pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;
            }

            //Make ScoreBoxes  not editable
            subjectForm.subject1.ReadOnly = true;
            subjectForm.subject2.ReadOnly = true;
            subjectForm.subject3.ReadOnly = true;
            subjectForm.subject4.ReadOnly = true;
            subjectForm.subject5.ReadOnly = true;
            subjectForm.subject6.ReadOnly = true;





        }

        private void LoadClasseFromDBToForm()
        {
            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))

                    DBConnection.Open();
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM Classes";


                //Get the values Read
                sqlite_reader = sqlite_cmd.ExecuteReader();

                //Load value read into Combo Box, currentClass
                while (sqlite_reader.Read())
                {
                    currentClass.Items.Add(sqlite_reader["Class"].ToString());

                } //End While

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                DBConnection.Close();
            }
        }




        private void currentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            LoadSubjects();
            studentListCaption.Text = "List of Students in " + currentClass.Text + ":";

            try
            {
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "select * from StudentRecord where  Class ='" + currentClass.Text + "';";
                sqlite_reader = sqlite_cmd.ExecuteReader();

                studentList.Items.Clear();
                while (sqlite_reader.Read())
                {
                    studentList.Items.Add(sqlite_reader["FullName"]);

                }

                if (studentList.Items.Count > 0)
                studentList.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }

        private void studentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentStudentGrpBox.Text = studentList.Text.ToUpper();

            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();

                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * from StudentRecord where  FullName ='" + studentList.Text + "';";

                sqlite_reader = sqlite_cmd.ExecuteReader();


                while (sqlite_reader.Read())
                {
                    subjectForm.subject1.Text = sqlite_reader["English"].ToString();
                    subjectForm.subject2.Text = sqlite_reader["Maths"].ToString();
                    subjectForm.subject3.Text = sqlite_reader["BasicSci"].ToString();
                    subjectForm.subject4.Text = sqlite_reader["BasicTech"].ToString();
                    subjectForm.subject5.Text = sqlite_reader["BusStd"].ToString();
                    subjectForm.subject6.Text = sqlite_reader["SocialStd"].ToString();

                    byte[] Imagebit = (byte[])(sqlite_reader["Image"]);

                    if (Imagebit == null)
                    {
                        pictureBox1.Image = null;
                    }
                    else
                    {
                        MemoryStream mstream = new MemoryStream(Imagebit);
                        pictureBox1.Image = System.Drawing.Image.FromStream(mstream);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }

        //Method that compute Grade

        private char GetGrade(int score)
        {
            char Grade = ' ';
            if (score >= 70 && score <= 100)
            {
                Grade = 'A';
            }

            else if (score >= 60 && score <= 69)
            {
                Grade = 'B';
            }

            else if (score >= 50 && score <= 59)
            {
                Grade = 'C';
            }

            else if (score >= 45 && score <= 49)
            {
                Grade = 'D';
            }

            else if (score >= 40 && score <= 44)
            {
                Grade = 'E';
            }

            else
            {
                Grade = 'F';
            }

            return Grade;
        }


        private void printout_btn_Click(object sender, EventArgs e)
        {

            System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();

            printDocument.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 793, 1122);
            printDocument.DefaultPageSettings.Color = true;

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_ImageWaterMark);
            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_PrintPage);

            printDocument.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(printDocument_PrintWaterMark);

            printDialog1.Document = printDocument;


            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
           

            Graphics graphic = e.Graphics;

            System.Drawing.Font font = new System.Drawing.Font("Courier New", 12);
            float fontHeight = font.GetHeight();
            int x = 10;
            int y = 10;
            int offset = 40;
            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(600, 90, 150, 150);



            string StudentName = " ";
            System.Drawing.Image studentImage = null;
            int score_in_English = 0;
            int score_in_Maths = 0;
            int score_in_BasicSci = 0;
            int score_in_BasicTech = 0;
            int score_in_BusStd = 0;
            int score_in_SocialStd = 0;
            string Comment = null;
            string TeacherComment = null;
            byte[] Imagebit = null;
            string Class = null;
            double Ave = 0.0;
            string currentSession = null;
            string currentTerm = null;

            //Draw a Rectangular Border
            Pen BorderPen = new Pen(Color.Brown, 5);
            Rectangle BorderRect = new Rectangle(0, 0, 788, 1030);
            graphic.DrawRectangle(BorderPen, BorderRect);
            //graphic.FillRectangle(new SolidBrush(Color.AliceBlue), BorderRect);

            //Read Session Details from DataBase
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            sqlite_cmd = DBConnection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * from SessionDetails where  id= 1 ";

             sqlite_reader = sqlite_cmd.ExecuteReader();

             while (sqlite_reader.Read())
             {
                 currentSession = sqlite_reader["Session"].ToString();
                 currentTerm = sqlite_reader["Term"].ToString();
             }

             //Generate Number of Student in class
             if (DBConnection.State.Equals(ConnectionState.Closed))
                 DBConnection.Open();
             DataTable LocalTable = new DataTable();

             numberInClassCommand = new SQLiteDataAdapter("SELECT * FROM StudentRecord WHERE Class= '" + currentClass.Text + "'", DBConnection);
             numberInClassCommand.Fill(LocalTable);

            //Write Heading 
            graphic.DrawString(label9.Text.PadLeft(20), new System.Drawing.Font("Times New Roman", 40, FontStyle.Bold), new SolidBrush(Color.Red),
                0, y);

            graphic.DrawString(address_lbl.Text.PadLeft(0), new System.Drawing.Font("Times New Roman", 16, FontStyle.Bold), new SolidBrush(Color.Black),
                90, y + 50);

            graphic.DrawString("Current Session: "+currentSession , new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold), new SolidBrush(Color.Red),
                60, y + 150);

            graphic.DrawString("Current Term: "+currentTerm, new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold), new SolidBrush(Color.Red),
               340, y + 150);

            graphic.DrawString("No in Class: " + LocalTable.Rows.Count, new System.Drawing.Font("Times New Roman", 14, FontStyle.Bold), new SolidBrush(Color.Black),
               280, y + 190);

            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            sqlite_cmd = DBConnection.CreateCommand();
            sqlite_cmd.CommandText = "SELECT * from StudentRecord where  FullName ='" + studentList.Text + "';";

            sqlite_reader = sqlite_cmd.ExecuteReader();


            while (sqlite_reader.Read())
            {
                StudentName = sqlite_reader["FullName"].ToString();
                score_in_English = Convert.ToInt32(sqlite_reader["English"]);
                score_in_Maths = Convert.ToInt32(sqlite_reader["Maths"]);
                score_in_BasicSci = Convert.ToInt32(sqlite_reader["BasicSci"]);
                score_in_BasicTech = Convert.ToInt32(sqlite_reader["BasicTech"]);
                score_in_BusStd = Convert.ToInt32(sqlite_reader["BusStd"]);
                score_in_SocialStd = Convert.ToInt32(sqlite_reader["SocialStd"]);
                Class = sqlite_reader["Class"].ToString();
                Ave = Convert.ToDouble(sqlite_reader["Average"]);
                Comment = sqlite_reader["PrincipalComment"].ToString();
                TeacherComment = sqlite_reader["TeacherComment"].ToString();
                Imagebit = (byte[])(sqlite_reader["Image"]);

                MemoryStream mstream = new MemoryStream(Imagebit);
                studentImage = System.Drawing.Image.FromStream(mstream);

                //Get Total Scores

                //Draw Image with Borders
                Pen myPen = new Pen(Color.Brown, 8);

                graphic.DrawRectangle(myPen, rect);
                graphic.DrawImage(studentImage, rect);
                offset = offset + (int)fontHeight + 180;

                graphic.DrawString("Current Class: ", new System.Drawing.Font("Arial Black", 11, FontStyle.Bold), new SolidBrush(Color.Black), 580, y + offset);
                graphic.DrawString(Class.ToString(), new System.Drawing.Font("Arial Black", 11, FontStyle.Bold), new SolidBrush(Color.Red), 705, y + offset);

                offset = offset + 30;
                graphic.DrawString(StudentName.ToUpper(), new System.Drawing.Font("Times New Roman", 32, FontStyle.Bold), new SolidBrush(Color.Black), 50, y + offset);

                offset = offset + 20;

                graphic.DrawString("SUBJECTS".PadRight(20) + "SCORE".PadRight(15) + "GRADE".PadRight(15), new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Blue), x + 30, y + 50 + offset);
                offset = offset + 35;

                graphic.DrawString("English".PadRight(20) + score_in_English.ToString().PadRight(18) + GetGrade(score_in_English).ToString().PadRight(15),
                               new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Red), x + 30, y + 50 + offset);
                offset = offset + 30;

                graphic.DrawString("Mathematics".PadRight(20) + score_in_Maths.ToString().PadRight(18) + GetGrade(score_in_Maths).ToString().PadRight(15),
         new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.SteelBlue), x + 30, y + 50 + offset);
                offset = offset + 30;
                graphic.DrawString("Basic Science".PadRight(20) + score_in_BasicSci.ToString().PadRight(18) + GetGrade(score_in_BasicSci).ToString().PadRight(15),
                    new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Black), x + 30, y + 50 + offset);
                offset = offset + 30;
                graphic.DrawString("Basic Tech".PadRight(20) + score_in_BasicTech.ToString().PadRight(18) + GetGrade(score_in_BasicTech).ToString().PadRight(15),
                    new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Red), x + 30, y + 50 + offset);
                offset = offset + 30;
                graphic.DrawString("Bus. Studies".PadRight(20) + score_in_BusStd.ToString().PadRight(18) + GetGrade(score_in_BusStd).ToString().PadRight(15),
                 new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.SteelBlue), x + 30, y + 50 + offset);
                offset = offset + 30;
                graphic.DrawString("Social Science".PadRight(20) + score_in_SocialStd.ToString().PadRight(18) + GetGrade(score_in_SocialStd).ToString().PadRight(15),
                    new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Black), x + 30, y + 50 + offset);

                graphic.DrawString("Average Score: " + string.Format("{0:f2}", Ave), new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Blue), 50, y + offset + 220);
                graphic.DrawString("Average Grade: " + GetGrade(Convert.ToInt32(Ave)), new System.Drawing.Font("Courier New", 16, FontStyle.Bold), new SolidBrush(Color.Green), 413.5f, y + offset + 220);
                offset = offset + 40;
                //Write comment
                graphic.DrawString("Principal\'s Comment: ", new System.Drawing.Font("Segeo UI", 16, FontStyle.Bold), new SolidBrush(Color.Red), 50, y + offset + 250);
                offset = offset + 40;
                graphic.DrawString(Comment.PadLeft(0), new System.Drawing.Font("Segeo UI", 14, FontStyle.Italic), new SolidBrush(Color.Black), 40, y + offset + 250);
                offset = offset + 40;
                graphic.DrawString("Class Teacher\'s Comment: ", new System.Drawing.Font("Segeo UI", 16, FontStyle.Bold), new SolidBrush(Color.Red), 50, y + offset + 250);
                offset = offset + 30;
                graphic.DrawString(TeacherComment.PadLeft(0), new System.Drawing.Font("Segeo UI", 14, FontStyle.Italic), new SolidBrush(Color.Black), 40, y + offset + 250);


                graphic.DrawString("Principal\'s Signature:", new System.Drawing.Font("Times New Roman", 18, FontStyle.Bold), new SolidBrush(Color.Black), 510, 950);
                graphic.DrawString("----------------------", new System.Drawing.Font("Arial Black", 24, FontStyle.Bold), new SolidBrush(Color.Black), 510, 980);

            }
            sqlite_reader.Close();
            DBConnection.Close();
        }


        private void printDocument_PrintWaterMark(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            Graphics g = e.Graphics;
            g.TranslateTransform(100, 100);
            g.RotateTransform(50);
            g.DrawString(label9.Text, new Font("Tahoma", 60, FontStyle.Bold),
                        new SolidBrush(Color.FromArgb(30, Color.Black)), 20, 0);


        }

        private void printDocument_ImageWaterMark(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {

            System.Drawing.Rectangle rect = new System.Drawing.Rectangle(280, 420, 700, 700);
            Graphics g = e.Graphics;
            System.Drawing.Image StudentImage = pictureBox3.Image;
            // Create image attributes and set large gamma.
            System.Drawing.Imaging.ImageAttributes imageAttr = new System.Drawing.Imaging.ImageAttributes();
            imageAttr.SetGamma(0.2f, System.Drawing.Imaging.ColorAdjustType.Bitmap);
            //imageAttr.SetColorKey(Color.White, Color.White);


            // Draw adjusted image to screen.
            g.DrawImage(StudentImage, rect, 10, 10, 700, 700, GraphicsUnit.Pixel, imageAttr);
            printNumber++;




        }





        private void subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }


        //Using Escape key to close App
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }


        private void LoadSubjects()
        {
            subjectForm.VerticalScroll.Value = 0;
            //Load Instance of SubjectOffered Form (i.e subjectForm) into panel1
            subjectForm.TopLevel = false;
            subjectForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            subjectForm.Dock = DockStyle.Fill;
            groupBox1.Controls.Add(subjectForm);
            subjectForm.Show();
        }

    } //End LoadClasseFromDBToForm
} //;

