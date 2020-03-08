using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Speech;
using System.Speech.Synthesis;

namespace AskIt_ScoreSheet_Project
{
    public partial class MainMenu : Form
    {
        //GlobalVariables Declarations
        public static bool LogInOpened = false;
        public static bool LogInCloseButtonPressed = false;
        SpeechSynthesizer speechReader = new SpeechSynthesizer();
        SpeechSynthesizer ctrlSpeechReader = new SpeechSynthesizer();

        public MainMenu()
        {
            InitializeComponent();
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

            speechReader.Dispose();
            speechReader = new SpeechSynthesizer();
            speechReader.SpeakAsync("Welcome! User," + LogIn.user);

            if (LogIn.user == "admin")
            {
                label1.AutoSize = false;
                label1.Text = "Welcome, " + LogIn.user + "!";
            }

            else
            {
                label1.AutoSize = true;
                label1.Text = "Welcome, " + LogIn.user.ToUpper() + " Teacher" + "!";
                existingRec.Enabled = false;
                results_btn.Enabled = false;
                newRec.Enabled = false;
                results_btn.Enabled = false;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult msg = MessageBox.Show("Are you sure you want to Close?\nYou\'ll be Logged out and the Whole Application will be closed\n", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg == DialogResult.Yes)
            {
                LogInCloseButtonPressed = true;
                Application.Exit();
            }

            else
            {
                ;
            }

        }

        private void logOut_Click(object sender, EventArgs e)
        {

            DialogResult msg = MessageBox.Show(LogIn.user + ", Are you sure you want to Logout?", "Logout Info", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (msg == DialogResult.Yes)
            {
                LogInOpened = true;
                LogIn fm = new LogIn();
                this.Hide();
                fm.ShowDialog();
            }

            else
            {
                ;

            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime time = DateTime.Now;
            lbl_time.Text = time.ToString("dddd-mmm-yyyy hh:mm tt");
        }

        private void newRec_Click(object sender, EventArgs e)
        {
            LogInOpened = true;
            NewRecord fm = new NewRecord();
            fm.ShowDialog();
        }

        private void existingRec_Click(object sender, EventArgs e)
        {
            LogInOpened = true;
            ExistingRecord fm = new ExistingRecord();
            fm.ShowDialog();
        }



        private void newRec_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.ForeColor = Color.DarkGreen;
        }

        private void MainMenu_MouseHover(object sender, EventArgs e)
        {
            /*newRec.ForeColor = Color.Green;
            existingRec.ForeColor = Color.Navy;
            logOut.ForeColor = Color.Red;
            uploadScores_btn.ForeColor = Color.DarkOrange;*/
        }

        private void uploadScores_btn_Click(object sender, EventArgs e)
        {
            UploadScores UploadForm = new UploadScores();
            UploadForm.ShowDialog();
        }

        private void passwordmgt_btn_Click(object sender, EventArgs e)
        {
            PasswordMgt ps = new PasswordMgt();
            ps.ShowDialog();
        }

        private void results_btn_Click(object sender, EventArgs e)
        {
            Results resultForm = new Results();
            resultForm.ShowDialog();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM, HT, 0);
            }
        }

        private void speakWhenControlAreaEntered(object sender, EventArgs e)
        {
            Button btn = (Button)sender;


            if (speechReader.State != SynthesizerState.Speaking)
            {
                ctrlSpeechReader.Dispose();
                ctrlSpeechReader = new SpeechSynthesizer();
                int position = btn.Text.LastIndexOf("\r");
                ctrlSpeechReader.SpeakAsync(btn.Text.Substring(0, position) + " " + btn.Text.Substring(position + 2));

            }
        }





    }
}
