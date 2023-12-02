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
        private DateTime currentDate { get; set; }

        public ToDoCalenderWindow()
        {
            InitializeComponent();
            //använd kanske timer senare?
            //myTimer.Interval = 1000;
            //myTimer.Tick += myTimerTick;
            //myTimer.Start();
            myTaskManager = new TaskManager();
            currentDate = DateTime.Now;
            setWeek(currentDate);
            loadTasks();
        }

        private void setWeek(DateTime date)
        {
            int week = getWeek(date);
            lblCurrentWeek.Text = "Week: " + week;
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
                    if (getWeek(currentDate) == getWeek(aDate))
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
        private void listView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {   //eftersom eventet triggas vid launch så har jag lagt till detta för att 
            // denna kod inte ska köras vid launch
            ListView currentListView = (ListView)sender;
            string dayAsString = (string)currentListView.Tag;
            DayOfWeek dayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), dayAsString);
            if (e.Item.Focused)
            {
                //lägg detta i en metod sen så att alla olika listviews kan återanvända ist

                ListViewItem checkedItem = e.Item;

                //notera att default värdet som returneras av checked är false.
                if (checkedItem.Checked)
                {
                    TaskToDo checkedTask = (TaskToDo)checkedItem.Tag;
                    DateTime checkedDate = getDateOfDay(dayOfWeek);
                    myTaskManager.checkTask(checkedTask, checkedDate);
                }
                else
                {
                    TaskToDo checkedTask = (TaskToDo)checkedItem.Tag;
                    DateTime checkedDate = getDateOfDay(dayOfWeek);
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



        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListView currentListView = (ListView)sender;
            if (currentListView.SelectedItems.Count > 0)
            {
                ListViewItem chosenItem = currentListView.SelectedItems[0];
                TaskToDo chosenTask = (TaskToDo)chosenItem.Tag;
                MoreAboutTask aTaskWindow = new MoreAboutTask(chosenTask, this);
                aTaskWindow.TopMost = true;
                aTaskWindow.Show();
            }
        }

        public void DeleteTask(TaskToDo taskToDel)
        {
            clearAll();
            myTaskManager.Delete(taskToDel);
            loadTasks();
        }

        public void clearAll()
        {
            //hämtar en lista av alla listviews
            IEnumerable<Control> listViewControls = Controls.OfType<ListView>();
            List<ListView> listViewList = new List<ListView>(listViewControls.Cast<ListView>());
            foreach (ListView aListView in listViewList)
            {
                aListView.Items.Clear();
            }
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            clearAll();
            currentDate = currentDate.AddDays(-7);
            setWeek(currentDate);
            loadTasks();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clearAll();
            currentDate = currentDate.AddDays(7);
            setWeek(currentDate);
            loadTasks();
        }
    }
}