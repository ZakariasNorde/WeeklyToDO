namespace ToDoCalender
{
    partial class MoreAboutTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MoreAboutTask));
            taskName = new Label();
            lblNameOfTask = new Label();
            lblDesc = new Label();
            txtDesc = new TextBox();
            txtName = new TextBox();
            txtInfo = new TextBox();
            btnDelete = new Button();
            SuspendLayout();
            // 
            // taskName
            // 
            taskName.Location = new Point(0, 0);
            taskName.Name = "taskName";
            taskName.Size = new Size(100, 23);
            taskName.TabIndex = 2;
            // 
            // lblNameOfTask
            // 
            lblNameOfTask.AutoSize = true;
            lblNameOfTask.BackColor = SystemColors.Highlight;
            lblNameOfTask.Location = new Point(345, 26);
            lblNameOfTask.Name = "lblNameOfTask";
            lblNameOfTask.Size = new Size(98, 20);
            lblNameOfTask.TabIndex = 1;
            lblNameOfTask.Text = "Name of Task";
            // 
            // lblDesc
            // 
            lblDesc.AutoSize = true;
            lblDesc.BackColor = SystemColors.ActiveCaption;
            lblDesc.Location = new Point(571, 107);
            lblDesc.Name = "lblDesc";
            lblDesc.Size = new Size(85, 20);
            lblDesc.TabIndex = 3;
            lblDesc.Text = "Description";
            // 
            // txtDesc
            // 
            txtDesc.Location = new Point(515, 140);
            txtDesc.Multiline = true;
            txtDesc.Name = "txtDesc";
            txtDesc.ScrollBars = ScrollBars.Horizontal;
            txtDesc.Size = new Size(201, 270);
            txtDesc.TabIndex = 4;
            // 
            // txtName
            // 
            txtName.Location = new Point(318, 49);
            txtName.Name = "txtName";
            txtName.Size = new Size(153, 27);
            txtName.TabIndex = 5;
            // 
            // txtInfo
            // 
            txtInfo.BackColor = Color.Orange;
            txtInfo.Location = new Point(65, 143);
            txtInfo.Multiline = true;
            txtInfo.Name = "txtInfo";
            txtInfo.ReadOnly = true;
            txtInfo.Size = new Size(202, 267);
            txtInfo.TabIndex = 6;
            txtInfo.Text = resources.GetString("txtInfo.Text");
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.Red;
            btnDelete.Location = new Point(576, 442);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 7;
            btnDelete.Text = "DELETE TASK";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // MoreAboutTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(863, 542);
            Controls.Add(btnDelete);
            Controls.Add(txtInfo);
            Controls.Add(txtName);
            Controls.Add(txtDesc);
            Controls.Add(lblDesc);
            Controls.Add(lblNameOfTask);
            Controls.Add(taskName);
            Name = "MoreAboutTask";
            Text = "MoreAboutTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label taskName;
        private Label lblNameOfTask;
        private Label lblDesc;
        private TextBox txtDesc;
        private TextBox txtName;
        private TextBox txtInfo;
        private Button btnDelete;
    }
}