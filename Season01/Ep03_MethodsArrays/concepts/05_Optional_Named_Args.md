# 05. Optional and named arguments

**In one line:** defaults like JS default params, plus named arguments so you rarely need an options object.

## JS vs C#

```js
function greet(name, greeting = "Hello", { shout = false } = {}) { ... }
greet("Ada", undefined, { shout: true });
```
```csharp
static string Greet(string name, string greeting = "Hello", bool shout = false) { ... }
Greet("Ada", shout: true);
```

## Key points

- Optional parameters come after required ones.
- Defaults must be compile-time constants (`"x"`, `0`, `null`, `default`). For "new list by default" use `List<int>? items = null` and `items ??= new();` in the body.
- Named arguments can appear in any order once you name them.
- Named arguments make `true`, `false` and magic numbers readable: `Save(path, overwrite: true)`.

## Gotchas

- Default values are baked into the **caller** at compile time. Changing a default in a shared library needs callers to recompile. (Matters for NuGet libraries, not your app.)

Run it: `dotnet run -- 05`
