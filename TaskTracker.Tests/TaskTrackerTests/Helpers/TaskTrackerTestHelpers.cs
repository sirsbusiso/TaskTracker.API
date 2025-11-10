using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Tests.TaskTrackerTests.Helpers
{
    public class TaskTrackerTestHelpers
    {
        public static List<TaskEntity> GetAllData()
        {
            return new List<TaskEntity>
            {
                 new TaskEntity
                {
                    Id = 1,
                    Title = "Setup Project",
                    Description = "Initialize project structure and database",
                    Status = Status.New,
                    Priority = Priority.High,
                    CreatedAt = DateTime.UtcNow.ToString()
                },
                new TaskEntity
                {
                    Id = 2,
                    Title = "Create API Endpoints",
                    Description = "Implement CRUD for TaskEntity",
                    Status = Status.InProgress,
                    Priority = Priority.Medium,
                    CreatedAt = DateTime.UtcNow.ToString()
                },
                new TaskEntity
                {
                    Id = 3,
                    Title = "Write Unit Tests",
                    Description = "Add unit tests for repository layer",
                    Status = Status.Done,
                    Priority = Priority.Low,
                    CreatedAt = DateTime.UtcNow.ToString()
                }
            };
        }

        public static TaskAddDto InvalidTaskAddDto()
        {
            return new TaskAddDto
            {
                Description = "",
                CreatedAt = "2025-11-10T18:30:00.123Z",
                Status = Status.New,
                Priority = Priority.High,
                Title = ""
            };
        }
    }
}
