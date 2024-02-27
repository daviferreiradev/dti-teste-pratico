using Moq;
using TaskSystem.Repositories.Interfaces;
using TaskSystem.Services;
using Xunit;
using System.Collections.Generic;
using TaskSystem.Models;
using System;
using System.Threading.Tasks;

public class TaskServiceTests
{
    [Fact]
    public async Task GetAllTasksAsync_ReturnsSortedTasks()
    {
        var mockRepo = new Mock<ITaskRepository>();
        var tasks = new List<TaskModel>
        {
            new TaskModel { Id = 1, Name = "Task 1", Date = DateTime.Now.AddDays(1) },
            new TaskModel { Id = 2, Name = "Task 2", Date = DateTime.Now.AddDays(2) }
        };
        mockRepo.Setup(repo => repo.GetAllTasks()).ReturnsAsync(tasks);

        var service = new TaskService(mockRepo.Object);

        var result = await service.GetAllTasksAsync();

        Assert.True(result[0].Date < result[1].Date, "Os tasks devem estar ordenados por data");
    }
}
