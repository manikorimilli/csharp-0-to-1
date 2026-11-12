# 04. Access modifiers

**In one line:** four you will see daily: `public`, `private`, `protected`, `internal`.

| Modifier | Visible to | JS / Java equivalent |
|---|---|---|
| `public` | everyone | normal JS member, Java `public` |
| `private` | only this type | JS `#field`, Java `private` |
| `protected` | this type and subclasses | Java `protected` (without package access) |
| `internal` | anything in the same project (assembly) | Java package-private (roughly) |
| `protected internal`, `private protected` | combinations, rare | |

## Defaults

- Members of a class or struct: **private**.
- Top-level types (classes, interfaces): **internal**.
- Interface members: public.

## Key points

- Be explicit: most style guides want the modifier written out.
- `internal` matters in multi-project solutions (Ep10): types in `Core` that `Api` should not see.
- `private` is per type, not per instance: an `Account` method can read another `Account`'s private fields.

## Gotchas

- A public method cannot expose a less accessible type (CS0050/CS0051): returning an `internal` class from a `public` method of a `public` class is an error.

Run it: `dotnet run -- 04`
