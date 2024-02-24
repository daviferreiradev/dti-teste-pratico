using TaskSystem.Models;

namespace TaskSystem.Services.Interfaces;
public interface ITaskService
{
    Task<TaskModel> FindTaskByIdAsync(int id);
    Task<TaskModel> AddTaskAsync(TaskModel task);
    Task<bool> DeleteTaskAsync(int id);
    Task<List<TaskModel>> GetAllTasksAsync();
}
