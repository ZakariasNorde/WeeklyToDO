namespace AddForm
{
    partial class AddFormWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtTaskName = new TextBox();
            lblTaskName = new Label();
            dateTimePicker1 = new DateTimePicker();
            txtDescription = new TextBox();
            lblTaskDescription = new Label();
            cmbRoutine = new ComboBox();
            btnClearTask = new Button();
            listViewDates = new ListView();
            columnHeader1 = new ColumnHeader();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // txtTaskName
            // 
            txtTaskName.Location = new Point(73, 95);
            txtTaskName.Name = "txtTaskName";
            txtTaskName.Size = new Size(125, 27);
            txtTaskName.TabIndex = 0;
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.BackColor = SystemColors.ActiveCaption;
            lblTaskName.Location = new Point(73, 49);
            lblTaskName.Name = "lblTaskName";
            lblTaskName.Size = new Size(77, 20);
            lblTaskName.TabIndex = 1;
            lblTaskName.Text = "Task name";
            lblTaskName.Click += label1_Click;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(293, 95);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(278, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtDescription
            // 
            txtDescription.Location = new Point(73, 197);
            txtDescription.Multiline = true;
            txtDescription.Name = "txtDescription";
            txtDescription.ScrollBars = ScrollBars.Vertical;
            txtDescription.Size = new Size(154, 159);
            txtDescription.TabIndex = 3;
            // 
            // lblTaskDescription
            // 
            lblTaskDescription.AutoSize = true;
            lblTaskDescription.BackColor = SystemColors.ActiveCaption;
            lblTaskDescription.Location = new Point(73, 157);
            lblTaskDescription.Name = "lblTaskDescription";
            lblTaskDescription.Size = new Size(116, 20);
            lblTaskDescription.TabIndex = 4;
            lblTaskDescription.Text = "Task Description";
            // 
            // cmbRoutine
            // 
            cmbRoutine.FormattingEnabled = true;
            cmbRoutine.Items.AddRange(new object[] { "Add task to chosen days every week", "Add task only to chosen days" });
            cmbRoutine.Location = new Point(293, 49);
            cmbRoutine.Name = "cmbRoutine";
            cmbRoutine.Size = new Size(278, 28);
            cmbRoutine.TabIndex = 5;
            cmbRoutine.Text = "Choose task type";
            cmbRoutine.SelectedIndexChanged += cmbRoutine_SelectedIndexChanged;
            // 
            // btnClearTask
            // 
            btnClearTask.BackColor = Color.Orange;
            btnClearTask.Location = new Point(95, 382);
            btnClearTask.Name = "btnClearTask";
            btnClearTask.Size = new Size(94, 29);
            btnClearTask.TabIndex = 6;
            btnClearTask.Text = "Clear Task";
            btnClearTask.UseVisualStyleBackColor = false;
            // 
            // listViewDates
            // 
            listViewDates.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listViewDates.Location = new Point(293, 157);
            listViewDates.Name = "listViewDates";
            listViewDates.Size = new Size(278, 199);
            listViewDates.TabIndex = 7;
            listViewDates.UseCompatibleStateImageBehavior = false;
            listViewDates.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Dates chosen";
            columnHeader1.Width = 250;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Orange;
            btnAdd.Location = new Point(614, 157);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 54);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Task to all chosen dates";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // AddFormWindow
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(listViewDates);
            Controls.Add(btnClearTask);
            Controls.Add(cmbRoutine);
            Controls.Add(lblTaskDescription);
            Controls.Add(txtDescription);
            Controls.Add(dateTimePicker1);
            Controls.Add(lblTaskName);
            Controls.Add(txtTaskName);
            Name = "AddFormWindow";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtTaskName;
        private Label lblTaskName;
        private DateTimePicker dateTimePicker1;
        private TextBox txtDescription;
        private Label lblTaskDescription;
        private ComboBox cmbRoutine;
        private Button btnClearTask;
        private ListView listViewDates;
        private ColumnHeader columnHeader1;
        private Button btnAdd;
    }
}