using Microsoft.EntityFrameworkCore;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Infrastructure.Data
{
    public class TaskTrackerDbContext: DbContext
    {
        public TaskTrackerDbContext(DbContextOptions<TaskTrackerDbContext> options) : base(options) { }

        public DbSet<TaskEntity> Tasks {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<TaskEntity>()
               .Property(t => t.Status)
               .HasConversion<string>();

            modelBuilder.Entity<TaskEntity>()
                .Property(t => t.Priority)
                .HasConversion<string>();

            // Optional: Seed data
            modelBuilder.Entity<TaskEntity>().HasData(
                new TaskEntity
                {
                    Id = 1,
                    Title = "Setup Project",
                    Description = "Initialize project structure and database",
                    Status = Status.New,
                    Priority = Priority.High,
                    CreatedAt = DateTime.UtcNow.ToString("dd-MM-yyyy")
                },
                new TaskEntity
                {
                    Id = 2,
                    Title = "Create API Endpoints",
                    Description = "Implement CRUD for TaskEntity",
                    Status = Status.InProgress,
                    Priority = Priority.Medium,
                    CreatedAt = DateTime.UtcNow.ToString("dd-MM-yyyy")
                },
                new TaskEntity
                {
                    Id = 3,
                    Title = "Write Unit Tests",
                    Description = "Add unit tests for repository layer",
                    Status = Status.Done,
                    Priority = Priority.Low,
                    CreatedAt = DateTime.UtcNow.ToString("dd-MM-yyyy")
                }
            );

        }
    }
}
