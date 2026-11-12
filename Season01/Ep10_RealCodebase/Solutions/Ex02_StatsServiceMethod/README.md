# Solution 2: add a service method (stats)

| File | Change |
|---|---|
| `src/RealWorldSample.Core/Models/TodoStats.cs` | new `record TodoStats(int Total, int Done, int Pending)` |
| `src/RealWorldSample.Core/Interfaces/ITodoService.cs` | added `Task<TodoStats> GetStatsAsync(...)` |
| `src/RealWorldSample.Core/Services/TodoService.cs` | implemented with LINQ `Count(i => i.IsDone)` |
| `src/RealWorldSample.Api/Controllers/TodosController.cs` | added `[HttpGet("stats")] GetStats(...)` |

Why no route clash with `GET /api/todos/{id:int}`? The `:int` constraint means "stats" can never match `{id}`.
Without the constraint, ASP.NET would still pick the literal `stats` route first (literal segments win), but constraints make the intent clear.

```bash
curl http://localhost:5080/api/todos/stats     # {"total":2,"done":0,"pending":2}
```

Apply: `cp -r Solutions/Ex02_StatsServiceMethod/src RealWorldSample/`
