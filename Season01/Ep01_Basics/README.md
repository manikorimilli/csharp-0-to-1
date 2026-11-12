# Ep01 Basics

How a C# program is built and run, the core types, strings, console I/O, operators and conversions.
Time: about 2 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [dotnet CLI and project structure](concepts/01_Dotnet_CLI.md) | [01_DotnetCli.cs](Examples/01_DotnetCli.cs) | `dotnet run -- 01` |
| 2 | [Top-level statements vs Main](concepts/02_Top_Level_Statements.md) | [02_TopLevelStatements.cs](Examples/02_TopLevelStatements.cs) | `dotnet run -- 02` |
| 3 | [Types, var, const](concepts/03_Types.md) | [03_Types.cs](Examples/03_Types.cs) | `dotnet run -- 03` |
| 4 | [String interpolation and raw strings](concepts/04_Strings_Interpolation.md) | [04_Strings.cs](Examples/04_Strings.cs) | `dotnet run -- 04` |
| 5 | [Console I/O](concepts/05_Console_IO.md) | [05_ConsoleIO.cs](Examples/05_ConsoleIO.cs) | `dotnet run -- 05` |
| 6 | [Operators (== vs ===)](concepts/06_Operators.md) | [06_Operators.cs](Examples/06_Operators.cs) | `dotnet run -- 06` |
| 7 | [Casting, Parse, TryParse](concepts/07_Casting_Parsing.md) | [07_CastingParsing.cs](Examples/07_CastingParsing.cs) | `dotnet run -- 07` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## How this project is wired

[Program.cs](Program.cs) is a small menu: `dotnet run` lists everything, `dotnet run -- 03` runs one example,
`dotnet run -- s3` runs the solution to exercise 3, `dotnet run -- challenge` runs the episode challenge.
Each example is a static class with a `Run()` method, so many files can live in one project.

## Checkpoint

You are done when you can answer without looking:
- What does `var x = 5;` followed by `x = "five";` do? (compile error)
- Which type do you use for money? (`decimal`, literal suffix `m`)
- How do you safely turn user text into an int? (`int.TryParse(text, out int n)`)
