using AutoMapper;
using Microsoft.AspNetCore.Components;
using TodoClient.Models;
using TodoClient.Services;

namespace TodoClient.Pages
{
    public partial class Todos
    {

        [Inject]
        private ITodosService _todosService { get; set; }

        [Inject]
        private IMapper _mapper { get; set; }

        IList<ReadTodoDto> _todos { get; set; }

        protected override async Task OnInitializedAsync()
        {
            IList<Todo> todos = await _todosService.GetAllTodosAsync();
            _todos = _mapper.Map<IList<ReadTodoDto>>(todos);
        }

        private async Task CompleteTodo(Guid id)
        {
            ReadTodoDto toComplete = _todos.FirstOrDefault(todo => todo.Id == id);
            toComplete.Completed = !toComplete.Completed;
            
            await _todosService.CompleteTodoAsync(id);
        }

        private async Task CreateTodo(CreateTodoDto todo)
        {
            await _todosService.InsertTodoAsync(todo);
            IList<Todo> todos = await _todosService.GetAllTodosAsync();
            _todos = _mapper.Map<IList<ReadTodoDto>>(todos);
            StateHasChanged();
        }

        private async Task DeleteTodo(Guid id)
        {
            _todos.Remove(_todos.FirstOrDefault(item => item.Id == id));
            await _todosService.DeleteTodoAsync(id);
        }

        private async Task UpdateTodo(ReadTodoDto updateTo)
        {

            ReadTodoDto toBeUpdated = (from item in _todos
                                where item.Id == updateTo.Id
                                select item).FirstOrDefault();

            toBeUpdated = updateTo;
            Todo todo = _mapper.Map<Todo>(updateTo);
            await _todosService.UpdateTodoAsync(todo);
        }

    }
}
