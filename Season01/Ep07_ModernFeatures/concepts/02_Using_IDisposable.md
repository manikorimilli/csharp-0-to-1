# 02. using and IDisposable

**In one line:** `using` guarantees `Dispose()` is called when a scope ends. It is C++ RAII, or JS `try { ... } finally { handle.close(); }`.

```csharp
using var conn = new SqlConnection(cs);    // disposed at end of the enclosing block
using (var file = File.OpenRead(path))     // older block form
{
    ...
}                                          // disposed here, even on exceptions

await using var stream = ...;              // IAsyncDisposable (Ep09)
```

## Writing a disposable type

```csharp
public sealed class TempFile : IDisposable
{
    public string Path { get; } = System.IO.Path.GetTempFileName();
    public void Dispose() => File.Delete(Path);
}
```

## Key points

- Anything that implements `IDisposable` and that **you created** should be in a `using`: streams, readers/writers, `HttpResponseMessage`, DB connections, `CancellationTokenSource`, timers.
- Objects injected by DI (Ep10) are disposed by the container. Do not dispose them yourself.
- The garbage collector frees memory, but not files or sockets on a schedule you control. That is what `Dispose` is for.

## Gotchas

- `HttpClient` is the famous exception: create it once (or via `IHttpClientFactory`), do not `using` a new one per request.
- `using var` lives until the end of the **enclosing block**, which may be later than you think.

Run it: `dotnet run -- 02`
