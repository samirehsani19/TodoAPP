using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Models;

namespace ToDoApp.Infrastructur.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        /// <summary>
        /// todo list
        /// </summary>
        private List<TodoItem> _todoItems = new ();

        /// <summary>
        /// Get all todo items
        /// </summary>
        /// <returns></returns>
        public List<TodoItem> GetAll()
            => _todoItems;

        /// <summary>
        /// Get a single todo item filtered by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public TodoItem? GetById(Guid id)
            => _todoItems.FirstOrDefault(x => x.Id == id);

        /// <summary>
        /// Add a todo item
        /// </summary>
        /// <param name="item"></param>
        public void Add(TodoItem item) 
            => _todoItems.Add(item);

        /// <summary>
        /// Delete a todo item
        /// </summary>
        /// <param name="item"></param>
        public void Delete(TodoItem item)
            => _todoItems.Remove(item);
    }
}
