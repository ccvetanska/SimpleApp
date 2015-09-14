using SimpleApp.BusinessServices.Contracts;
using SimpleApp.DataAccess;
using SimpleApp.Model;
using System.Collections.Generic;

namespace SimpleApp.BusinessServices.Impl
{
    public class UserService : IUserService
    {
        //public void AddUser(string username, string password)
        //{
        //    IDao<UserItem> dao = DaoFactory.Instance.GetDao<UserItem>();
        //    UserItem item = new UserItem();
        //    item.Username = username;
        //    item.Password = password;
        //    dao.Add(item);
        //}

        public bool ValidateUser(string username, string password)
        {
            UserDaoDatabase dao =  new UserDaoDatabase();
            IEnumerable<UserItem> userItems = dao.GetAll();
            foreach(UserItem useritem in userItems)
            {
                if (useritem.Username == username && useritem.Password == password) 
                {
                    return true;
                }
            }
            return false;
        }
    }
}
