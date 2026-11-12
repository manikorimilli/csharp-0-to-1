# 01. if / else and ternary

**In one line:** same syntax as JS, but conditions must be real `bool`s.

## JS vs C#

```js
if (items.length) { ... }          // truthy
const label = n > 0 ? "pos" : "neg";
```
```csharp
if (items.Length > 0) { ... }      // must be bool
var label = n > 0 ? "pos" : "neg";
```

## Key points

- No truthy/falsy: `if (count)`, `if (name)`, `if (obj)` do not compile. Write `count > 0`, `!string.IsNullOrEmpty(name)`, `obj != null`.
- Both ternary branches must have compatible types: `flag ? 1 : "one"` is an error.
- Braces are optional for a single statement; most teams require them.

## Gotchas

- `if (x = 5)` is a compile error in C# (good!), not an assignment bug like in C++/JS.

Run it: `dotnet run -- 01`
