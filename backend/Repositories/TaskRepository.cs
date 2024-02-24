using Microsoft.EntityFrameworkCore;
using TaskSystem.Data;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;

namespace TaskSystem.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskSystemDBContext _dbContext;

        public TaskRepository(TaskSystemDBContext TaskSystemDBContext)
        {
            _dbContext = TaskSystemDBContext;
        }

        public async Task<TaskModel> FindTaskById(int id)
        {
            return await _dbContext.Tasks.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<TaskModel>> GetAllTasks()
        {
            return await _dbContext.Tasks.ToListAsync();
        }

        public async Task<TaskModel> AddTask(TaskModel task)
        {
            await _dbContext.Tasks.AddAsync(task);
            await _dbContext.SaveChangesAsync();

            return task;
        }

        public async Task<bool> DeleteTask(int id)
        {
            TaskModel taskPorId = await FindTaskById(id);

            if(taskPorId == null)
                throw new Exception($"Usuário para o ID: {id} não foi encontrado no banco de dados.");
            

            _dbContext.Tasks.Remove(taskPorId);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
