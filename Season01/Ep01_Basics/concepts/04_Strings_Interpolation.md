# 04. String interpolation and raw strings

**In one line:** `$"Hi {name}"` is JS `` `Hi ${name}` ``, with formatting built in.

## JS vs C#

| JS | C# |
|---|---|
| `` `Hi ${name}` `` | `$"Hi {name}"` |
| `` `${price.toFixed(2)}` `` | `$"{price:F2}"` |
| `` `${name.padEnd(8)}` `` | `$"{name,-8}"` |
| multi-line template literal | raw string `"""..."""` |
| `String.raw\`C:\\temp\`` | verbatim `@"C:\temp"` |

## Format specifiers (after the colon)

```csharp
$"{3.14159:F2}"     // 3.14       fixed decimals
$"{1234567:N0}"     // 1,234,567  thousands separators
$"{0.256:P1}"       // 25.6 %     percent
$"{42:D5}"          // 00042      zero padded
$"{DateTime.Now:yyyy-MM-dd}"
$"{name,10}"        // right-align in 10 chars; {name,-10} left-aligns
```

## Raw string literals (C# 11)

```csharp
string json = """
    { "name": "Ada" }
    """;                       // indentation up to the closing """ is removed

string json2 = $$"""{"name": "{{name}}"}""";   // $$: interpolate with {{ }}
```

## Key points

- `{{` and `}}` produce literal braces in a normal `$""` string.
- `@"..."` verbatim strings: backslashes are literal, `""` is a quote.
- You can combine: `$@"C:\Users\{user}"`.

## Gotchas

- Number formatting follows the current culture (`1.234,50` in Germany). This repo sets `InvariantGlobalization` so output is the same everywhere. Real apps often pass `CultureInfo.InvariantCulture` explicitly.

Run it: `dotnet run -- 04`
