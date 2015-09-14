using SimpleApp.Model;
using System;
using System.Collections.Generic;

namespace SimpleApp.DataAccess
{
    /// <summary>
    /// General contract about the service provided by a Dao class
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IDao<T>
    {
        /// <summary>
        /// Returns all objects of type T
        /// </summary>
        /// <returns>A collection of items of type T</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Add a new object of type T to storage
        /// </summary>
        /// <param name="entity">An object of type T</param>
        void Add(T entity);

        /// <summary>
        /// Deletes an object by its Id
        /// </summary>
        /// <param name="Id"></param>
        void Delete(int Id);

        /// <summary>
        /// Returns an item of type T with the identifier Id  
        /// </summary>
        /// <param name="Id">identifier</param>
        /// <returns></returns>
        T FindItem(int Id);

        /// <summary>
        /// Returns an item of type T with 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //T FindItem(string username, string password);

        /// <summary>
        /// Checks if there is an item corresponding to the identifier Id 
        /// </summary>
        /// <param name="Id">identifier</param>
        /// <returns></returns>
        bool ExistsItemWithId(int Id);

        /// <summary>
        /// Change the completed status of an object
        /// </summary>
        /// <param name="Id">identifier</param>
        /// <param name="changeTo">the state we will change to</param>
        //void ChangeCompl(int Id, bool changeTo);
    }
}
