using Microsoft.AspNetCore.Mvc;
using TaskSystem.Models;
using TaskSystem.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public async Task<ActionResult<List<TaskModel>>> GetAllTasks()
        {
            var tasks = await _taskService.GetAllTasksAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTaskById(int id)
        {
            var task = await _taskService.FindTaskByIdAsync(id);
            if (task == null) return NotFound($"Task with ID: {id} was not found.");
            return Ok(task);
        }

        [HttpPost]
        public async Task<ActionResult<TaskModel>> AddTask([FromBody] TaskModel task)
        {
            try
            {
                var addedTask = await _taskService.AddTaskAsync(task);
                return CreatedAtAction(nameof(GetTaskById), new { id = addedTask.Id }, addedTask);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            try
            {
                await _taskService.DeleteTaskAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}
