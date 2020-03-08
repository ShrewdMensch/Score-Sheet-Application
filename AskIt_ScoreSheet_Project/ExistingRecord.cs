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
using System.Data.SQLite;
using System.Speech;
using System.Speech.Synthesis;

namespace AskIt_ScoreSheet_Project
{
    public partial class ExistingRecord : Form
    {

        /*--------------------------------GLOBAL VARIABLES DECLARATION------------*/
        //GlobalVariables Declarations
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        SpeechSynthesizer speechReader = new SpeechSynthesizer();
        
        private SQLiteDataReader sqlite_reader;
        ToolTip pictureTip = new ToolTip(); //Tooltip on Student's Image

        //Create a Local Data Table to hold the content of Acces DataBase
        DataTable LocalDataTable = new DataTable();

      
        string studentSex = null; //Global vaiable for storing student sex

        public ExistingRecord()
        {
            InitializeComponent();
            DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");
        }

        private void ExistingRecord_Load(object sender, EventArgs e)
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
            //ConnectToDataBase();
            if (currentClass.Items.Count > 0)
            currentClass.SelectedIndex = 0;
            if (studentList.Items.Count > 0)
            {
                studentList.SelectedIndex = 0;
                studentList.Select();

            }

            else
                pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;
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
                    studentClass.Items.Add(sqlite_reader["Class"].ToString());
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
        } // End LoadClasseFromDBToForm()




        private void currentClass_SelectedIndexChanged(object sender, EventArgs e)
        {
             studentListCaption.Text = "List of Students in " + currentClass.Text + ":";

            RefreshStudentList();
            if (studentList.Items.Count > 0)
            {
                studentList.SelectedIndex = 0;
                studentList.Select();
            }

        } //End currentClass_SelectedIndexChanged Event

        private void studentList_SelectedIndexChanged(object sender, EventArgs e)
        {
            speechReader.Dispose();
            speechReader = new SpeechSynthesizer();
            speechReader.SpeakAsync(studentList.Text);
            
            currentStudentGrpBox.Text = studentList.Text.ToUpper();
          
            LoadDataToForm();

        }

