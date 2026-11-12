# Ep02 Control Flow

Branching and looping. Most of it looks like JS; the new parts are switch **expressions** and patterns.
Time: about 1.5 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [if / else and ternary](concepts/01_If_Else_Ternary.md) | [01_IfElse.cs](Examples/01_IfElse.cs) | `dotnet run -- 01` |
| 2 | [switch statement](concepts/02_Switch_Statement.md) | [02_SwitchStatement.cs](Examples/02_SwitchStatement.cs) | `dotnet run -- 02` |
| 3 | [Switch expressions](concepts/03_Switch_Expressions.md) | [03_SwitchExpressions.cs](Examples/03_SwitchExpressions.cs) | `dotnet run -- 03` |
| 4 | [Basic pattern matching](concepts/04_Pattern_Matching_Basics.md) | [04_PatternMatching.cs](Examples/04_PatternMatching.cs) | `dotnet run -- 04` |
| 5 | [for, while, do-while](concepts/05_Loops.md) | [05_Loops.cs](Examples/05_Loops.cs) | `dotnet run -- 05` |
| 6 | [foreach (vs for...of)](concepts/06_Foreach.md) | [06_Foreach.cs](Examples/06_Foreach.cs) | `dotnet run -- 06` |
| 7 | [break and continue](concepts/07_Break_Continue.md) | [07_BreakContinue.cs](Examples/07_BreakContinue.cs) | `dotnet run -- 07` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

Runner: `dotnet run` lists everything, `dotnet run -- all` runs every example, `dotnet run -- s4` runs solution 4.

## Checkpoint

- Rewrite an if/else chain that returns a value as a switch expression.
- Explain what `if (obj is Customer c)` does in one sentence.
- Why does `if (count)` not compile?
