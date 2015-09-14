using SimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.DataAccess
{
    /// <summary>
    /// Implements data access for UserItem objects with database
    /// </summary>
    public class UserDaoDatabase : IDao<UserItem>
    {
        private Entities Database { get; set; }

        public UserDaoDatabase()
        {
            Database = new Entities();
        }

        public IEnumerable<UserItem> GetAll()
        {
            List<USER> users = Database.USERS.ToList();
            List<UserItem> result = new List<UserItem>();
            foreach (USER user in users)
            {
                UserItem userItem = new UserItem()
                {
                    Id = user.ID,
                    Username = user.USERNAME,
                    Password = user.PASSWORD
                };
                result.Add(userItem);
            }

            return result;
        }

        public void Add(UserItem entity)
        {
            if (entity == null)
            {
                return;
            }

            USER newUser = new USER();
            newUser.USERNAME = entity.Username;
            newUser.PASSWORD = entity.Password;
            Database.USERS.Add(newUser);
            Database.SaveChanges();
        }

        public void Delete(int Id)
        {
            if (!ExistsItemWithId(Id))
            {
                return;
            }
            List<USER> users = Database.USERS.ToList();
            foreach (USER user in users)
            {
                if (user.ID == Id)
                {
                    Database.USERS.Remove(user);
                }
            }
            Database.SaveChanges();
        }

        public bool ExistsItemWithId(int Id)
        {
            List<USER> users = Database.USERS.ToList();
            foreach (USER user in users)
            {
                if (user.ID == Id)
                {
                    return true;
                }
            }
            return false;
        }

        public UserItem FindItem(int Id)
        {
            List<USER> users = Database.USERS.ToList();
            foreach (USER user in users)
            {
                if (user.ID == Id)
                    return new UserItem()
                    {
                        Id = user.ID,
                        Username = user.USERNAME,
                        Password = user.PASSWORD
                    };
            }
            return null;
        }

        public void ChangeCompl(int Id, bool changeTo)
        {
        }
    }
}
