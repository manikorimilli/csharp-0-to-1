# 05. Nullable value types (int?)

**In one line:** `int?` is "an int or nothing". Use it for optional numbers, dates and bools.

```csharp
int? age = null;
age.HasValue                  // false
age = 30;
age.Value                     // 30 (throws InvalidOperationException if null)
int years = age ?? 0;         // fallback
int same = age.GetValueOrDefault();
if (age is int a) { ... }     // unwrap with a pattern
```

## JS comparison

```js
let age = null;           // or undefined
const years = age ?? 0;
```

## Key points

- `int?` is shorthand for `Nullable<int>`.
- `int` converts to `int?` implicitly; `int?` to `int` needs `??`, `.Value`, or a cast.
- Arithmetic with `null` gives `null`: `(int?)5 + null` is `null`.
- Typical places: database columns that allow NULL, optional query parameters, `DateTime? DeletedAt`.

## Gotchas

- Comparisons with `null` are `false`: `(int?)null > 0` and `(int?)null <= 0` are both `false`.
- `bool?` in an `if` does not compile: write `if (flag == true)` or `if (flag ?? false)`.

Run it: `dotnet run -- 05`
