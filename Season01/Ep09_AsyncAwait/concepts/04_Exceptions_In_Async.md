# 04. Exceptions in async code

**In one line:** `try/catch` around `await` works like in JS. An exception is stored in the task until someone awaits it.

```csharp
try
{
    var user = await _repo.GetUserAsync(id);
}
catch (HttpRequestException ex)
{
    _logger.LogWarning(ex, "Lookup failed");
}
```

## Key points

- A faulted task that is never awaited hides its error, like an unhandled rejected Promise (but without the console warning).
- `await Task.WhenAll(...)` rethrows the **first** exception. All of them are in `whenAllTask.Exception.InnerExceptions`.
- `.Result` / `.Wait()` wrap errors in `AggregateException`; `await` unwraps them. Another reason to always `await`.
- Cancellation shows up as `OperationCanceledException` (or the derived `TaskCanceledException`).

## Gotchas

- Exceptions thrown inside an `async void` method cannot be caught by the caller and can crash the process.
- An `async` method that throws before its first `await` still reports the exception through the task, not at the call site.

Run it: `dotnet run -- 04`
