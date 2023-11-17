using System.Globalization;
using Models;
using System.Timers;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace ToDoCalender
{
    public partial class ToDoCalenderWindow : Form
    {
        public string currentDay;
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();
        public ToDoCalenderWindow()
        {
            InitializeComponent();
            myTimer.Interval = 1000;
            myTimer.Tick += myTimerTick;
            myTimer.Start();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void myTimerTick(object sender, EventArgs e)
        {
            string currentTime = DateTime.Now.ToString();
            string currentDay = getCurrentDay();
            lblCurrentTime.Text = $"Week {getCurrentWeek()} {currentDay} {currentTime}";

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

        private void button1_Click(object sender, EventArgs e)
        {
            ListViewItem ettItem = new ListViewItem("HEEEEJ");
            ettItem.Checked = true;
            listView1.Items.Add(ettItem);
        }



        private void btnAddTask_Click(object sender, EventArgs e)
        {
            AddForm addWindow = new AddForm();
            addWindow.Show();
            ListViewItem ettItem = new ListViewItem("btnadd");
            ettItem.Checked = true;
            listView1.Items.Add(ettItem);
        }

        private int getCurrentWeek()
        {
            DateTime now = DateTime.Now;
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Calendar calendar = cultureInfo.Calendar;
            return calendar.GetWeekOfYear(now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
        }

        private string getCurrentDay()
        {
            DateTime today = DateTime.Today;
            return today.DayOfWeek.ToString();
        }
    }
}