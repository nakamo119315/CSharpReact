using Microsoft.AspNetCore.Mvc;

namespace MyApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TodoItemsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var todos = new[]
            {
                new { Id = 1, Title = "Learn C#", Done = false },
                new { Id = 2, Title = "Learn React", Done = true },
                new { Id = 3, Title = "Connect Frontend & Backend", Done = false }
            };
            return Ok(todos);
        }
    }
}
