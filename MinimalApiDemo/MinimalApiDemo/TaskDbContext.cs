using Microsoft.EntityFrameworkCore;

namespace MinimalApiDemo;

public class TaskDbContext : DbContext
{
    public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
    {
    }

    // Parametersless constructor for EF Core tools (e.g., migrations)
    public TaskDbContext() : base()
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Configure the database connection string here
            optionsBuilder.UseSqlite("Data Source=tasks.db");
        }
    }

    public DbSet<Task> Tasks { get; set; }
}