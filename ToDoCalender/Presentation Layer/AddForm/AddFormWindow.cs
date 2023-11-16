namespace AddForm
{
    public partial class AddFormWindow : Form
    {
        public AddFormWindow()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            DateTime chosenDate = dateTimePicker1.Value;
            string dateString = chosenDate.ToString();
            ListViewItem dateItem = new ListViewItem(dateString);
            listViewDates.Items.Add(dateItem);

        }
    }
}