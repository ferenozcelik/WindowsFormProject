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
    public partial class UserListPopUp : Form
    {
        SqlConnection connection = new SqlConnection(@"Data Source = .\SQLEXPRESS; Initial Catalog = TestDB; Integrated Security = True");
        SqlCommand sqlCommand;
        public UserListPopUp()
        {
            InitializeComponent();
            DisplayUsers();
        }
        public void DisplayUsers()
        {
            using (connection)
            {
                sqlCommand = new SqlCommand("Select UserID as ID, FirstName as [First Name], LastName as [Last Name], Country, City, Role", connection);
                connection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("Select UserID as ID, FirstName as [First Name], LastName as [Last Name], Country, City, Role from Users", connection);
                DataTable dataTable = new DataTable();
                sqlDa.Fill(dataTable);

                //dgvUserList.AutoGenerateColumns = false;  // ERROR
                dgvUserList.DataSource = dataTable;
            }
            
        }
    }
}
