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

        public List<TaskToDo> getAllTask()
        {
            return repository.getAll();
        }
    }
}