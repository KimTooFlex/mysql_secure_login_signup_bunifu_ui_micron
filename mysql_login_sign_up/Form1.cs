using Data.Models;
using Micron;
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
    public partial class Form1 : Form
    {
        MicronDbContext micron = new MicronDbContext();
        public Form1()
        {
            InitializeComponent();


            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage2);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void btnSignUp_Click(object sender, EventArgs e)
        {
            //check db
            User user = micron.GetRecord<User>($"email='{txtEmail.Text}' AND password = MD5('{txtPassword.Text}')");

            if (user != null)
            {
                MessageBox.Show("User already exists.");
                return;
            }

            user = new User()
            {
                Name = txtName.Text,
                Email = txtEmail.Text,
                Password = Program.CalculateMD5Hash(txtPassword.Text)
            };

            user = micron.Save(user);
            MessageBox.Show("Account successfully created");

            txtEmail.Text = txtName.Text = txtPassword.Text = string.Empty;

            bunifuPages1.SetPage(0);

        }

        private void btnSignIn_Click(object sender, EventArgs e)
        {
            User user = micron.GetRecord<User>($"email='{txtEmail2.Text}' AND password = MD5('{txtPassword2.Text}')");

            if (user == null)
            {
                MessageBox.Show("Invalid Login Credentials.");
                return;
            }

            //access home page
            this.Visible = false;
            var home = new frmHome(user);
            home.ShowDialog();
            if (home.DialogResult != DialogResult.No) this.Close();
            this.Visible = true;
        }
    }
}
