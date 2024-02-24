using Moq;
using TaskSystem.Models;
using TaskSystem.Repositories.Interfaces;
using TaskSystem.Services;

public class FindTaskByIdAsyncTests
{
    [Fact]
    public async Task FindTaskByIdAsync_ExistingId_ReturnsTask()
    {
        var mockRepo = new Mock<ITaskRepository>();
        var service = new TaskService(mockRepo.Object);
        var taskId = 1;
        var expectedTask = new TaskModel { Id = taskId, Name = "Existing Task", Date = DateTime.Now.AddDays(1) };

        mockRepo.Setup(repo => repo.FindTaskById(taskId)).ReturnsAsync(expectedTask);

        var result = await service.FindTaskByIdAsync(taskId);

        Assert.NotNull(result);
        Assert.Equal(taskId, result.Id);
    }
}
