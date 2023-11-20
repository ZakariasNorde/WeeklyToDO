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
                    addTaskToView(listViewMonday, taskToAdd);
                    break;

                case "Tuesday":
                    addTaskToView(listViewTuesday, taskToAdd);
                    break;

                case "Wednesday":
                    addTaskToView(listViewWednesday, taskToAdd);
                    break;

                case "Thursday":
                    addTaskToView(listViewThursday, taskToAdd);
                    break;

                case "Friday":
                    addTaskToView(listViewFriday, taskToAdd);
                    break;

                case "Saturday":
                    addTaskToView(listViewSaturday, taskToAdd);
                    break;

                case "Sunday":
                    addTaskToView(listViewSunday, taskToAdd);
                    break;
            }
        }
        
        public void addTask(TaskToDo aTask)
        {
            if (aTask.Routine)
            {
                foreach(string aDay in aTask.WeekDays)
                {
                    addTaskToDay(aDay, aTask);
                }
            }

            else
            {
                foreach(DateTime aDate in aTask.Dates)
                {   
                    if (getWeek(DateTime.Now) == getWeek(aDate))
                    {
                        string dayOfWeek = aDate.DayOfWeek.ToString();
                        addTaskToDay(dayOfWeek, aTask);
                    }
                }
            }
        }

        private void addTaskToView(ListView aListView, TaskToDo taskToAdd)
        {
            ListViewItem aTask = new ListViewItem(taskToAdd.Title);
            aTask.Tag = taskToAdd;
            aTask.Checked = false;
            aListView.Items.Add(aTask);
        }

        private void loadTasks()
        {
            List<TaskToDo> tasksFromFile = myTaskManager.getAllTask();
            foreach (TaskToDo aTask in tasksFromFile)
            {
                addTask(aTask);
            }
        }
    }
}