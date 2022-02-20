using Microsoft.EntityFrameworkCore;
using Assignment_1_Task.Models;

namespace Assignment_1_Task.DatabaseContexts {
    public class TaskDbContext : DbContext {
        public TaskDbContext() { }
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base (options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=DBName;Integrated Security=True");
        }

        public DbSet<Task> Tasks { get; set; }
    }
}