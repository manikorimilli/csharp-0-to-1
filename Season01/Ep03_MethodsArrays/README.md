# Ep03 Methods and Arrays

Fixed-size arrays, how methods are declared, and the parameter features JS does not have:
overloading, named args, `ref`/`out`/`in`, `params`, and tuples. Time: about 2 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Arrays](concepts/01_Arrays.md) | [01_Arrays.cs](Examples/01_Arrays.cs) | `dotnet run -- 01` |
| 2 | [Multi-dimensional and jagged arrays](concepts/02_MultiDim_Jagged_Arrays.md) | [02_MultiDimJagged.cs](Examples/02_MultiDimJagged.cs) | `dotnet run -- 02` |
| 3 | [Methods](concepts/03_Methods.md) | [03_Methods.cs](Examples/03_Methods.cs) | `dotnet run -- 03` |
| 4 | [Overloading](concepts/04_Overloading.md) | [04_Overloading.cs](Examples/04_Overloading.cs) | `dotnet run -- 04` |
| 5 | [Optional and named arguments](concepts/05_Optional_Named_Args.md) | [05_OptionalNamed.cs](Examples/05_OptionalNamed.cs) | `dotnet run -- 05` |
| 6 | [ref, out, in](concepts/06_Ref_Out_In.md) | [06_RefOutIn.cs](Examples/06_RefOutIn.cs) | `dotnet run -- 06` |
| 7 | [params (vs JS rest params)](concepts/07_Params.md) | [07_Params.cs](Examples/07_Params.cs) | `dotnet run -- 07` |
| 8 | [Tuples and deconstruction](concepts/08_Tuples_Deconstruction.md) | [08_Tuples.cs](Examples/08_Tuples.cs) | `dotnet run -- 08` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint

- What does `int.TryParse(s, out var n)` return, and where does the number go?
- How do you return two values from a method without `out`?
- Why does a method that sets `arr[0] = 0` change the caller's array, but `n = 0` does not change the caller's int?
