// File: TodoApp.Tests/ExternalTodoServiceTests.cs
using Xunit;
using Moq;
using backend.Services;
using backend.Clients;
using backend.Dtos;

public class ExternalTodoServiceTests
{
    [Fact]
    public async Task CreateTodoAsync_ShouldReturnTodoItemResponse()
    {
        // Arrange
        var mockClient = new Mock<ITodoApiClient>();
        var service = new ExternalTodoService(mockClient.Object);

        var request = new TodoItemCreateRequest { Title = "Test Todo" };
        var expected = new TodoItemResponse { Id = 1, Title = "Test Todo" };

        mockClient.Setup(c => c.CreateTodoAsync(request)).ReturnsAsync(expected);

        // Act
        var result = await service.CreateTodoAsync(request);

        // Assert
        Assert.Equal(expected.Title, result.Title);
        mockClient.Verify(c => c.CreateTodoAsync(request), Times.Once());
    }

    [Fact]
    public async Task GetTodosAsync_ShouldReturnListOfTodos()
    {
        var mockClient = new Mock<ITodoApiClient>();
        var service = new ExternalTodoService(mockClient.Object);

        var todos = new List<TodoItemResponse>
        {
            new TodoItemResponse { Id = 1, Title = "First" },
            new TodoItemResponse { Id = 2, Title = "Second" }
        };

        mockClient.Setup(c => c.GetTodosAsync()).ReturnsAsync(todos);

        var result = await service.GetTodosAsync();

        Assert.Equal(2, result.Count);
        Assert.Contains(result, t => t.Title == "First");
    }
}
