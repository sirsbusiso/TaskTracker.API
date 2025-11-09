using System.Linq.Expressions;
using TaskTracker.API.Model;
using TaskTracker.Application.DTOs;
using TaskTracker.Domain.Entities;

namespace TaskTracker.Application.Interfaces
{
    public interface ITaskService
    {
        Task<ApiResponse<List<TaskDto>>> GetAllAsync();
        Task<ApiResponse<TaskDto>> GetByIdAsync(int taskId);
        Task<ApiResponse<TaskDto>> AddAsync(TaskAddDto taskAddDto);
        Task<ApiResponse<TaskDto>> UpdateAsync(int taskId, TaskUpdateDto taskUpdateDto);
        Task<ApiResponse<bool>> DeleteAsync(int taskId);
        Task<ApiResponse<List<TaskDto>>> FindAsync(string query);
    }
}
