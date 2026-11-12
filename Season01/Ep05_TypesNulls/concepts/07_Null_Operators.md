# 07. Null operators: ?. ?? ??= !

**In one line:** the first three work exactly like their JS versions; `!` is TypeScript's non-null assertion.

| Operator | C# | JS / TS |
|---|---|---|
| Null-conditional member | `user?.Address?.City` | `user?.address?.city` |
| Null-conditional index | `list?[0]` | `list?.[0]` |
| Null-conditional call | `handler?.Invoke()` | `handler?.()` |
| Coalesce | `name ?? "Anon"` | `name ?? "Anon"` |
| Coalesce assign | `cache ??= new()` | `cache ??= {}` |
| Throw if null | `x ?? throw new ArgumentNullException(nameof(x))` | (none) |
| Null-forgiving | `user!.Name` | `user!.name` (TS) |

## Key points

- `a?.B` where `B` is an `int` gives an `int?`. Add `?? 0` to get back to `int`.
- `?? throw` is a common guard in constructors.
- `!` does nothing at runtime. It only silences the warning. If you are wrong you still get a `NullReferenceException`.

## Gotchas

- `??` in C# only checks `null`, same as JS. `""` and `0` are not null, so `"" ?? "x"` is `""`.
- Before C# 14 you cannot assign through `?.`: `a?.B = 1` is a compile error in .NET 8.

Run it: `dotnet run -- 07`
