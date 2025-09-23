namespace backend.Services;

using Dtos;
using Repositories;
using Mappers;
using Models;

public class TodoService
{
    private readonly ITodoRepository _repository;

    public TodoService(ITodoRepository repository)
    {
        _repository = repository;
    }

    public async Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request)
    {
        var entity = TodoItemMapper.ToEntity(request);
        var saved = await _repository.AddAsync(entity);
        return TodoItemMapper.ToResponse(saved);
    }

    public async Task<IEnumerable<TodoItemResponse>> GetTodosAsync()
    {
        var entities = await _repository.GetAllAsync();
        return TodoItemMapper.ToResponseList(entities);
    }
}
