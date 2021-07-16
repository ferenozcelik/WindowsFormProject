using System;
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

        static string conStr = @"Data Source = .\SQLEXPRESS; Initial Catalog = TestDB; Integrated Security = True";
        //SqlConnection connection = new SqlConnection(conStr);
        SqlCommand sqlCommand;
        SqlDataReader reader;

        public static string userName;
        public static string firstName, lastName;
        public static string country, city;
        public static string role;
        public static bool admin;

        public void Login(string username, string password, Form form1)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(conStr))
                {
                    sqlCommand = new SqlCommand("Select * from Users Where Username = '" + username + "' and Password = '" + password + "'", connection);
                    connection.Open();
                    try
                    {
                        reader = sqlCommand.ExecuteReader();

                        if (reader.Read()) // if it could read
                        {
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
                        sqlCommand.Dispose();
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                            "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        sqlCommand.Dispose();
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                //return;
            }

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

        private void LoginScreen_FormClosed(object sender, FormClosedEventArgs e)
        {
            //exit application when form is closed
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            string usernameInput = txtUser.Text;
            string passwordInput = txtPass.Text;
            Login(usernameInput, passwordInput, this);
        }
    }
}
