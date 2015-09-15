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
            ToDoDaoDatabase daoToDo = new ToDoDaoDatabase();
            UserDaoDatabase daoUser = new UserDaoDatabase();
            //user -> id of the user   (userId)    
            int userId = daoUser.FindIdByUsername(user);
            IEnumerable<Model.ToDoItem> result = daoToDo.GetToDosByUserId(userId);
            return result;
        }

        /// <summary>
        /// Adds new ToDo
        /// </summary>
        /// <param name="todoText">The text of the ToDo item</param>
        public void AddToDo(string todoText, string user)
        {
            ToDoDaoDatabase daoToDo = new ToDoDaoDatabase();
            UserDaoDatabase daoUser = new UserDaoDatabase();
            ToDoItem item = new ToDoItem();
            int userId = daoUser.FindIdByUsername(user);
            item.Text = todoText;
            item.UserId = userId;
            daoToDo.Add(item);
        }

        /// <summary>
        /// Deletes ToDo item
        /// </summary>
        /// <param name="id">The id of the item</param>
        public void DeleteToDo(int id)
        {
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            dao.Delete(id);
        }

        public void CompleteToDo(bool todoCompleted)
        {
            IDao<ToDoItem> dao = DaoFactory.Instance.GetDao<ToDoItem>();
            ToDoItem item = new ToDoItem();
            item.Completed = true;
            dao.Add(item);
        }


        /// <summary>
        /// Changes the completed status of ToDo item
        /// </summary>
        /// <param name="id">id of the item</param>
        /// <param name="isCompleted"></param>
        public void ChangeCompleted(int id, bool isCompleted)
        {
            //save to db
            ToDoDaoDatabase dao = new ToDoDaoDatabase();
            ToDoItem item = dao.FindItem(id);
            if (item != null)
            {
                dao.ChangeCompl(id, isCompleted);
            }
        }
    }
}