
namespace LoginApp.Tasks
{
    partial class TaskViewPopUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvTaskList = new System.Windows.Forms.DataGridView();
            this.buttonDeleteTask = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTaskList
            // 
            this.dgvTaskList.AllowUserToAddRows = false;
            this.dgvTaskList.AllowUserToDeleteRows = false;
            this.dgvTaskList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTaskList.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.dgvTaskList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTaskList.Location = new System.Drawing.Point(12, 12);
            this.dgvTaskList.Name = "dgvTaskList";
            this.dgvTaskList.ReadOnly = true;
            this.dgvTaskList.RowHeadersWidth = 51;
            this.dgvTaskList.RowTemplate.Height = 29;
            this.dgvTaskList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTaskList.Size = new System.Drawing.Size(1170, 383);
            this.dgvTaskList.TabIndex = 0;
            // 
            // buttonDeleteTask
            // 
            this.buttonDeleteTask.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDeleteTask.Font = new System.Drawing.Font("Segoe UI Semibold", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteTask.ForeColor = System.Drawing.Color.Maroon;
            this.buttonDeleteTask.Location = new System.Drawing.Point(950, 432);
            this.buttonDeleteTask.Name = "buttonDeleteTask";
            this.buttonDeleteTask.Size = new System.Drawing.Size(232, 60);
            this.buttonDeleteTask.TabIndex = 1;
            this.buttonDeleteTask.Text = "Delete";
            this.buttonDeleteTask.UseVisualStyleBackColor = true;
            this.buttonDeleteTask.Click += new System.EventHandler(this.buttonDeleteTask_Click);
            // 
            // TaskViewPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1194, 504);
            this.Controls.Add(this.buttonDeleteTask);
            this.Controls.Add(this.dgvTaskList);
            this.Name = "TaskViewPopUp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TaskViewPopUp";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTaskList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTaskList;
        private System.Windows.Forms.Button buttonDeleteTask;
    }
}