# 08. Controllers and endpoints (vs Express routes)

**In one line:** a controller is a class whose public methods ("actions") handle routes declared with attributes.

## Express vs ASP.NET Core

```js
const router = express.Router();
router.get("/api/todos/:id", async (req, res) => {
  const item = await todoService.getById(Number(req.params.id));
  if (!item) return res.status(404).end();
  res.json(item);
});
```
```csharp
[ApiController]
[Route("api/[controller]")]                 // /api/todos
public class TodosController(ITodoService todoService) : ControllerBase
{
    [HttpGet("{id:int}")]                   // /api/todos/5
    public async Task<ActionResult<TodoDto>> GetById(int id, CancellationToken ct)
    {
        var item = await todoService.GetByIdAsync(id, ct);
        return item is null ? NotFound() : Ok(TodoDto.From(item));
    }
}
```

| Express | ASP.NET Core |
|---|---|
| `req.params.id` | method parameter `int id` (bound from the route) |
| `req.query.page` | `int page` parameter, or `[FromQuery] int page` |
| `req.body` (with `express.json()`) | complex parameter, e.g. `CreateTodoRequest request` |
| `res.json(x)` | `return Ok(x);` |
| `res.status(201).json(x)` | `return CreatedAtAction(...)` / `Created(...)` |
| `res.status(204).end()` | `return NoContent();` |
| `res.status(404).end()` | `return NotFound();` |
| `res.status(400).json(err)` | `return BadRequest(err);` |
| `app.use(middleware)` | `app.UseXxx()` in `Program.cs` |
| validation middleware | `[ApiController]` + attributes like `[Required]` |

## Return types

- `ActionResult<T>`: either a `T` (200) or another result (`NotFound()`).
- `IActionResult`: any result, no body type.
- JSON is camelCase by default (`IsDone` becomes `isDone`).

## Minimal APIs

The other style, closer to Express, used for small services:

```csharp
app.MapGet("/health", () => Results.Ok(new { status = "ok" }));
app.MapGet("/api/todos/{id:int}", async (int id, ITodoService s) =>
    await s.GetByIdAsync(id) is { } item ? Results.Ok(item) : Results.NotFound());
```

## Gotchas

- Route constraints like `{id:int}` mean `/api/todos/abc` is a 404, not a 400.
- Controllers should stay thin: parse input, call a service, map the result to HTTP. Business rules go in services.
