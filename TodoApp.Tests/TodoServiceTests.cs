namespace TodoApp.Tests;

using Xunit;
using Moq;
using backend.Application.Services;
using backend.Domain.Repositories;
using backend.Infrastructure.Persistence;
using backend.Application.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;
using backend.Domain.Entities;

public class TodoServiceTests
{
    [Fact]
    public async Task CreateTodoAsync_ShouldReturnTodoItemResponse()
    {
        // Arrange
        var mockRepo = new Mock<ITodoRepository>();
        var service = new TodoService(mockRepo.Object);

        var request = new TodoItemCreateRequest { Title = "Test Todo" };
        var expectedEntity = new TodoItem { Id = 1, Title = "Test Todo" };

        mockRepo
            .Setup(r => r.AddAsync(It.IsAny<TodoItem>()))
            .ReturnsAsync(expectedEntity);

        // Act
        var result = await service.CreateTodoAsync(request);

        // Assert
        Assert.Equal(request.Title, result.Title);
        mockRepo.Verify(r => r.AddAsync(It.IsAny<TodoItem>()), Times.Once());
    }

    [Fact]
    public async Task GetTodos_ShouldReturnListOfTodos()
    {
        // Arrange
        var mockRepo = new Mock<ITodoRepository>();
        var service = new TodoService(mockRepo.Object);

        var todos = new List<TodoItem>
        {
            new TodoItem { Id = 1, Title = "First" },
            new TodoItem { Id = 2, Title = "Second" }
        };

        mockRepo
            .Setup(r => r.GetAllAsync())
            .ReturnsAsync(todos);

        // Act
        var result = await service.GetTodosAsync();

        // Assert
        Assert.Equal(2, result.Count());
        Assert.Contains(result, t => t.Title == "First");
        Assert.Contains(result, t => t.Title == "Second");
        mockRepo.Verify(r => r.GetAllAsync(), Times.Once());
    }
}
