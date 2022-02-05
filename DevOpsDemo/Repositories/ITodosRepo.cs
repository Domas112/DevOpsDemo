using DevOpsDemo.Models;

namespace DevOpsDemo.Repositories
{
    public interface ITodosRepo
    {
        bool SaveChanges();
        public Task<ICollection<Todo>> GetAllTodos();
        public Task<Todo?> GetTodoById(Guid id);
        public Task<Todo?> AddTodo(Todo todo);
        public Task<Todo?> CompleteTodo(Guid id);
    }
}
