using DALToDo.Repository;
using Models;
namespace BLLToDO
{
    public class TaskManager
    {
        public TaskManager()
        {

        }

        public TaskToDo createTask(string name, string desc, List<String> days)
        {
            TaskToDo createdTask = new TaskToDo(name, desc, days);
            return createdTask;
        }
    }
}