# 05. static

**In one line:** `static` members belong to the type, not an instance. Same as JS `static` and Java `static`.

```csharp
public class Counter
{
    public static int Created { get; private set; }   // shared by all instances
    public Counter() => Created++;
    public static Counter Create() => new();          // factory method
}

public static class MathHelpers                        // only static members, no `new`
{
    public const double Tau = 6.283185;
    public static double Clamp(double v, double lo, double hi) => Math.Max(lo, Math.Min(hi, v));
}

Counter.Created;                 // access through the type name
MathHelpers.Clamp(5, 0, 1);
```

## Key points

- `static class` = utility container. `Math`, `Console`, `File`, `Path` are static classes.
- Extension methods (Ep07) must live in a static class.
- `const` is implicitly static. `static readonly` is for values computed at runtime.
- `using static System.Math;` lets you write `Sqrt(2)` instead of `Math.Sqrt(2)`.

## Gotchas

- Static mutable state is shared by every request in a web app. Avoid it in services; use DI singletons instead (Ep10).

Run it: `dotnet run -- 05`
