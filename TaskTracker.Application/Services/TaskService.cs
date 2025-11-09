using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskTracker.API.Exceptions;
using TaskTracker.API.Model;
using TaskTracker.Application.DTOs;
using TaskTracker.Application.Interfaces;
using TaskTracker.Domain.Entities;
using TaskTracker.Infrastructure.Interfaces;

namespace TaskTracker.Application.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IMapper _mapper;

        public TaskService(ITaskRepository taskRepository, IMapper mapper)
        {
            _taskRepository = taskRepository;
            _mapper = mapper;
        }

        public async Task<ApiResponse<TaskDto>> AddAsync(TaskAddDto taskAddDto)
        {
            if (string.IsNullOrEmpty(taskAddDto.Title) || string.IsNullOrEmpty(taskAddDto.Description))
                throw new ApiException(400, $"Title and Description are required");
            var task = _mapper.Map<TaskEntity>(taskAddDto);
            var taskResponse = await _taskRepository.AddAsync(task);
            return new ApiResponse<TaskDto>(200, "Task added successfullty", _mapper.Map<TaskDto>(taskResponse));
        }

        public async Task<ApiResponse<bool>> DeleteAsync(int taskId)
        {
            var task = await _taskRepository.DeleteAsync(taskId);
            if (!task)
                throw new ApiException(404, $"Task not found for: {taskId}");
            return new ApiResponse<bool>(200, $"Task deleted successfully for id: {taskId}", task);

        }

        public async Task<ApiResponse<List<TaskDto>>> FindAsync(string query)
        {
            Expression<Func<TaskEntity, bool>> predicate = t =>
                (!string.IsNullOrEmpty(query) && t.Title.Contains(query, StringComparison.OrdinalIgnoreCase)) ||
                (!string.IsNullOrEmpty(query) && t.Description.ToString().Contains(query, StringComparison.OrdinalIgnoreCase));

            var taskResponse = await _taskRepository.FindAsync(predicate);
            if (taskResponse == null)
                throw new ApiException(404, $"No task found for: {predicate}");
            return new ApiResponse<List<TaskDto>>(200, "Task found", _mapper.Map<List<TaskDto>>(taskResponse));
        }

        public async Task<ApiResponse<List<TaskDto>>> GetAllAsync()
        {
            var taskResponse = await _taskRepository.GetAllAsync();
            if (!taskResponse.Any())
                throw new ApiException(404, $"No task found");
            return new ApiResponse<List<TaskDto>>(200, "Tasks Found", _mapper.Map<List<TaskDto>>(taskResponse));
        }

        public async Task<ApiResponse<TaskDto>> GetByIdAsync(int taskId)
        {
            var taskResponse = await _taskRepository.GetByIdAsync(taskId);
            if (taskResponse == null)
                throw new ApiException(404, $"Task not found for: {taskId}");
            return new ApiResponse<TaskDto>(200, "Task found", _mapper.Map<TaskDto>(taskResponse));
        }

        public async Task<ApiResponse<TaskDto>> UpdateAsync(int taskId, TaskUpdateDto taskUpdateDto)
        {
            var getTask = await _taskRepository.GetByIdAsync(taskId);
            if (getTask == null)
                throw new ApiException(404, $"Task not found for: {taskId}");
            var task = _mapper.Map(taskUpdateDto, getTask);
            var taskResponse = await _taskRepository.UpdateAsync(task);
            return new ApiResponse<TaskDto>(200, "Task updated successfully", _mapper.Map<TaskDto>(taskResponse));
        }
    }
}
