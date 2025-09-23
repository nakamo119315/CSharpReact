namespace backend.Application.Services;

using Dtos;
using Mappers;
using Domain.Repositories;
using Domain.Entities;

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
