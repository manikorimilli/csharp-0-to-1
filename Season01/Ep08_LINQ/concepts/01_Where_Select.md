# 01. Where and Select (vs JS filter and map)

**In one line:** `Where` = `filter`, `Select` = `map`, `SelectMany` = `flatMap`. They work on any `IEnumerable<T>`: arrays, lists, sets, dictionaries.

## JS vs C#

| JS | C# LINQ |
|---|---|
| `arr.filter(x => x > 2)` | `arr.Where(x => x > 2)` |
| `arr.map(x => x * 2)` | `arr.Select(x => x * 2)` |
| `arr.map((x, i) => ...)` | `arr.Select((x, i) => ...)` |
| `arr.flatMap(o => o.lines)` | `arr.SelectMany(o => o.Lines)` |
| `arr.map(p => ({ name: p.name }))` | `arr.Select(p => new { p.Name })` (anonymous type) |

```csharp
var names = products
    .Where(p => p.Price < 200)
    .Select(p => p.Name)
    .ToList();               // JS returns an array; LINQ returns a lazy sequence until ToList()
```

## Key points

- LINQ lives in `System.Linq` (included by implicit usings). The methods are extension methods (Ep07).
- Results are `IEnumerable<T>`, not arrays. Add `.ToList()` or `.ToArray()` when you need a collection.
- Chains read top to bottom; put one operator per line in longer queries.

## Gotchas

- `Select` does not change the original collection, same as JS `map`.
- Do not use `Select` for side effects. Use `foreach`.

Run it: `dotnet run -- 01`
