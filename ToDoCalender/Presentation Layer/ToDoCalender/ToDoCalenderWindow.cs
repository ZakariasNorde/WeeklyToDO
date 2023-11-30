using System.Globalization;
using Models;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;
using BLLToDO;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ToDoCalender
{
    public partial class ToDoCalenderWindow : Form
    {
        public string currentDay;
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        private TaskManager myTaskManager;

        public ToDoCalenderWindow()
        {
            InitializeComponent();
            myTimer.Interval = 1000;
            myTimer.Tick += myTimerTick;
            myTimer.Start();
            myTaskManager = new TaskManager();
            loadTasks();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void myTimerTick(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString();
            string currentDay = getCurrentDay();
            lblCurrentTime.Text = $"Week {getWeek(DateTime.Now)} {currentDay} {currentTime}";

        }

        private void lblTuesday_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void lblSunday_Click(object sender, EventArgs e)
        {

        }


        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddForm addWindow = new AddForm(this);
            addWindow.Show();
        }

        public static int getWeek(DateTime aDate)
        {
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Calendar calendar = cultureInfo.Calendar;
            return calendar.GetWeekOfYear(aDate, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }

        private string getCurrentDay()
        {
            DateTime today = DateTime.Today;
            return today.DayOfWeek.ToString();
        }

        public void addTaskToDay(string weekDay, TaskToDo taskToAdd)
        {
            switch (weekDay)
            {
                case "Monday":
                    addTaskToView(listViewMonday, taskToAdd, DayOfWeek.Monday);
                    break;

                case "Tuesday":
                    addTaskToView(listViewTuesday, taskToAdd, DayOfWeek.Tuesday);
                    break;

                case "Wednesday":
                    addTaskToView(listViewWednesday, taskToAdd, DayOfWeek.Wednesday);
                    break;

                case "Thursday":
                    addTaskToView(listViewThursday, taskToAdd, DayOfWeek.Thursday);
                    break;

                case "Friday":
                    addTaskToView(listViewFriday, taskToAdd, DayOfWeek.Friday);
                    break;

                case "Saturday":
                    addTaskToView(listViewSaturday, taskToAdd, DayOfWeek.Saturday);
                    break;

                case "Sunday":
                    addTaskToView(listViewSunday, taskToAdd, DayOfWeek.Sunday);
                    break;
            }
        }

        public void addTask(TaskToDo aTask)
        {
            if (aTask.Routine)
            {
                foreach (string aDay in aTask.WeekDays)
                {
                    addTaskToDay(aDay, aTask);
                }
            }

            else
            {
                foreach (DateTime aDate in aTask.Dates)
                {
                    if (getWeek(DateTime.Now) == getWeek(aDate))
                    {
                        string dayOfWeek = aDate.DayOfWeek.ToString();
                        addTaskToDay(dayOfWeek, aTask);
                    }
                }
            }
        }

        private void addTaskToView(ListView aListView, TaskToDo taskToAdd, DayOfWeek aDay)

        {

            ListViewItem aTask = new ListViewItem(taskToAdd.Title);
            aTask.Tag = taskToAdd;

            if (isCheckedDay(taskToAdd, aDay))
            {
                aTask.Checked = true;
            }

            else
            {
                aTask.Checked = false;
            }
            aListView.Items.Add(aTask);

        }

        private bool isCheckedDay(TaskToDo aTask, DayOfWeek weekday)
        {
            DateTime aDate = getDateOfDay(weekday);
            DateTime shortDate = aDate.Date;
            bool isChecked = false;

            foreach (DateTime dateFromList in aTask.CheckedDates)
            {
                DateTime shortDateList = dateFromList.Date;
                if (shortDate == shortDateList)
                {
                    isChecked = true;
                }
            }
            return isChecked;
        }
        private void loadTasks()
        {
            List<TaskToDo> tasksFromFile = myTaskManager.getAllTask();
            foreach (TaskToDo aTask in tasksFromFile)
            {
                addTask(aTask);
            }
        }
        //hur får jag uncheck att bli persistent
        private void listViewWednesday_ItemChecked(object sender, ItemCheckedEventArgs e)
        {   //eftersom eventet triggas vid launch så har jag lagt till detta för att 
            // denna kod inte ska köras vid launch
            if (e.Item.Focused)
            {
                //lägg detta i en metod sen så att alla olika listviews kan återanvända ist

                ListViewItem checkedItem = e.Item;
                //notera att default värdet som returneras av checked är false.
                if (checkedItem.Checked)
                {
                    TaskToDo checkedTask = (TaskToDo)checkedItem.Tag;
                    DateTime checkedDate = getDateOfDay(DayOfWeek.Wednesday);
                    myTaskManager.checkTask(checkedTask, checkedDate);
                }
                else
                {
                    TaskToDo checkedTask = (TaskToDo)checkedItem.Tag;
                    DateTime checkedDate = getDateOfDay(DayOfWeek.Wednesday);
                    myTaskManager.unCheckTask(checkedTask, checkedDate);
                }
            }

        }




        private DateTime getDateOfDay(DayOfWeek weekday)
        {
            DateTime today = DateTime.Now;
            int daysUntilTargetDay = ((int)weekday - (int)today.DayOfWeek);
            DateTime result = today.AddDays(daysUntilTargetDay);
            return result;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<TaskToDo> allTasks = myTaskManager.getAllTask();
            foreach (TaskToDo aTask in allTasks)
            {
                if (aTask.CheckedDates.Count == 0)
                {

                }
                else
                {
                    string aDate = aTask.CheckedDates[0].ToString();
                    textBox1.Text = aDate;
                }
            }
        }

        private void listViewWednesday_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView currentListView = (ListView)sender;
            if (currentListView.SelectedItems.Count > 0)
            {
                ListViewItem chosenItem = currentListView.SelectedItems[0];
                TaskToDo chosenTask = (TaskToDo)chosenItem.Tag;
                MoreAboutTask aTaskWindow = new MoreAboutTask(chosenTask);
                aTaskWindow.TopMost = true;
                aTaskWindow.Show();
            }
        }
    }
}