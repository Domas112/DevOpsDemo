using System.ComponentModel.DataAnnotations;

namespace DevOpsDemo.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Description { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        [Required]
        public DateTime Deadline { get; set; }
    }
}
