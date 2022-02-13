using DevOpsDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace DevOpsDemo.DataContexts
{
    public class MainDbContext : DbContext
    {
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<User>()
            .HasMany(u => u.TodoList)
            .WithOne(t => t.User);

        }

    }
}
