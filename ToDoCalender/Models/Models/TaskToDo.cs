namespace Models
{
    public class TaskToDo
    {
        public string Title { get; set; }  
        public string Description { get; set; }
        public List<WeekdayEnum.WeekDays> WeekDays { get; set; }
        public bool Routine { get; set; }
        public List<DateTime> Dates { get; set; }
        public TaskToDo(string title, string description, List<DateTime> dates)
        {
            Title = title;
            Description = description;
            Routine = false;
            Dates = dates;
            
        }

        public TaskToDo(string title, string description,  List<string> days)
        {
            Title = title;
            Description = description;
            Routine = true;
            WeekDays = new List<WeekdayEnum.WeekDays>();
            foreach(string aDay in days)
            {
                //kolla om detta verkligen funkar och kolla vad jag tjänar på att använda enum lista ist
                WeekDays.Add((WeekdayEnum.WeekDays)Enum.Parse(typeof(WeekdayEnum.WeekDays), aDay));
            }
        }

        
    }
}