using System.ComponentModel.DataAnnotations;

namespace TodoClient.Models
{
    public class CreateTodoDto
    {
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
    }
}
