using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class ProfileDetailsPopUp : Form
    {
        
        public ProfileDetailsPopUp()
        {
            InitializeComponent();
            labelFirstName.Text = LoginScreen.firstName;
            labelLastName.Text = LoginScreen.lastName;
            labelCountry.Text = LoginScreen.country;
            labelCity.Text = LoginScreen.city;
            labelRole.Text = LoginScreen.role;
        }


        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void ProfileDetailsPopUp_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void labelFirstName_Click(object sender, EventArgs e)
        {

        }
    }
}
