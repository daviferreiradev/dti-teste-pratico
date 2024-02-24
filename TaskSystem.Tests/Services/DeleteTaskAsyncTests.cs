using Moq;
using TaskSystem.Repositories.Interfaces;
using TaskSystem.Services;

public class DeleteTaskAsyncTests
{
    [Fact]
    public async Task DeleteTaskAsync_ExistingId_ReturnsTrue()
    {
        var mockRepo = new Mock<ITaskRepository>();
        var service = new TaskService(mockRepo.Object);
        var taskId = 1;

        mockRepo.Setup(repo => repo.DeleteTask(taskId)).ReturnsAsync(true);

        var result = await service.DeleteTaskAsync(taskId);

        Assert.True(result);
    }
}
