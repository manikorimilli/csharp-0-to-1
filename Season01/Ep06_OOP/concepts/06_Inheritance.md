# 06. Inheritance: base, virtual/override, abstract, sealed

**In one line:** `class Dog : Animal` is JS `class Dog extends Animal`, but methods must opt in to being overridden.

## JS vs C#

| JS | C# |
|---|---|
| `class Dog extends Animal` | `class Dog : Animal` |
| `super(name)` | `: base(name)` after the constructor signature |
| `super.describe()` | `base.Describe()` |
| every method is overridable | only `virtual` / `abstract` methods, overridden with `override` |
| (none) | `abstract class`: cannot be instantiated |
| (none) | `sealed class`: cannot be inherited |

```csharp
public abstract class Animal
{
    protected Animal(string name) => Name = name;
    public string Name { get; }
    public abstract string Sound();                          // no body, must override
    public virtual string Describe() => $"{Name} says {Sound()}";
}

public class Dog : Animal
{
    public Dog(string name) : base(name) { }
    public override string Sound() => "Woof";
    public override string Describe() => base.Describe() + "!";
}
```

## Key points

- Single class inheritance only; implement many interfaces instead (next lesson).
- `override` is required. Without it you get `new` (hiding) behavior and warning CS0114.
- Common overrides: `ToString()`, `Equals()`, `GetHashCode()`.

## Gotchas

- Java devs: C# methods are **not virtual by default**. A non-virtual method called through a base reference always runs the base version.
- Prefer composition and interfaces over deep hierarchies. Real code bases rarely go more than 2 levels deep.

Run it: `dotnet run -- 06`
