namespace TodoClient.Models
{
    public class Todo
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? Deadline { get; set; }
        public bool Completed { get; set; }

    }
}
