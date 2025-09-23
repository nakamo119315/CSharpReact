using Microsoft.EntityFrameworkCore;
using backend.Infrastructure.Persistence;
using backend.Infrastructure.Clients;
using backend.Application.Services;
using backend.Application.Interfaces;
using backend.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// SQLite を登録
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite("Data Source=app.db"));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});
// リポジトリ登録
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// サービス登録
builder.Services.AddScoped<TodoService>();
builder.Services.AddHttpClient<IGeminiClient, GeminiClient>();
builder.Services.AddScoped<GeminiService>();
builder.Services.AddControllers();

var app = builder.Build();

app.UseCors();
app.MapControllers();

app.Run();