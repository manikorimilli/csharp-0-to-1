# Challenge solution: due dates and an overdue endpoint

A full vertical slice through every layer.

| Layer | File | Change |
|---|---|---|
| Model | `Core/Models/TodoItem.cs` | `DateTime? DueAtUtc`, `bool IsOverdue(DateTime nowUtc)` |
| DTOs | `Core/Models/TodoDto.cs`, `CreateTodoRequest.cs` | `DueAtUtc` added (optional in the request) |
| Config | `Core/Options/TodoOptions.cs`, `Api/appsettings.json` | `DefaultDueInDays` (7) |
| Contract | `Core/Interfaces/ITodoService.cs` | `CreateAsync(title, dueAtUtc, ct)`, `GetOverdueAsync(ct)` |
| Logic | `Core/Services/TodoService.cs` | injects `TimeProvider`; rejects past due dates; default due date from options; LINQ for overdue; structured logs |
| DI | `Infrastructure/DependencyInjection.cs` | `services.AddSingleton(TimeProvider.System);` |
| HTTP | `Api/Controllers/TodosController.cs` | `GET /api/todos/overdue`; `Create` passes `request.DueAtUtc` |
| Tests | `Tests/Fakes/FixedTimeProvider.cs`, `Tests/Services/TodoServiceTests.cs` | controllable clock; 3 new tests including "time travel" with `Advance` |

Things worth noticing:
- `DueAtUtc < nowUtc` with a `DateTime?` is a lifted comparison: `null < x` is `false`, so items without a due date are never overdue (Ep05).
- Adding an optional parameter **before** `CancellationToken` keeps old callers like `CreateAsync("title")` compiling.
- `TimeProvider` is an abstract class in .NET 8, so a test double overrides one method.

```bash
curl -X POST localhost:5080/api/todos -H "Content-Type: application/json" \
     -d '{"title":"File taxes","dueAtUtc":"2030-04-30T00:00:00Z"}'
curl localhost:5080/api/todos/overdue
```

Apply: `cp -r Solutions/Challenge_DueDates/src Solutions/Challenge_DueDates/tests RealWorldSample/`
