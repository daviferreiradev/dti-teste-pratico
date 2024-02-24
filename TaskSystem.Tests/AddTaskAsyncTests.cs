using Moq;
using System;
using Xunit;
using TaskSystem.Services;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;
using System.Threading.Tasks;

public class AddTaskAsyncTests
{
    [Fact]
    public async Task AddTaskAsync_ValidTask_ReturnsTask()
    {
        var mockRepo = new Mock<ITaskRepository>();
        var service = new TaskService(mockRepo.Object);
        var newTask = new TaskModel { Name = "New Task", Date = DateTime.Now.AddDays(1) };

        mockRepo.Setup(repo => repo.AddTask(It.IsAny<TaskModel>())).ReturnsAsync(new TaskModel { Id = 1, Name = "New Task", Date = DateTime.Now.AddDays(1) });

        var result = await service.AddTaskAsync(newTask);

        Assert.NotNull(result);
        Assert.Equal("New Task", result.Name);
    }

    [Fact]
    public async Task AddTaskAsync_InvalidName_ThrowsArgumentException()
    {
        var service = new TaskService(null); // No need to setup repo for this test

        var task = new TaskModel { Name = "", Date = DateTime.Now.AddDays(1) };

        await Assert.ThrowsAsync<ArgumentException>(() => service.AddTaskAsync(task));
    }
}
