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
            textBox1 = new TextBox();
            lblTaskName = new Label();
            dateTimePicker1 = new DateTimePicker();
            textBox2 = new TextBox();
            lblTaskDescription = new Label();
            cmbRoutine = new ComboBox();
            btnClearTask = new Button();
            listView1 = new ListView();
            columnHeader1 = new ColumnHeader();
            btnAdd = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Location = new Point(73, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(125, 27);
            textBox1.TabIndex = 0;
            // 
            // lblTaskName
            // 
            lblTaskName.AutoSize = true;
            lblTaskName.Location = new Point(73, 52);
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
            // 
            // textBox2
            // 
            textBox2.Location = new Point(73, 197);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.ScrollBars = ScrollBars.Vertical;
            textBox2.Size = new Size(154, 159);
            textBox2.TabIndex = 3;
            // 
            // lblTaskDescription
            // 
            lblTaskDescription.AutoSize = true;
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
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader1 });
            listView1.Location = new Point(293, 157);
            listView1.Name = "listView1";
            listView1.Size = new Size(250, 199);
            listView1.TabIndex = 7;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Dates chosen";
            columnHeader1.Width = 250;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.Orange;
            btnAdd.Location = new Point(612, 173);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(134, 54);
            btnAdd.TabIndex = 8;
            btnAdd.Text = "Add Task to all chosen dates";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(800, 450);
            Controls.Add(btnAdd);
            Controls.Add(listView1);
            Controls.Add(btnClearTask);
            Controls.Add(cmbRoutine);
            Controls.Add(lblTaskDescription);
            Controls.Add(textBox2);
            Controls.Add(dateTimePicker1);
            Controls.Add(lblTaskName);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Label lblTaskName;
        private DateTimePicker dateTimePicker1;
        private TextBox textBox2;
        private Label lblTaskDescription;
        private ComboBox cmbRoutine;
        private Button btnClearTask;
        private ListView listView1;
        private ColumnHeader columnHeader1;
        private Button btnAdd;
    }
}