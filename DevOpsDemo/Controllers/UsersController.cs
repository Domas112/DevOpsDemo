using AutoMapper;
using DevOpsDemo.Dtos.UserDtos;
using DevOpsDemo.Models;
using DevOpsDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepo _usersRepo;
        private readonly IMapper _mapper;
        public UsersController(IUsersRepo usersRepo, IMapper mapper)
        {
            _usersRepo = usersRepo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserReadDto>?>> GetAllUsers()
        {
            ICollection<User>? users = await _usersRepo.GetAllUsers();

            if (users == null) return NotFound();

            return Ok(_mapper.Map<ICollection<UserReadDto>>(users));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserReadDto>> GetUserById(Guid id)
        {
            User? user = await _usersRepo.GetUserById(id);
            
            if(user == null) return NotFound();

            return Ok(_mapper.Map<UserReadDto>(user));
        }

        [HttpPost]
        public async Task<ActionResult<UserReadDto>> InsertUser(UserCreateDto userDto)
        {
            if (userDto == null) return BadRequest("The required inputs must not be empty");
            
            User user = _mapper.Map<User>(userDto);
            User? inserted = await _usersRepo.CreateUser(user);

            if(inserted == null) return BadRequest();

            return Ok(_mapper.Map<UserReadDto>(inserted));
        }

        [HttpDelete]
        public async Task<ActionResult<ICollection<UserReadDto>>> DeleteUser(Guid id)
        {
            ICollection<User>? newUserList = await _usersRepo.DeleteUser(id);

            if(newUserList == null) return NotFound();

            return Ok(_mapper.Map<ICollection<UserReadDto>>(newUserList));
        }

        [HttpPut]
        public async Task<ActionResult<UserReadDto>> UpdateUser(UserUpdateDto userDto)
        {
            User user = _mapper.Map<User>(userDto);
            User? updatedUser = await _usersRepo.UpdateUser(user);

            if(updatedUser == null) return NotFound();

            return Ok(_mapper.Map<UserReadDto>(updatedUser));
        }
    }
}
