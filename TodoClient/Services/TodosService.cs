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

        public async Task<IList<Todo>?> GetAllTodosAsync()
        {
            IList<Todo>? todos = await _httpClient.GetFromJsonAsync<IList<Todo>>("/todos");
            return todos;
        }

        public async Task CompleteTodoAsync(Guid id)
        {
            await _httpClient.SendAsync(new HttpRequestMessage(HttpMethod.Post, $"/todos/complete/{id.ToString()}"));
        }

        public async Task InsertTodoAsync(CreateTodoDto todo)
        {
            await _httpClient.PostAsJsonAsync<CreateTodoDto>("/todos", todo);
        }

        public async Task DeleteTodoAsync(Guid id)
        {
            await _httpClient.DeleteAsync($"/todos/{id.ToString()}");
        }

        public async Task UpdateTodoAsync(Todo todo)
        {
            await _httpClient.PutAsJsonAsync<Todo>($"/todos", todo);
        }
    }
}
