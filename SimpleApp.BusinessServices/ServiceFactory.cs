using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleApp.BusinessServices
{
    /// <summary>
    /// Provides service implementations
    /// </summary>
    public class ServiceFactory
    {
        private static ServiceFactory _instance;
        Dictionary<Type, object> serviceRegistrations = new Dictionary<Type, object>();

        /// <summary>
        /// The instance
        /// </summary>
        public static ServiceFactory Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ServiceFactory();
                }

                return _instance;
            }
        }

        /// <summary>
        /// Registers an implementation of a service contract
        /// </summary>
        /// <typeparam name="T">The service contract (interface)</typeparam>
        /// <param name="svc">The service implementation</param>
        public void RegisterService<T>(object svc)
        {
            if(!serviceRegistrations.ContainsKey(typeof(T)))
            {
                serviceRegistrations.Add(typeof(T), svc);
            }
            else
            {
                throw new NotSupportedException("Only single registration of a type is supported!");
            }
        }

        /// <summary>
        /// Provides an implementation of a service contract if available
        /// </summary>
        /// <typeparam name="T">The service contract (interface)</typeparam>
        /// <returns>The service implementation if registered, null otherwise</returns>
        public T GetService<T>()
        {
            if (serviceRegistrations.ContainsKey(typeof(T)))
            {
                return (T)serviceRegistrations[typeof(T)];
            }

            return default(T);
        }
    }
}
