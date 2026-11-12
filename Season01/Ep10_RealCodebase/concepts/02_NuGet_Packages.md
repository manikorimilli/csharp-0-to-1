# 02. NuGet packages (vs npm)

**In one line:** NuGet is npm for .NET; packages are listed in the `.csproj` with exact versions.

| npm | NuGet / dotnet CLI |
|---|---|
| `npm install serilog` | `dotnet add package Serilog` |
| `npm install serilog@3.1.1` | `dotnet add package Serilog --version 3.1.1` |
| `npm uninstall x` | `dotnet remove package X` |
| `npm install` (restore) | `dotnet restore` (automatic on build) |
| `npm outdated` | `dotnet list package --outdated` |
| `package-lock.json` | optional `packages.lock.json` |
| npmjs.com | nuget.org |
| `devDependencies` | no split; test packages live in the test project |
| `.npmrc` (private registry) | `nuget.config` |

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Extensions.Options" Version="8.0.2" />
</ItemGroup>
```

## Packages you will see in most code bases

| Area | Packages |
|---|---|
| Database | `Microsoft.EntityFrameworkCore`, `Dapper` |
| Logging | built-in `ILogger`, `Serilog` |
| Validation | DataAnnotations (built in), `FluentValidation` |
| Mapping | manual mapping, `AutoMapper`, `Mapster` |
| HTTP resilience | `Polly`, `Microsoft.Extensions.Http.Resilience` |
| API docs | `Swashbuckle.AspNetCore` (Swagger) |
| Tests | `xunit` / `NUnit` / `MSTest`, `Moq` / `NSubstitute`, `FluentAssertions` |

## Key points

- Package references are **transitive**: Api gets Core's packages through the project reference.
- Large teams pin versions in one place: `Directory.Packages.props` (Central Package Management). If a `PackageReference` has no `Version`, look there.
- ASP.NET Core itself is not a NuGet package you add; it comes from `Sdk="Microsoft.NET.Sdk.Web"`.

## In this sample

`RealWorldSample.Core.csproj` uses three small `Microsoft.Extensions.*` abstraction packages so Core can use `ILogger`, `IOptions` and `IServiceCollection` without depending on ASP.NET Core.
