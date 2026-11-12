# 01. Arrays

**In one line:** C# arrays are fixed-size and single-typed, like C++/Java arrays. For a growable JS-style array use `List<T>` (Ep04).

## JS vs C#

| JS | C# |
|---|---|
| `const a = [1, 2, 3]` | `int[] a = { 1, 2, 3 };` or `int[] a = [1, 2, 3];` (C# 12) |
| `new Array(3)` | `new int[3]` (filled with `0`) |
| `a.length` | `a.Length` |
| `a.at(-1)` | `a[^1]` |
| `a.slice(1, 3)` | `a[1..3]` |
| `a.push(4)` | not possible, use `List<T>` |
| `a.sort()` | `Array.Sort(a)` (in place, numeric sort for ints) |
| `a.indexOf(x)` | `Array.IndexOf(a, x)` |
| `a.includes(x)` | `a.Contains(x)` (LINQ) |
| `console.log(a)` | `Console.WriteLine(string.Join(", ", a))` |

## Key points

- Elements start at their default (`0`, `false`, `null`).
- Arrays are **reference types**: passing one to a method lets the method change its elements.
- Out-of-range access throws `IndexOutOfRangeException` (JS returns `undefined`).

## Gotchas

- `Console.WriteLine(arr)` prints `System.Int32[]`.
- `a == b` compares references, not contents. Use `a.SequenceEqual(b)` (LINQ).

Run it: `dotnet run -- 01`
