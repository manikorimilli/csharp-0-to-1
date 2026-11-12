# 02. Top-level statements vs Main

**In one line:** modern C# lets `Program.cs` be a plain script; older code wraps everything in `static void Main`.

## Modern (C# 9+, what `dotnet new console` gives you)

```csharp
// Program.cs
Console.WriteLine($"Hello, {args.Length} args");
return 0; // optional exit code
```

## Classic (you will still see this everywhere, same as Java)

```csharp
namespace MyApp;

internal class Program
{
    static void Main(string[] args)    // or: static async Task<int> Main(...)
    {
        Console.WriteLine("Hello");
    }
}
```

## JS comparison

In Node the file itself is the program, top to bottom. Top-level statements give you the same feel. The compiler generates the `Program` class and `Main` method behind the scenes.

## Key points

- Only **one file** per project can contain top-level statements.
- `args` (a `string[]`) is available implicitly.
- `await` works at the top level too (the generated Main becomes async).
- Methods declared at the top level are local functions; classes must come **after** the statements.

## Gotchas

- Mixing a top-level `Program.cs` and a class with `static void Main` gives warning CS7022 and the `Main` is ignored.

Run it: `dotnet run -- 02`
