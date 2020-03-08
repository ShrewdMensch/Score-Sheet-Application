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
    public partial class UploadScores : Form
    {
        /*--------------------------------GLOBAL VARIABLES DECLARATION------------*/
        //GlobalVariables Declarations
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_reader;
        ToolTip pictureTip = new ToolTip(); //Tooltip on Student's Image

        //Create a Global Instance of SubjectOffered Form , so as to be usable at all scope
        SubjectOffered subjectForm = new SubjectOffered();


        public UploadScores()
        {
            InitializeComponent();
            DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");
            subjectForm.VerticalScroll.Maximum = 100;
            subjectForm.VerticalScroll.Minimum = 0;

        }

        private void UploadScores_Load(object sender, EventArgs e)
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

            LoadClasseFromDBToForm();
            LoadSubjects();
            if (currentClass.Items.Count > 0)
                currentClass.SelectedIndex = 0;
            if (studentList.Items.Count > 0)
            {
                studentList.SelectedIndex = 0;
                studentList.Select();
            }

            else
                pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;

            //Give Each Teacher access to their Subject score only
            if (LogIn.user != "admin")
            {
                txt_comment.Enabled = false;
                txt_teacherComment.Enabled = false;

                switch (LogIn.user)
                {
                    case "english":
                        subjectForm.subject2.ReadOnly = true;
                        subjectForm.subject3.ReadOnly = true;
                        subjectForm.subject4.ReadOnly = true;
                        subjectForm.subject5.ReadOnly = true;
                        subjectForm.subject6.ReadOnly = true;
                        break;

                    case "maths":
                        subjectForm.subject1.ReadOnly = true;
                        subjectForm.subject3.ReadOnly = true;
                        subjectForm.subject4.ReadOnly = true;
                        subjectForm.subject5.ReadOnly = true;
                        subjectForm.subject6.ReadOnly = true;
                        break;

                    case "basicsci":
                        subjectForm.subject1.ReadOnly = true;
                        subjectForm.subject2.ReadOnly = true;
                        subjectForm.subject4.ReadOnly = true;
                        subjectForm.subject5.ReadOnly = true;
                        subjectForm.subject6.ReadOnly = true;
                        break;

                    case "basictech":
                        subjectForm.subject1.ReadOnly = true;
                        subjectForm.subject3.ReadOnly = true;
                        subjectForm.subject2.ReadOnly = true;
                        subjectForm.subject5.ReadOnly = true;
                        subjectForm.subject6.ReadOnly = true;
                        break;

                    case "busstd":
                        subjectForm.subject1.ReadOnly = true;
                        subjectForm.subject3.ReadOnly = true;
                        subjectForm.subject4.ReadOnly = true;
                        subjectForm.subject2.ReadOnly = true;
                        subjectForm.subject6.ReadOnly = true;
                        break;

                    case "socialstd":
                        subjectForm.subject1.ReadOnly = true;
                        subjectForm.subject3.ReadOnly = true;
                        subjectForm.subject4.ReadOnly = true;
                        subjectForm.subject5.ReadOnly = true;
                        subjectForm.subject2.ReadOnly = true;
                        break;

                    default:
                        break;
                }
            }

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
            LoadSubjects();

            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();


            try
            {
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
                    txt_comment.Text = sqlite_reader["PrincipalComment"].ToString();
                    txt_teacherComment.Text = sqlite_reader["TeacherComment"].ToString();
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

        private void btn_saveToDb_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();

                sqlite_cmd = DBConnection.CreateCommand();

                //Get Total Score
                Int32 TotalScore = Convert.ToInt32(subjectForm.subject1.Text) + Convert.ToInt32(subjectForm.subject2.Text) + Convert.ToInt32(subjectForm.subject3.Text)
                        + Convert.ToInt32(subjectForm.subject4.Text) + Convert.ToInt32(subjectForm.subject5.Text) + Convert.ToInt32(subjectForm.subject6.Text);

                //Get Average
                double AverageScore = (double)TotalScore / 6;
                sqlite_cmd.CommandText = "UPDATE StudentRecord SET English= '" + subjectForm.subject1.Text + "', Maths= '" + subjectForm.subject2.Text + "',BasicSci= '" +
                    subjectForm.subject3.Text + "', BasicTech= '" + subjectForm.subject4.Text + "',PrincipalComment='" + txt_comment.Text + "', BusStd= '" + subjectForm.subject5.Text + "', SocialStd= '" + subjectForm.subject6.Text
                    + "', Total= " + TotalScore + ", Average= " + AverageScore + ", TeacherComment= '" + txt_teacherComment.Text + "' WHERE FullName ='" + studentList.Text + "';";

                //Execute Command
                //MessageBox.Show(sqlite_cmd.CommandText);
                sqlite_cmd.ExecuteNonQuery();
                MessageBox.Show("Saving Successful");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }


        private void subject_KeyPress(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }



        private void UploadScores_SizeChanged(object sender, EventArgs e)
        {

            if (this.WindowState == FormWindowState.Maximized)
            {
                btn_saveToDb.TextAlign = ContentAlignment.MiddleCenter;

                foreach (Control controls in panel1.Controls)
                {
                    if (controls is Label)
                    {
                        ((Label)controls).Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }

                    if (controls is TextBox)
                    {
                        ((TextBox)controls).Font = new System.Drawing.Font("Arial Rounded MT Bold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }

                }
            }

            else
            {
                btn_saveToDb.TextAlign = ContentAlignment.MiddleRight;

                foreach (Control controls in panel1.Controls)
                {
                    if (controls is Label)
                    {
                        ((Label)controls).Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }

                    if (controls is TextBox)
                    {
                        ((TextBox)controls).Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    }

                }
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
            groupBox3.Controls.Add(subjectForm);
            subjectForm.Show();
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureTip.Active = false;
            pictureTip.SetToolTip(pictureBox1, currentStudentGrpBox.Text);
            pictureTip.Active = true;
        }





    } //End LoadClasseFromDBToForm
} //;

