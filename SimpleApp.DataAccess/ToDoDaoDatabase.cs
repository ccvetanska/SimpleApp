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
                                            Completed = todo.COMPLETED,
                                            UserId = todo.USERID
                                        };
                result.Add(todoItem);
            }

            return result;
        }

        public IEnumerable<ToDoItem> GetToDosByUserId(int userId)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            List<ToDoItem> result = new List<ToDoItem>();
            foreach (TODO todo in todoes)
            {
                if (todo.USERID == userId)
                {
                    ToDoItem todoItem = new ToDoItem()
                    {
                        Id = todo.ID,
                        Text = todo.TEXT,
                        Completed = todo.COMPLETED,
                        UserId = todo.USERID
                    };
                    result.Add(todoItem);
                }
            }
            
            return result;
        }


        
    public IEnumerable<ToDoItem> GetToDosByUserId(int userId, bool showCompleted)
        {
            List<TODO> todoes = Database.TODOes.Where(todo => todo.USERID == userId && (todo.COMPLETED==showCompleted || showCompleted)).ToList();
            List<ToDoItem> result = new List<ToDoItem>();
            foreach (TODO todo in todoes)
            {
                ToDoItem todoItem = new ToDoItem()
                {
                    Id = todo.ID,
                    Text = todo.TEXT,
                    Completed = todo.COMPLETED,
                    UserId = todo.USERID
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
            newToDo.USERID = entity.UserId;
            Database.TODOes.Add(newToDo);
            Database.SaveChanges();
        }

        public void Delete(int Id)
        {
            if (!ExistsItemWithId(Id))
            {
                return;
            }
            List<TODO> todoes = Database.TODOes.ToList();
            foreach (TODO todo in todoes)
            {
                if (todo.ID == Id)
                {
                    Database.TODOes.Remove(todo);
                }
            }
            Database.SaveChanges();
        }

        public bool ExistsItemWithId(int Id)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            foreach(TODO todo in todoes)
            {
                if (todo.ID == Id)
                    return true;
            }
            return false;
        }

        public ToDoItem FindItem(int Id)
        {
            List<TODO> todoes = Database.TODOes.ToList();
            foreach (TODO todo in todoes)
            {
                if (todo.ID == Id)
                    return new ToDoItem()
                    {
                        Id = todo.ID,
                        Text = todo.TEXT,
                        Completed = todo.COMPLETED,
                        UserId=todo.USERID
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

