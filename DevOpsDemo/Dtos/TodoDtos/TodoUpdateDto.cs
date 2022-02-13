namespace DevOpsDemo.Dtos.TodoDtos
{
    public class TodoUpdateDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; }
    }
}
