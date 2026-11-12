# 03. HashSet<T>

**In one line:** JS `Set`, with built-in set algebra.

## JS vs C#

| JS | C# |
|---|---|
| `new Set([1, 2])` | `new HashSet<int> { 1, 2 }` or `new HashSet<int>(list)` |
| `s.add(x)` | `s.Add(x)` (returns `false` if already present) |
| `s.has(x)` | `s.Contains(x)` |
| `s.delete(x)` | `s.Remove(x)` |
| `s.size` | `s.Count` |
| `[...new Set(arr)]` | `new HashSet<int>(arr)` or LINQ `arr.Distinct()` |

## Set operations (modify the set in place)

```csharp
a.UnionWith(b);        // a = a ∪ b
a.IntersectWith(b);    // a = a ∩ b
a.ExceptWith(b);       // a = a - b
a.IsSubsetOf(b);       // bool
a.Overlaps(b);         // bool
```

## Key points

- `Contains` is O(1). Replacing `list.Contains` inside a loop with a `HashSet` is a classic performance fix.
- Pass `StringComparer.OrdinalIgnoreCase` for case-insensitive strings.

## Gotchas

- `UnionWith` and friends return `void` and mutate the set. Copy first if you need the original.
- No index access (`set[0]` does not exist).

Run it: `dotnet run -- 03`
