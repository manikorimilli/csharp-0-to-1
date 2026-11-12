# 01. Classes and constructors

**In one line:** like JS classes, but fields are declared with types, the constructor has the class name, and overloads are allowed.

## JS vs C#

```js
class Product {
  #price;
  constructor(name, price) { this.name = name; this.#price = price; }
  describe() { return `${this.name}: ${this.#price}`; }
}
```
```csharp
public class Product
{
    private readonly string _name;
    private decimal _price;

    public Product(string name, decimal price)
    {
        _name = name;
        _price = price;
    }

    public Product(string name) : this(name, 0m) { }   // chain to another constructor

    public string Describe() => $"{_name}: {_price}";
}
```

## Primary constructors (C# 12)

```csharp
public class OrderService(IOrderRepository repo, ILogger<OrderService> logger)
{
    public Order? Get(int id) => repo.Find(id);   // parameters usable everywhere in the class
}
```

You will see this style a lot in new service classes.

## Key points

- `this.` is optional. Private fields are usually named `_camelCase` to avoid clashes.
- `readonly` fields can only be assigned in the declaration or constructor.
- No constructor written? The compiler adds a public parameterless one.
- `new` is required, as in JS. `Product p = new("Pen", 1m);` is target-typed `new`.

## Gotchas

- Methods are not on a prototype you can patch at runtime. The shape of a class is fixed at compile time.
- `Console.WriteLine(obj)` prints the type name. Override `ToString()` or use a record.

Run it: `dotnet run -- 01`
