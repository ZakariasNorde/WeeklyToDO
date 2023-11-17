using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddForm
{
    public class Validation
    {
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
    }
}
