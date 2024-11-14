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
		private void btnAdd_Click(object sender, EventArgs e)
		{
			TaskToDo createdTask;
			if (!ValidateBeforeAdd())
			{
				return;
			}
			string taskName = txtTaskName.Text;
			string taskDesc = txtDescription.Text;


			if (checkRoutine())
			{
				List<string> weekDays = GetWeekDays();
				createdTask = myTaskManager.createTask(taskName, taskDesc, weekDays);
			}

			else
			{
				List<DateTime> selectedDates = GetDates();
				if (selectedDates == null)
				{
					MessageBox.Show("Something is wrong with the date format");
					return;
				}
				createdTask = myTaskManager.createTask(taskName, taskDesc, selectedDates);

			}
			clearAll();
			calenderWindow.addTask(createdTask);
		}

		private List<string> GetWeekDays()
		{
			List<string> daysAsString = new List<string>();
			foreach (ListViewItem anItem in listViewDates.Items)
			{
				daysAsString.Add(anItem.Tag.ToString());
			}
			return daysAsString;
		}

		private List<DateTime> GetDates()
		{
			List<DateTime> dates = new List<DateTime>();

			foreach (ListViewItem anItem in listViewDates.Items)
			{
				DateTime aDate;
				bool success = DateTime.TryParse(anItem.Text, out aDate);
				if (success)
				{
					dates.Add(aDate);
				}
				else
				{
					return null;
				}
			}
			return dates;
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
		private bool ValidateBeforeAdd()
		{
			if (!InputValidation.validateTxt(txtTaskName) || !InputValidation.validateTxt(txtDescription))
			{
				MessageBox.Show("Please fill all boxes first");
				return false;
			}

			if (InputValidation.listViewIsEmpty(listViewDates))
			{
				MessageBox.Show("Task must be assigned to ateast 1 date/day");
				return false;
			}

			if (cmbRoutine.SelectedIndex == -1)
			{
				MessageBox.Show("Please choose task type first");
				return false;
			}
			return true;
		}


		private void cmbRoutine_SelectedIndexChanged(object sender, EventArgs e)
		{
			listViewDates.Items.Clear();
		}

		private void btnClearTask_Click(object sender, EventArgs e)
		{
			clearAll();
		}

		private void clearAll()
		{
			txtDescription.Clear();
			txtTaskName.Clear();
			listViewDates.Items.Clear();
		}

		private void dateTimePicker1_CloseUp(object sender, EventArgs e)
		{
			if (checkRoutine())
			{
				DateTime chosenDay = dateTimePicker1.Value;
				string dayOfWeek = chosenDay.DayOfWeek.ToString();
				ListViewItem dayItem = new ListViewItem("All " + dayOfWeek + "s");
				dayItem.Tag = dayOfWeek;
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

		private void clearDates_Click(object sender, EventArgs e)
		{
			listViewDates.Items.Clear();
		}
	}

}
