using DevOpsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DevOpsDemo.DataContexts
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }

        public DbSet<Todo> Todos { get; set; }
    }
}
