# 03. Methods

**In one line:** functions always live inside a type and declare their parameter and return types.

## JS vs C#

```js
function add(a, b) { return a + b; }
const square = x => x * x;
```
```csharp
static int Add(int a, int b) { return a + b; }
static int Square(int x) => x * x;          // expression-bodied member
static void Log(string msg) => Console.WriteLine(msg);  // void = no return value
```

## Key points

- Naming: **PascalCase** for methods (`GetUser`), camelCase for parameters and locals.
- `static` methods belong to the type (`Math.Max`); instance methods need an object (Ep06).
- Local functions can be declared inside a method (like nested JS functions). Mark them `static` to forbid capturing outer variables.
- All code paths must return a value, or it is a compile error (CS0161).

## Gotchas

- There are no free functions outside a type (except in the top-level `Program.cs`, where the compiler hides the class for you).
- Default parameter passing is **by value**: a method cannot change the caller's `int` without `ref` (lesson 06). For objects the *reference* is copied, so the method can modify the object.

Run it: `dotnet run -- 03`
