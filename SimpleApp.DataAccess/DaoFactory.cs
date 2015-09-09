using SimpleApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.DataAccess
{
    /// <summary>
    /// Responsible for providing dao objects
    /// </summary>
    public class DaoFactory
    {
        private static DaoFactory _instance;

        /// <summary>
        /// The data access type
        /// </summary>
        public static DataAccessType AccessType { get; set; }

        /// <summary>
        /// The instance
        /// </summary>
        public static DaoFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new DaoFactory();
                }

                return _instance;
            }
        }
        
        /// <summary>
        /// Returns a dao for objects of type T
        /// </summary>
        /// <typeparam name="T">The type of objects the Dao class handles</typeparam>
        /// <returns>An implementation of IDao for objects of type T</returns>
        public IDao<T> GetDao<T>()
        {
            return GetDao<T>(AccessType);
        }

        /// <summary>
        /// Returns a dao for objects of type T
        /// </summary>
        /// <typeparam name="T">The type of objects the Dao class handles</typeparam>
        /// <param name="dataAccessType">The type of data access used</param>
        /// <returns>An implementation of IDao for objects of type T</returns>
        public IDao<T> GetDao<T>(DataAccessType dataAccessType)
        {
            if (typeof(T).IsAssignableFrom(typeof(ToDoItem)))
            {
                switch (dataAccessType)
                {
                    case DataAccessType.Database:
                        return new ToDoDaoDatabase() as IDao<T>;
                    case DataAccessType.InMemory:
                        return new ToDoDaoInMemory() as IDao<T>;
                    default:
                        return null;
                }
            }
            else
            {
                return null;
            }
        }

    }
}
