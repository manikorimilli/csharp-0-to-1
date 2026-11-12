# 02. OrderBy and ThenBy (vs JS sort)

**In one line:** sort by a **key** instead of writing a comparator; secondary keys use `ThenBy`. The original is not modified.

## JS vs C#

| JS | C# |
|---|---|
| `[...a].sort((x, y) => x.price - y.price)` | `a.OrderBy(x => x.Price)` |
| `... y.price - x.price` | `a.OrderByDescending(x => x.Price)` |
| `sort((x, y) => x.cat.localeCompare(y.cat) \|\| y.price - x.price)` | `a.OrderBy(x => x.Cat).ThenByDescending(x => x.Price)` |
| `[...nums].sort((a, b) => a - b)` | `nums.Order()` (.NET 7+) |

## Key points

- `OrderBy` is **stable**: equal keys keep their original order.
- `List<T>.Sort()` (Ep04) sorts in place; LINQ `OrderBy` returns a new sorted sequence.
- String keys sort with the current culture by default. Pass `StringComparer.Ordinal` for byte-wise order.

## Gotchas

- `.OrderBy(a).OrderBy(b)` sorts by `b` only. The second key must be `ThenBy`.
- JS `sort()` without a comparator sorts numbers as strings; C# sorts numbers numerically.

Run it: `dotnet run -- 02`
