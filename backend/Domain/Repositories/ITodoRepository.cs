namespace backend.Domain.Repositories;

using Microsoft.EntityFrameworkCore;
using Entities;

public interface ITodoRepository
{
    Task<TodoItem> AddAsync(TodoItem todo);
    Task<List<TodoItem>> GetAllAsync();
}