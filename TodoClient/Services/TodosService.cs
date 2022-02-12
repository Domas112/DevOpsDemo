using System.Net.Http.Json;
using TodoClient.Models;

namespace TodoClient.Services
{
    public class TodosService : ITodosService
    {
        private readonly HttpClient _httpClient;
        public TodosService(HttpClient httpClient)
        {
            _httpClient = httpClient;

        }

        public async Task<ICollection<Todo>?> GetAllTodosAsync()
        {
            ICollection<Todo>? todos = await _httpClient.GetFromJsonAsync<ICollection<Todo>>("/todos");
            return todos;
        }

        public async Task CompleteTodoAsync(Guid id)
        {
            await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"/complete/{id}"));
        }
    }
}
