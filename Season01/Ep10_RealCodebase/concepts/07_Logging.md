# 07. Logging with ILogger

**In one line:** inject `ILogger<T>` and call `LogInformation`, `LogWarning`, `LogError` with a message **template**, not an interpolated string.

```csharp
public class TodoService(ILogger<TodoService> logger)
{
    public void Complete(int id)
    {
        logger.LogInformation("Completing todo {TodoId}", id);    // structured
        // logger.LogInformation($"Completing todo {id}");        // works, but loses the TodoId field
    }
}
```

## JS comparison

| Node | .NET |
|---|---|
| `console.log` / `console.error` | `logger.LogInformation` / `logger.LogError` |
| pino / winston with JSON fields | `ILogger` with message templates (built in) |
| `logger.child({ module })` | `ILogger<TodoService>` (category = class name) |

## Levels (lowest to highest)

`Trace`, `Debug`, `Information`, `Warning`, `Error`, `Critical`.
`appsettings.json` sets the minimum per category:

```json
"Logging": { "LogLevel": { "Default": "Information", "Microsoft.AspNetCore": "Warning" } }
```

## Key points

- `{TodoId}` placeholders become searchable fields in tools like Seq, Elastic, Application Insights, Datadog.
- Pass exceptions as the first argument: `logger.LogError(ex, "Failed to save todo {TodoId}", id);`
- Many teams plug in **Serilog** behind the same `ILogger` interface. Your code does not change.
- In tests use `NullLogger<T>.Instance` (see `TodoServiceTests`).

## Gotchas

- Placeholders are matched by **position**, not by name.
- Do not log secrets or personal data.
