# 08. Records

**In one line:** `record Person(string Name, int Age);` is a one-line immutable data class with value equality, nice `ToString`, and `with` copies.

```csharp
public record Person(string Name, int Age);

var a = new Person("Ann", 30);
var b = new Person("Ann", 30);
a == b;                          // true  (a normal class would be false)
a.ToString();                    // Person { Name = Ann, Age = 30 }
var older = a with { Age = 31 }; // copy with changes
var (name, age) = a;             // deconstruction
```

## JS comparison

| JS | C# record |
|---|---|
| `{ name: "Ann", age: 30 }` | `new Person("Ann", 30)` |
| `{ ...a, age: 31 }` | `a with { Age = 31 }` |
| deep-equal helper | `a == b` built in |
| `Object.freeze` | properties are `init`-only |

## Variants

```csharp
public record Product(string Sku, decimal Price) { public bool Pricey => Price > 100; }
public record class Order { public required int Id { get; init; } }   // property style
public readonly record struct Point(int X, int Y);                     // value type
```

## When to use

- Records: DTOs, API request/response models, messages, value objects, configuration.
- Classes: entities with identity and changing state, services.

## Gotchas

- Equality is shallow: two records holding different `List<T>` instances with the same items are **not** equal.
- `with` makes a shallow copy.

Run it: `dotnet run -- 08`
