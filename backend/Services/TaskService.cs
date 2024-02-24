using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;
using TaskSystem.Services.Interfaces;

namespace TaskSystem.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        /*FindTaskByIdAsync*/
        public async Task<TaskModel> FindTaskByIdAsync(int id)
        {
            return await _taskRepository.FindTaskById(id);
        }

        public async Task<TaskModel> AddTaskAsync(TaskModel task)
        {
            if (string.IsNullOrWhiteSpace(task.Name))
                throw new ArgumentException("The 'Name' field must be filled.");

            if (task.Date <= DateTime.Now)
                throw new ArgumentException("The 'Date' must be in the future.");

            return await _taskRepository.AddTask(task);
        }

        public async Task<bool> DeleteTaskAsync(int id)
        {
            return await _taskRepository.DeleteTask(id);
        }

        public async Task<List<TaskModel>> GetAllTasksAsync()
        {
            var tasks = await _taskRepository.GetAllTasks();
            tasks.Sort((x, y) => DateTime.Compare(x.Date, y.Date));
            return tasks;
        }
    }
}
