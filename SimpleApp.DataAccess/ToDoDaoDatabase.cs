using SimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.DataAccess
{
    /// <summary>
    /// Implements data access for ToDoItem objects with Database storage
    /// </summary>
    public class ToDoDaoDatabase : IDao<ToDoItem>
    {
        private Entities Database { get; set; }

        public ToDoDaoDatabase()
        {
            Database = new Entities();
        }

        public IEnumerable<ToDoItem> GetAll()
        {
            List<TODO> todoes = Database.TODOes.ToList();
            List<ToDoItem> result = new List<ToDoItem>();
            foreach(TODO todo in todoes)
            {
                ToDoItem todoItem = new ToDoItem() 
                                        { 
                                            Id = todo.ID, 
                                            Text = todo.TEXT,
                                            Completed = todo.COMPLETED
                                        };
                result.Add(todoItem);
            }

            return result;
        }

        public void Add(ToDoItem entity)
        {
            if (entity == null)
            {
                return;
            }

            TODO newToDo = new TODO();
            newToDo.TEXT = entity.Text;

            Database.TODOes.Add(newToDo);
            Database.SaveChanges();
        }

        public bool ExistsElementWithId(int Id)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            foreach(TODO todo in todoes)
            {
                if (todo.ID == Id)
                    return true;
            }
            return false;
        }

        public ToDoItem FindElementById(int Id)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            foreach (TODO todo in todoes)
            {
                if (todo.ID == Id)
                    return new ToDoItem()
                    {
                        Id = todo.ID,
                        Text = todo.TEXT,
                        Completed = todo.COMPLETED
                    };
            }
            return null;            
        }

        public void ChangeCompl(int Id, bool changeTo)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            foreach (TODO todo in todoes)
            {
                if (todo.ID == Id)
                    todo.COMPLETED = changeTo;
            }
            Database.SaveChanges();
        }
        
    }
}
