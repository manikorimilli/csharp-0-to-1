# 09. Namespaces (vs JS modules and imports)

**In one line:** namespaces organize type **names**; they are not files or modules. `using` brings a namespace into scope.

```csharp
// File: Billing/Invoice.cs
namespace Shop.Billing;            // file-scoped namespace (C# 10)

public class Invoice { }
```
```csharp
// File: Program.cs
using Shop.Billing;                // like an import, but of a whole namespace
var inv = new Invoice();
```

## JS vs C#

| JS modules | C# |
|---|---|
| each file is a module | every `.cs` file in the project is compiled together |
| `export class Invoice` | `public class Invoice` (visibility, not export) |
| `import { Invoice } from "./billing/invoice.js"` | `using Shop.Billing;` |
| path-based | name-based; convention: namespace mirrors folder path |
| `import * as T from "x"` | `using T = Some.Namespace;` (alias) |
| | `global using X;` once for the whole project |

## Key points

- Old style wraps the file: `namespace Shop.Billing { ... }`. Same meaning, one more indent level.
- `ImplicitUsings` gives you `System`, `System.Collections.Generic`, `System.Linq`, `System.IO`, `System.Threading.Tasks`, and a few more.
- Types from **another project** need a project reference first (Ep10), then a `using`.

## Gotchas

- "The type or namespace name 'X' could not be found" usually means a missing `using` (your IDE can add it with a quick fix) or a missing project/package reference.

Run it: `dotnet run -- 09`
