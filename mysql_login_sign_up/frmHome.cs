using Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace mysql_login_sign_up
{
    public partial class frmHome : Form
    {
        public frmHome(User user)
        {
            InitializeComponent();

            lblName.Text = $"Welcome back {user.Name}";
            lblEmail.Text = user.Email;
        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
