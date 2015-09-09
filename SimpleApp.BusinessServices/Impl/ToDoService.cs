using SimpleApp.BusinessServices.Contracts;
using SimpleApp.DataAccess;
using SimpleApp.Model;
using System.Collections.Generic;

namespace SimpleApp.BusinessServices.Impl
{
    /// <summary>
    /// Implements IToDoService
    /// </summary>
    public class ToDoService : IToDoService
    {
        /// <summary>
        /// Returns the ToDo items for a give user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A collection of ToDoItems</returns>
        public IEnumerable<ToDoItem> GetToDosForUser(string user)
        {
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            IEnumerable<Model.ToDoItem> result = dao.GetAll();

            return result;
        }

        /// <summary>
        /// Adds new ToDo
        /// </summary>
        /// <param name="todoText">The text of the ToDo item</param>
        public void AddToDo(string todoText)
        {
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            ToDoItem item = new ToDoItem();
            item.Text = todoText;
            dao.Add(item);
        }

        public void CompleteToDo(bool todoCompleted)
        {
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            ToDoItem item = new ToDoItem();
            item.Completed = true;
            dao.Add(item);            
        }


        public void ChangeCompleted(int id, bool isCompleted)
        {
            //save to db
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            dao.GetAll();
            // find the item with the needed id
            if (isCompleted)
                item.Completed = false;
            else
                item.Completed = true;
            

        }
    }
}