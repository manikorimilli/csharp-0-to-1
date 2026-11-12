# 06. StringBuilder and string immutability

**In one line:** strings never change (same as JS/Java); build big strings with `StringBuilder`.

```csharp
string name = "ada";
name.ToUpper();          // returns a new string, which is discarded
name = name.ToUpper();   // correct

var sb = new StringBuilder();       // using System.Text;
foreach (var line in lines)
    sb.AppendLine(line);
sb.Append("total: ").Append(total); // calls chain
string result = sb.ToString();
```

## When to use what

| Situation | Use |
|---|---|
| A few values | `$"..."` |
| A collection with a separator | `string.Join(", ", items)` |
| Many appends in a loop | `StringBuilder` |

## JS comparison

JS engines optimize `+=` in loops well, so JS devs rarely think about this. In C# `s += x` in a loop of thousands of iterations is a real performance smell, and reviewers will point it out.

## Gotchas

- `StringBuilder` is in `System.Text`, which is **not** in the implicit usings. Add `using System.Text;`.

Run it: `dotnet run -- 06`
