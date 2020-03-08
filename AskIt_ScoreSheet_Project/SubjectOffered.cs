using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AskIt_ScoreSheet_Project
{
    public partial class SubjectOffered : Form
    {
        public SubjectOffered()
        {
            InitializeComponent();
        }

        private void subject(object sender, KeyPressEventArgs e)
        {
            Char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8)
            {
                e.Handled = true;
            }
        }

    }
}
