using Microsoft.AspNetCore.Mvc;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;

namespace TaskTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTasks()
        {
            var taskResult = await _taskService.GetAllAsync();
            return Ok(taskResult);
        }

        [HttpGet("{taskId}")]
        public async Task<IActionResult> GetTaskById(int taskId)
        {
            var taskResult = await _taskService.GetByIdAsync(taskId);
            return Ok(taskResult);
        }
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? title, [FromQuery] string description)
        {
            var taskResult = await _taskService.FindAsync(title, description);
            return Ok(taskResult);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask([FromBody] TaskAddDto task)
        {
            var taskResult = await _taskService.AddAsync(task);
            return Ok(taskResult);
        }

        [HttpPut("{taskId}")]
        public async Task<IActionResult> UpdateTask(int taskId, [FromBody] TaskUpdateDto task)
        {
            var taskResult = await _taskService.UpdateAsync(taskId, task);
            return Ok(taskResult);
        }

        [HttpDelete("{taskId}")]
        public async Task<IActionResult> Delete(int taskId)
        {
            var taskResult = await _taskService.DeleteAsync(taskId);
            return Ok(taskResult);
        }



    }
}
