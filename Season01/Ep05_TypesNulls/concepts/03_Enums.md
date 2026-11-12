# 03. Enums

**In one line:** named integer constants with type safety. Think TypeScript `enum`, which plain JS lacks.

```csharp
public enum OrderStatus { Pending, Paid, Shipped, Cancelled = 99 }

var s = OrderStatus.Paid;
Console.WriteLine(s);              // "Paid"
int n = (int)s;                    // 1
var t = (OrderStatus)2;            // Shipped
Enum.TryParse<OrderStatus>("paid", ignoreCase: true, out var parsed);
foreach (var v in Enum.GetValues<OrderStatus>()) { }
```

## JS comparison

```js
const OrderStatus = Object.freeze({ Pending: "Pending", Paid: "Paid" });
```

## Flags

```csharp
[Flags]
public enum Permission { None = 0, Read = 1, Write = 2, Delete = 4 }

var p = Permission.Read | Permission.Write;
p.HasFlag(Permission.Write);   // true
```

## Key points

- Enum names are PascalCase and **singular** (`OrderStatus`), except `[Flags]` enums which are often plural.
- Switch expressions over enums are idiomatic.
- `ToString()` gives the name; ASP.NET can be configured to serialize enums as strings in JSON.

## Gotchas

- Any int can be cast to an enum, even undefined ones: `(OrderStatus)42` is legal. Validate with `Enum.IsDefined`.
- The default value is `0`, so make the first member a sensible default (`None`, `Unknown`, `Pending`).

Run it: `dotnet run -- 03`
