using AutoMapper;
using ToDoApp.Application.Dtos;
using ToDoApp.Domain.Models;

namespace ToDoApp.Application.Mappers
{
    // I use Automapper for a clean and easy mapping of my object instead of doing it manually
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TodoItem, TodoItemDto>().ReverseMap();
            CreateMap<TodoAddDto, TodoItem>();
        }
    }
}
