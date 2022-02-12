using Microsoft.AspNetCore.Components;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient.Pages
{
    public partial class Todos
    {

        [Inject]
        private ITodosService _todosService { get; set; }


        ICollection<Todo> _todos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _todos = await _todosService.GetAllTodosAsync();
        }

        private async Task CompleteTodo(Guid id)
        {
            Console.WriteLine(id.ToString());
            await _todosService.CompleteTodoAsync(id);
        }

    }
}
