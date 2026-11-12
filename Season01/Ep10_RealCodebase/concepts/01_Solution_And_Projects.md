# 01. .sln and .csproj files (vs package.json) and project references

**In one line:** a `.csproj` is one package/app (like one `package.json`); a `.sln` groups several projects (like a monorepo workspace).

## The pieces

```
RealWorldSample/
├── RealWorldSample.sln                       <- solution: list of projects (IDE + `dotnet build` at root)
├── src/
│   ├── RealWorldSample.Api/RealWorldSample.Api.csproj
│   ├── RealWorldSample.Core/RealWorldSample.Core.csproj
│   └── RealWorldSample.Infrastructure/RealWorldSample.Infrastructure.csproj
└── tests/RealWorldSample.Tests/RealWorldSample.Tests.csproj
```

| JS / Node | C# / .NET |
|---|---|
| `package.json` | `X.csproj` |
| npm/pnpm workspaces, Nx, Turborepo | `X.sln` |
| `"dependencies"` | `<PackageReference Include="..." Version="..." />` |
| `"my-lib": "workspace:*"` / `file:../core` | `<ProjectReference Include="..\Core\Core.csproj" />` |
| `"scripts"` | no equivalent; use `dotnet build/run/test` (or a Makefile) |
| `"main"` / entry point | `OutputType Exe` + `Program.cs` |
| `node_modules/`, `dist/` | `obj/`, `bin/` |

## A .csproj, annotated

```xml
<Project Sdk="Microsoft.NET.Sdk.Web">          <!-- Sdk.Web = ASP.NET Core app -->
  <PropertyGroup>
    <TargetFramework>net8.0</TargetFramework>  <!-- like "engines": { "node": "20" } -->
    <Nullable>enable</Nullable>
    <ImplicitUsings>enable</ImplicitUsings>
  </PropertyGroup>
  <ItemGroup>
    <ProjectReference Include="..\RealWorldSample.Core\RealWorldSample.Core.csproj" />
  </ItemGroup>
</Project>
```

## Project references

- Arrows go one way: `Api -> Core`, `Api -> Infrastructure`, `Infrastructure -> Core`, `Tests -> Core + Infrastructure`.
- **Core references nothing of ours.** That is the point: business logic does not depend on web or storage details.
- Circular references are not allowed (the build fails), which keeps the layers honest.

## Commands

```bash
dotnet build                                   # at the .sln folder: builds everything
dotnet run --project src/RealWorldSample.Api   # run one project
dotnet test                                    # runs every test project in the solution
dotnet sln add path/to/New.csproj              # add a project to the solution
dotnet add src/A reference src/B               # add a project reference
```

## Gotchas

- Newer SDKs may create `.slnx` (XML) instead of `.sln`. Same idea.
- Shared settings for all projects often live in `Directory.Build.props` at the root. If a setting is not in a `.csproj`, look there.
