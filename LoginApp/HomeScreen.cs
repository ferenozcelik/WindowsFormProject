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
                buttonAssignTask.Visible = false;
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void HomeScreen_Load(object sender, EventArgs e)
        {
            txtWelcome.Text = LoginScreen.firstName + " " + LoginScreen.lastName;
        }


        private void buttonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }

        private void buttonCreateAcc_Click(object sender, EventArgs e)
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

        private void buttonProfileDet_Click(object sender, EventArgs e)
        {
            ProfileDetailsPopUp profileDetailsPopUp = new ProfileDetailsPopUp();
            DialogResult dialogResult = profileDetailsPopUp.ShowDialog();
            profileDetailsPopUp.Dispose();
        }

        private void buttonUserList_Click(object sender, EventArgs e)
        {
            UserListPopUp userListPopUp = new UserListPopUp();
            if (UserListPopUp.state)
            {
                DialogResult dialogResult = userListPopUp.ShowDialog();
                userListPopUp.Dispose();
            }
        }

        private void buttonAssignTask_Click(object sender, EventArgs e)
        {

            TaskAssignPopUp taskAssignPopUp = new TaskAssignPopUp();
            DialogResult dialogResult = taskAssignPopUp.ShowDialog();
            taskAssignPopUp.Dispose();
        }

        
    }
}
