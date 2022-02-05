using DevOpsDemo.DataContexts;
using DevOpsDemo.Models;

namespace DevOpsDemo.Repositories
{
    public class TodosRepo : ITodosRepo
    {
        private readonly TodoDbContext _ctx;
        public TodosRepo(TodoDbContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ICollection<Todo>> GetAllTodos()
        {
            return _ctx.Todos.ToList();
        }

        public async Task<Todo?> GetTodoById(Guid id)
        {
            return _ctx.Todos.FirstOrDefault(todo => todo.Id == id);
        }

        public async Task<Todo?> AddTodo(Todo todo)
        {
            await _ctx.Todos.AddAsync(todo);
            if (SaveChanges())
            {
                return todo;
            }
            else
            {
                return null;
            }
        }

        public async Task<Todo?> CompleteTodo(Guid id)
        {
            Todo? toComplete = _ctx.Todos.FirstOrDefault(todo => todo.Id == id);

            if(toComplete != null)
            {
                toComplete.Completed = true;
            }

            _ctx.Todos.Update(toComplete);

            if (SaveChanges())
            {
                return toComplete;
            }
            else
            {
                return null;
            }

        }

        public bool SaveChanges()
        {
            return (_ctx.SaveChanges() >= 0);
        }
    }
}
