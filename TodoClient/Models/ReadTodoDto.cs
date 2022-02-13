namespace TodoClient.Models
{
    public class ReadTodoDto
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; }
        public bool EditDisabled { get; set; } = true;
    }
}
