# 03. Switch expressions

**In one line:** a switch that **returns a value**, written with `=>` arms. Very common in modern C#.

## Syntax

```csharp
string label = status switch
{
    200 => "OK",
    404 => "Not found",
    >= 500 => "Server error",   // relational pattern
    _ => "Other"                // discard = default
};
```

Match several values at once with a tuple:

```csharp
decimal fee = (country, total) switch
{
    ("US", >= 50m) => 0m,
    ("US", _)      => 5m,
    _              => 20m
};
```

## JS comparison

JS has no expression switch. The closest is an object lookup or a chain of ternaries:

```js
const label = { 200: "OK", 404: "Not found" }[status] ?? "Other";
```

## Key points

- Arms are checked top to bottom; first match wins.
- The compiler warns if the arms are not exhaustive (CS8509). Add `_ =>`.
- Combine with expression-bodied methods: `static string Name(int x) => x switch { ... };`

## Gotchas

- No `case`, no `break`, arms are separated by **commas**, and the whole thing ends with `;`.
- A missing match at runtime throws `SwitchExpressionException`.

Run it: `dotnet run -- 03`
