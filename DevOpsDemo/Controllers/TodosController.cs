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
        public TodosController(ITodosRepo repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Todo>>> GetAllTodos()
        {
            return Ok(await _repo.GetAllTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Todo>> GetTodoById(Guid id)
        {
            Todo todo = await _repo.GetTodoById(id);
            if (todo != null)
            {
                return Ok(todo);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<Todo>> CreateTodo(Todo todo)
        {
            if (todo == null)
            {
                return BadRequest("The todo cannot be empty");
            }
            Todo? addedTodo = await _repo.AddTodo(todo);

            if (addedTodo != null)
            {
                return Ok(addedTodo);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("complete/{id}")]
        public async Task<ActionResult<Todo>> CompleteTodo(Guid id)
        {
            Todo? completedTodo = await _repo.CompleteTodo(id);
            if (completedTodo == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(completedTodo);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ICollection<Todo>>> DeleteTodo(Guid id)
        {
            var toDelete = await _repo.DeleteTodo(id);

            if (toDelete == null) return BadRequest();

            return Ok(toDelete);
        }

        [HttpPut]
        public async Task<ActionResult<Todo>> UpdateTodo(Todo todo)
        {
            var updated = await _repo.UpdateTodo(todo);
            if(updated == null) return BadRequest();

            return Ok(updated);
        }
    }
}
