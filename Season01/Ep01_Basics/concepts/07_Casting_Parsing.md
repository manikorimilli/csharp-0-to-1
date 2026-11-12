# 07. Casting, Parse and TryParse

**In one line:** widening is implicit, narrowing needs `(type)`, and text becomes numbers with `int.TryParse`.

## JS vs C#

| JS | C# |
|---|---|
| `parseInt("12")` | `int.Parse("12")` (throws on bad input) |
| `Number.isNaN(parseInt(s))` check | `if (int.TryParse(s, out int n)) { ... }` |
| `Math.trunc(9.9)` | `(int)9.9` |
| `String(42)` / `` `${42}` `` | `42.ToString()` |
| `Number("3.5")` | `double.Parse("3.5", CultureInfo.InvariantCulture)` |

## Casting

```csharp
int i = 42;
long l = i;          // implicit: safe widening
double d = i;        // implicit
int back = (int)9.99; // explicit: truncates to 9
```

## Parsing

```csharp
int a = int.Parse("123");          // throws FormatException if not a number

if (int.TryParse(input, out int age))  // `out` returns a 2nd value (Ep03)
    Console.WriteLine(age + 1);
else
    Console.WriteLine("Invalid");
```

`Convert.ToInt32(x)` also exists. It accepts `null` (returns 0) and **rounds** doubles (`Convert.ToInt32(3.7)` is 4), while a cast truncates.

## Gotchas

- `Math.Round(2.5)` is `2` (banker's rounding). Use `MidpointRounding.AwayFromZero` for school rounding.
- Prefer `TryParse` for user input; `Parse` for data you trust (and want to fail loudly).
- `(int)"42"` does not compile. Strings are never cast to numbers.

Run it: `dotnet run -- 07`
