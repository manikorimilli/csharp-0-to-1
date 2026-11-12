# 05. GroupBy

**In one line:** like JS `Object.groupBy` / lodash `groupBy`, but each group is a sequence with a `.Key`, and you usually `Select` a summary right after.

```csharp
var summary = products
    .GroupBy(p => p.Category)
    .Select(g => new
    {
        Category = g.Key,
        Count = g.Count(),
        Total = g.Sum(p => p.Price)
    });
```

## JS vs C#

```js
const groups = Object.groupBy(products, p => p.category);
for (const [cat, items] of Object.entries(groups)) { ... }
```
```csharp
foreach (var g in products.GroupBy(p => p.Category))
    Console.WriteLine($"{g.Key}: {g.Count()}");
```

## Key points

- Composite keys: `GroupBy(c => (c.Country, c.IsVip))` then `g.Key.Country`.
- `ToLookup(key)` is an eagerly built, indexable grouping: `lookup["Furniture"]` (empty, not an exception, for unknown keys).
- To get a dictionary of groups: `.GroupBy(...).ToDictionary(g => g.Key, g => g.ToList())`.

## Gotchas

- Groups come out in order of first appearance, not sorted. Add `OrderBy(g => g.Key)` if needed.

Run it: `dotnet run -- 05`
