# 06. foreach

**In one line:** JS `for (const x of items)` is C# `foreach (var x in items)`.

## JS vs C#

| JS | C# |
|---|---|
| `for (const x of arr)` | `foreach (var x in arr)` |
| `for (const k in obj)` (keys) | `foreach (var kv in dict)` then `kv.Key`, `kv.Value` |
| `arr.forEach((x, i) => ...)` | `for` loop, or `foreach (var (x, i) in arr.Select((x, i) => (x, i)))` |
| `for (const [k, v] of map)` | `foreach (var (k, v) in dict)` |

## Key points

- Works on anything that implements `IEnumerable<T>`: arrays, `List<T>`, `Dictionary`, strings (chars), LINQ results.
- The loop variable is read-only.

## Gotchas

- Do not use `in` for keys like JS `for...in`. C# `in` is always "each element".
- Adding or removing items from a `List<T>` **while** iterating it with `foreach` throws `InvalidOperationException` ("Collection was modified").

Run it: `dotnet run -- 06`
