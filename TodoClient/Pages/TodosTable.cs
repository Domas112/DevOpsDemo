using Microsoft.AspNetCore.Components;
using TodoClient.Models;

namespace TodoClient.Pages
{
    public partial class TodosTable
    {
        //##### PARAMETERS ######
        [Parameter]
        public IList<Todo>? todos { get; set; }

        [Parameter]
        public EventCallback<Guid> CompleteTodo { get; set; }

        [Parameter]
        public EventCallback<Guid> DeleteTodo { get; set; }

        [Parameter]
        public EventCallback<Todo> UpdateTodo { get; set; }

        //#### OTHER VARS ####
        private bool disabled = true;
        private bool edited = false;


        //## OTHER FUNCTIONS ##
        private async Task edit(Todo todo)
        {
            if (disabled)
            {
                disabled = false;
            }
            else
            {
                await UpdateTodo.InvokeAsync(todo);
                disabled = true;
            }

        }




    }
}
