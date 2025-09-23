// File: backend/Clients/ITodoApiClient.cs
namespace backend.Clients;

using backend.Dtos;

public interface ITodoApiClient
{
    Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request);
    Task<List<TodoItemResponse>> GetTodosAsync();
}
