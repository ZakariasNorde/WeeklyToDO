using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using AddForm;
using BLLToDO;
using Models;

namespace ToDoCalender
{

    public partial class AddForm : Form
    {
        private TaskManager myTaskManager;
        public ToDoCalenderWindow calenderWindow;
        public AddForm(object sender)
        {
            InitializeComponent();
            myTaskManager = new TaskManager();
            calenderWindow = (ToDoCalenderWindow)sender;
        }

        public bool checkRoutine()
        {
            string chosenType = cmbRoutine.Text;
            bool routine = false;

            if (chosenType.Contains("only"))
            {
                routine = false;
            }

            else if (chosenType.Contains("every"))
            {
                routine = true;
            }

            return routine;
        }

        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            //lägg till validering så att user har valt minst 1 datum först
            //lägg till validering så att user har valt task typ först
            //lägg till så att när du lagt valt routine eller inte och sedan ändrar efteråt så nollställs listviewn så att 
            //den inte innehåller både datum i datum form och veckodagar som strings då kraschar det i TaskToDo konstruktorn.
            if (Validation.validateTxt(txtTaskName) && Validation.validateTxt(txtDescription))
            {

                string taskName = txtTaskName.Text;
                string taskDesc = txtDescription.Text;

                if (cmbRoutine.SelectedIndex == -1)
                {
                    MessageBox.Show("Please choose task type first");
                }
                else
                {
                    if (checkRoutine())
                    {
                        List<string> daysAsString = new List<string>();
                        foreach (ListViewItem anItem in listViewDates.Items)
                        {
                            daysAsString.Add(anItem.Text);
                        }

                        TaskToDo createdTask = myTaskManager.createTask(taskName, taskDesc, daysAsString);
                        calenderWindow.addTask(createdTask);

                    }

                    else
                    {
                        List<DateTime> dates = new List<DateTime>();
                        foreach (ListViewItem anItem in listViewDates.Items)
                        {
                            string[] dateSplits = anItem.Text.Split("-");
                            List<int> datesSplitsAsInt = new List<int>();    
                            
                            foreach (string aPart in dateSplits)
                            {
                                int intPart = int.Parse(aPart);
                                datesSplitsAsInt.Add(intPart);
                            }

                            DateTime aDate = new DateTime(datesSplitsAsInt[0], datesSplitsAsInt[1], datesSplitsAsInt[2]);
                            dates.Add(aDate);
                        }

                        TaskToDo createdTask = myTaskManager.createTask(taskName, taskDesc, dates);
                        calenderWindow.addTask(createdTask);

                    }

                    


                }
            }
            else
            {
                MessageBox.Show("Please fill all textboxes first");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (checkRoutine())
            {
                DateTime chosenDay = dateTimePicker1.Value;
                string dayOfWeek = chosenDay.DayOfWeek.ToString();
                ListViewItem dayItem = new ListViewItem(dayOfWeek);
                listViewDates.Items.Add(dayItem);
            }
            else
            {
                DateTime chosenDate = dateTimePicker1.Value;
                string dateString = chosenDate.ToString("yyyy-MM-dd");
                ListViewItem dateItem = new ListViewItem(dateString);
                listViewDates.Items.Add(dateItem);
            }
        }

        private void cmbRoutine_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewDates.Items.Clear();
        }

        private void btnClearTask_Click(object sender, EventArgs e)
        {
            txtDescription.Clear();
            txtTaskName.Clear();
            listViewDates.Items.Clear();
        }
    }

}
