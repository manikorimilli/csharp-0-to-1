# 05. CancellationToken (vs JS AbortController)

**In one line:** `CancellationTokenSource` is `AbortController`, `CancellationToken` is `AbortSignal`.

| JS | C# |
|---|---|
| `const ctrl = new AbortController()` | `using var cts = new CancellationTokenSource();` |
| `ctrl.signal` | `cts.Token` |
| `ctrl.abort()` | `cts.Cancel()` |
| `AbortSignal.timeout(500)` | `cts.CancelAfter(500)` or `new CancellationTokenSource(500)` |
| `fetch(url, { signal })` | `await http.GetAsync(url, token)` |
| `signal.throwIfAborted()` | `token.ThrowIfCancellationRequested()` |
| `AbortError` | `OperationCanceledException` |

```csharp
public async Task<Report> BuildAsync(int id, CancellationToken cancellationToken = default)
{
    var data = await _repo.LoadAsync(id, cancellationToken);   // pass it down
    cancellationToken.ThrowIfCancellationRequested();          // or check between steps
    return Compute(data);
}
```

## Key points

- Convention: the token is the **last** parameter, often named `cancellationToken` or `ct`, often `= default`.
- Pass the token to every async call that accepts one. Cancellation is cooperative: nothing stops unless code checks the token.
- In ASP.NET Core, add a `CancellationToken` parameter to an action and the framework cancels it when the client disconnects.

## Gotchas

- `CancellationTokenSource` is `IDisposable`; use `using`.
- Catch `OperationCanceledException` (base type), not only `TaskCanceledException`.

Run it: `dotnet run -- 05`
