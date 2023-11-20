namespace ToDoCalender
{
    partial class AddForm
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
            dateTimePicker1 = new DateTimePicker();
            btnAdd = new Button();
            lblTaskName = new Label();
            txtTaskName = new TextBox();
            lblTaskDescription = new Label();
            txtDescription = new TextBox();
            btnClearTask = new Button();
            cmbRoutine = new ComboBox();
            listViewDates = new ListView();
            columnHeader1 = new ColumnHeader();
            SuspendLayout();
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(277, 109);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 5;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Orange;
            btnAdd.Location = new Point(641, 201);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 54);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add Task to all chosen dates";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.BackColor = SystemColors.ActiveCaption;
            lblTaskName.Location = new Point(73, 73);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(77, 20);
            lblTaskName.TabIndex = 10;
            lblTaskName.Text = "Task name";
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(73, 109);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(125, 27);
            txtTaskName.TabIndex = 11;
            // 
            // lblTaskDescription
            // 
            lblTaskDescription.AutoSize = true;
            lblTaskDescription.BackColor = SystemColors.ActiveCaption;
            lblTaskDescription.Location = new Point(73, 167);
            lblTaskDescription.Name = "lblTaskDescription";
            lblTaskDescription.Size = new Size(116, 20);
            lblTaskDescription.TabIndex = 12;
            lblTaskDescription.Text = "Task Description";
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(73, 215);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(154, 159);
            txtDescription.TabIndex = 13;
            // 
            // btnClearTask
            // 
            btnClearTask.BackColor = Color.Orange;
            btnClearTask.Location = new Point(73, 399);
            btnClearTask.Name = "btnClearTask";
            btnClearTask.Size = new Size(94, 29);
            btnClearTask.TabIndex = 14;
            btnClearTask.Text = "Clear Task";
            btnClearTask.UseVisualStyleBackColor = false;
            btnClearTask.Click += btnClearTask_Click;
            // 
            // cmbRoutine
            // 
            cmbRoutine.FormattingEnabled = true;
            cmbRoutine.Items.AddRange(new object[] { "Add task to chosen days every week", "Add task only to chosen days" });
            cmbRoutine.Location = new Point(277, 65);
            cmbRoutine.Name = "cmbRoutine";
            cmbRoutine.Size = new Size(278, 28);
            cmbRoutine.TabIndex = 15;
            cmbRoutine.Text = "Choose task type";
            cmbRoutine.SelectedIndexChanged += cmbRoutine_SelectedIndexChanged;
            // 
            // listViewDates
            // 
            listViewDates.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewDates.Location = new Point(277, 175);
            listViewDates.Name = "listViewDates";
            listViewDates.Size = new Size(278, 199);
            listViewDates.TabIndex = 16;
            listViewDates.UseCompatibleStateImageBehavior = false;
            listViewDates.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Dates chosen";
            columnHeader1.Width = 250;
            // 
            // AddForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(849, 496);
            Controls.Add(listViewDates);
            Controls.Add(cmbRoutine);
            Controls.Add(btnClearTask);
            Controls.Add(txtDescription);
            Controls.Add(lblTaskDescription);
            Controls.Add(txtTaskName);
            Controls.Add(lblTaskName);
            Controls.Add(btnAdd);
            Controls.Add(dateTimePicker1);
            Name = "AddForm";
            Text = "AddForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DateTimePicker dateTimePicker1;
        private Button btnAdd;
        private Label lblTaskName;
        private TextBox txtTaskName;
        private Label lblTaskDescription;
        private TextBox txtDescription;
        private Button btnClearTask;
        private ComboBox cmbRoutine;
        private ListView listViewDates;
        private ColumnHeader columnHeader1;
    }
}