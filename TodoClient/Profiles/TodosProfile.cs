using AutoMapper;
using TodoClient.Models;

namespace TodoClient.Profiles
{
    public class TodosProfile : Profile
    {
        public TodosProfile()
        {
            CreateMap<Todo, ReadTodoDto>();
            CreateMap<ReadTodoDto, Todo>();
        }
    }
}
