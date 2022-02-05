using System.ComponentModel.DataAnnotations;

namespace DevOpsDemo.Models
{
    public class Todo
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        [Required]
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        
        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; } = false;
    }
}
