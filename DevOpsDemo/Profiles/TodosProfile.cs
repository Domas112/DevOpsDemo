using AutoMapper;
using DevOpsDemo.Dtos.TodoDtos;
using DevOpsDemo.Models;

namespace DevOpsDemo.Profiles
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<Todo, TodoReadDto>();
            CreateMap<TodoCreateDto, Todo>();
            CreateMap<TodoUpdateDto, Todo>();
        }
    }
}
