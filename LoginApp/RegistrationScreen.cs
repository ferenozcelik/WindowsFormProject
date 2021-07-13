using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class RegistrationScreen : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = TestDB; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader reader;
        public static string userName, passWord;
        public static string firstName, lastName;
        public static string countrY, citY;
        public RegistrationScreen()
        {
            InitializeComponent();
        }

        private void RegistrationScreen_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True; MultipleActiveResultSets=true");
        }

        public void Register()
        {
            connection.Open();
            if (txtPassword.Text != string.Empty && txtConfirmPassword.Text != string.Empty && txtUsername.Text != string.Empty
                && txtFirstName.Text != string.Empty && txtLastName.Text != string.Empty
                && txtCountry.Text != string.Empty && txtCity.Text != string.Empty && checkedListBoxRole.SelectedItems.Count != 0)
            {
                if (txtPassword.Text == txtConfirmPassword.Text)
                {
                    sqlCommand = new SqlCommand("Select * from Users where Username = '" + txtUsername.Text + "'", connection);
                    reader = sqlCommand.ExecuteReader();
                    if (reader.Read())
                    {
                        reader.Close();
                        MessageBox.Show("Username already exists. Please try another username", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        reader.Close();
                        
                        sqlCommand = new SqlCommand("insert into Users values(@Username, @Password, @LastName, " +
                            "@FirstName, @Country, @City, @Role, @Admin)", connection);
                        sqlCommand.Parameters.AddWithValue("Username", txtUsername.Text);
                        sqlCommand.Parameters.AddWithValue("Password", txtPassword.Text);
                        sqlCommand.Parameters.AddWithValue("LastName", txtLastName.Text);
                        sqlCommand.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                        sqlCommand.Parameters.AddWithValue("Country", txtCountry.Text);
                        sqlCommand.Parameters.AddWithValue("City", txtCity.Text);

                        // checkedListBox Role control
                        string selectedRole;
                        string[] selectedRoles;
                        /*
                        if (checkedListBoxRole.SelectedItems.Count > 1)
                        {
                            selectedRoles = new string[checkedListBoxRole.SelectedItems.Count];
                            foreach (var role in selectedRoles)
                            {
                                
                            }
                        }
                        */
                        if (checkedListBoxRole.SelectedItems.Count == 1)
                        {
                            selectedRole = checkedListBoxRole.SelectedItem.ToString();
                            sqlCommand.Parameters.AddWithValue("Role", selectedRole);
                        }
                        

                        // checkBox Admin control
                        if (checkBoxAdmin.Checked == true)
                        {
                            sqlCommand.Parameters.AddWithValue("Admin", true);
                        }
                        else
                        {
                            sqlCommand.Parameters.AddWithValue("Admin", false);
                        }
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Your account is created. Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        
                        this.Hide();
                        LoginScreen loginScreen = new LoginScreen();
                        loginScreen.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxAdmin_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //checkedListBoxRole.ClearSelected();
            foreach (int index in checkedListBoxRole.CheckedIndices)
            {
                checkedListBoxRole.SetItemCheckState(index, CheckState.Unchecked);
            }
        }

        private void checkedListBoxRole_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            for (int index = 0; index < checkedListBoxRole.Items.Count; ++index)
            {
                if (index != e.Index) 
                {
                    checkedListBoxRole.SetItemChecked(index, false);
                }
            }
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register();
        }
    }
}
