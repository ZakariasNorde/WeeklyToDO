using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace ToDoCalender
{
    public class MyEventArgs : EventArgs
    {
        public string Args;

        public MyEventArgs(string args) 
        {
            Args = args;
        }
    }
}
