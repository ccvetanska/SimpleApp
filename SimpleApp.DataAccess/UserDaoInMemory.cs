using SimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.DataAccess
{
    public class UserDaoInMemory : IDao<UserItem>
    {
        private static List<UserItem> inMemoryStore = new List<UserItem>();

        public IEnumerable<UserItem> GetAll()
        {
            return inMemoryStore;
        }

        public void Add(UserItem entity)
        {
            inMemoryStore.Add(entity);
        }

        public void Delete(int id)
        {
            foreach (UserItem td in inMemoryStore)
                if (td.Id == id)
                {
                    inMemoryStore.Remove(td);
                }
        }
        public void ChangeCompl(int id, bool compl)
        {

        }
        public bool ExistsItemWithId(int id)
        {
            foreach (UserItem td in inMemoryStore)
            {
                if (td.Id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public UserItem FindItem(int id)
        {
            foreach (UserItem td in inMemoryStore)
            {
                if (td.Id == id)
                {
                    return td;
                }
            }
            return null;
        }
    }
}
