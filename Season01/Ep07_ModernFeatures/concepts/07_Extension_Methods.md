# 07. Extension methods

**In one line:** add methods to existing types (even `string` or interfaces) without changing them. Like patching `String.prototype`, but scoped and type-safe.

```csharp
namespace MyApp.Extensions;

public static class StringExtensions               // static, non-nested, non-generic class
{
    public static string Truncate(this string s, int max) =>   // `this` marks the extended type
        s.Length <= max ? s : s[..max] + "...";
}

// usage (with `using MyApp.Extensions;`)
"Hello world".Truncate(5);     // "Hello..."
```

## Why it matters for reading code

- **All of LINQ** is extension methods on `IEnumerable<T>`: `Where`, `Select`, `OrderBy`...
- ASP.NET startup code is extension methods: `builder.Services.AddControllers()`, `app.UseHttpsRedirection()`, `app.MapGet(...)`.
- Teams add their own: `services.AddInfrastructure()` registers a whole layer (Ep10).

## Key points

- Extension methods are just static methods with nicer call syntax: `s.Truncate(5)` compiles to `StringExtensions.Truncate(s, 5)`.
- They are only visible when their namespace is imported.
- An instance method with the same signature always wins.
- They cannot access private members of the extended type.

## Gotchas

- "X does not contain a definition for Y" when copying sample code often means a missing `using` for the extension namespace (or a missing NuGet package).

Run it: `dotnet run -- 07`
