using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Drawing.Text;
using System.Speech;
using System.Speech.Synthesis;

namespace AskIt_ScoreSheet_Project
{
    public partial class LogIn : Form
    {
        //GlobalVariables Declarations
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_reader;
        public static string user;

        SpeechSynthesizer speechReader = new SpeechSynthesizer();

        public LogIn()
        {
            Thread t = new Thread(new ThreadStart(DoNothing));
            if (!MainMenu.LogInOpened)
            {

                t = new Thread(new ThreadStart(SplashStart));
                t.Start();
                Thread.Sleep(5000);
            }
            InitializeComponent();
            t.Abort();

            if (File.Exists("dataBase.db"))
                DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");

            else
            {
                DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3; New= True; Compress= True;");

                // DBConnection.Close();
            }


        }

        //Function to use with Thread not to show wen u are not just starting
        private void DoNothing()
        {

        }

        private void SplashStart()
        {
            Application.Run(new SplashScreen());
        }


        private void LogIn_Load(object sender, EventArgs e)
        {

            string message = "Welcome!! Please Enter your Login Credentials";
            speechReader.Dispose();
            speechReader = new SpeechSynthesizer();
            IReadOnlyCollection<InstalledVoice> installedVoices = speechReader.GetInstalledVoices();
            InstalledVoice voice = installedVoices.First();
            speechReader.SelectVoice(voice.VoiceInfo.Name);
            speechReader.SpeakAsync(message);


            //Check if the Custom font Exits Then Use if it does exist
            if (File.Exists(@"Fonts\BOD_R.ttf"))
            {
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(@"Fonts\Blackletter686 BT.ttf");

                foreach (Control control in Controls)
                {
                    if (control is GroupBox)
                        (control).Font = new System.Drawing.Font(pfc.Families[0], 22.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }
            }
            //DataBase Access and Operations
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();

            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandType = CommandType.Text;

                //Check if  First Table exists
                sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= 'AuthorizedUsers'";
                var name = sqlite_cmd.ExecuteScalar();
                //check if table exists
                if (name != null && name.ToString() == "AuthorizedUsers")
                    return;
                else
                {
                    //If not Exist then Create First Table
                    sqlite_cmd.CommandText = "CREATE TABLE AuthorizedUsers( id  INTEGER,UserName VARCHAR(45) PRIMARY KEY,Password VARCHAR(45));";
                    sqlite_cmd.ExecuteNonQuery();
                    //insert Defaults into First Table
                    sqlite_cmd.CommandText = "INSERT INTO AuthorizedUsers(id,UserName,Password) VALUES(1,'admin','1234');";
                    sqlite_cmd.ExecuteNonQuery();
                }

                //Check if  Second Table exists
                sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= 'AvailableSubjects'";
                var name2 = sqlite_cmd.ExecuteScalar();
                //check if table exists
                if (name2 != null && name.ToString() == "AvailableSubjects")
                    return;
                else
                {
                    //If not Exist then Create Second Table
                    sqlite_cmd.CommandText = "CREATE TABLE AvailableSubjects (id INTEGER PRIMARY KEY, Subjects VARCHAR(45), Teacher  VARCHAR(45));";
                    sqlite_cmd.ExecuteNonQuery();
                }

                //Check if  Third Table exists
                sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= 'Classes'";
                name = sqlite_cmd.ExecuteScalar();
                //check if table exists
                if (name != null && name.ToString() == "Classes")
                    return;
                else
                {
                    //If not Exist 
                    //Create Third Table
                    sqlite_cmd.CommandText = "CREATE TABLE Classes (id INTEGER PRIMARY KEY,Class VARCHAR(45));";
                    sqlite_cmd.ExecuteNonQuery();

                    //insert Defaults into Third Table
                    sqlite_cmd.CommandText = "INSERT INTO Classes(id,Class)  VALUES(1,'Jss1')";
                    sqlite_cmd.ExecuteNonQuery();
                    sqlite_cmd.CommandText = "INSERT INTO Classes(id,Class)  VALUES(2,'Jss2')";
                    sqlite_cmd.ExecuteNonQuery();
                    sqlite_cmd.CommandText = "INSERT INTO Classes(id,Class)  VALUES(3,'Jss3')";
                    sqlite_cmd.ExecuteNonQuery();

                }

                //Check if  Fourth Table exists
                sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= 'StudentRecord'";
                name = sqlite_cmd.ExecuteScalar();
                //check if table exists
                if (name != null && name.ToString() == "StudentRecord")
                    return;
                else
                {
                    //If not Exist then Create First Table
                    //Create Fourth Table
                    sqlite_cmd.CommandText = @"CREATE TABLE StudentRecord (StudentID  STRING,FirstName VARCHAR(100),LastName VARCHAR(100),FullName  VARCHAR(100) PRIMARY KEY, DOB VARCHAR,
    State            VARCHAR(100),
    Sex              VARCHAR(10),
    Class            VARCHAR(10),
    English          INTEGER NOT NULL DEFAULT (0),
    Maths            INTEGER NOT NULL DEFAULT (0),
    BasicSci         INTEGER NOT NULL DEFAULT (0),
    BusStd           INTEGER NOT NULL DEFAULT (0),
    SocialStd        INTEGER NOT NULL DEFAULT (0),
    BasicTech        INTEGER NOT NULL DEFAULT (0),
    Total            INTEGER NOT NULL DEFAULT (0),
    Average          DOUBLE (20) NOT NULL DEFAULT (0),
    Address          VARCHAR (200),
    Image            BLOB,
    ParentPhone      VARCHAR (20),
    PrincipalComment VARCHAR,
    TeacherComment   VARCHAR
);";
                    sqlite_cmd.ExecuteNonQuery();
                }


                //Check if  Fifth Table exists
                sqlite_cmd.CommandText = "SELECT name FROM sqlite_master WHERE name= 'SessionDetails'";
                name = sqlite_cmd.ExecuteScalar();
                //check if table exists
                if (name != null && name.ToString() == "SessionDetails")
                    return;
                else
                {
                    //If not Exist then Create Fifth Table
                    sqlite_cmd.CommandText = "CREATE TABLE SessionDetails( id  INTEGER PRIMARY KEY,Term VARCHAR(45),Session VARCHAR(45),SchoolName VARCHAR(45), Address VARCHAR(45));";
                    sqlite_cmd.ExecuteNonQuery();
                    //insert Defaults into Fifth Table
                    sqlite_cmd.CommandText = @"INSERT INTO SessionDetails(Term,Session, SchoolName, Address) VALUES('1st', '2015/2016','YETKEM HIGH SCHOOL','Yetkem Avenue, Surulere, Alagbado, Lagos State.');";
                    sqlite_cmd.ExecuteNonQuery();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        } //End LogIn_Load


        private void button1_Click(object sender, EventArgs e)
        {
            UserLogin();

        }


        private void password_txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                button1.Select();
        }




