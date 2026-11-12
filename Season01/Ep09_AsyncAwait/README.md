# Ep09 Async / Await

If you know JS promises and `async`/`await`, you know 80% of this. The C#-specific parts are
`Task` vs `Promise` naming, `CancellationToken`, and the blocking traps (`.Result`, `async void`).
Time: about 2 hours.

Note: this episode's [Program.cs](Program.cs) is async (it awaits each example).

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [Task and Task&lt;T&gt; (vs Promise)](concepts/01_Task_vs_Promise.md) | [01_Tasks.cs](Examples/01_Tasks.cs) | `dotnet run -- 01` |
| 2 | [async / await](concepts/02_Async_Await.md) | [02_AsyncAwait.cs](Examples/02_AsyncAwait.cs) | `dotnet run -- 02` |
| 3 | [Task.WhenAll / WhenAny (vs Promise.all / race)](concepts/03_WhenAll_WhenAny.md) | [03_WhenAllWhenAny.cs](Examples/03_WhenAllWhenAny.cs) | `dotnet run -- 03` |
| 4 | [Exceptions in async code](concepts/04_Exceptions_In_Async.md) | [04_AsyncExceptions.cs](Examples/04_AsyncExceptions.cs) | `dotnet run -- 04` |
| 5 | [CancellationToken (vs AbortController)](concepts/05_CancellationToken.md) | [05_Cancellation.cs](Examples/05_Cancellation.cs) | `dotnet run -- 05` |
| 6 | [Common mistakes](concepts/06_Common_Mistakes.md) | [06_CommonMistakes.cs](Examples/06_CommonMistakes.cs) | `dotnet run -- 06` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint

- Translate `const [a, b] = await Promise.all([f(), g()]);` to C#.
- Why is `var x = GetAsync().Result;` a problem?
- Where does a `CancellationToken` parameter go, and what do you do with it?
