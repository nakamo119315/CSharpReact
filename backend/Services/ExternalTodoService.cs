// File: backend/Services/ExternalTodoService.cs
namespace backend.Services;

using backend.Clients;
using backend.Dtos;

public class ExternalTodoService
{
    private readonly ITodoApiClient _client;

    public ExternalTodoService(ITodoApiClient client)
    {
        _client = client;
    }

    public async Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request)
    {
        return await _client.CreateTodoAsync(request);
    }

    public async Task<List<TodoItemResponse>> GetTodosAsync()
    {
        return await _client.GetTodosAsync();
    }
}
