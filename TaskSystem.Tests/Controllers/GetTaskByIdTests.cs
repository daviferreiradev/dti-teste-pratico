using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Threading.Tasks;
using TaskSystem.Controllers;
using TaskSystem.Models;
using TaskSystem.Services.Interfaces;
using Xunit;

namespace TaskSystem.Tests.Controllers
{
    public class GetTaskByIdTests
    {
        private readonly Mock<ITaskService> _mockService;
        private readonly TaskController _controller;

        public GetTaskByIdTests()
        {
            _mockService = new Mock<ITaskService>();
            _controller = new TaskController(_mockService.Object);
        }

        [Fact]
        public async Task GetTaskById_ReturnsNotFound_WhenTaskDoesNotExist()
        {
            _mockService.Setup(service => service.FindTaskByIdAsync(It.IsAny<int>())).ReturnsAsync((TaskModel)null);

            var result = await _controller.GetTaskById(1);

            Assert.IsType<NotFoundObjectResult>(result.Result);
        }
    }
}