        //Function that loads Data to Form
        private void LoadDataToForm()
        {

            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();


            try
            {
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * from StudentRecord where  FullName ='" + studentList.Text + "';";
                sqlite_reader = sqlite_cmd.ExecuteReader();


                while (sqlite_reader.Read())
                {
                    txt_firstName.Text = sqlite_reader["FirstName"].ToString();
                    txt_lastName.Text = sqlite_reader["LastName"].ToString();
                    txt_phone.Text = sqlite_reader["ParentPhone"].ToString();
                    studentClass.Text = sqlite_reader["Class"].ToString();
                    DOB.Value = Convert.ToDateTime(sqlite_reader["DOB"]);
                    txt_address.Text = sqlite_reader["Address"].ToString();
                    studentSex = sqlite_reader["Sex"].ToString();
                    studentState.Text = sqlite_reader["State"].ToString();
                    StudentID_txt.Text = sqlite_reader["StudentID"].ToString();
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

                    //Know which sex Radio Button needs to be checked
                    {
                        if (studentSex == "Male")
                        {
                            maleRadioBtn.Checked = true;
                        }

                        else if (studentSex == "Female")
                        {
                            femaleRadioBtn.Checked = true;
                        }
                        else
                        {
                            maleRadioBtn.Checked = false;
                            femaleRadioBtn.Checked = false;
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }

        private void maleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            studentSex = "Male";
        }

        private void femaleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            studentSex = "Female";
        }

        private void btn_saveToDb_Click(object sender, EventArgs e)
        {
            byte[] ImageBytes;

            //Get Image as Byte[] from pictureBox1
            Bitmap Bmp = new Bitmap(pictureBox1.Image);
            MemoryStream myStream = new MemoryStream();
            Bmp.Save(myStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            ImageBytes = myStream.ToArray();

            
          if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();
         
          try
            {
                sqlite_cmd = DBConnection.CreateCommand();
                
              
              
                sqlite_cmd.CommandText = "UPDATE StudentRecord SET FirstName = '"+txt_firstName.Text+"',LastName='"+txt_lastName.Text
                    +"', DOB ='"+DOB.Text+"', Class = '"+studentClass.Text+"',State= '"+studentState.Text+"',ParentPhone= '"+
                    txt_phone.Text + "', Address= '" + txt_address.Text + "', Sex = '" + studentSex + "', Image = @IMG, FullName= '" + txt_firstName.Text +
                    " " + txt_lastName.Text + "'  where FullName= '" + studentList.Text + "' ";

                SQLiteParameter imageParameter = new SQLiteParameter("@IMG", DbType.Binary);
                imageParameter.Value = ImageBytes;
                imageParameter.Size = ImageBytes.Length;
                sqlite_cmd.Parameters.Add(imageParameter);

                DialogResult msg = MessageBox.Show("Did you really want to Save Changes made so far?", "Saving Record...", MessageBoxButtons.YesNo, MessageBoxIcon.Information); ;

                //Perform action according to User's preference
                {

                    if (msg == DialogResult.Yes)
                    {
                        sqlite_cmd.ExecuteNonQuery();
                        MessageBox.Show("Data Updated Successfully", "Saving Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshStudentList();
                        this.btn_saveToDb.Click += new EventHandler(studentList_SelectedIndexChanged);

                        if (studentList.Items.Count > 0)
                        {
                            studentList.SelectedIndex = 0;
                            studentList.Select();
                        }
                    }
                        
                    else
                    {
                        ;
                    }
                }

              
            }

          catch (Exception ex)
          {
              MessageBox.Show(ex.Message);
          }

          DBConnection.Close();

        } //End btn_saveToDb_Click


        private void deleteFromDb_btn_Click(object sender, EventArgs e)
        {
             //
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            try
            {
                sqlite_cmd = DBConnection.CreateCommand();



                sqlite_cmd.CommandText = "DELETE  FROM StudentRecord where FullName= '" + studentList.Text + "' ";
                
                DialogResult msg = MessageBox.Show("Did You want to Delete this current Record Permanently?\nAction can be Reversed once deleted"+
                    "!", "Important Information...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                //Perform action according to User's preference
                {

                    if (msg == DialogResult.Yes)
                    {
                        sqlite_cmd.ExecuteNonQuery();
                        RefreshStudentList();
                        MessageBox.Show("Record Deleted Successfully", "Delete Status", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        if (studentList.Items.Count > 0)
                        {
                            studentList.SelectedIndex = 0;
                            studentList.Select();
                        }
                    }

                    else
                    {
                        ;
                    }
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

          DBConnection.Close();
        }

        private void changeImage_btn_Click(object sender, EventArgs e)
        {
            OpenFileDialog BrowseImageDlg = new OpenFileDialog();
            BrowseImageDlg.Title = "Select Student\'s Image";
            BrowseImageDlg.Filter = "Jpeg Files(*.jpg)|*.jpg|Png Files(*.png)|*.png|All Files(*.*)|*.*";
            try
            {
                if (BrowseImageDlg.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.Image = Image.FromFile(BrowseImageDlg.FileName);
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void RefreshStudentList()
        {
             if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            
            try
            {
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "select * from StudentRecord where  Class ='" + currentClass.Text + "';";
                sqlite_reader = sqlite_cmd.ExecuteReader();

                //Clear Displays
                studentList.Items.Clear();
                txt_firstName.Text = null;
                txt_lastName.Text = null;
                txt_phone.Text = null;
                studentClass.Text = null;
                studentState.Text = null;
                DOB.Text = null;
                txt_address.Text = null;
                maleRadioBtn.Checked = false;
                femaleRadioBtn.Checked = false;
                currentStudentGrpBox.Text = "Student Name";
                pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;

                while (sqlite_reader.Read())
                {
                    studentList.Items.Add(sqlite_reader["FullName"]);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }

        //Using Escape key to close App
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Put ToolTip on PictureBox when Mouse Enters it visible area
        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureTip.Active = false;
            pictureTip.SetToolTip(pictureBox1, currentStudentGrpBox.Text);
            pictureTip.Active = true;
        }

        private void studentListCaption_Enter(object sender, EventArgs e)
        {

        }

        private void currentStudentGrpBox_Enter(object sender, EventArgs e)
        {

        }
       


    }
}
