using SimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.DataAccess
{
    /// <summary>
    /// Implements data access for ToDoItem objects with In Memory storage
    /// </summary>
    public class ToDoDaoInMemory : IDao<ToDoItem>
    {
        private static List<ToDoItem> inMemoryStore = new List<ToDoItem>();
                 
        public IEnumerable<ToDoItem> GetAll()
        {
            return inMemoryStore;
        }
        
        public void Add(ToDoItem entity)
        {
            inMemoryStore.Add(entity);
        }

        public void ChangeCompl(int id, bool compl)
        {
            foreach (ToDoItem td in inMemoryStore)
                if(td.Id==id)
                {
                    td.Completed = compl;
                }
        }
        public bool ExistsElementWithId(int id)
        {
            foreach (ToDoItem td in inMemoryStore)
            {
                if (td.Id==id)
                {
                    return true;
                }
            }
            return false;
        }

        public ToDoItem FindElementById(int id)
        {
            foreach (ToDoItem td in inMemoryStore)
            {
                if (td.Id==id)
                {
                    return td;
                }
            }
            return null;
        }
    }
}
