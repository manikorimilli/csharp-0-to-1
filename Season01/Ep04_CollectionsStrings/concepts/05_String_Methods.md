# 05. Common string methods

**In one line:** nearly every JS string method exists, in PascalCase, with a few traps.

| JS | C# | Note |
|---|---|---|
| `s.length` | `s.Length` | |
| `s.trim()` | `s.Trim()` | also `TrimStart`, `TrimEnd` |
| `s.toUpperCase()` | `s.ToUpper()` | |
| `s.includes(x)` | `s.Contains(x)` | |
| `s.startsWith(x)` | `s.StartsWith(x)` | |
| `s.indexOf(x)` | `s.IndexOf(x)` | |
| `s.replaceAll(a, b)` | `s.Replace(a, b)` | C# `Replace` replaces **all** |
| `s.slice(a, b)` | `s[a..b]` | range |
| `s.substring(a, b)` | `s.Substring(a, length)` | **2nd arg is a length** |
| `s.split(",")` | `s.Split(',')` | options: `TrimEntries`, `RemoveEmptyEntries` |
| `arr.join(",")` | `string.Join(",", arr)` | static method |
| `s.padStart(5, "0")` | `s.PadLeft(5, '0')` | |
| `"=".repeat(3)` | `new string('=', 3)` | |
| `!s` (empty check) | `string.IsNullOrEmpty(s)` | also `IsNullOrWhiteSpace` |
| `a.localeCompare(b)` | `string.Compare(a, b, StringComparison.Ordinal)` | |
| `/regex/.test(s)` | `Regex.IsMatch(s, "pattern")` | `System.Text.RegularExpressions` |

## Case-insensitive comparison

```csharp
string.Equals(a, b, StringComparison.OrdinalIgnoreCase)
s.Contains("abc", StringComparison.OrdinalIgnoreCase)
```

## Key points

- `char` helpers: `char.IsDigit`, `char.IsLetter`, `char.IsWhiteSpace`, `char.ToUpper`.
- Strings compare by value with `==`.

## Gotchas

- `Substring(start, length)`, not `(start, end)`.
- `s.ToUpper();` alone does nothing useful; strings are immutable (next lesson).

Run it: `dotnet run -- 05`
