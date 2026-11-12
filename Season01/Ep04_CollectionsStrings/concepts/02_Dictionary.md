# 02. Dictionary<TKey, TValue>

**In one line:** a typed hash map, like JS `Map`. Use it wherever JS code uses an object as a lookup table.

## JS vs C#

| JS (`Map`) | C# |
|---|---|
| `new Map()` | `new Dictionary<string, int>()` |
| `m.set(k, v)` | `d[k] = v;` (add or overwrite) |
| | `d.Add(k, v)` (throws if `k` exists) |
| `m.get(k)` | `d[k]` (**throws** if missing) |
| `m.get(k) ?? def` | `d.GetValueOrDefault(k, def)` |
| `m.has(k)` | `d.ContainsKey(k)` |
| `m.delete(k)` | `d.Remove(k)` |
| `m.size` | `d.Count` |
| `for (const [k, v] of m)` | `foreach (var (k, v) in d)` |
| `[...m.keys()]` | `d.Keys` |

## The pattern you will see everywhere

```csharp
if (cache.TryGetValue(id, out var user))
    return user;
```

Counting:

```csharp
counts[word] = counts.GetValueOrDefault(word) + 1;
```

## Key points

- Keys are compared with the type's equality. For case-insensitive string keys:
  `new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase)`.
- Iteration order is not guaranteed. Use `SortedDictionary` or sort the keys if order matters.

## Gotchas

- `d[missingKey]` throws `KeyNotFoundException`. JS returns `undefined`. This is the most common runtime error for JS developers in C#.
- `ContainsKey` followed by `d[key]` does two lookups; `TryGetValue` does one.

Run it: `dotnet run -- 02`
