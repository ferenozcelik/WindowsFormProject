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
                && txtCountry.Text != string.Empty && txtCity.Text != string.Empty)
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
                            "@FirstName, @Country, @City)", connection);
                        sqlCommand.Parameters.AddWithValue("Username", txtUsername.Text);
                        sqlCommand.Parameters.AddWithValue("Password", txtPassword.Text);
                        sqlCommand.Parameters.AddWithValue("LastName", txtLastName.Text);
                        sqlCommand.Parameters.AddWithValue("FirstName", txtFirstName.Text);
                        sqlCommand.Parameters.AddWithValue("Country", txtCountry.Text);
                        sqlCommand.Parameters.AddWithValue("City", txtCity.Text);
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
                MessageBox.Show("Please enter value in all field!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

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
