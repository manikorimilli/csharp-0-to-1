# Ep10 Reading a Real Codebase

Everything from Ep01 to Ep09, assembled the way C# teams structure real services:
a tiny Todo API in four projects. The goal is to recognize the shape of a production code base,
follow a request through it, and make small changes with confidence. Time: about 3 hours.

## The sample

```
RealWorldSample/
├── RealWorldSample.sln
├── src/
│   ├── RealWorldSample.Api/              <- Program.cs, Controllers/, appsettings*.json, .http file
│   ├── RealWorldSample.Core/             <- Models/, Interfaces/, Services/, Options/
│   └── RealWorldSample.Infrastructure/   <- Repositories/ (in-memory, no real database)
└── tests/
    └── RealWorldSample.Tests/            <- xUnit tests, Fakes/
```

Dependencies point inward: `Api -> Core`, `Api -> Infrastructure -> Core`, `Tests -> Core + Infrastructure`.

## Run it

```bash
cd RealWorldSample
dotnet build
dotnet test
dotnet run --project src/RealWorldSample.Api
```

The API listens on `http://localhost:5080` (see `Properties/launchSettings.json`). In another terminal:

```bash
curl http://localhost:5080/api/todos
curl -X POST http://localhost:5080/api/todos -H "Content-Type: application/json" -d '{"title":"Learn C#"}'
curl -X POST http://localhost:5080/api/todos/1/complete
```

Or open [RealWorldSample.Api.http](RealWorldSample/src/RealWorldSample.Api/RealWorldSample.Api.http) in VS Code (REST Client), Rider or Visual Studio.
Stop the server with Ctrl+C.

## Learning order

Read a concept, then find it in the sample (the "Where in the sample" column).

| # | Concept | Where in the sample |
|---|---|---|
| 1 | [.sln and .csproj (vs package.json), project references](concepts/01_Solution_And_Projects.md) | `RealWorldSample.sln`, every `*.csproj` |
| 2 | [NuGet packages (vs npm)](concepts/02_NuGet_Packages.md) | `RealWorldSample.Core.csproj`, `RealWorldSample.Tests.csproj` |
| 3 | [Folder and naming conventions](concepts/03_Folder_Naming_Conventions.md) | the whole tree |
| 4 | [Attributes (vs decorators)](concepts/04_Attributes.md) | `TodosController.cs`, `CreateTodoRequest.cs`, tests |
| 5 | [Dependency injection](concepts/05_Dependency_Injection.md) | `Program.cs`, both `DependencyInjection.cs`, constructors |
| 6 | [Configuration: appsettings.json and IOptions (vs .env)](concepts/06_Configuration.md) | `appsettings*.json`, `TodoOptions.cs`, `Program.cs` |
| 7 | [Logging with ILogger](concepts/07_Logging.md) | `TodoService.cs`, `TodosController.cs` |
| 8 | [Controllers and endpoints (vs Express)](concepts/08_Controllers_Endpoints.md) | `TodosController.cs`, `/health` in `Program.cs` |
| 9 | [Unit tests with xUnit](concepts/09_Unit_Tests.md) | `tests/RealWorldSample.Tests` |
| 10 | [How to read an unfamiliar C# codebase](concepts/10_How_To_Read_A_Codebase.md) | start at `Program.cs` |

Suggested reading path through the code, matching guide 10:
1. [Program.cs](RealWorldSample/src/RealWorldSample.Api/Program.cs)
2. [TodosController.cs](RealWorldSample/src/RealWorldSample.Api/Controllers/TodosController.cs)
3. [ITodoService.cs](RealWorldSample/src/RealWorldSample.Core/Interfaces/ITodoService.cs) then [TodoService.cs](RealWorldSample/src/RealWorldSample.Core/Services/TodoService.cs)
4. [ITodoRepository.cs](RealWorldSample/src/RealWorldSample.Core/Interfaces/ITodoRepository.cs) then [InMemoryTodoRepository.cs](RealWorldSample/src/RealWorldSample.Infrastructure/Repositories/InMemoryTodoRepository.cs)
5. [TodoServiceTests.cs](RealWorldSample/tests/RealWorldSample.Tests/Services/TodoServiceTests.cs)

Then do the [Exercises](Exercises.md). Solutions are full-file overlays in [Solutions/](Solutions/).

## About Examples/

This episode has no separate `Examples/` folder: the [RealWorldSample](RealWorldSample) solution **is** the example,
and every concept note points to the file that demonstrates it.

## Checkpoint (end of Day 3)

- Starting from `POST /api/todos`, name every class the request passes through, in order.
- Where would you register a new `IEmailSender`, and with which lifetime?
- How do you override `Todo:MaxTitleLength` in production without editing a file?
- Write a test for a service that depends on an interface, without a mocking library.
