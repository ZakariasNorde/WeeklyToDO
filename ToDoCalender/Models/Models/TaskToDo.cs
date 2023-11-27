using System.Linq;
using System.Collections.Generic;
namespace Models
{
    public class TaskToDo
    {
        public string Title { get; set; }  
        public string Description { get; set; }
        
        // fixa så att de är enums public List<WeekdayEnum.WeekDays> WeekDays { get; set; }

        public List<string> WeekDays { get; set; }
        public bool Routine { get; set; }
        public List<DateTime> Dates { get; set; }
        
        public List<DateTime> CheckedDates { get; set; } 
        public TaskToDo(string title, string description, List<DateTime> dates)
        {
            Title = title;
            Description = description;
            Routine = false;
            Dates = dates;
            CheckedDates = new List<DateTime>(); 
        }

        public TaskToDo()
        {

        }

        public TaskToDo(string title, string description,  List<string> days)
        {
            Title = title;
            Description = description;
            Routine = true;
            WeekDays = days;
            CheckedDates = new List<DateTime>();
        }

        public void checkTask(DateTime date)
        {   DateTime shortDate = date.Date;
            CheckedDates.Add(shortDate);
        }
        

        public void unCheckTask(DateTime date)
        {
            
            int i = 0;
            bool hittad = false;
            while(i < CheckedDates.Count && !hittad)
            {
                DateTime aDate = CheckedDates[i];
                if(aDate == date.Date)
                {
                    CheckedDates.RemoveAt(i);
                    hittad = true;
                }
                i++;
            }
            
        }
    }
}