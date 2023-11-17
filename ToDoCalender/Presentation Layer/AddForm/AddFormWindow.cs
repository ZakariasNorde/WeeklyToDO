using Models;
using BLLToDO;

namespace AddForm
{
    public partial class AddFormWindow : Form
    {
        private TaskManager myTaskManager;
        public AddFormWindow()
        {
            InitializeComponent();
            myTaskManager = new TaskManager();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void cmbRoutine_SelectedIndexChanged(object sender, EventArgs e)
        {
            listViewDates.Items.Clear();
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
                string dateString = chosenDate.ToString();
                ListViewItem dateItem = new ListViewItem(dateString);
                listViewDates.Items.Add(dateItem);
            }

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
                        addTaskToView(createdTask);
                        
                    }

                    else
                    {

                    }


                }
            }
            else
            {
                MessageBox.Show("Fill all textboxes first");
            }

                
            
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

        public void addTaskToView(TaskToDo aTask)
        {
            ListViewItem anItem = new ListViewItem(aTask.Title);
            anItem.Tag = aTask;
            
        }
        
    }
}