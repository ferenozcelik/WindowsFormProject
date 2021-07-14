﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    
    public partial class LoginScreen : Form
    {
        // database bağlantı sağlanamazsa message box
        
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = TestDB; Integrated Security = True");
        SqlCommand sqlCommand;
        SqlDataReader reader;

        public static string userName;
        public static string firstName, lastName;
        public static string country, city;
        public static string role;
        public static bool admin;

        public void Login(string username, string password, Form form1)
        {
            using (connection)
            {

            }


            sqlCommand = new SqlCommand("Select * from Users Where Username='" + username + "' and Password='" + password + "'", connection);
            //using (connection) { }
            try
            {
                connection.Open();
                // hata olursa connection açılıyor mu?
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                reader = sqlCommand.ExecuteReader();
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                    "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                connection.Close();
                return;
            }

            if (reader.Read()) // if it could read
            {
                //MessageBox.Show("Login successful!", "Succeeded", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // store data of the user
                userName = reader["Username"].ToString();
                firstName = reader["FirstName"].ToString();
                lastName = reader["LastName"].ToString();
                country = reader["Country"].ToString();
                city = reader["City"].ToString();
                admin = (bool)reader["Admin"];
                role = reader["Role"].ToString();

                reader.Close();

                // show home screen
                HomeScreen home = new HomeScreen();
                form1.Hide();
                home.ShowDialog();
                Application.Exit();
            }
            else
            {
                MessageBox.Show("Wrong username or password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            sqlCommand.Dispose();
        }

        
        public LoginScreen()
        {
            //Thread t = new Thread(new ThreadStart(StartForm));
            //t.Start();
            //Thread.Sleep(5000);
            InitializeComponent();
            //t.Abort();
            //t.Interrupt();

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {

        }


        private void LoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed
            Application.Exit();
        }

        private void LoginScreen_Shown(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUser.Text;
            string passwordInput = txtPass.Text;
            Login(usernameInput, passwordInput, this);

        }


    }
}
