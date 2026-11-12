# 02. Object initializers

**In one line:** `new Customer { Name = "Ann", Age = 30 }` sets properties right after construction. It looks like a JS object literal but is fully typed.

```csharp
var c = new Customer
{
    Name = "Ann",
    Address = new Address { City = "Oslo" },
    Tags = { "vip" }                      // adds to the existing list
};

var people = new List<Customer>
{
    new() { Name = "Bob" },
    new() { Name = "Cid" }
};

var dict = new Dictionary<string, int> { ["a"] = 1, ["b"] = 2 };
```

## JS comparison

```js
const c = { name: "Ann", address: { city: "Oslo" }, tags: ["vip"] };
```

In C# you need a class or record with those properties. For a quick throwaway shape use an **anonymous type**: `var p = new { X = 1, Y = 2 };` (read-only, only usable inside the method).

## Key points

- The constructor runs first, then the initializer assignments.
- Works with `set` and `init` properties, and is how you satisfy `required` properties.

## Gotchas

- Initializers are not JSON. No quotes around property names, `=` not `:`, and you cannot add properties that the type does not declare.

Run it: `dotnet run -- 02`
