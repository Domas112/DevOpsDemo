using AutoMapper;
using DevOpsDemo.Dtos.TodoDtos;
using DevOpsDemo.Models;
using DevOpsDemo.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevOpsDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TodosController : ControllerBase
    {
        private readonly ITodosRepo _repo;
        private readonly IMapper _mapper;
        public TodosController(ITodosRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<TodoReadDto>>> GetAllTodos()
        {
            ICollection<TodoReadDto> response = _mapper.Map<ICollection<TodoReadDto>>(await _repo.GetAllTodos());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TodoReadDto>> GetTodoById(Guid id)
        {

            Todo? todo = await _repo.GetTodoById(id);
            

            if (todo != null)
            {
                TodoReadDto response = _mapper.Map<TodoReadDto>(todo);
                return Ok(response);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<TodoReadDto>> CreateTodo(TodoCreateDto todoDto)
        {

            if (todoDto == null) return BadRequest("The todo cannot be empty");
            
            Todo todo = _mapper.Map<Todo>(todoDto);
            Todo? addedTodo = await _repo.AddTodo(todo);

            if (addedTodo != null)
            {
                TodoReadDto response = _mapper.Map<TodoReadDto>(addedTodo);
                return Ok(response);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("complete/{id}")]
        public async Task<ActionResult<TodoReadDto>> CompleteTodo(Guid id)
        {
            Todo? completedTodo = await _repo.CompleteTodo(id);
            if (completedTodo == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(_mapper.Map<TodoReadDto>(completedTodo));
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ICollection<TodoReadDto>>> DeleteTodo(Guid id)
        {
            ICollection<Todo>? afterDelete = await _repo.DeleteTodo(id);

            if (afterDelete == null) return BadRequest();

            return Ok(_mapper.Map<TodoReadDto>(afterDelete));
        }

        [HttpPut]
        public async Task<ActionResult<TodoReadDto>> UpdateTodo(TodoUpdateDto todoDto)
        {
            Todo todo = _mapper.Map<Todo>(todoDto);
            var updated = await _repo.UpdateTodo(todo);
            if(updated == null) return BadRequest();

            return Ok(_mapper.Map<TodoReadDto>(updated));
        }
    }
}
