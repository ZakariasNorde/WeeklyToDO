using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoCalender
{
    internal class InputValidation
    {
        
        public static bool ValidateDelete()
        {
            DialogResult theResult = MessageBox.Show("Attention! The task will be deleted from all dates are you sure you want to delete", "Confirm removal!", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (theResult.ToString().Equals("Yes"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool validateTxt(TextBox aTextBox)
        {
            string txtBoxString = aTextBox.Text;
            if (string.IsNullOrEmpty(txtBoxString))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool listViewIsEmpty(ListView aListView)
        {
            if(aListView.Items.Count == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
