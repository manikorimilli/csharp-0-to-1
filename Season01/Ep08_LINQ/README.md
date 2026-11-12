# Ep08 LINQ

LINQ is how C# code filters, maps, sorts, groups and aggregates data. If you know JS array methods,
you already know most of it; the new ideas are key-based sorting, grouping, and deferred execution.
Time: about 2.5 hours.

All examples share the small dataset in [SampleData.cs](SampleData.cs).

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Where and Select (vs filter/map)](concepts/01_Where_Select.md) | [01_WhereSelect.cs](Examples/01_WhereSelect.cs) | `dotnet run -- 01` |
| 2 | [OrderBy and ThenBy (vs sort)](concepts/02_OrderBy_ThenBy.md) | [02_OrderBy.cs](Examples/02_OrderBy.cs) | `dotnet run -- 02` |
| 3 | [FirstOrDefault (vs find)](concepts/03_FirstOrDefault.md) | [03_FirstOrDefault.cs](Examples/03_FirstOrDefault.cs) | `dotnet run -- 03` |
| 4 | [Any/All/Count/Sum (vs some/every/reduce)](concepts/04_Any_All_Count_Sum.md) | [04_Aggregates.cs](Examples/04_Aggregates.cs) | `dotnet run -- 04` |
| 5 | [GroupBy](concepts/05_GroupBy.md) | [05_GroupBy.cs](Examples/05_GroupBy.cs) | `dotnet run -- 05` |
| 6 | [ToList, ToDictionary and other operators](concepts/06_ToList_ToDictionary.md) | [06_Materializing.cs](Examples/06_Materializing.cs) | `dotnet run -- 06` |
| 7 | [Method syntax vs query syntax](concepts/07_Method_vs_Query_Syntax.md) | [07_QuerySyntax.cs](Examples/07_QuerySyntax.cs) | `dotnet run -- 07` |
| 8 | [Deferred execution](concepts/08_Deferred_Execution.md) | [08_DeferredExecution.cs](Examples/08_DeferredExecution.cs) | `dotnet run -- 08` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint

- Translate `users.filter(u => u.active).map(u => u.email)` to C#.
- What is the difference between `First`, `FirstOrDefault` and `Single`?
- Why can calling `.Count()` twice on a query do the work twice?
