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
    public partial class PasswordMgt : Form
    {

        //SQLite Objects
        private SQLiteConnection DBConnection;
        private SQLiteCommand sqlite_cmd;
        private SQLiteDataReader sqlite_reader;
        //Create a Local Data Table to hold the content of Acces DataBase
        DataTable LocalDataTable = new DataTable();
        ToolTip toolTip1 = new ToolTip();
        ToolTip toolTip2 = new ToolTip();

        public PasswordMgt()
        {
            InitializeComponent();
            DBConnection = new SQLiteConnection("Data Source=dataBase.db;Version= 3;");

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword();
            
        }

       
        private void reconfirmPassword_TextChanged(object sender, EventArgs e)
        {

            if (newPassword.Text == reconfirmPassword.Text)
            {
                passwordMatchLbl.Image = AskIt_ScoreSheet_Project.Properties.Resources.check_icon;
                toolTip1.Active = false;
                toolTip1.RemoveAll();
                toolTip2.SetToolTip(this.passwordMatchLbl, "Reconfirm Password matches New Password   ");
                toolTip2.Active = true;


            }

            else if (newPassword.Text != reconfirmPassword.Text)
            {
                passwordMatchLbl.Image = AskIt_ScoreSheet_Project.Properties.Resources.delete_icon;
                toolTip2.Active = false;
                toolTip2.RemoveAll();
                toolTip1.SetToolTip(this.passwordMatchLbl, "Reconfirm Password does not match New Password");
                toolTip1.Active = true;
            }
            

        }

        private void reconfirmPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            char key = e.KeyChar;
            if (key == 13)
            {
               ChangePassword();
            }
        }
        private void ChangePassword()
        {
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();
            string username = " ";
            string password = " ";
            DialogResult msg = DialogResult.Cancel;
            SQLiteDataReader sqlite_reader;
            //Create a new SQL Command
            sqlite_cmd = DBConnection.CreateCommand();
            try
            {


                sqlite_cmd.CommandText = "select * from AuthorizedUsers where UserName = '" + LogIn.user + "';";


                //Store Value read in OledbDataReader Object
                sqlite_reader = sqlite_cmd.ExecuteReader();

                while (sqlite_reader.Read())
                {
                    username = sqlite_reader["UserName"].ToString();
                    password = sqlite_reader["Password"].ToString();
                }

                sqlite_reader.Close();

                DBConnection.Close();

                if (old_Password.Text == password)
                {
                    if (DBConnection.State.Equals(ConnectionState.Closed))
                        DBConnection.Open();

                    if (newPassword.Text == reconfirmPassword.Text)
                    {

                        msg = MessageBox.Show("Are you sure you want to Change your Password?", "Password Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    }

                    if (msg == DialogResult.Yes)
                    {
                        try
                        {
                            sqlite_cmd.CommandText = "update AuthorizedUsers set  Password='" + newPassword.Text + "' where UserName = '" + LogIn.user + "'; ";


                            sqlite_cmd.ExecuteNonQuery();

                            MessageBox.Show("Password Changed Successfully\nChanges will be applied after re-login", "Password Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }


                }

                else
                {
                    MessageBox.Show("New Password Does not match", "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void change_Click(object sender, EventArgs e)
        {
            ChangePassword();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();
                

                if (password_txt.Text == password2_txt.Text)
                {
                    sqlite_cmd = DBConnection.CreateCommand();
                    
                    int count = 0;
                    sqlite_cmd = DBConnection.CreateCommand();
                    sqlite_cmd.CommandText = "SELECT * FROM AuthorizedUsers WHERE UserName= '" + userName_txt.Text + "'";
                    SQLiteDataReader reader = sqlite_cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        count++;
                    }

                    reader.Close();

                    if (count > 0)
                    {
                        MessageBox.Show("Username " + userName_txt.Text + " Already Exists");
                    }

                    else
                    {
                        sqlite_cmd.CommandText = @"INSERT INTO AuthorizedUsers(UserName,Password) VALUES('" + userName_txt.Text + "' ,'" + password_txt.Text + "');";

                        sqlite_cmd.ExecuteNonQuery();
                        MessageBox.Show("User, " + userName_txt.Text + " Have Been Created Successfully");
                        password_txt.Text = null;
                        password_txt.Text = null;
                        password2_txt.Text = null;
                        userName_txt.Text = null;

                    }
                   
                }

                else
                   MessageBox.Show("Mismatched Passwords");

            }

            catch (Exception ex)
            {
                

                
                MessageBox.Show(ex.Message);
            }

            DBConnection.Close();
        }

        private void PasswordMgt_Load(object sender, EventArgs e)
        {
            if (File.Exists(@"Fonts\BOD_R.ttf"))
            {
                PrivateFontCollection pfc = new PrivateFontCollection();
                pfc.AddFontFile(@"Fonts\BOD_R.ttf");

                foreach (Control control in panel2.Controls)
                {

                    (control).Font = new System.Drawing.Font(pfc.Families[0], 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (control is TextBox)
                        (control).Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));


                }

                foreach (Control control in panel1.Controls)
                {

                    (control).Font = new System.Drawing.Font(pfc.Families[0], 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (control is TextBox)
                        (control).Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

                }

            } //End if

            if (LogIn.user != "admin")
                toolStripButton2.Enabled = false;
            panel1.Visible = true;
            panel2.Visible = false;

            CheckBox []box=new CheckBox[LocalDataTable.Rows.Count + 1];
            int height =1;
            int padding=10;
            ConnectToDataBase();
           /* try
            {
                for (int i = 0; i < LocalDataTable.Rows.Count; i++)
                {
                    int pt = 3;

                    box[i] = new CheckBox();
                    box[i].Tag = i.ToString();
                    box[i].Text = "box" + i;
                    box[i].AutoSize = true;
                    box[i].Location = new Point(3, pt);
                    box[i].Bounds = new Rectangle(10, 20 + padding + height, 40, 22);
                    pt += 17;
                    panel3.Controls.Add(box[i]);
                    height += 22;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            } */
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            
            //Clear User Inputs When Action changed
            foreach (Control control in panel2.Controls)
            {
                if (control is TextBox)
                    control.Text = null;
            }
            old_Password.Select();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            //Clear User Inputs When Action changed
            foreach (Control control in panel1.Controls)
            {
                if (control is TextBox)
                    control.Text = null;
            }
            userName_txt.Select();

        }

        private void password2_txt_TextChanged(object sender, EventArgs e)
        {
            if (password_txt.Text == password2_txt.Text)
            {
                label8.Image = AskIt_ScoreSheet_Project.Properties.Resources.check_icon;
                toolTip1.Active = false;
                toolTip1.RemoveAll();
                toolTip2.SetToolTip(this.label8, "Reconfirm Password matches New Password   ");
                toolTip2.Active = true;


            }

            else if (password_txt.Text != password2_txt.Text)
            {
                label8.Image = AskIt_ScoreSheet_Project.Properties.Resources.delete_icon;
                toolTip2.Active = false;
                toolTip2.RemoveAll();
                toolTip1.SetToolTip(this.label8, "Reconfirm Password does not match New Password");
                toolTip1.Active = true;
            }
            
        }
         List<string> items = new List<string>();
         List<TreeNode> selectedNodes = new List<TreeNode>();

        private void button3_Click(object sender, EventArgs e)
        {
            if (DBConnection.State.Equals(ConnectionState.Closed))
                DBConnection.Open();
            try
            {
                sqlite_cmd = DBConnection.CreateCommand();
                sqlite_cmd.CommandText = "SELECT * from StudentRecord";
                sqlite_reader = sqlite_cmd.ExecuteReader();


                while (sqlite_reader.Read())
                {
                    treeView1.Nodes.Add(sqlite_reader["FirstName"].ToString() + " " + sqlite_reader["LastName"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
              //items.Add(treeView1.SelectedNode.ToString() + "/n");
            foreach (TreeNode tD in selectedNodes)
            {
                richTextBox1.Text += tD.Text;
            }
            
            getListOfSelections(items);

        }

        private void getSelectedItems(TreeNodeCollection tV)
        {
            //selectedNodes.Clear();
            foreach (TreeNode nD in tV)
            {
                if (nD.Checked)
                {
                    selectedNodes.Add(nD);
                }

            }
        }

        public void getListOfSelections(List<String> stringList) {
            foreach (String s in stringList)
            {
                
            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            getSelectedItems(treeView1.Nodes);
        }

        private void ConnectToDataBase()
        {
            SQLiteDataAdapter DbAdapter = new SQLiteDataAdapter("SELECT StudentID as 'ID',FirstName as 'First Name', LastName as 'Last Name' FROM StudentRecord", DBConnection);



            try
            {


                if (DBConnection.State.Equals(ConnectionState.Closed))
                    DBConnection.Open();



                DbAdapter.Fill(LocalDataTable);


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

    }
}
