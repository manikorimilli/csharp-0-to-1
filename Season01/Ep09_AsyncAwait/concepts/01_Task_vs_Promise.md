# 01. Task and Task<T> (vs JS Promise)

**In one line:** `Task<T>` is `Promise<T>`, `Task` is `Promise<void>`, and `await` works the same way.

| JS | C# |
|---|---|
| `Promise<string>` | `Task<string>` |
| `Promise<void>` | `Task` |
| `Promise.resolve(42)` | `Task.FromResult(42)` |
| `Promise.resolve()` | `Task.CompletedTask` |
| `new Promise(r => setTimeout(r, 100))` | `Task.Delay(100)` |
| `p.then(f)` | `await p` (or `ContinueWith`, rarely) |
| pending / fulfilled / rejected | `Status`: `WaitingForActivation`, `RanToCompletion`, `Faulted`, `Canceled` |

## Key points

- Like a Promise, a `Task` returned by an async method is already running ("hot").
- The big runtime difference: JS has **one thread** and an event loop. .NET has a **thread pool**; code after an `await` may resume on another thread. For app code this rarely matters, but shared mutable state needs care.
- `Task.Run(() => ...)` pushes CPU work to the thread pool. There is no JS equivalent (closest: a Web Worker).

## Gotchas

- `task.Result` and `task.Wait()` block the current thread until the task is done. In JS there is no way to block; in C# there is, and you almost never should (lesson 06).

Run it: `dotnet run -- 01`
