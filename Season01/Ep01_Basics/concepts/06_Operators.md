# 06. Operators

**In one line:** mostly the same symbols as JS/Java/C++, but `==` is type-safe and integer division truncates.

## Differences that matter

| Topic | JS | C# |
|---|---|---|
| Equality | `===` (strict), `==` (coercing) | only `==`, and it never coerces |
| `1 == "1"` | `true` with `==` | **compile error** |
| String equality | value | value (`==` works; Java needs `.equals`) |
| `7 / 2` | `3.5` | `3` (int / int) |
| Power | `2 ** 10` | `Math.Pow(2, 10)` |
| Truthy | `if (count)` | `if (count > 0)`; conditions must be `bool` |
| Overflow | becomes float | wraps silently (use `checked` to throw) |

## Same as you know

`+ - * / %`, `++ --`, `+= -= *= /=`, `&& || !`, `< > <= >=`, `?:`, bitwise `& | ^ ~ << >>`.

## C#-specific ones you will meet (covered later)

- `??` and `??=` null coalescing (Ep05)
- `?.` null-conditional (Ep05)
- `is` type/pattern test (Ep02, Ep07)
- `=>` lambda and expression body (Ep03, Ep07)

## Gotchas

- `"Total: " + 3 + 4` is `"Total: 34"`, same left-to-right rule as JS.
- `==` on two class instances compares **references** unless the type overrides it (strings and records do).

Run it: `dotnet run -- 06`
