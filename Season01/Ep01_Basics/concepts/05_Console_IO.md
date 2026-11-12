# 05. Console input and output

**In one line:** `Console.WriteLine` is `console.log`; `Console.ReadLine` reads a line and may return `null`.

## JS vs C#

| JS (Node) | C# |
|---|---|
| `console.log(x)` | `Console.WriteLine(x)` |
| `process.stdout.write(x)` | `Console.Write(x)` |
| `console.error(x)` | `Console.Error.WriteLine(x)` |
| `readline` + callback/await | `string? line = Console.ReadLine();` (blocking) |

## Key points

- `Console.ReadLine()` returns `string?`: `null` at end of input. Handle it:
  ```csharp
  string name = Console.ReadLine() ?? "";
  ```
- Input is always a string. Convert with `int.TryParse` (next lessons).
- Old-style composite formatting is still common: `Console.WriteLine("{0} + {1}", a, b);`

## Gotchas

- Unlike `console.log(obj)`, `Console.WriteLine(obj)` prints `obj.ToString()`, which for most classes is just the type name. Records (Ep06) print their properties.

Run it: `dotnet run -- 05` (type a name and press Enter)
