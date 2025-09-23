// File: backend/Clients/TodoApiClient.cs
namespace backend.Clients;

using System.Net.Http.Json;
using backend.Dtos;

public class TodoApiClient : ITodoApiClient
{
    private readonly HttpClient _httpClient;

    public TodoApiClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync("todos", request);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<TodoItemResponse>()!;
    }

    public async Task<List<TodoItemResponse>> GetTodosAsync()
    {
        var response = await _httpClient.GetFromJsonAsync<List<TodoItemResponse>>("todos");
        return response ?? new List<TodoItemResponse>();
    }
}
