using SimpleApp.BusinessServices.Contracts;
using SimpleApp.DataAccess;
using SimpleApp.Model;
using System;
using System.Collections.Generic;

namespace SimpleApp.BusinessServices.Impl
{
    public class UserService : IUserService
    {
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

        public void CreateUser(string username, string password)
        {
            UserDaoDatabase dao = new UserDaoDatabase();
            UserItem user = new UserItem();
            user.Password = password;
            user.Username = username;
            dao.Add(user);
        }
    }
}
