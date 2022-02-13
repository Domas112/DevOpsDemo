using Microsoft.AspNetCore.Components;
using TodoClient.Models;

namespace TodoClient.Pages
{
    public partial class TodosTable
    {
        //##### PARAMETERS ######
        [Parameter]
        public IList<ReadTodoDto>? todos { get; set; }

        [Parameter]
        public EventCallback<Guid> CompleteTodo { get; set; }

        [Parameter]
        public EventCallback<Guid> DeleteTodo { get; set; }

        [Parameter]
        public EventCallback<ReadTodoDto> UpdateTodo { get; set; }

        //#### OTHER VARS ####
        private bool disabled = true;

        //## OTHER FUNCTIONS ##
        private async Task edit(ReadTodoDto todo)
        {
            if (todo.EditDisabled)
            {
                todo.EditDisabled = false;
            }
            else
            {
                await UpdateTodo.InvokeAsync(todo);
                todo.EditDisabled = true;
            }

        }




    }
}
