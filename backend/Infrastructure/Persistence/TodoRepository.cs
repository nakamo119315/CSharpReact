namespace backend.Infrastructure.Persistence;

using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Domain.Repositories;

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
