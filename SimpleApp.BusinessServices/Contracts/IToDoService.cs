using SimpleApp.Model;
using System.Collections.Generic;

namespace SimpleApp.BusinessServices.Contracts
{
    public interface IToDoService
    {
        /// <summary>
        /// Returns the ToDo items for a give user
        /// </summary>
        /// <param name="user">The user</param>
        /// <returns>A collection of ToDoItems</returns>
        IEnumerable<ToDoItem> GetToDosForUser(string user);

        /// <summary>
        /// Adds new ToDo
        /// </summary>
        /// <param name="todoText">The text of the ToDo item</param>
        void AddToDo(string todoText, string user);

        /// <summary>
        /// Deletes an existing ToDo
        /// </summary>
        /// <param name="id"></param>
        void DeleteToDo(int id);

        /// <summary>
        /// Marks/unmarks an existing ToDo as completed
        /// </summary>
        /// <param name="todoCompleted">True if the ToDo item is completed</param>
        void CompleteToDo(bool todoCompleted);

        void ChangeCompleted(int id, bool isCompleted);
    }
}
