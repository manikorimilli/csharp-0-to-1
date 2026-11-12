# 03. Static types: int, double, decimal, bool, char, string, var, const

**In one line:** every variable has one type fixed at compile time. `var` only saves typing; it is not JS `let`.

## The types you use daily

| C# | Size | JS equivalent | Use for |
|---|---|---|---|
| `int` | 32-bit | `number` | counts, indexes, ids |
| `long` | 64-bit | `number` / `BigInt` | big ids, timestamps |
| `double` | 64-bit float | `number` | measurements, math |
| `decimal` | 128-bit base 10 | (none) | **money** |
| `bool` | | `boolean` | `true` / `false` only |
| `char` | 16-bit | 1-char string | single characters, `'A'` |
| `string` | | `string` | text, `"Ada"` |

Literals: `10`, `10L`, `1.5` (double), `1.5f` (float), `1.5m` (decimal), `1_000_000`.

## JS vs C#

```js
let count = 1;        // can later hold "one"
const NAME = "Ada";   // binding is constant
```
```csharp
var count = 1;            // inferred as int, stays int forever
int total = 0;            // explicit type
const string Name = "Ada"; // compile-time constant (literal values only)
readonly ...               // runtime constant for fields (Ep06)
```

## Key points

- `var` requires an initializer and is resolved at compile time. Use it when the type is obvious from the right side.
- `const` only works for primitives and strings with literal values. For "assigned once" fields use `readonly`.
- Type keywords are aliases: `int` = `System.Int32`, `string` = `System.String`. Prefer the keywords.
- Numeric types have helpers: `int.MaxValue`, `double.NaN`, `int.Parse(...)`.

## Gotchas

- `double` has the JS `0.1 + 0.2 != 0.3` problem. `decimal` does not. Use `decimal` for money.
- `decimal price = 9.99;` does not compile. Write `9.99m`.
- Unassigned locals are a compile error (no `undefined`).

Run it: `dotnet run -- 03`
