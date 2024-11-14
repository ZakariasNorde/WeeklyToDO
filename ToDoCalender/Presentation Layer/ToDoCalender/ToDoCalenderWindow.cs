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
        public List<DateTime> datesOfWeek { get; set; }
        List<TextBox> DayBoxes = new List<TextBox>();

        public ToDoCalenderWindow()
        {
            InitializeComponent();
            myTimer.Interval = 1000;
            myTimer.Tick += myTimerTick;
            myTimer.Start();
            myTaskManager = new TaskManager();
            datesOfWeek = new List<DateTime>();
            currentDate = DateTime.Now;
            fillLabelList();
            setDatesOfWeek();
            setBoxes(currentDate);
            loadTasks();
        }

        public void myTimerTick(object sender, EventArgs e)
        {
            TimeSpan currentTime = DateTime.Now.TimeOfDay;
            int hours = currentTime.Hours;
            int minutes = currentTime.Minutes;
            int seconds = currentTime.Seconds;
            //D2 gör att det alltid visas minst 2 siffor alltså 00 ist för 0
            lblTime.Text = $"{hours:D2}:{minutes:D2}:{seconds:D2}";
        }
        private void setBoxes(DateTime date)
        {
            int week = getWeek(date);
            lblCurrentWeek.Text = "Week: " + week;
            setDatesOfWeek();
        }

        private void fillLabelList()
        {
            List<TextBox> labels = new List<TextBox>();
            labels.Add(txtMonday);
            labels.Add(txtTuesday);
            labels.Add(txtWednesday);
            labels.Add(txtThursday);
            labels.Add(txtFriday);
            labels.Add(txtSaturday);
            labels.Add(txtSunday);
            DayBoxes = labels;
        }
        public void setDatesOfWeek()
        {
            DateTime firstDayOfWeek = currentDate.AddDays((int)DayOfWeek.Monday - (int)currentDate.DayOfWeek);
            datesOfWeek.Clear();
            for (int i = 0; i < 7; i++)
            {
                datesOfWeek.Add(firstDayOfWeek.AddDays(i));
            }
            setLabelDaysOfWeek();
        }

        public void setLabelDaysOfWeek()
        {
            for (int i = 0; i < 7; i++)
            {
                DateTime aDate = datesOfWeek[i];
                string theDayNumber = getDayWithSuffix(aDate);
                string weekDay = getWeekDay(aDate);
                string month = getMonth(aDate);
                DayBoxes[i].Text = weekDay + " The " + theDayNumber + " of " + month;
            }
        }
        public static string getDayWithSuffix(DateTime date)
        {
            int day = date.Day;
            string suffix;

            if (day >= 11 && day <= 13)
            {
                suffix = "th";
            }
            else
            {
                switch (day % 10)
                {
                    case 1:
                        suffix = "st";
                        break;
                    case 2:
                        suffix = "nd";
                        break;
                    case 3:
                        suffix = "rd";
                        break;
                    default:
                        suffix = "th";
                        break;
                }
            }

            return $"{day}{suffix}";
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

        public int getYear(DateTime aDate)
        {
            return aDate.Year;
        }
        public string getMonth(DateTime aDate)
        {
            return aDate.ToString("MMMM");
        }

        public string getWeekDay(DateTime aDate)
        {
            return aDate.DayOfWeek.ToString();
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
                    if (getWeek(currentDate) == getWeek(aDate) && getYear(currentDate) == getYear(aDate))
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
            int daysUntilTargetDay = ((int)weekday - (int)currentDate.DayOfWeek);
            DateTime result = currentDate.AddDays(daysUntilTargetDay);
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
            updateCurrentDay(-7);
            setBoxes(currentDate);
            loadTasks();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clearAll();
            updateCurrentDay(7);
            setBoxes(currentDate);
            loadTasks();
        }

        private void updateCurrentDay(int numberToAdd)
        {
            currentDate = currentDate.AddDays(numberToAdd);
            setDatesOfWeek();
        }


    }
}