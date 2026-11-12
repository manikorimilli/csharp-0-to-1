# 04. Overloading

**In one line:** several methods can share a name if their parameter lists differ, like C++ and Java.

```csharp
static string Describe(int n) => $"int {n}";
static string Describe(string s) => $"string {s}";
static string Describe(int a, int b) => $"{a},{b}";
```

## JS comparison

JS has one function per name; you branch on `typeof` or `arguments.length` inside it. In C# the compiler picks the overload at compile time from the argument types.

## Key points

- Overloads differ by number or types of parameters (or `ref`/`out`). The return type alone is not enough.
- Optional parameters (next lesson) often replace a pile of overloads.

## Gotchas

- Ambiguous calls are compile errors, e.g. `M(null)` when `M(string)` and `M(int[])` both exist. Cast to pick one: `M((string?)null)`.

Run it: `dotnet run -- 04`