        private void close_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure you want to Close?\nYou\'re not Logged in yet and the Whole Application will be closed\n", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg == DialogResult.Yes)
            {

                Application.Exit();
            }

            else
            {
                ;
            }
        }

        private void minimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void password_txt_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == 13)
            {
                UserLogin();
            }

        }

        private void UserLogin()
        {
            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();

                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * FROM  AuthorizedUsers WHERE UserName= '" + this.userName_txt.Text + "' and Password= '" + password_txt.Text + "'; ";
                sqlite_reader = sqlite_cmd.ExecuteReader();
                int count = 0;

                while (sqlite_reader.Read())
                {

                    count = count + 1;
                    user = sqlite_reader["UserName"].ToString();
                }

                if (count == 1)
                {

                    DBConnection.Close();
                    MainMenu fm = new MainMenu();
                    this.Hide();
                    fm.ShowDialog();
                }

                else if (count < 1)
                {
                    //Use Voice Prompt
                    string message = "UserName/Password not Correct";
                    speechReader.Dispose();
                    speechReader = new SpeechSynthesizer();
                    speechReader.SpeakAsync(message);
                    MessageBox.Show("UserName/Password not Correct", null, MessageBoxButtons.OK, MessageBoxIcon.Error);


                }

                else
                {

                    MessageBox.Show("Duplicated Login Credentials", null, MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            // DBConnection.Close();

        }

        private void label7_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM, HT, 0);
            }
        }

    }
}
