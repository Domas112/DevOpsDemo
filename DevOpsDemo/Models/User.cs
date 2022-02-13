using System.ComponentModel.DataAnnotations;

namespace DevOpsDemo.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string Email { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<Todo> TodoList { get; set; } = new List<Todo>();
    }
}
