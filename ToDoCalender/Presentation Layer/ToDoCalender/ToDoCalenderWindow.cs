using System.Globalization;
using AddForm;
namespace ToDoCalender
{
    public partial class ToDoCalenderWindow : Form
    {
        public ToDoCalenderWindow()
        {
            InitializeComponent();
            lblWeek.Text = $"Week {getCurrentWeek()}";

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lblTuesday_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private int getCurrentWeek()
        {
            DateTime now = DateTime.Now;
            CultureInfo cultureInfo = CultureInfo.CurrentCulture;
            Calendar calendar = cultureInfo.Calendar;
            return calendar.GetWeekOfYear(now, CalendarWeekRule.FirstFullWeek, DayOfWeek.Monday);
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
            AddFormWindow addWindow = new AddFormWindow();
            addWindow.Show();
            ListViewItem ettItem = new ListViewItem("btnadd");
            ettItem.Checked = true;
            listView1.Items.Add(ettItem);
        }
    }
}