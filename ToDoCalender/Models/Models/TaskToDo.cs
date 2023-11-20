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
        public TaskToDo(string title, string description, List<DateTime> dates)
        {
            Title = title;
            Description = description;
            Routine = false;
            Dates = dates;
            
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
        }

        
    }
}