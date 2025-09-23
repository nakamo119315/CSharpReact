namespace backend.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; } = null!;
}