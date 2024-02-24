using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskSystem.Controllers;
using TaskSystem.Models;
using TaskSystem.Services.Interfaces;
using Xunit;

namespace TaskSystem.Tests.Controllers
{
	public class GetAllTasksTests
	{
		private readonly Mock<ITaskService> _mockService;
		private readonly TaskController _controller;

		public GetAllTasksTests()
		{
			_mockService = new Mock<ITaskService>();
			_controller = new TaskController(_mockService.Object);
		}

		[Fact]
		public async Task GetAllTasks_ReturnsOkObjectResult_WithAListOfTasks()
		{
			var mockTasks = new List<TaskModel>
			{
				new TaskModel { Id = 1, Name = "Test Task 1", Date = DateTime.Now.AddDays(1) },
				new TaskModel { Id = 2, Name = "Test Task 2", Date = DateTime.Now.AddDays(2) }
			};
			_mockService.Setup(service => service.GetAllTasksAsync()).ReturnsAsync(mockTasks);

			var result = await _controller.GetAllTasks();

			var actionResult = Assert.IsType<OkObjectResult>(result.Result);
			var returnedTasks = Assert.IsType<List<TaskModel>>(actionResult.Value);
			Assert.Equal(2, returnedTasks.Count);
		}
	}
}
