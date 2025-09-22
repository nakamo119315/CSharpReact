namespace backend.Controllers;
using Microsoft.AspNetCore.Mvc;
using Services;
using Dtos;


// TodoItemsController.cs
[ApiController]
[Route("api/[controller]")]
public class TodoItemsController : ControllerBase
{
    private readonly TodoService _service;

    public TodoItemsController(TodoService service)
    {
        _service = service;
    }

    [HttpGet]
    public ActionResult<IEnumerable<TodoItemResponse>> GetTodos()
    {
        var todos = _service.GetTodos();
        return Ok(todos);
    }

    [HttpPost]
    public async Task<ActionResult<TodoItemResponse>> Create(TodoItemCreateRequest request)
    {
        var created = await _service.CreateTodoAsync(request);
        return Ok(created);
    }
}
