# 01. dotnet CLI and project structure

**In one line:** `dotnet` is your `npm` + `node` + `tsc` in one tool, and the `.csproj` file is your `package.json`.

## Everyday commands

| Task | JavaScript | C# |
|---|---|---|
| New project | `npm init` | `dotnet new console -o MyApp` |
| Run | `npm start` / `node index.js` | `dotnet run` |
| Pass args to your app | `npm start -- --x` | `dotnet run -- --x` |
| Compile only | `tsc` | `dotnet build` |
| Add a dependency | `npm install lodash` | `dotnet add package Newtonsoft.Json` |
| Restore dependencies | `npm install` | `dotnet restore` (runs automatically on build) |
| Tests | `npm test` | `dotnet test` |
| List templates | | `dotnet new list` |

## A minimal project

```
MyApp/
├── MyApp.csproj      <- project file (SDK, target framework, packages)
├── Program.cs        <- entry point
├── bin/  obj/        <- build output (like dist/ and node_modules/.cache), git-ignored
```

```xml
<Project Sdk="Microsoft.NET.Sdk">
  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net8.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>   <!-- auto "using System;" etc. -->
    <Nullable>enable</Nullable>               <!-- nullable reference types on -->
  </PropertyGroup>
</Project>
```

## Key points

- **Every `.cs` file under the project folder is compiled together.** No `import`/`require` between your own files. Types are found by namespace (see Ep06).
- `ImplicitUsings` adds common `using` lines for you (`System`, `System.Linq`, `System.Collections.Generic`, ...).
- The output is a `.dll` (an "assembly"), run by the .NET runtime, like a `.jar` on the JVM.

## Gotchas

- `dotnet run` with **two** `.csproj` files in one folder fails. Use `--project path/to/X.csproj`.
- Args for your program go **after** `--`. `dotnet run 03` is read by dotnet, `dotnet run -- 03` by your app.

Run it: `dotnet run -- 01`
