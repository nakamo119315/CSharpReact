namespace backend.Services;

using Data;
using Models;
using Dtos;
using Repositories;
using Mappers;


// TodoService.cs
public class TodoService
{
    private readonly AppDbContext _context;

    public TodoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TodoItemResponse> CreateTodoAsync(TodoItemCreateRequest request)
    {
        var entity = TodoItemMapper.ToEntity(request);
        _context.TodoItems.Add(entity);
        await _context.SaveChangesAsync();
        return TodoItemMapper.ToResponse(entity);
    }

    public IEnumerable<TodoItemResponse> GetTodos()
    {
        var entities = _context.TodoItems.OrderByDescending(t => t.CreatedAt).ToList();
        return TodoItemMapper.ToResponseList(entities);
    }
}


