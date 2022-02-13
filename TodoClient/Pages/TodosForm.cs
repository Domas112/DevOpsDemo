using Microsoft.AspNetCore.Components;
using TodoClient.Models;

namespace TodoClient.Pages
{
    public partial class TodosForm
    {
        [Parameter]
        public EventCallback<CreateTodoDto> CreateTodo { get; set; }

      
        private CreateTodoDto todo { get; set; } = new();
    
    }
}
