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

        SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=TestDB;Integrated Security=True; MultipleActiveResultSets=true");
        SqlCommand sqlCommand;
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
            var confirmResult = Confirmation.Confirm();
            if (confirmResult == DialogResult.Yes)
            {
                Assign();
            }
            else { }
        }

        // ****??
        //SqlCommand sqlCommandNew = new SqlCommand("insert into Tasks values(@Task, @Role, @DueDate)", connection);
        public void Assign()
        {
            connection.Open();
            if (txtTask.Text == string.Empty || !dateTimePickerDueDate.Checked || checkedListBoxRoles.CheckedItems.Count == 0)
            {
                MessageBox.Show("Please fill in all the required fields!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                // for loop checkedListBox Roles
                for (int i = 0; i < checkedListBoxRoles.CheckedItems.Count; i++)
                {

                    //MessageBox.Show(checkedListBoxRoles.CheckedItems[i].ToString());

                    sqlCommand = new SqlCommand("insert into Tasks values(@Task, @Role, @DueDate)", connection);
                    sqlCommand.Parameters.AddWithValue("Task", txtTask.Text);
                    sqlCommand.Parameters.AddWithValue("Role", checkedListBoxRoles.CheckedItems[i].ToString());
                    sqlCommand.Parameters.AddWithValue("DueDate", dateTimePickerDueDate.Value.ToString("yyyy/MM/dd"));
                    //dateTimePickerDueDate.Value.ToString("yyyy-MM-dd hh:mm:ss.fff");
                    //dateTimePickerDueDate.Value.Date.ToString("yyyy-MM-dd")

                    sqlCommand.ExecuteNonQuery();
                }

                MessageBox.Show("Task assigned!", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            connection.Close();
        }

        
    }
}
