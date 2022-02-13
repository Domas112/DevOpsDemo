using Microsoft.AspNetCore.Components;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient.Pages
{
    public partial class Todos
    {

        [Inject]
        private ITodosService _todosService { get; set; }


        IList<Todo> _todos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _todos = await _todosService.GetAllTodosAsync();
        }

        private async Task CompleteTodo(Guid id)
        {
            Todo toComplete = _todos.FirstOrDefault(todo => todo.Id == id);
            toComplete.Completed = !toComplete.Completed;
            
            await _todosService.CompleteTodoAsync(id);
        }

        private async Task CreateTodo(CreateTodoDto todo)
        {
            await _todosService.InsertTodoAsync(todo);
        }

        private async Task DeleteTodo(Guid id)
        {
            _todos.Remove(_todos.FirstOrDefault(item => item.Id == id));
            await _todosService.DeleteTodoAsync(id);
        }

        private async Task UpdateTodo(Todo updateTo)
        {
            Todo toBeUpdated = (from item in _todos
                                where item.Id == updateTo.Id
                                select item).FirstOrDefault();

            toBeUpdated = updateTo;
            await _todosService.UpdateTodoAsync(updateTo);
        }

    }
}
