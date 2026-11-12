# 07. break and continue

**In one line:** same as JS, except there are no labels to break out of nested loops.

```csharp
foreach (var n in numbers)
{
    if (n < 0) continue;   // skip this one
    if (n > 100) break;    // stop looping
    Console.WriteLine(n);
}
```

## Leaving nested loops

JS has `outer: for (...) { ... break outer; }`. C# does not. Idiomatic options:

1. Move the loops into a method and `return` (cleanest).
2. Use a `bool found` flag checked by the outer loop.
3. `goto` exists but is rarely accepted in code reviews.

## Gotchas

- Inside a `switch` inside a loop, `break` exits the **switch**, not the loop. Use `continue`, `return`, or a flag.

Run it: `dotnet run -- 07`
