# Ep10 Exercises

These are small changes to [RealWorldSample](RealWorldSample). Do them one at a time, and reset between them
if you like (`git stash`, or copy the folder first). Each solution folder contains the **full** changed files
at the same paths plus a README explaining the change.

Before and after each exercise:

```bash
cd RealWorldSample
dotnet build
dotnet test
dotnet run --project src/RealWorldSample.Api      # then try the endpoint (curl or the .http file)
```

---

## 1. Add an endpoint: DELETE /api/todos/{id}

The repository already has `DeleteAsync`. Add `DeleteAsync` to `ITodoService` and `TodoService` (log the outcome),
then a controller action that returns `204 No Content` or `404 Not Found`.
Time: 10 minutes.
Solution: [Solutions/Ex01_DeleteEndpoint](Solutions/Ex01_DeleteEndpoint/README.md)

---

## 2. Add a service method: statistics

Add `GET /api/todos/stats` returning `{ "total": 3, "done": 1, "pending": 2 }`.
Create a `TodoStats` record in `Core/Models`, a `GetStatsAsync` method on the service (use LINQ), and the controller action.
Think about why `"stats"` does not collide with `{id:int}`.
Time: 10 minutes.
Solution: [Solutions/Ex02_StatsServiceMethod](Solutions/Ex02_StatsServiceMethod/README.md)

---

## 3. Register a new dependency: a clock

`TodoService` calls `DateTime.UtcNow` directly, so tests cannot control time.
1. Create `IClock` (`DateTime UtcNow { get; }`) in `Core/Interfaces`.
2. Implement `SystemClock` in `Infrastructure/Time`.
3. Register it in `AddInfrastructure` with the right lifetime.
4. Inject it into `TodoService` and use it.
5. Fix the tests (they construct `TodoService` directly) with a `FakeClock`, and add a test that checks `CreatedAtUtc`.

First, run the app after step 4 but **without** step 3 and read the error message.
Time: 15 minutes.
Solution: [Solutions/Ex03_RegisterDependency](Solutions/Ex03_RegisterDependency/README.md)

---

## 4. Add a configuration option

Add `MaxOpenItems` to `TodoOptions` (default 10). Set it to 10 in `appsettings.json` and 3 in `appsettings.Development.json`.
`CreateAsync` must refuse to create a todo when the number of not-done items has reached the limit
(throw `InvalidOperationException`), and the controller must translate that to `409 Conflict`.
Then override it from the command line with an environment variable.
Time: 15 minutes.
Solution: [Solutions/Ex04_ConfigurationOption](Solutions/Ex04_ConfigurationOption/README.md)

---

## 5. Write tests

`CompleteAsync` has no tests. In a new file `tests/RealWorldSample.Tests/Services/TodoServiceCompleteTests.cs` write:
- unknown id returns `false` and does not call `UpdateAsync`,
- an existing item becomes done, gets `CompletedAtUtc`, and is saved once,
- completing twice keeps the first completion time,
- a `[Theory]` for `MaxTitleLength` with at least one passing and one failing case.

Use `FakeTodoRepository` (look at `UpdateCalls`).
Time: 15 minutes.
Solution: [Solutions/Ex05_WriteTests](Solutions/Ex05_WriteTests/README.md)

---

## Episode Challenge: due dates

Add due dates end to end:
- `TodoItem.DueAtUtc` (nullable) and `IsOverdue(DateTime nowUtc)`; include it in `TodoDto` and in `CreateTodoRequest` (optional).
- New option `DefaultDueInDays` (7): when no due date is sent, the service sets one.
- Reject due dates in the past with a 400.
- `GET /api/todos/overdue` returns open items past their due date, earliest first, and logs a warning with the count.
- Use .NET 8's built-in `TimeProvider` (register `TimeProvider.System`) instead of `DateTime.UtcNow`,
  and write tests with a small `FixedTimeProvider : TimeProvider` that can `Advance` time.

Time: 45 minutes.
Solution: [Solutions/Challenge_DueDates](Solutions/Challenge_DueDates/README.md)
