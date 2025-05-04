using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Interfaces
{
    public interface ITodoRepository
    {
        /// <summary>
        /// get all todos
        /// </summary>
        /// <returns></returns>
        List<TodoItem> GetAll();
        
        /// <summary>
        /// Get a todo item filtered by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        TodoItem? GetById(Guid id);

        /// <summary>
        /// add a todo item
        /// </summary>
        /// <param name="item"></param>
        void Add(TodoItem item);
        /// <summary>
        /// delete a todo item
        /// </summary>
        /// <param name="item"></param>
        void Delete(TodoItem item);
    }
}
