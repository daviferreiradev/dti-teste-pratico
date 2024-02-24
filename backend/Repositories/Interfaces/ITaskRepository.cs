using TaskSystem.Models;

namespace TaskSystem.Repositories.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskModel> FindTaskById(int id);
        Task<List<TaskModel>> GetAllTasks();
        Task<TaskModel> AddTask(TaskModel task);
        Task<bool> DeleteTask(int id);
    }
}
