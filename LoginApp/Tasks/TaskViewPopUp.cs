﻿using LoginApp.Constants;
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

        public bool taskListState = true;
        public TaskViewPopUp()
        {
            InitializeComponent();

            if (LoginScreen.admin == false)
            {
                buttonDeleteTask.Enabled = false;
                buttonDeleteTask.Visible = false;
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
                        sqlDa = new SqlDataAdapter("Select Task, Role, DueDate as [Due Date] from Tasks order by DueDate", connection);
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

        private void buttonDeleteTask_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTaskList.SelectedRows)
            {
                if (!row.IsNewRow)
                {
                    dgvTaskList.Rows.Remove(row);
                }

            }
            sqlDa.Update(dataTable);
        }
    }
}