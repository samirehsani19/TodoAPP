using Microsoft.AspNetCore.Mvc;
using ToDoApp.Application.Dtos;
using ToDoApp.Application.Exceptions;
using ToDoApp.Application.Services;

namespace ToDoApp.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodoService _todoService;
        public TodosController(ITodoService todoService)
        {
            _todoService = todoService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var todos = _todoService.GetAll();
            return Ok(todos);
        }

        [HttpPost]
        public IActionResult Create([FromBody] TodoAddDto item)
        {
            try
            {
                var newTodo = _todoService.Add(item);
                return CreatedAtAction(nameof(GetAll), new { id = newTodo.Id }, newTodo);
            }
            catch (TodoAlreadyExistsException ex)
            {
                return Conflict(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _todoService.Delete(id);
                return NoContent();
            }
            catch (TodoNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
