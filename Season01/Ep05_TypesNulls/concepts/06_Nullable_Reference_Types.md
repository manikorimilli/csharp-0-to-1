# 06. Nullable reference types (string?)

**In one line:** with `<Nullable>enable</Nullable>`, `string` means "never null" and `string?` means "may be null". The compiler warns you, like TypeScript's `strictNullChecks`.

```csharp
public class User
{
    public string Email { get; set; } = "";   // must be initialized
    public string? Nickname { get; set; }     // optional
}

string Shout(User u)
{
    // u.Nickname.ToUpper();                  // warning CS8602: possible null dereference
    return u.Nickname?.ToUpper() ?? u.Email;  // fine
}
```

## TypeScript comparison

| TypeScript | C# |
|---|---|
| `let s: string` | `string s` |
| `let s: string \| null` | `string? s` |
| `s!.length` | `s!.Length` |
| type narrowing after `if (s)` | flow analysis after `if (s is not null)` |

## Key points

- It is a **compile-time** feature only. At runtime `string` and `string?` are the same type, so a `null` can still sneak in from JSON or old code.
- The warnings you will see most: CS8600 (assigning null to non-null), CS8602 (dereferencing a maybe-null), CS8618 (non-nullable property not initialized in the constructor).
- Fix CS8618 with an initializer (`= "";`), a constructor, or the `required` modifier (Ep06).

## Gotchas

- Older code bases may have nullable **disabled**. Then `string` can be null and you get no warnings. Check `<Nullable>` in the `.csproj` (or `#nullable enable` at the top of a file).
- Treat these warnings as errors in new code; many teams set `<TreatWarningsAsErrors>true</TreatWarningsAsErrors>`.

Run it: `dotnet run -- 06`
