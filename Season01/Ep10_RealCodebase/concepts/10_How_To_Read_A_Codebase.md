# 10. How to read an unfamiliar C# code base

A repeatable route through any ASP.NET Core solution. Try it on [RealWorldSample](../RealWorldSample) first.

## Step 1: the map (5 minutes)

1. Open the `.sln` (or list `*.csproj` files). Each project is a layer or a deployable app.
2. Read each `.csproj`: `Sdk.Web` = a web app; `ProjectReference` = which layer depends on which; `PackageReference` = the tech stack (EF Core? MediatR? Serilog?).
3. Look for `Directory.Build.props` and `Directory.Packages.props` at the root for shared settings and versions.
4. Draw the arrows: `Api -> Core <- Infrastructure`. Core is where the business lives.

## Step 2: Program.cs (10 minutes)

`Program.cs` (or `Startup.cs` in older apps) answers three questions:

| Question | Look for |
|---|---|
| What services exist and how are they wired? | `builder.Services.Add...` and custom `AddXxx()` extension methods. Jump into each. |
| What runs on every request? | `app.Use...` middleware, in order: exception handling, HTTPS, auth, CORS... |
| What endpoints exist? | `app.MapControllers()`, `app.MapGet(...)`, `app.MapGroup(...)` |

Also note configuration sections it binds (`Configure<TOptions>`) and anything done at startup (migrations, seeding).

## Step 3: follow one request end to end (15 minutes)

Pick one endpoint, e.g. `POST /api/todos`:

1. **Controller** `TodosController.Create`: find it by route (`[Route]` + `[HttpPost]`). Note the input type (`CreateTodoRequest`), the service it calls, and which HTTP results it can return.
2. **Service** `ITodoService.CreateAsync`: "Go to implementation" (Ctrl+F12 / Cmd+F12) lands on `TodoService`. Read the rules: validation, defaults, logging, which repository calls happen.
3. **Repository** `ITodoRepository.AddAsync`: implementation in Infrastructure (`InMemoryTodoRepository`; in real apps EF Core or Dapper). Note how data is stored and queried.
4. Go back up: how does the result become the HTTP response (`CreatedAtAction` + `TodoDto`)?

## What to look for in each layer

| Layer | Look for | Red flags |
|---|---|---|
| Controllers / endpoints | routes, attributes (`[Authorize]`), input/output types, status codes | business logic in controllers |
| Services | business rules, validation, transactions, logging, which interfaces they use | `.Result` / `.Wait()`, huge classes |
| Repositories / data | queries (LINQ, SQL), `async` usage, `ToList()` placement | loading whole tables, N+1 queries |
| Models / DTOs | entities vs request/response records, validation attributes | entities returned directly from APIs |
| Options / config | which settings exist and their defaults | secrets in `appsettings.json` |
| Tests | what behavior is specified; they are executable documentation | no tests for core rules |

## Step 4: run it

```bash
dotnet build
dotnet test
dotnet run --project src/RealWorldSample.Api
```

Then call endpoints with the `.http` file or curl, and watch the logs.

## Useful IDE moves (VS Code C# Dev Kit, Rider, Visual Studio)

- Go to definition (F12), go to implementation (Ctrl+F12), find all references (Shift+F12).
- Search a route string (`"api/todos"`) or log message text to find code fast.
- "Find usages" on an interface tells you who depends on it; on an `AddScoped` line, what is wired.

## Questions to ask the team

- Which project is the entry point, and how is it deployed?
- Where do configuration and secrets come from in each environment?
- What are the conventions for errors (exceptions, `Result` types, ProblemDetails)?
- How are database changes (migrations) handled?
