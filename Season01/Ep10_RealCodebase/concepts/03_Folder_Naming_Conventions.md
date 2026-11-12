# 03. Folder and naming conventions

**In one line:** names are predictable; once you know the conventions you can guess where anything lives.

## Folders and namespaces

- Namespace = project name + folder path: `src/RealWorldSample.Core/Services/TodoService.cs` contains `namespace RealWorldSample.Core.Services;`.
- One public type per file, file named after the type (`TodoService.cs`).
- Common folders: `Controllers/`, `Models/` (or `Entities/`, `Dtos/`), `Interfaces/` (or `Abstractions/`), `Services/`, `Repositories/`, `Options/`, `Extensions/`, `Middleware/`.

## Naming

| Thing | Convention | Example |
|---|---|---|
| Types, methods, properties, constants | PascalCase | `TodoService`, `GetAllAsync`, `MaxTitleLength` |
| Interfaces | `I` + PascalCase | `ITodoRepository` |
| Parameters, locals | camelCase | `cancellationToken`, `item` |
| Private fields | `_camelCase` | `_repository` |
| Async methods | suffix `Async` | `CreateAsync` |
| Generic type params | `T` or `TName` | `TEntity`, `TResult` |
| Test classes | `<Class>Tests` | `TodoServiceTests` |
| Test methods | `Method_Scenario_Expected` | `CreateAsync_BlankTitle_Throws` |

## Common class suffixes and what they mean

| Suffix | Role |
|---|---|
| `Controller` | HTTP endpoints |
| `Service` | business logic |
| `Repository` | data access |
| `Options` / `Settings` | configuration classes |
| `Dto`, `Request`, `Response` | data shapes crossing a boundary |
| `Extensions` | static class with extension methods |
| `Exception` | custom exceptions |
| `Handler` | one operation (MediatR, CQRS style) |
| `Validator` | FluentValidation rules |
| `Middleware` | HTTP pipeline component |
| `Factory`, `Provider`, `Builder` | create or supply objects |

## JS comparison

JS file names are usually kebab-case and one file can export many things. In C#, PascalCase file = type name, and folders map to namespaces.

## Gotchas

- `.Abstractions` in a project or package name means "interfaces only", e.g. `Microsoft.Extensions.Logging.Abstractions`.
