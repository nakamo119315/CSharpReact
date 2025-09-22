namespace backend.Repositories;

using Microsoft.EntityFrameworkCore;
using Data;
using Models;

public interface ITodoRepository
{
    Task<TodoItem> AddAsync(TodoItem todo);
    Task<List<TodoItem>> GetAllAsync();
}

public class TodoRepository : ITodoRepository
{
    private readonly AppDbContext _context;

    public TodoRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TodoItem> AddAsync(TodoItem todo)
    {
        _context.TodoItems.Add(todo);
        await _context.SaveChangesAsync();
        return todo;
    }

    public async Task<List<TodoItem>> GetAllAsync()
    {
        return await _context.TodoItems.OrderByDescending(t => t.CreatedAt).ToListAsync();
    }
}
