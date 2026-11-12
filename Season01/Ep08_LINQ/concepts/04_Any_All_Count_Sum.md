# 04. Any, All, Count, Sum and friends (vs JS some, every, reduce)

**In one line:** dedicated methods replace most uses of JS `reduce`.

| JS | C# |
|---|---|
| `arr.some(fn)` | `arr.Any(fn)` |
| `arr.every(fn)` | `arr.All(fn)` |
| `arr.length > 0` | `arr.Any()` |
| `arr.filter(fn).length` | `arr.Count(fn)` |
| `arr.reduce((s, x) => s + x.price, 0)` | `arr.Sum(x => x.Price)` |
| average via reduce | `arr.Average(x => x.Price)` |
| `Math.min(...arr.map(f))` | `arr.Min(f)` |
| item with max value | `arr.MaxBy(x => x.Price)` (.NET 6+) |
| `arr.includes(x)` | `arr.Contains(x)` |
| `arr.reduce(fn, seed)` | `arr.Aggregate(seed, fn)` |

## Key points

- `Any()` stops at the first match; prefer it to `Count() > 0`.
- `Max(x => x.Price)` returns the **value**; `MaxBy(x => x.Price)` returns the **item**.
- For lists, `.Count` (property) is O(1); LINQ `.Count()` without a predicate also uses it when it can.

## Gotchas

- On an empty sequence: `Sum` returns 0, but `Average`, `Min`, `Max` **throw** for non-nullable numbers. Use `DefaultIfEmpty(0)` or check `Any()` first.

Run it: `dotnet run -- 04`
