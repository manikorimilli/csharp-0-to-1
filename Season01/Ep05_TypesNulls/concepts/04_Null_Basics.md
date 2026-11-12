# 04. null in C# vs JS null/undefined

**In one line:** C# has `null` and no `undefined`. Things that are `undefined` in JS are compile errors or exceptions in C#.

| JS situation | JS result | C# result |
|---|---|---|
| Read an unassigned variable | `undefined` | compile error |
| Read a missing property | `undefined` | compile error |
| Missing map key `m.get("x")` | `undefined` | `KeyNotFoundException` (use `TryGetValue`) |
| Missing array index | `undefined` | `IndexOutOfRangeException` |
| Call a method on null | `TypeError` | `NullReferenceException` |
| Unset class field | `undefined` | its default: `0`, `false`, `null` |

## Checking for null

```csharp
if (customer is null) return;          // modern, preferred
if (customer is not null) { ... }
if (customer != null) { ... }          // also fine, very common
if (customer is { Name: var n }) { }   // not null AND extract a property
```

## Key points

- Only reference types and `T?` value types can hold `null`.
- `NullReferenceException` ("NRE") is the C# equivalent of "Cannot read properties of null". The nullable features in the next lessons exist to prevent it at compile time.

Run it: `dotnet run -- 04`
