using Microsoft.AspNetCore.Mvc;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;

namespace RealWorldSample.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly ILogger<TodosController> _logger;

    public TodosController(ITodoService todoService, ILogger<TodosController> logger)
    {
        _todoService = todoService;
        _logger = logger;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _todoService.GetAllAsync(cancellationToken);
        return Ok(items.Select(TodoDto.From));
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var item = await _todoService.GetByIdAsync(id, cancellationToken);
        if (item is null)
        {
            return NotFound();
        }
        return Ok(TodoDto.From(item));
    }

    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create(CreateTodoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _todoService.CreateAsync(request.Title, cancellationToken);
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, TodoDto.From(item));
        }
        catch (ArgumentException ex)
        {
            _logger.LogInformation("Rejected new todo: {Reason}", ex.Message);
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpPost("{id:int}/complete")]
    public async Task<IActionResult> Complete(int id, CancellationToken cancellationToken)
    {
        bool found = await _todoService.CompleteAsync(id, cancellationToken);
        return found ? NoContent() : NotFound();
    }

    // NEW: DELETE /api/todos/5  -> 204 No Content, or 404 Not Found
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        bool deleted = await _todoService.DeleteAsync(id, cancellationToken);
        return deleted ? NoContent() : NotFound();
    }
}
