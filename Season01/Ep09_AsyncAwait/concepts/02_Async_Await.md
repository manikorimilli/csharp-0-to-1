# 02. async / await

**In one line:** identical idea to JS. Mark the method `async`, return `Task` or `Task<T>`, and `await` other tasks.

## JS vs C#

```js
async function getOrder(id) {
  const res = await fetch(`/orders/${id}`);
  return await res.json();
}
```
```csharp
public async Task<Order?> GetOrderAsync(int id)
{
    var response = await _http.GetAsync($"/orders/{id}");
    return await response.Content.ReadFromJsonAsync<Order>();
}
```

## Return types

| You return | Method signature |
|---|---|
| a value `T` | `async Task<T> NameAsync()` |
| nothing | `async Task NameAsync()` |
| nothing, event handler only | `async void Button_Click(...)` |
| hot path value | `async ValueTask<T>` (treat like `Task<T>`) |

## Key points

- Naming convention: async methods end in `Async`.
- "Async all the way": once something is async, its callers become async too, up to the controller action or `Main`.
- Top-level `Program.cs` and `static async Task Main` can `await` directly.
- Async lambdas: `Func<Task>` and `Func<int, Task<string>>`.
- `await foreach` exists for `IAsyncEnumerable<T>` (streams of results, EF Core `AsAsyncEnumerable`).

## Gotchas

- `async` does not make code run in the background. It only lets the method pause at `await` points without blocking a thread.

Run it: `dotnet run -- 02`
