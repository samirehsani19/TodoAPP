using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Interfaces;
using ToDoApp.Application.Services;
using ToDoApp.Domain.Models;

namespace ToDoApp.Test
{
    public class TodoServiceTests
    {
        private readonly Mock<ITodoRepository> _todoRepoMock;
        private readonly Mock<ILogger<TodoService>> _loggerMock;
        private readonly Mock<IMapper> _mapperMock;
        private readonly TodoService _todoService;
        public TodoServiceTests()
        {
            _todoRepoMock = new Mock<ITodoRepository>();
            _mapperMock = new Mock<IMapper>();
            _loggerMock = new Mock<ILogger<TodoService>>();
            _todoService = new TodoService(_todoRepoMock.Object, _loggerMock.Object, _mapperMock.Object);
        }

        [Fact]
        public void GetAll_ReturnsListOfTodos()
        {
            // arrange
            var todos = new List<TodoItem>()
            {
                 new TodoItem { Id = Guid.NewGuid(), Title = "Test Todo 1", Description = "Test description 1" },
                 new TodoItem { Id = Guid.NewGuid(), Title = "Test Todo 2", Description = "Test description 2" }
            };

            // mock repo to return data
            _todoRepoMock.Setup(repo => repo.GetAll()).Returns(todos);

            // mock auto mapper to return dto object
            _mapperMock.Setup(mapper =>
                    mapper.Map<List<TodoItemDto>>(todos)).Returns(new List<TodoItemDto>()
                    {
                        new TodoItemDto { Id = todos[0].Id, Title = todos[0].Title, Description = todos[0].Description },
                        new TodoItemDto { Id = todos[1].Id, Title = todos[1].Title, Description = todos[1].Description }
                    });

            // act
            var result = _todoService.GetAll();

            // assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void Add_ReturnsMappedTodoItemDto()
        {
            // arrange
            var todoAddDto = new TodoAddDto { Title = "New Todo", Description = "New description" };
            var todoItem = new TodoItem { Id = Guid.NewGuid(), Title = todoAddDto.Title, Description = todoAddDto.Description };

            // mock mapper
            _mapperMock.Setup(mapper=> mapper.Map<TodoItem>(todoAddDto)).Returns(todoItem);
            _mapperMock.Setup(mapper => mapper.Map<TodoItemDto>(todoItem)).Returns(new TodoItemDto()
            {
                Id = todoItem.Id,
                Title = todoItem.Title, 
                Description = todoItem.Description
            });

            // act
            var result = _todoService.Add(todoAddDto);

            // assert
            Assert.NotNull(result);
            Assert.Equal(todoAddDto.Title, result.Title);
        }
    }
}
