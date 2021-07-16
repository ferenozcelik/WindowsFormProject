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
        //SqlCommand sqlCommand;

        public static bool state = true;
        public UserListPopUp()
        {
            InitializeComponent();
            DisplayUsers();
        }
        public void DisplayUsers()
        {
            try
            {
                using (connection)
                {
                    // COMMAND'I DATAADAPTER'A VEREMİYORUM
                    //sqlCommand = new SqlCommand("Select UserID as ID, FirstName as [First Name], LastName as [Last Name], Country, City, Role", connection);

                    connection.Open(); // bağlanamazsa açmıyor. kapalı kalıyor
                    state = true;
                    SqlDataAdapter sqlDa = new SqlDataAdapter("Select UserID as ID, FirstName as [First Name], LastName as [Last Name], Country, City, Role from Users", connection);
                    DataTable dataTable = new DataTable();
                    sqlDa.Fill(dataTable);

                    dgvUserList.DataSource = dataTable;
                    //dgvUserList.AutoGenerateColumns = false;  // error
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.", 
                    "Error code: " + e.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                state = false;
                // EKRANIN GELMESİNİ ENGELLE
            }
        }
    }
}
