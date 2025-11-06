using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Data;
using TaskTracker.Infrastructure.Interfaces;

namespace TaskTracker.Infrastructure.Repository
{
    public class TaskRepository(TaskTrackerDbContext context) : GenericRepository<TaskEntity>(context), ITaskRepository
    {
    }
}
