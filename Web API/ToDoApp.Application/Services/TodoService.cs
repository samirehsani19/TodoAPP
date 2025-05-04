using AutoMapper;
using Microsoft.Extensions.Logging;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Interfaces;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todoRepository;
        private readonly ILogger<TodoService> _logger;
        private readonly IMapper _mapper;
        public TodoService(ITodoRepository todoRepository, ILogger<TodoService> logger, IMapper mapper)
        {
            _todoRepository = todoRepository;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        ///  return all todos
        /// </summary>
        /// <returns></returns>
        public List<TodoItemDto> GetAll()
        {
            var todos = _todoRepository.GetAll();
            return _mapper.Map<List<TodoItemDto>>(todos);
        }

        public TodoItemDto Add(TodoAddDto item)
        {
            var todoItem = _mapper.Map<TodoItem>(item);
            // if using DB. we must check for if Todo already exist or not.

            _logger.LogInformation($"Adding new Todo with id {todoItem.Id}");
            _todoRepository.Add(todoItem);

            return _mapper.Map<TodoItemDto>(todoItem);
        }

        public void Delete(Guid id)
        {
            var todoToDelete = _todoRepository.GetById(id);
            
            // find todo by Id
            if (todoToDelete == null)
            {
                _logger.LogError($"A todo with id {id} is missing. Cannot be deleted");
                throw new TodoNotFoundException(id);
            }

            _logger.LogInformation($"Deleting todo with Id = {id}");
            _todoRepository.Delete(todoToDelete);
        }
    }
}
