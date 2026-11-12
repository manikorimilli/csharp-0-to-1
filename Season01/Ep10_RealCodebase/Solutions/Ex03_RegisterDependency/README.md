# Solution 3: register a new dependency (IClock)

| File | Change |
|---|---|
| `src/RealWorldSample.Core/Interfaces/IClock.cs` | new interface: `DateTime UtcNow { get; }` |
| `src/RealWorldSample.Infrastructure/Time/SystemClock.cs` | new implementation returning `DateTime.UtcNow` |
| `src/RealWorldSample.Infrastructure/DependencyInjection.cs` | `services.AddSingleton<IClock, SystemClock>();` |
| `src/RealWorldSample.Core/Services/TodoService.cs` | new constructor parameter `IClock clock`; replaced `DateTime.UtcNow` |
| `tests/RealWorldSample.Tests/Fakes/FakeClock.cs` | test clock with a settable time |
| `tests/RealWorldSample.Tests/Services/TodoServiceTests.cs` | passes `FakeClock`; new test `CreateAsync_SetsCreatedAtFromClock` |

What to notice:
- The interface lives in **Core** (what the business needs); the implementation in **Infrastructure** (how).
- Adding a constructor parameter is all it takes on the consumer side. The container resolves it.
- If you forget the registration, the app fails at the first request with
  `Unable to resolve service for type 'IClock' while attempting to activate 'TodoService'`.
- Tests that call the constructor directly must be updated. That is expected and is the compiler helping you.
- .NET 8 has a built-in abstraction for this, `TimeProvider` (see the challenge solution). Many code bases still have their own `IClock` / `IDateTimeProvider`.

Apply: `cp -r Solutions/Ex03_RegisterDependency/src Solutions/Ex03_RegisterDependency/tests RealWorldSample/`
