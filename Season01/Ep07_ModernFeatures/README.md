# Ep07 Modern C# Features

Exceptions, resource cleanup, generics, functions as values (delegates and lambdas),
events, extension methods and advanced patterns. Time: about 2.5 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Exceptions](concepts/01_Exceptions.md) | [01_Exceptions.cs](Examples/01_Exceptions.cs) | `dotnet run -- 01` |
| 2 | [using and IDisposable](concepts/02_Using_IDisposable.md) | [02_UsingDisposable.cs](Examples/02_UsingDisposable.cs) | `dotnet run -- 02` |
| 3 | [Generics and constraints](concepts/03_Generics_Constraints.md) | [03_Generics.cs](Examples/03_Generics.cs) | `dotnet run -- 03` |
| 4 | [Delegates, Func, Action](concepts/04_Delegates_Func_Action.md) | [04_Delegates.cs](Examples/04_Delegates.cs) | `dotnet run -- 04` |
| 5 | [Lambdas (vs JS arrow functions)](concepts/05_Lambdas.md) | [05_Lambdas.cs](Examples/05_Lambdas.cs) | `dotnet run -- 05` |
| 6 | [Events (vs addEventListener)](concepts/06_Events.md) | [06_Events.cs](Examples/06_Events.cs) | `dotnet run -- 06` |
| 7 | [Extension methods](concepts/07_Extension_Methods.md) | [07_ExtensionMethods.cs](Examples/07_ExtensionMethods.cs) | `dotnet run -- 07` |
| 8 | [Advanced pattern matching](concepts/08_Advanced_Pattern_Matching.md) | [08_AdvancedPatterns.cs](Examples/08_AdvancedPatterns.cs) | `dotnet run -- 08` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint (end of Day 2)

- Read `Func<string, int, bool>` out loud. (takes a string and an int, returns bool)
- What is the difference between `throw;` and `throw ex;`?
- Where must an extension method live, and why does `using` matter for it?
- Write a switch expression arm that matches an order whose customer is a VIP.
