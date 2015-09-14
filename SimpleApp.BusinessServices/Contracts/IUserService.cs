using SimpleApp.Model;
using System.Collections.Generic;

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



    }
}
