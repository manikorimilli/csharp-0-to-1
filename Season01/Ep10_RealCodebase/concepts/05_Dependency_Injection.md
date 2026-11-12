# 05. Dependency injection

**In one line:** classes ask for their dependencies in the constructor; a built-in container creates them and passes them in. You almost never write `new SomeService(...)` in app code.

## The two halves

```csharp
// 1. Register: "when someone asks for ITodoService, give them a TodoService"   (Program.cs or AddXxx extensions)
builder.Services.AddScoped<ITodoService, TodoService>();
builder.Services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

// 2. Consume: ask for it in a constructor (constructor injection)
public class TodosController(ITodoService todoService) : ControllerBase { ... }
public class TodoService(ITodoRepository repository, ILogger<TodoService> logger) : ITodoService { ... }
```

When a request hits `TodosController`, the container sees it needs `ITodoService`, which needs `ITodoRepository`, `IOptions<TodoOptions>` and `ILogger<TodoService>`, and builds the whole graph.

## Lifetimes

| Method | One instance per | Typical use |
|---|---|---|
| `AddSingleton` | application | caches, in-memory stores, config wrappers, `HttpClient` factories |
| `AddScoped` | HTTP request | services, repositories, EF Core `DbContext` |
| `AddTransient` | every injection | small stateless helpers |

## JS comparison

Express apps usually `import` modules directly or pass dependencies by hand. NestJS has the same idea as ASP.NET Core (`@Injectable()`, providers, constructor injection). In .NET, DI is built into the platform and used everywhere.

## Why teams do it

- Swap implementations (in-memory now, SQL later) by changing one registration line.
- Tests construct classes with fakes (see `TodoServiceTests`).
- Lifetimes and disposal are handled for you.

## Reading tip

To find which class implements an interface, search for `ITodoService,` in `Add...` calls, or use "Go to implementation" in your IDE.

## Gotchas

- **Captive dependency:** a singleton must not depend on a scoped service (in Development the container throws to warn you).
- "Unable to resolve service for type X while attempting to activate Y" = you forgot to register X.
- Outside a request (startup code, background jobs) create a scope with `app.Services.CreateScope()` to get scoped services (see `Program.cs`).
