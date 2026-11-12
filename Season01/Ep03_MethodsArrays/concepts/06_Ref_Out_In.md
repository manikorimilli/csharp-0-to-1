# 06. ref, out, in

**In one line:** pass a variable by reference. `ref` = C++ `int&`, `out` = "this method fills it", `in` = C++ `const T&`.

```csharp
static void Increment(ref int x) => x++;
static bool TryParsePoint(string s, out int x, out int y) { ... }
static double Len(in Vector3 v) => ...;

int n = 1;
Increment(ref n);                 // keyword required at the call site
if (int.TryParse("42", out int value)) { ... }
TryParsePoint("1,2", out _, out var y);   // discard with _
```

| | Must be assigned before call | Method must assign | Method can modify |
|---|---|---|---|
| `ref` | yes | no | yes |
| `out` | no | **yes** | yes |
| `in` | yes | no | no |

## JS comparison

JS has none of this. You return an object or array instead: `const { ok, value } = tryParse(s)`.

## What you will actually see

- `out` in the **Try pattern**: `int.TryParse`, `dictionary.TryGetValue(key, out var v)`.
- `ref` and `in` rarely in application code (mostly performance code).
- For new code returning two values, a **tuple** (lesson 08) is usually clearer than `out`.

## Gotchas

- `out` and `ref` parameters cannot be used in `async` methods.

Run it: `dotnet run -- 06`
