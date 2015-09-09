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
        /// Returns an object of type T with the identifier Id or returns 
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        bool ExistsElementWithId(int Id);
    }
}
