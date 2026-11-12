using Microsoft.AspNetCore.Mvc;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;

namespace RealWorldSample.Api.Controllers;

// Attributes configure the framework (like decorators in NestJS / TypeScript):
//   [ApiController]           automatic 400 for invalid bodies, binds JSON bodies, etc.
//   [Route("api/[controller]")]  [controller] = class name minus "Controller" -> /api/todos
[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;
    private readonly ILogger<TodosController> _logger;

    // Constructor injection: the DI container passes registered services in.
    public TodosController(ITodoService todoService, ILogger<TodosController> logger)
    {
        _todoService = todoService;
        _logger = logger;
    }

    // GET /api/todos            (Express: router.get("/api/todos", handler))
    [HttpGet]
    public async Task<ActionResult<IEnumerable<TodoDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _todoService.GetAllAsync(cancellationToken);
        return Ok(items.Select(TodoDto.From));             // 200 + JSON array
    }

    // NEW: GET /api/todos/stats
    // "stats" does not match the {id:int} constraint below, so the two routes never clash.
    [HttpGet("stats")]
    public async Task<ActionResult<TodoStats>> GetStats(CancellationToken cancellationToken) =>
        Ok(await _todoService.GetStatsAsync(cancellationToken));

    // GET /api/todos/5          ({id:int} is a route constraint: only digits match)
    [HttpGet("{id:int}")]
    public async Task<ActionResult<TodoDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var item = await _todoService.GetByIdAsync(id, cancellationToken);
        if (item is null)
        {
            return NotFound();                             // 404
        }
        return Ok(TodoDto.From(item));
    }

    // POST /api/todos   body: { "title": "Buy milk" }   (JSON body -> CreateTodoRequest)
    [HttpPost]
    public async Task<ActionResult<TodoDto>> Create(CreateTodoRequest request, CancellationToken cancellationToken)
    {
        try
        {
            var item = await _todoService.CreateAsync(request.Title, cancellationToken);
            // 201 Created + Location header pointing at GET /api/todos/{id}
            return CreatedAtAction(nameof(GetById), new { id = item.Id }, TodoDto.From(item));
        }
        catch (ArgumentException ex)
        {
            _logger.LogInformation("Rejected new todo: {Reason}", ex.Message);
            return BadRequest(new { error = ex.Message }); // 400
        }
    }

    // POST /api/todos/5/complete
    [HttpPost("{id:int}/complete")]
    public async Task<IActionResult> Complete(int id, CancellationToken cancellationToken)
    {
        bool found = await _todoService.CompleteAsync(id, cancellationToken);
        return found ? NoContent() : NotFound();           // 204 or 404
    }
}
