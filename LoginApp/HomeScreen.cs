using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class HomeScreen : Form
    {
        
        public HomeScreen()
        {
            InitializeComponent();
            if (LoginScreen.admin == false)
            {
                buttonUserList.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            txtWelcome.Text = LoginScreen.firstName + " " + LoginScreen.lastName;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginScreen.admin == true)
            {
                this.Hide();
                RegistrationScreen registrationScreen = new RegistrationScreen();
                registrationScreen.ShowDialog();
            }
            else if (LoginScreen.admin == false)
            {
                MessageBox.Show("You must be admin to create a new account!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ProfileDetailsPopUp profileDetailsPopUp = new ProfileDetailsPopUp();
            DialogResult dialogResult = profileDetailsPopUp.ShowDialog();
            profileDetailsPopUp.Dispose();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }

        private void buttonUserList_Click(object sender, EventArgs e)
        {
            UserListPopUp userListPopUp = new UserListPopUp();
            DialogResult dialogResult = userListPopUp.ShowDialog();
            userListPopUp.Dispose();
        }
    }
}
