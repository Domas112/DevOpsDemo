using AutoMapper;
using DevOpsDemo.Dtos.UserDtos;
using DevOpsDemo.Models;

namespace DevOpsDemo.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();
        }
    }
}
