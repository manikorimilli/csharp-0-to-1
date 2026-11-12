# 06. ToList, ToDictionary and other everyday operators

**In one line:** `ToList`, `ToArray`, `ToDictionary`, `ToHashSet` run the query and store the results.

```csharp
List<string> names = customers.Select(c => c.Name).ToList();
Dictionary<int, Product> byId = products.ToDictionary(p => p.Id);
Dictionary<string, decimal> priceByName = products.ToDictionary(p => p.Name, p => p.Price);
HashSet<string> tags = posts.SelectMany(p => p.Tags).ToHashSet();
```

## Other operators you will meet daily

| C# | JS equivalent |
|---|---|
| `Distinct()` | `[...new Set(arr)]` |
| `DistinctBy(x => x.Key)` | lodash `uniqBy` |
| `Skip(n).Take(m)` | `slice(n, n + m)` (pagination) |
| `Take(n)` | `slice(0, n)` |
| `Chunk(3)` | lodash `chunk` |
| `Zip(other, (a, b) => ...)` | lodash `zip` |
| `Concat(other)` | `arr.concat(other)` |
| `Reverse()` | `[...arr].reverse()` |
| `Enumerable.Range(1, 5)` | `Array.from({ length: 5 }, (_, i) => i + 1)` |
| `Enumerable.Empty<T>()` | `[]` |

## Key points

- Materialize once if you iterate several times or need `Count`/indexing.
- Return types: real code often returns `IEnumerable<T>` (lazy) or `IReadOnlyList<T>` (materialized) from methods.

## Gotchas

- `ToDictionary` throws `ArgumentException` ("An item with the same key has already been added") on duplicate keys. Use `GroupBy` or `ToLookup` when keys repeat, or `DistinctBy` first.

Run it: `dotnet run -- 06`
