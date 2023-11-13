using System.Globalization;

namespace ToDoCalender
{
    public partial class Form1 : Form
    {
        public Form1()
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
    }
}