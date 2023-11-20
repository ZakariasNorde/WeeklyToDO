using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALToDo.Repository
{
    internal interface IRepository<T>
    {
        void add(T anObject);
        void remove(T anObject);
        List<T> getAll(); 
        //void updateList(List<T> updatedList);
        void saveChanges();

    }
}
