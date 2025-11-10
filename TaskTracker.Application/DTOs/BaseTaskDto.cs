
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.DTOs
{
    public class BaseTaskDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public Status Status { get; set; } = Status.New;
        public Priority Priority { get; set; }
        public string? DueDate { get; set; }
        public string CreatedAt { get; set; } = DateTime.UtcNow.ToString("dd-MM-yyyy");
    }
}
