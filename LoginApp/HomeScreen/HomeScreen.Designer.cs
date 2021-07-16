
namespace LoginApp
{
    partial class HomeScreen
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtWelcome = new System.Windows.Forms.Label();
            this.buttonCreateAcc = new System.Windows.Forms.Button();
            this.buttonProfileDetails = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonUserList = new System.Windows.Forms.Button();
            this.buttonAssignTask = new System.Windows.Forms.Button();
            this.buttonViewTasks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(786, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtWelcome
            // 
            this.txtWelcome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWelcome.AutoSize = true;
            this.txtWelcome.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtWelcome.Location = new System.Drawing.Point(900, 9);
            this.txtWelcome.Name = "txtWelcome";
            this.txtWelcome.Size = new System.Drawing.Size(65, 35);
            this.txtWelcome.TabIndex = 1;
            this.txtWelcome.Text = "User";
            // 
            // buttonCreateAcc
            // 
            this.buttonCreateAcc.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonCreateAcc.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonCreateAcc.Location = new System.Drawing.Point(12, 25);
            this.buttonCreateAcc.Name = "buttonCreateAcc";
            this.buttonCreateAcc.Size = new System.Drawing.Size(170, 47);
            this.buttonCreateAcc.TabIndex = 2;
            this.buttonCreateAcc.Text = "Create Account";
            this.buttonCreateAcc.UseVisualStyleBackColor = true;
            this.buttonCreateAcc.Click += new System.EventHandler(this.buttonCreateAcc_Click);
            // 
            // buttonProfileDetails
            // 
            this.buttonProfileDetails.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonProfileDetails.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonProfileDetails.Location = new System.Drawing.Point(12, 78);
            this.buttonProfileDetails.Name = "buttonProfileDetails";
            this.buttonProfileDetails.Size = new System.Drawing.Size(170, 47);
            this.buttonProfileDetails.TabIndex = 3;
            this.buttonProfileDetails.Text = "Profile Details";
            this.buttonProfileDetails.UseVisualStyleBackColor = true;
            this.buttonProfileDetails.Click += new System.EventHandler(this.buttonProfileDet_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonLogout.Location = new System.Drawing.Point(786, 78);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(170, 48);
            this.buttonLogout.TabIndex = 4;
            this.buttonLogout.Text = "Log out";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonUserList
            // 
            this.buttonUserList.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonUserList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonUserList.Location = new System.Drawing.Point(12, 131);
            this.buttonUserList.Name = "buttonUserList";
            this.buttonUserList.Size = new System.Drawing.Size(170, 47);
            this.buttonUserList.TabIndex = 5;
            this.buttonUserList.Text = "User List";
            this.buttonUserList.UseVisualStyleBackColor = true;
            this.buttonUserList.Click += new System.EventHandler(this.buttonUserList_Click);
            // 
            // buttonAssignTask
            // 
            this.buttonAssignTask.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonAssignTask.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAssignTask.Location = new System.Drawing.Point(12, 335);
            this.buttonAssignTask.Name = "buttonAssignTask";
            this.buttonAssignTask.Size = new System.Drawing.Size(170, 47);
            this.buttonAssignTask.TabIndex = 6;
            this.buttonAssignTask.Text = "Assign Tasks";
            this.buttonAssignTask.UseVisualStyleBackColor = true;
            this.buttonAssignTask.Click += new System.EventHandler(this.buttonAssignTasks_Click);
            // 
            // buttonViewTasks
            // 
            this.buttonViewTasks.Cursor = System.Windows.Forms.Cursors.Default;
            this.buttonViewTasks.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonViewTasks.Location = new System.Drawing.Point(12, 282);
            this.buttonViewTasks.Name = "buttonViewTasks";
            this.buttonViewTasks.Size = new System.Drawing.Size(170, 47);
            this.buttonViewTasks.TabIndex = 7;
            this.buttonViewTasks.Text = "View Tasks";
            this.buttonViewTasks.UseVisualStyleBackColor = true;
            this.buttonViewTasks.Click += new System.EventHandler(this.buttonViewTasks_Click);
            // 
            // HomeScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1177, 617);
            this.Controls.Add(this.buttonViewTasks);
            this.Controls.Add(this.buttonAssignTask);
            this.Controls.Add(this.buttonUserList);
            this.Controls.Add(this.buttonLogout);
            this.Controls.Add(this.buttonProfileDetails);
            this.Controls.Add(this.buttonCreateAcc);
            this.Controls.Add(this.txtWelcome);
            this.Controls.Add(this.label1);
            this.Name = "HomeScreen";
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtWelcome;
        private System.Windows.Forms.Button buttonCreateAcc;
        private System.Windows.Forms.Button buttonProfileDetails;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonUserList;
        private System.Windows.Forms.Button buttonAssignTask;
        private System.Windows.Forms.Button buttonViewTasks;
    }
}