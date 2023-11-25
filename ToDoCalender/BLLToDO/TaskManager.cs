using DALToDo.Repository;
using Models;
namespace BLLToDO
{
    public class TaskManager
    {
        private TaskRepository repository;
        public TaskManager()
        {
            repository = new TaskRepository();
        }
        //du måste lägga in validering så att om man lägger till ett task med samma titel och beskrivning
        //då ska de datumen istället läggas till i det taskets lista istället för att
        //skapa ett nytt task för då blir de konstigt när man ska uppdatera.
        public TaskToDo createTask(string name, string desc, List<String> days)
        {
            TaskToDo createdTask = new TaskToDo(name, desc, days);
            repository.add(createdTask);
            return createdTask;
        }

        public TaskToDo createTask(string name, string desc, List<DateTime> dates)
        {
            TaskToDo createdTask = new TaskToDo(name, desc, dates);
            repository.add(createdTask);
            return createdTask;
        }
        
        public void checkTask(TaskToDo aTask, DateTime dateToCheck)
        {
            List<TaskToDo> allTask = repository.getAll();
            int i = 0;
            bool hittad = false;
            while(i < allTask.Count && !hittad)
            {
                TaskToDo taskToCheck = allTask[i];
                if(taskToCheck.Description.Equals(aTask.Description) && taskToCheck.Title.Equals(aTask.Title))
                {
                    taskToCheck.checkTask(dateToCheck);
                    allTask[i] = taskToCheck;
                    hittad = true;
                }
                i++;
            }
            repository.updateList(allTask);
        }
        public List<TaskToDo> getAllTask()
        {
            return repository.getAll();
        }
    }
}