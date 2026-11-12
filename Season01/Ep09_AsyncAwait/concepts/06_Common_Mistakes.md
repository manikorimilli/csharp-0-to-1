# 06. Common async mistakes

**In one line:** most async bugs in code reviews are one of these six.

| Mistake | Why it hurts | Do this instead |
|---|---|---|
| `async void DoWork()` | caller cannot await; exceptions crash the process | `async Task DoWork()` (void only for UI event handlers) |
| `GetAsync().Result` / `.Wait()` | blocks a thread, can deadlock (WinForms, WPF, old ASP.NET), wraps errors in `AggregateException` | `await GetAsync()` |
| Forgetting `await` | work runs unobserved, errors lost, ordering bugs. Compiler warning CS4014 | `await` it, or `_ = ...` for deliberate fire-and-forget with its own error handling |
| `await` in a loop for independent calls | N x slower | `await Task.WhenAll(items.Select(DoAsync))` |
| `Task.Run` around I/O | wastes a thread pool thread | call the async I/O API directly |
| `Thread.Sleep` in async code | blocks the thread | `await Task.Delay(...)` |

## JS comparison

- JS cannot block, so `.Result` has no JS equivalent. It is the C#-specific trap.
- Forgetting `await` is the same bug as forgetting it in JS.

## Also good to recognize

- `.ConfigureAwait(false)`: common in library code ("do not resume on the captured context"). Not needed in ASP.NET Core app code.
- `GetAwaiter().GetResult()`: another way to block; same warnings as `.Result`.
- Sync over async in constructors: constructors cannot be async. Use a static `CreateAsync` factory or initialize lazily.

Run it: `dotnet run -- 06`
