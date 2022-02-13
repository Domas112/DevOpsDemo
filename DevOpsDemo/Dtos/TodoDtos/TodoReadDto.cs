namespace DevOpsDemo.Dtos.TodoDtos
{
    public class TodoReadDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; } = false;
        public Guid UserId { get; set; }
    }
}
