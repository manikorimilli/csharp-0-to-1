# 08. Advanced pattern matching

**In one line:** switch expressions can match on type, shape, nested properties and list contents. Modern C# code uses this heavily.

## Pattern cheat sheet

| Pattern | Example |
|---|---|
| Type | `Circle c => ...` |
| Positional (records/tuples) | `Circle(var r) => ...` |
| Property | `{ Status: "Paid", Total: > 100 } => ...` |
| Extended property (C# 10) | `{ Customer.IsVip: true } => ...` |
| Relational / logical | `> 0 and < 10`, `not null`, `"a" or "b"` |
| `var` capture | `{ Width: var w } => w * 2` |
| List (C# 11) | `[]`, `[var only]`, `["add", var item]`, `[var first, .., var last]` |
| Discard | `_ => ...` |
| Guard | `Rectangle r when r.Width == r.Height => ...` |

```csharp
static decimal Shipping(Order o) => o switch
{
    { Status: "Cancelled" } => 0m,
    { Customer.IsVip: true } => 0m,
    { Customer.Country: "US", Total: >= 50m } => 0m,
    _ => 25m
};
```

## JS comparison

JS has no pattern matching (there is a TC39 proposal). Equivalent JS is an `if` chain with destructuring and optional chaining.

## Key points

- Arms are evaluated top to bottom; put specific cases first. The compiler reports arms that can never match (CS8510).
- Patterns never throw on `null`: `{ Customer.IsVip: true }` simply does not match if `Customer` is null.

## Gotchas

- Non-exhaustive switch expressions compile with warning CS8509 and throw `SwitchExpressionException` at runtime when nothing matches.

Run it: `dotnet run -- 08`
