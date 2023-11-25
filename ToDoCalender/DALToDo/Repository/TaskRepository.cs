using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DALToDo.Repository
{
    public class TaskRepository : IRepository<TaskToDo>
    {
        public List<TaskToDo> tasks;
        public MyXmlSerializer<TaskToDo> serializer;
        public TaskRepository() 
        {
            serializer = new MyXmlSerializer<TaskToDo>();
            tasks = serializer.deSerialize();
            if(tasks.Count == 0)
            {
                tasks = new List<TaskToDo>();
            }
            
        }

        public void add(TaskToDo aTask)
        {
            tasks.Add(aTask);
            saveChanges();
        }

        public void updateList(List<TaskToDo> newList)
        {
            tasks = newList;
            saveChanges();
        }
        public void remove(TaskToDo aTask)
        {
            
        }

        public List<TaskToDo> getAll()
        {
            return serializer.deSerialize();
        }

        public void saveChanges()
        {
            serializer.serialize(tasks);
        }
    }
}
