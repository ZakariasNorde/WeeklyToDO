using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Models;

namespace ToDoCalender
{
    public partial class MoreAboutTask : Form
    {
        public TaskToDo TheTask;
        public MoreAboutTask(TaskToDo aTask)
        {
            TheTask = aTask;
            InitializeComponent();
            setComponentValues();
        }

        public void setComponentValues()
        {
            taskName.Text = TheTask.Title;
        }

    }
}
