# 02. switch statement

**In one line:** like JS/Java switch, but no accidental fall-through, and it works on strings and patterns.

## JS vs C#

```js
switch (day) {
  case "Sat":
  case "Sun": console.log("weekend"); break;
  default: console.log("weekday");
}
```
```csharp
switch (day)
{
    case "Sat":
    case "Sun":
        Console.WriteLine("weekend");
        break;
    case "Mon" or "Tue":                 // pattern combinators (C# 9)
        Console.WriteLine("start of week");
        break;
    case var d when d.StartsWith('W'):   // guard with `when`
        Console.WriteLine("W-day");
        break;
    default:
        Console.WriteLine("weekday");
        break;
}
```

## Key points

- Every non-empty case section must end in `break`, `return`, `throw`, `continue` or `goto case`.
- Empty cases can be stacked to share a body.
- Matches strings by value; `default` can go anywhere.

## Gotchas

- Forgetting `break` is a **compile error** (CS0163), not a silent fall-through.
- In modern code you will often see a switch **expression** instead (next lesson) when the goal is to produce a value.

Run it: `dotnet run -- 02`
