# 03. FirstOrDefault, First, Single (vs JS find)

**In one line:** `FirstOrDefault(pred)` is JS `find(pred)`, returning `null` (or `0` for numbers) instead of `undefined`.

| Method | No match | Several matches | Use when |
|---|---|---|---|
| `First(pred)` | throws | returns the first | a match must exist |
| `FirstOrDefault(pred)` | `default` (`null`, `0`) | returns the first | "find, maybe" (most common) |
| `Single(pred)` | throws | **throws** | exactly one must exist (lookup by id) |
| `SingleOrDefault(pred)` | `default` | **throws** | zero or one expected |
| `Last` / `LastOrDefault` | | | from the end |

```csharp
var user = users.FirstOrDefault(u => u.Email == email);
if (user is null) return NotFound();

int firstBig = nums.FirstOrDefault(n => n > 10, -1);  // custom default (.NET 6+)
```

## JS vs C#

| JS | C# |
|---|---|
| `arr.find(fn)` | `arr.FirstOrDefault(fn)` |
| `arr.findIndex(fn)` | `list.FindIndex(fn)` (List only) |
| `arr.findLast(fn)` | `arr.LastOrDefault(fn)` |
| `arr[0]` | `arr.First()` or `arr[0]` |

## Gotchas

- For `int`, `FirstOrDefault` returns `0` when nothing matches, which may be a valid value. Use the overload with a default or `Any` first.
- `First()` exceptions ("Sequence contains no matching element") are a common production bug. Prefer `FirstOrDefault` + null check unless absence is truly impossible.

Run it: `dotnet run -- 03`
