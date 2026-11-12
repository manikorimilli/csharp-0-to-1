# Season 01: C# from 0 to 1

Ten episodes, from "how do I run this" to "I can find my way around a production solution".
Each episode is a standalone .NET 8 project: `cd` into it and `dotnet run`.

| Ep | Topic | You will learn | Time | Day |
|---|---|---|---|---|
| [01](Ep01_Basics/README.md) | Basics | dotnet CLI, top-level statements, types, `$""` strings, console, `==`, casting, `TryParse` | 2 h | 1 |
| [02](Ep02_ControlFlow/README.md) | Control Flow | if/ternary, switch statement and expression, basic patterns, loops, `foreach` | 1.5 h | 1 |
| [03](Ep03_MethodsArrays/README.md) | Methods and Arrays | arrays (multi-dim, jagged), methods, overloading, named/optional args, `ref`/`out`/`in`/`params`, tuples | 2 h | 1 |
| [04](Ep04_CollectionsStrings/README.md) | Collections and Strings | `List`, `Dictionary`, `HashSet`, `Queue`, `Stack`, string methods, `StringBuilder` | 2 h | 1 |
| [05](Ep05_TypesNulls/README.md) | Types and Nulls | value vs reference, structs, enums, `int?`, `string?`, `?.` `??` `??=` `!` | 2 h | 2 |
| [06](Ep06_OOP/README.md) | OOP the C# Way | classes, properties, access modifiers, static, inheritance, interfaces, records, namespaces, partial | 3 h | 2 |
| [07](Ep07_ModernFeatures/README.md) | Modern C# Features | exceptions, `using`, generics, delegates, `Func`/`Action`, lambdas, events, extension methods, patterns | 2.5 h | 2 |
| [08](Ep08_LINQ/README.md) | LINQ | `Where`/`Select`, `OrderBy`, `FirstOrDefault`, `Any`/`Sum`, `GroupBy`, `ToDictionary`, query syntax, deferred execution | 2.5 h | 3 |
| [09](Ep09_AsyncAwait/README.md) | Async / Await | `Task` vs Promise, `WhenAll`/`WhenAny`, async exceptions, `CancellationToken`, common mistakes | 2 h | 3 |
| [10](Ep10_RealCodebase/README.md) | Reading a Real Codebase | `.sln`/`.csproj`, NuGet, DI, configuration, logging, controllers, xUnit, a reading guide | 3 h | 3 |

## Episode layout (Ep01 to Ep09)

```
EpNN_Topic/
├── README.md        overview, learning order, checkpoint questions
├── concepts/        one short note per concept: syntax, JS vs C#, key points, gotchas
├── Examples/        one runnable example per concept   ->  dotnet run -- 03
├── Exercises.md     5 to 8 exercises plus an Episode Challenge
├── Solutions/       one solution per exercise          ->  dotnet run -- s3 / challenge
├── Program.cs       a small menu that runs examples and solutions
└── EpNN_Topic.csproj
```

Ep10 replaces `Examples/` with a four-project solution, `RealWorldSample/`, and its solutions are
full-file overlays you copy onto the sample.

## Exercise types

Across each episode you will find a mix of:
1. **Convert C++ to C#**: rewrite a small C++ snippet idiomatically.
2. **Write**: a method or class that does X.
3. **Predict the output**: write down the answer first, then run the solution.
4. **Find and fix the bug**: compile errors and runtime bugs typical for newcomers.
5. **Refactor**: make working code idiomatic (loop to LINQ, class to record, ...).

Exercises take 5 to 15 minutes each. Each episode ends with a slightly bigger **Episode Challenge** that combines its concepts.
