namespace DevOpsDemo.Dtos.TodoDtos
{
    public class TodoCreateDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? Deadline { get; set; }
        public Guid UserId { get; set; }
    }
}
