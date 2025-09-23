// File: backend/Clients/ITodoApiClient.cs
namespace backend.Application.Interfaces;

using Dtos;

public interface ITodoApiClient
{
    Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request);
    Task<List<TodoItemResponse>> GetTodosAsync();
}
