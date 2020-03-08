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
using System.Drawing.Text;

namespace AskIt_ScoreSheet_Project
{
    public partial class NewRecord : Form
    {
        /*--------------------------------GLOBAL VARIABLES DECLARATION------------*/


        //SQLite Objects
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_reader;

        //Create a Local Data Table to hold the content of Acces DataBase
        DataTable LocalDataTable = new DataTable();

        string studentSex = null; //Global vaiable for storing student sex


        //number of rows current in the database
        int rowNumber = 0;

        public NewRecord()
        {
            InitializeComponent();
            DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");

        }

        private void NewRecord_Load(object sender, EventArgs e)
        {
          
            LoadClasseFromDBToForm();
            ConnectToDataBase();
            //RefreshDataGridView();
            currentClass.SelectedIndex = 0;
            maleRadioBtn.Checked = true;

        }

        /****************Function that Connects to DataBase#########*******/
        private void LoadClasseFromDBToForm()
        {
            try
            {

                DBConnection.Open();
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "select * from Classes;";

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
        } //End LoadClasseFromDBToForm

        private void ConnectToDataBase()
        {
            SQLiteDataAdapter DbAdapter = new SQLiteDataAdapter("SELECT StudentID as 'ID',FirstName as 'First Name', LastName as 'Last Name' FROM StudentRecord", DBConnection);



            try
            {


                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();



                DbAdapter.Fill(LocalDataTable);


                if (LocalDataTable.Rows.Count != 0)

                    rowNumber = LocalDataTable.Rows.Count;

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

        private void btn_saveToDb_Click(object sender, EventArgs e)
        {
            byte[] ImageBytes;

            if (pictureBox1.Image == null)
            {
                Bitmap Bmp = new Bitmap(AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con);
                MemoryStream myStream = new MemoryStream();
                Bmp.Save(myStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageBytes = myStream.ToArray();
            }

            else
            {
                Bitmap Bmp = new Bitmap(pictureBox1.Image);
                MemoryStream myStream = new MemoryStream();
                Bmp.Save(myStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                ImageBytes = myStream.ToArray();
            }

            RefreshDataBase();

            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();
            if (txt_firstName.Text == null)
                MessageBox.Show("You Must Enter a name");
            else
            {
                try
                {
                    sqlite_cmd = DBConnection.CreateCommand();

                    sqlite_cmd.CommandText = "insert into StudentRecord(StudentID,FirstName,LastName,DOB,Class,ParentPhone,Address,Image, FullName,Sex,State) values('" + ((rowNumber + 1) + "-" + DateTime.Now.Hour + DateTime.Now.Second + "/" + DateTime.Now.Year).ToString() + "','" +
                        txt_firstName.Text + "','" + txt_lastName.Text + "', '" + DOB.Value + "','" + currentClass.Text + "', '" +
                        txt_phone.Text + "', '" + txt_address.Text + "',@IMG,'" + txt_firstName.Text + " " + txt_lastName.Text + "','" + studentSex + "','" + studentState.Text + "'); ";



                    SQLiteParameter imageParameter = new SQLiteParameter("@IMG", DbType.Binary);
                    imageParameter.Value = ImageBytes;
                    imageParameter.Size = ImageBytes.Length;
                    sqlite_cmd.Parameters.Add(imageParameter);

                    if (ImageBytes.Length <= 40960)
                    {
                        if ((txt_firstName.Text + txt_lastName) != null)
                        {
                            sqlite_cmd.ExecuteNonQuery();
                            ClearForm();
                            MessageBox.Show("Data Successfully Saved", "Saving Status", MessageBoxButtons.OK);
                        }

                    }

                    else
                    {
                        MessageBox.Show("Image size is more the maximum limit of 40KB.\nPlease Select Another Image File for the Student");
                        pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;
                    }



                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);

                }
            }
            DBConnection.Close();
            //RefreshDataGridView();
        }



        private void RefreshDataBase()
        {
            DBConnection.Close();
            LocalDataTable.Clear();
            ConnectToDataBase();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MemoryStream strm = new MemoryStream();
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

        private void maleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            studentSex = "Male";
        }

        private void femaleRadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            studentSex = "Female";
        }

        //Using Escape key to close App
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
                this.Close();
            return base.ProcessCmdKey(ref msg, keyData);
        }

        //Function that clears Controls or set to default
        private void ClearForm()
        {
            txt_address.Text = null;
            txt_firstName.Text = null;
            txt_lastName.Text = null;
            txt_phone.Text = null;
            currentClass.SelectedIndex = 0;
            pictureBox1.Image = AskIt_ScoreSheet_Project.Properties.Resources.Portrait_con;
            DOB.Value = DateTime.Now;
            maleRadioBtn.Checked = true;
            studentState.Text = null;
        }




    } //End Form NewRecord
}
