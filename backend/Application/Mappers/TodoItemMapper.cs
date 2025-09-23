// TodoItemMapper.cs
namespace backend.Application.Mappers;

using Dtos;
using Domain.Entities;
public static class TodoItemMapper
{
    public static TodoItemResponse ToResponse(TodoItem entity)
    {
        return new TodoItemResponse
        {
            Id = entity.Id,
            Title = entity.Title,
            IsDone = entity.IsDone,
            CreatedAt = entity.CreatedAt
        };
    }

    public static TodoItem ToEntity(TodoItemCreateRequest request)
    {
        return new TodoItem
        {
            Title = request.Title,
            IsDone = false,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static IEnumerable<TodoItemResponse> ToResponseList(IEnumerable<TodoItem> entities)
    {
        return entities.Select(e => ToResponse(e)).ToList();
    }
}
