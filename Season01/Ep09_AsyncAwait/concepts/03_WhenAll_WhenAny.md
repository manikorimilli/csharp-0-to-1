# 03. Task.WhenAll and Task.WhenAny (vs Promise.all and Promise.race)

**In one line:** start several tasks, then await them together.

| JS | C# |
|---|---|
| `await Promise.all([a(), b()])` | `await Task.WhenAll(A(), B())` |
| `const [x, y] = await Promise.all(...)` | `T[] results = await Task.WhenAll(tasks)` (same type `T`) |
| `await Promise.race([a(), b()])` | `var first = await Task.WhenAny(a, b); var r = await first;` |
| `Promise.allSettled` | `await Task.WhenAll(...)` in a try, then inspect each task's `Status` |
| `AbortSignal.timeout(ms)` / race with a timer | `await task.WaitAsync(TimeSpan.FromSeconds(2))` |

```csharp
var tasks = productIds.Select(id => _api.GetPriceAsync(id));   // start all
decimal[] prices = await Task.WhenAll(tasks);                  // wait for all
```

## Key points

- Start the tasks **before** awaiting. `await A(); await B();` runs them one after the other.
- `WhenAny` returns the **task** that finished first; await it again to get its value (or exception).
- Tasks of different types: `await Task.WhenAll(t1, t2);` then read `t1.Result` and `t2.Result` (safe: they are completed).

## Gotchas

- The losers of `WhenAny` keep running. Cancel them with a `CancellationToken` if needed.
- Firing 10,000 tasks at once can overload an API. Limit concurrency with `SemaphoreSlim` or `Parallel.ForEachAsync`.

Run it: `dotnet run -- 03`
