# 02. Structs vs classes

**In one line:** use a `class` by default; use a `struct` for small, immutable values like a coordinate or money amount.

```csharp
public readonly struct Point            // value type
{
    public int X { get; }
    public int Y { get; }
    public Point(int x, int y) { X = x; Y = y; }
}

public class Customer                   // reference type
{
    public string Name { get; set; } = "";
}
```

| | `struct` | `class` |
|---|---|---|
| Copy semantics | copied | shared reference |
| Inheritance | no (can implement interfaces) | yes |
| Null | no | yes |
| Typical size | small (a few fields) | anything |
| Examples in .NET | `int`, `DateTime`, `TimeSpan`, `Guid`, `KeyValuePair` | `string`, `List<T>`, `HttpClient`, your services |

## JS / C++ comparison

- JS has no structs. Every object is a reference.
- C++ `struct` and `class` differ only in default access. In C# they differ in **copy semantics**. Do not carry the C++ habit over.

## Key points

- Mark structs `readonly` so they cannot be mutated after creation.
- `record struct` (Ep06) gives you value equality and a nice `ToString` for free.

## Gotchas

- Mutable structs surprise people: `list[0].X = 5` does not compile, because `list[0]` returns a **copy**.

Run it: `dotnet run -- 02`
