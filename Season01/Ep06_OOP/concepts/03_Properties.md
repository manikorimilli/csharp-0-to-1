# 03. Properties: get / set / init, auto and computed

**In one line:** properties look like fields to the caller but are getter/setter methods, like JS `get`/`set`. In C# they are the default way to expose data.

## JS vs C#

```js
class Employee {
  #salary = 0;
  get salary() { return this.#salary; }
  set salary(v) { if (v < 0) throw new Error(); this.#salary = v; }
  get annual() { return this.#salary * 12; }
}
```
```csharp
public class Employee
{
    public string Name { get; set; } = "";             // auto-property
    public int Id { get; private set; }                // public read, private write
    public string Dept { get; init; } = "General";     // set only in initializer
    public required string Email { get; init; }        // caller must set it

    private decimal _salary;
    public decimal Salary                              // full property
    {
        get => _salary;
        set => _salary = value >= 0 ? value : throw new ArgumentOutOfRangeException(nameof(value));
    }

    public decimal Annual => Salary * 12;              // computed, read-only
}
```

## Key points

- Public fields are rare in C#. Expose properties, keep fields private.
- `init` + `required` is the modern way to make "immutable after creation" objects.
- Properties are PascalCase. Serializers (JSON) use properties, not fields.

## Gotchas

- `public string Name { get; set; }` without `= ""` gives warning CS8618 with nullable enabled.
- `=> expr` (computed every read) is different from `{ get; } = expr` (computed once at construction).

Run it: `dotnet run -- 03`
