using LoginApp.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LoginApp.Tasks
{
    public partial class TaskViewPopUp : Form
    {
        SqlCommand sqlCommand;

        public bool taskListState = true;
        public TaskViewPopUp()
        {
            InitializeComponent();

            if (LoginScreen.admin == false)
            {
                buttonDeleteTask.Enabled = false;
                buttonDeleteTask.Visible = false;
                buttonUpdateTask.Enabled = false;
                buttonUpdateTask.Visible = false;
                dgvTaskList.ReadOnly = true;
            }
            
            DisplayTasks();
        }


        SqlDataAdapter sqlDa = new SqlDataAdapter();
        DataTable dataTable = new DataTable();
        public void DisplayTasks()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings.conStr))
                {
                    connection.Open();
                    taskListState = true;
                    
                    // admin control
                    if (LoginScreen.admin == true) 
                    {
                        sqlDa = new SqlDataAdapter("Select Id as ID, Task, Role, DueDate as [Due Date] from Tasks order by ID", connection);
                    }
                    if (LoginScreen.admin == false)
                    {
                        sqlDa = new SqlDataAdapter("Select Task, Role, DueDate as [Due Date] from Tasks where Role = '" + LoginScreen.role + "'", connection);
                    }

                    try
                    {
                        sqlDa.Fill(dataTable);
                        dgvTaskList.DataSource = dataTable;
                    }
                    catch (SqlException e)
                    {
                        MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                                    "Error Code: " + Convert.ToString(e.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                        taskListState = false;
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error code: " + e.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
                taskListState = false;
            }
        }


        public void DeleteTask()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings.conStr))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in dgvTaskList.SelectedRows)
                    {

                        sqlCommand = new SqlCommand("Delete from Tasks where Id = " + row.Cells["ID"].Value, connection);

                        if (!row.IsNewRow)
                        {
                            try
                            {
                                //MessageBox.Show(row.Cells["ID"].Value.ToString());
                                dgvTaskList.Rows.Remove(row);
                                sqlCommand.ExecuteNonQuery();
                            }
                            catch (SqlException ex)
                            {
                                MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                                    "Error Code: " + Convert.ToString(ex.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                                sqlCommand.Dispose();
                            }
                        }
                    }
                    sqlCommand.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error code: " + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void UpdateTask()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionStrings.conStr))
                {
                    connection.Open();
                    foreach (DataGridViewRow row in dgvTaskList.SelectedRows)
                    {
                        sqlCommand = new SqlCommand("Update Tasks set Task = @task, DueDate = @dueDate where ID = @id", connection);

                        sqlCommand.Parameters.AddWithValue("task", row.Cells["Task"].Value.ToString());
                        sqlCommand.Parameters.AddWithValue("dueDate", row.Cells["Due Date"].Value);
                        sqlCommand.Parameters.AddWithValue("id", row.Cells["ID"].Value);
                        try
                        {
                            dgvTaskList.Update();               // ./ ./ ... /.. // ..../// LEARN
                            dgvTaskList.Refresh();              // ./ ./ ... /.. // ..../// LEARN
                            sqlCommand.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("An error occurred while processing your request. Contact your system administrator.",
                                "Error Code: " + Convert.ToString(ex.ErrorCode), MessageBoxButtons.OK, MessageBoxIcon.Error);
                            sqlCommand.Dispose();
                        }
                    }
                    MessageBox.Show("Task updated.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    sqlCommand.Dispose();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("An error occurred while establishing a connection to the server. Contact your system administrator.",
                    "Error code: " + ex.ErrorCode, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                DeleteTask();
            }
            else { }
        }

        private void buttonUpdateTask_Click(object sender, EventArgs e)
        {
            if (Confirmation.Confirm() == DialogResult.Yes)
            {
                UpdateTask();
            }
            else { }
        }
    }
}
