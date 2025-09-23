// File: backend/Controllers/ExternalTodoController.cs
namespace backend.Presentation.Controllers;

using Microsoft.AspNetCore.Mvc;
using Application.Services;
using Application.Dtos;

[ApiController]
[Route("api/external-todos")]
public class ExternalTodoController : ControllerBase
{
    private readonly ExternalTodoService _service;

    public ExternalTodoController(ExternalTodoService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemResponse>> Create(TodoItemCreateRequest request)
    {
        var result = await _service.CreateTodoAsync(request);
        return Ok(result);
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoItemResponse>>> Get()
    {
        var todos = await _service.GetTodosAsync();
        return Ok(todos);
    }
}
