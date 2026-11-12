# 05. Lambdas (vs JS arrow functions)

**In one line:** same `=>` syntax as JS arrow functions; the target type (`Func`, `Action`, or a parameter type) decides the parameter types.

| JS | C# |
|---|---|
| `x => x * 2` | `x => x * 2` |
| `(a, b) => a + b` | `(a, b) => a + b` |
| `() => 42` | `() => 42` |
| `x => { const y = x * 2; return y; }` | `x => { var y = x * 2; return y; }` |
| `(x: number) => x` (TS) | `(int x) => x` |
| `async () => await f()` | `async () => await F()` |

```csharp
var names = people.Where(p => p.Age > 18).Select(p => p.Name);   // LINQ, Ep08
button.Click += (sender, e) => Console.WriteLine("clicked");     // event handler
app.MapGet("/hello", () => "Hello");                              // minimal API endpoint
```

## Key points

- Closures capture variables by reference, like JS.
- `_` discards unused parameters: `(_, e) => ...`.
- `static x => ...` forbids captures (small perf/clarity win).
- `=>` also defines expression-bodied **members** (`int Square(int x) => x * x;`), which are not lambdas.

## Gotchas

- `var f = x => x;` does not compile: the compiler cannot infer the type of `x`. Write `Func<int, int> f = x => x;` or `var f = (int x) => x;`.
- A `for` loop variable captured in a lambda is shared across iterations (same old JS `var` trap). `foreach` variables are fresh per iteration.

Run it: `dotnet run -- 05`
