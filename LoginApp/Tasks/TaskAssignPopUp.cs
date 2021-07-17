using LoginApp.Constants;
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
    public partial class TaskAssignPopUp : Form
    {
        
        public static string task;
        public static string role;
        public static DateTime dueDate;

        static SqlConnection connection = new SqlConnection(ConnectionStrings.conStrMars);
        public TaskAssignPopUp()
        {
            InitializeComponent();

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TaskAssignScreen_Load(object sender, EventArgs e)
        {
            // listbox data
            //dataAdapter vs dataReader
            SqlCommand command = new SqlCommand("select distinct Role from Users", connection); // tüm rolleri al ve aynı olan rolleri ayrıştır
            SqlDataAdapter sqlDa = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            sqlDa.Fill(dataTable); // dataTable'ın içeriğini command execute edildiğinde gelen veri ile doldur

            for (int i = 0; i < dataTable.Rows.Count; i++) // dataTable'ın tüm elemanlarına sırayla eriş
            {
                checkedListBoxRoles.Items.Add(dataTable.Rows[i]["Role"].ToString()); 
                // dataTable'ın her bir elemanını dolaş, command execute edildiğinde rol listesi gelecek.
                // rol listesinde tek bir kolon var, "Role".
                // sırayla elemanları dolaşıp, "Role" kolonundaki karşılıklarını bul ve string'e çevir.
                // string'e çevrilen rolleri checkedListBox'a ekle.
            }
        }

        private void buttonAssign_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                Assign();
            }
            else { }
        }

        
        public void Assign()
        {
            try
            {
                using (SqlConnection connection2 = new SqlConnection(ConnectionStrings.conStr))
                {
                    //SqlCommand sqlCommand = new SqlCommand("insert into Tasks values(@Task, @Role, @DueDate)", connection2);
                    SqlCommand sqlCommand;
                    connection2.Open();
                    if (txtTask.Text == string.Empty || !dateTimePickerDueDate.Checked || checkedListBoxRoles.CheckedItems.Count == 0)
                    {
                        MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // for loop checkedListBox Roles
                        for (int i = 0; i < checkedListBoxRoles.CheckedItems.Count; i++)
                        {
                            sqlCommand = new SqlCommand("insert into Tasks values(@Task, @Role, @DueDate)", connection2);
                            sqlCommand.Parameters.AddWithValue("Task", txtTask.Text);
                            sqlCommand.Parameters.AddWithValue("Role", checkedListBoxRoles.CheckedItems[i].ToString());
                            sqlCommand.Parameters.AddWithValue("DueDate", dateTimePickerDueDate.Value.ToString("yyyy/MM/dd"));

                            //dateTimePickerDueDate.Value.ToString("yyyy-MM-dd hh:mm:ss.fff");
                            //dateTimePickerDueDate.Value.Date.ToString("yyyy-MM-dd")
                            
                            try
                            {
                                sqlCommand.ExecuteNonQuery();
                            }
                            catch (SqlException e)
                            {
                                MessageBox.Show(e.Message);
                                //MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                                //    "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                sqlCommand.Dispose();
                                return;
                            }
                            
                        }
                        MessageBox.Show("Task assigned!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error code: " + e.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
