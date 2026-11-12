# 01. List<T>

**In one line:** `List<T>` is the JS array you know (growable, indexable), but every element has the same type `T`.

## JS vs C#

| JS | C# |
|---|---|
| `const a = []` | `var a = new List<int>();` or `List<int> a = [];` |
| `[1, 2]` | `new List<int> { 1, 2 }` or `[1, 2]` |
| `a.length` | `a.Count` |
| `a.push(x)` | `a.Add(x)` |
| `a.push(...xs)` | `a.AddRange(xs)` |
| `a.splice(i, 0, x)` | `a.Insert(i, x)` |
| `a.splice(i, 1)` | `a.RemoveAt(i)` |
| remove a value | `a.Remove(x)` (first match) |
| `a.includes(x)` | `a.Contains(x)` |
| `a.find(fn)` | `a.Find(fn)` or LINQ `FirstOrDefault` |
| `a.filter(fn)` | `a.FindAll(fn)` or LINQ `Where` (Ep08) |
| `a = a.filter(x => !fn(x))` | `a.RemoveAll(fn)` (in place) |
| `a.sort((x, y) => x - y)` | `a.Sort()` or `a.Sort((x, y) => x.CompareTo(y))` |

## Key points

- `T` is a generic type parameter: `List<string>`, `List<Customer>`, `List<List<int>>`.
- `new()` target-typed: `List<string> names = new();`
- Exposing collections: public APIs usually return `IReadOnlyList<T>` or `IEnumerable<T>` instead of `List<T>`.

## Gotchas

- Changing a list inside `foreach` over it throws `InvalidOperationException`.
- `list[i]` out of range throws `ArgumentOutOfRangeException`.
- `Sort()` sorts in place and returns `void`. For a sorted copy use LINQ `OrderBy` (Ep08).

Run it: `dotnet run -- 01`
