using TodoClient.Models;

namespace TodoClient.Services
{
    public interface ITodosService
    {
        public Task<IList<Todo>> GetAllTodosAsync();
        public Task CompleteTodoAsync(Guid id);

        public Task InsertTodoAsync(CreateTodoDto todo);
        public Task DeleteTodoAsync(Guid id);
        public Task UpdateTodoAsync(Todo todo);

    }
}
