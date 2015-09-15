using SimpleApp.Model;
using System.Collections.Generic;
using System.Web;


namespace SimpleApp.BusinessServices.Contracts
{
    public interface IUserService 
    {
        /// <summary>
        /// Validates user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        bool ValidateUser(string username, string password);

        /// <summary>
        /// Creates new user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        void CreateUser(string username, string password);



    }
}
