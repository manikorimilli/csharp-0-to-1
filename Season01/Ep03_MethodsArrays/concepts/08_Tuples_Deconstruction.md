# 08. Tuples and deconstruction

**In one line:** lightweight groups of values with optional names; deconstruct them like JS destructuring.

## JS vs C#

| JS | C# |
|---|---|
| `return { min, max };` | `return (min, max);` with return type `(int Min, int Max)` |
| `const { min, max } = f();` | `var (min, max) = F();` |
| `const [, second] = arr;` | `var (_, second) = F();` |
| `[a, b] = [b, a];` | `(a, b) = (b, a);` |

```csharp
static (int Min, int Max) MinMax(int[] values) { ...; return (min, max); }

var r = MinMax(data);
Console.WriteLine(r.Min);          // by name
var (lo, hi) = MinMax(data);       // deconstruct
var point = (X: 1, Y: 2);          // tuple literal with names
```

## Key points

- Tuples are value types (`ValueTuple`) and compare with `==` by value.
- Records and many framework types also support deconstruction: `foreach (var (key, value) in dict)`.

## Gotchas

- Tuple names are compile-time only. Do not use tuples for public API data that gets serialized: names become `Item1`, `Item2`. Use a `record` (Ep06).
- Deconstruction is positional, not by name (JS object destructuring is by name).

Run it: `dotnet run -- 08`
