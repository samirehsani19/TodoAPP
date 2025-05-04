using ToDoApp.Application.Dtos;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Services
{
    public interface ITodoService
    {
        List<TodoItemDto> GetAll();
        TodoItemDto Add(TodoAddDto item);
        void Delete(Guid id);
    }
}
