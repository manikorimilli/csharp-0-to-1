# 01. Exceptions

**In one line:** `try/catch/finally` like JS, but you catch by **type**, can add `when` filters, and only `Exception` objects can be thrown.

## JS vs C#

```js
try { reserve(); }
catch (e) {
  if (e instanceof StockError) { ... } else throw e;
}
finally { cleanup(); }
```
```csharp
try { Reserve(); }
catch (InsufficientStockException ex) { ... }                 // most specific first
catch (HttpRequestException ex) when (ex.StatusCode == HttpStatusCode.NotFound) { ... }  // filter
catch (Exception ex) { logger.LogError(ex, "Failed"); throw; } // rethrow, keep stack trace
finally { Cleanup(); }
```

## Custom exceptions

```csharp
public class InsufficientStockException(string sku) : Exception($"No stock for {sku}")
{
    public string Sku { get; } = sku;
}
```

## Exceptions you will see daily

`ArgumentException`, `ArgumentNullException`, `ArgumentOutOfRangeException`, `InvalidOperationException`,
`NullReferenceException`, `KeyNotFoundException`, `FormatException`, `NotImplementedException`,
`OperationCanceledException` (Ep09).

## Key points

- `throw;` rethrows with the original stack trace. `throw ex;` resets it; reviewers will flag it.
- Wrap with context: `throw new InvalidOperationException("Loading config failed", ex);` (JS `{ cause }`).
- Guard helpers: `ArgumentNullException.ThrowIfNull(x);`, `ArgumentException.ThrowIfNullOrEmpty(s);`
- C# has no checked exceptions (unlike Java). Nothing forces you to declare or catch.

## Gotchas

- Do not use exceptions for normal control flow. Prefer `TryParse`/`TryGetValue` patterns.
- Catching `Exception` everywhere hides bugs. Catch what you can handle; let the rest bubble up to a global handler.

Run it: `dotnet run -- 01`
