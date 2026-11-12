# 07. Method syntax vs query syntax

**In one line:** two spellings of the same thing. Method syntax (`.Where(...)`) is the everyday style; query syntax (`from ... select`) reads like SQL and is nicer for joins.

```csharp
// Method syntax
var names = products.Where(p => p.Price > 100).OrderBy(p => p.Price).Select(p => p.Name);

// Query syntax (compiles to exactly the calls above)
var names2 = from p in products
             where p.Price > 100
             orderby p.Price
             select p.Name;
```

## Query keywords

| Query | Method |
|---|---|
| `from x in xs` | the source |
| `where cond` | `.Where(x => cond)` |
| `select expr` | `.Select(x => expr)` |
| `orderby a, b descending` | `.OrderBy(a).ThenByDescending(b)` |
| `join c in cs on o.CId equals c.Id` | `.Join(...)` |
| `group x by key into g` | `.GroupBy(...)` |
| `let y = expr` | introduces a variable (no clean method equivalent) |
| `from a in xs from b in a.Items` | `.SelectMany(...)` |

## Key points

- Some operators exist only as methods (`Count`, `First`, `ToList`, `Take`, `Distinct`). Wrap the query in parentheses: `(from ... select ...).ToList()`.
- Pick one style per query. Many teams use method syntax by default and query syntax for joins.

## Gotchas

- Query syntax ends with `select` or `group`. Forgetting it is a compile error.

Run it: `dotnet run -- 07`
