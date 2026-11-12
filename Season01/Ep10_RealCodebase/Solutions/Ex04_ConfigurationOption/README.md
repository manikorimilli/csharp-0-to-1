# Solution 4: a new configuration option (MaxOpenItems)

| File | Change |
|---|---|
| `src/RealWorldSample.Core/Options/TodoOptions.cs` | `public int MaxOpenItems { get; set; } = 10;` |
| `src/RealWorldSample.Api/appsettings.json` | `"MaxOpenItems": 10` |
| `src/RealWorldSample.Api/appsettings.Development.json` | `"MaxOpenItems": 3` (override for local testing) |
| `src/RealWorldSample.Core/Services/TodoService.cs` | count open items, throw `InvalidOperationException` at the limit |
| `src/RealWorldSample.Api/Controllers/TodosController.cs` | `catch (InvalidOperationException)` returns `Conflict(...)` (409) |
| `tests/RealWorldSample.Tests/Services/TodoServiceTests.cs` | new test `CreateAsync_OpenItemLimitReached_Throws` |

No change in `Program.cs`: the `Todo` section is already bound to `TodoOptions`, so a new property just works.

Try it (Development seeds 2 items, limit 3):

```bash
curl -X POST localhost:5080/api/todos -H "Content-Type: application/json" -d '{"title":"third"}'   # 201
curl -X POST localhost:5080/api/todos -H "Content-Type: application/json" -d '{"title":"fourth"}'  # 409
```

Override without touching files (double underscore = nesting):

```bash
Todo__MaxOpenItems=50 dotnet run --project src/RealWorldSample.Api
```

Apply: `cp -r Solutions/Ex04_ConfigurationOption/src Solutions/Ex04_ConfigurationOption/tests RealWorldSample/`
