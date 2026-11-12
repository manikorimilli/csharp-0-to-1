# 03. Generics and constraints

**In one line:** like TypeScript generics, but they exist at runtime, and `where` constraints say what `T` must support.

```csharp
static T FirstOr<T>(List<T> items, T fallback) => items.Count > 0 ? items[0] : fallback;

static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;

public class Repository<T> where T : class, IEntity
{
    private readonly Dictionary<int, T> _items = new();
    public T? Find(int id) => _items.GetValueOrDefault(id);
}
```

## Constraints

| Constraint | Meaning |
|---|---|
| `where T : class` | reference type |
| `where T : struct` | value type |
| `where T : new()` | has a parameterless constructor |
| `where T : SomeBase` | derives from a class |
| `where T : IComparable<T>` | implements an interface |
| `where T : notnull` | not nullable |

## TypeScript / Java comparison

- TS: `function first<T>(items: T[]): T` (erased at runtime). C#: real types, `typeof(T)` works.
- Java: type erasure and no `List<int>`. C#: `List<int>` stores real ints, no boxing.
- C++ templates: similar use, but C# checks the generic code once, against the constraints.

## Key points

- Type arguments are usually inferred: `Max(3, 7)` not `Max<int>(3, 7)`.
- Naming: `T`, or descriptive `TKey`, `TValue`, `TEntity`, `TResult`.

## Gotchas

- Without a constraint you can only use `object` members on `T`. "Operator '<' cannot be applied" means you need a constraint (or `IComparable<T>`).

Run it: `dotnet run -- 03`
