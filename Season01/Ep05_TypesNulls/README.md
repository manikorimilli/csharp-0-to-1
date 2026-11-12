# Ep05 Types and Nulls

The part of C# that differs most from JS: value vs reference semantics, structs, enums,
and how C# handles "nothing" with `int?`, `string?` and the null operators. Time: about 2 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Value types vs reference types](concepts/01_Value_vs_Reference_Types.md) | [01_ValueVsReference.cs](Examples/01_ValueVsReference.cs) | `dotnet run -- 01` |
| 2 | [Structs vs classes](concepts/02_Structs_vs_Classes.md) | [02_StructsVsClasses.cs](Examples/02_StructsVsClasses.cs) | `dotnet run -- 02` |
| 3 | [Enums](concepts/03_Enums.md) | [03_Enums.cs](Examples/03_Enums.cs) | `dotnet run -- 03` |
| 4 | [null in C# vs JS null/undefined](concepts/04_Null_Basics.md) | [04_NullBasics.cs](Examples/04_NullBasics.cs) | `dotnet run -- 04` |
| 5 | [Nullable value types (int?)](concepts/05_Nullable_Value_Types.md) | [05_NullableValueTypes.cs](Examples/05_NullableValueTypes.cs) | `dotnet run -- 05` |
| 6 | [Nullable reference types (string?)](concepts/06_Nullable_Reference_Types.md) | [06_NullableReferenceTypes.cs](Examples/06_NullableReferenceTypes.cs) | `dotnet run -- 06` |
| 7 | [Null operators ?. ?? ??= !](concepts/07_Null_Operators.md) | [07_NullOperators.cs](Examples/07_NullOperators.cs) | `dotnet run -- 07` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint

- After `var b = a;`, when does changing `b` change `a`?
- What is the difference between `string` and `string?` at compile time? At runtime?
- Rewrite `if (x != null && x.Y != null) return x.Y.Z; return "none";` in one expression.
