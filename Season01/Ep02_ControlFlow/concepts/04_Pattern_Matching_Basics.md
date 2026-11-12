# 04. Basic pattern matching

**In one line:** `is` checks a value against a shape and can bind a typed variable in the same step.

## The patterns you will see most

| Pattern | Example | Meaning |
|---|---|---|
| Type | `obj is string s` | is it a string? if so, call it `s` |
| Constant | `x is 0`, `x is null` | equals this constant |
| Not | `x is not null` | idiomatic null check |
| Relational | `x is > 0` | comparison |
| and / or | `age is >= 13 and <= 19` | combine patterns |
| Property | `s is { Length: 0 }` | check properties |

## JS vs C#

```js
if (typeof value === "string") { console.log(value.length); }
if (obj instanceof Dog) { obj.bark(); }
```
```csharp
if (value is string s) Console.WriteLine(s.Length);
if (animal is Dog d) d.Bark();
```

Java 16+ has the same `instanceof Dog d` idea.

## Key points

- The bound variable (`s`, `d`) is only definitely assigned where the pattern is known to match.
- `is not null` / `is null` are preferred over `!= null` in modern code (they cannot be fooled by operator overloads).

## Gotchas

- `c is 'a' or 'e'` works; `c == 'a' || 'e'` does not compile (no truthy chars).
- More advanced patterns (positional, list patterns) are in Ep07.

Run it: `dotnet run -- 04`
