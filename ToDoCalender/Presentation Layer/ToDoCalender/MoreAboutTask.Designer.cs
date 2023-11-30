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
            taskName = new Label();
            SuspendLayout();
            // 
            // taskName
            // 
            taskName.AutoSize = true;
            taskName.Location = new Point(345, 34);
            taskName.Name = "taskName";
            taskName.Size = new Size(0, 20);
            taskName.TabIndex = 0;
            // 
            // MoreAboutTask
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(taskName);
            Name = "MoreAboutTask";
            Text = "MoreAboutTask";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label taskName;
    }
}