# 06. Configuration: appsettings.json and IOptions (vs .env)

**In one line:** settings come from layered sources (JSON files, environment variables, command line) and are bound to typed classes injected as `IOptions<T>`.

## Sources, later ones win

1. `appsettings.json`
2. `appsettings.{Environment}.json` (e.g. `appsettings.Development.json`)
3. User secrets (Development only, for local passwords)
4. Environment variables
5. Command-line args

The environment name comes from `ASPNETCORE_ENVIRONMENT` (set to `Development` in `Properties/launchSettings.json`).

## JS vs C#

| Node | ASP.NET Core |
|---|---|
| `.env` + `dotenv` | `appsettings.json` + environment variables |
| `process.env.MAX_TITLE_LENGTH` | `IOptions<TodoOptions>.Value.MaxTitleLength` (typed) |
| `NODE_ENV` | `ASPNETCORE_ENVIRONMENT` |
| config per env via files | `appsettings.Development.json`, `appsettings.Production.json` |

## Typed options in three steps

```json
// appsettings.json
"Todo": { "MaxTitleLength": 100, "SeedSampleData": false }
```
```csharp
// 1. a class matching the section
public class TodoOptions { public int MaxTitleLength { get; set; } = 100; public bool SeedSampleData { get; set; } }

// 2. bind it (Program.cs)
builder.Services.Configure<TodoOptions>(builder.Configuration.GetSection("Todo"));

// 3. inject it
public TodoService(IOptions<TodoOptions> options) => _options = options.Value;
```

## Environment variables

Nested keys use a **double underscore**: `Todo__MaxTitleLength=50 dotnet run` overrides `Todo:MaxTitleLength`.
In code, nested keys use a colon: `builder.Configuration["Todo:MaxTitleLength"]`.

## Key points

- Connection strings: `"ConnectionStrings": { "Default": "..." }` read with `builder.Configuration.GetConnectionString("Default")`.
- Never commit secrets to `appsettings.json`. Use user secrets locally and environment variables or a vault in production.
- `IOptionsSnapshot<T>` / `IOptionsMonitor<T>` re-read changes at runtime; `IOptions<T>` is read once.

## Gotchas

- A typo in a section or property name does not fail; you silently get the default value.
