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

        public IEnumerable<ToDoItem> GetToDosForUser(string user, bool showCompleted)
        {
            ToDoDaoDatabase daoToDo = new ToDoDaoDatabase();
            UserDaoDatabase daoUser = new UserDaoDatabase();
            int userId = daoUser.FindIdByUsername(user);
            IEnumerable<Model.ToDoItem> result = daoToDo.GetToDosByUserId(userId,showCompleted);

            return result;
        }
                
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