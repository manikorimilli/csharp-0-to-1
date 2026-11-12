# 04. Attributes (vs JS/TS decorators)

**In one line:** `[Something]` above a class, method, property or parameter attaches metadata that the framework reads at runtime.

## TypeScript (NestJS) vs C# (ASP.NET Core)

```ts
@Controller("todos")
export class TodosController {
  @Get(":id")
  getById(@Param("id") id: number) { ... }
}
```
```csharp
[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    [HttpGet("{id:int}")]
    public ActionResult<TodoDto> GetById(int id) { ... }
}
```

The big difference: TS decorators are **functions that run** and can change the target. C# attributes are **passive data**; some other code (the framework, a serializer, a test runner) looks them up with reflection and acts on them.

## Attributes you will see constantly

| Attribute | Meaning |
|---|---|
| `[ApiController]`, `[Route]`, `[HttpGet]`, `[HttpPost]`... | routing and API behavior |
| `[FromBody]`, `[FromQuery]`, `[FromRoute]`, `[FromServices]` | where a parameter comes from |
| `[Authorize]`, `[AllowAnonymous]` | authentication rules |
| `[Required]`, `[StringLength]`, `[Range]`, `[EmailAddress]` | validation (DataAnnotations) |
| `[JsonPropertyName("x")]`, `[JsonIgnore]` | JSON serialization |
| `[Fact]`, `[Theory]`, `[InlineData]` | xUnit tests |
| `[Flags]` | enum flags (Ep05) |
| `[Obsolete("use X")]` | compiler warning for callers |

## Syntax notes

- Several attributes: `[Required, StringLength(100)]` or on separate lines.
- The `Attribute` suffix is optional: `[Required]` is the `RequiredAttribute` class.
- Arguments: positional then named, `[StringLength(100, MinimumLength = 3)]`.
- Targets: `[property: JsonIgnore]`, `[return: ...]`, `[assembly: ...]` (rare).

## Writing one (rarely needed)

```csharp
[AttributeUsage(AttributeTargets.Method)]
public class AuditAttribute(string action) : Attribute
{
    public string Action { get; } = action;
}
```
