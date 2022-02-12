using TodoClient.Models;

namespace TodoClient.Services
{
    public interface ITodosService
    {
        public Task<ICollection<Todo>> GetAllTodosAsync();
        public Task CompleteTodoAsync(Guid id);

    }
}
