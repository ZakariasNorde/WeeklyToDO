using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLLToDO;
using Models;

namespace ToDoCalender
{
    public partial class MoreAboutTask : Form
    {
        private ToDoCalenderWindow OriginalWindow { get; set; }
        public TaskToDo TheTask { get; set; }
        public MoreAboutTask(TaskToDo aTask, object sender)
        {
            TheTask = aTask;
            InitializeComponent();
            setComponentValues();
            OriginalWindow = (ToDoCalenderWindow)sender;

        }

        public void setComponentValues()
        {
            txtName.Text = TheTask.Title;
            txtDesc.Text = TheTask.Description;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (InputValidation.ValidateDelete())
            {
                MessageBox.Show("Task Deleted!");
                OriginalWindow.DeleteTask(TheTask);
                this.Close();
            }
            else
            {
                MessageBox.Show("Task was not deleted!");
            }
        }
    }
}
