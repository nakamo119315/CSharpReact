using backend.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace backend.Presentation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeminiController : ControllerBase
{
    private readonly GeminiService _service;

    public GeminiController(GeminiService service)
    {
        _service = service;
    }

    [HttpPost("ask")]
    public async Task<IActionResult> Ask([FromBody] string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
            return BadRequest("Prompt is required.");

        var result = await _service.AskAsync(prompt);
        return Ok(result);
    }
}
