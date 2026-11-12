# 04. Queue<T> and Stack<T>

**In one line:** dedicated FIFO and LIFO collections. In JS you would use an array with `push`/`shift`/`pop`.

| Operation | JS array | `Queue<T>` | `Stack<T>` |
|---|---|---|---|
| add | `push` | `Enqueue(x)` | `Push(x)` |
| remove next | `shift()` / `pop()` | `Dequeue()` | `Pop()` |
| look at next | `a[0]` / `a.at(-1)` | `Peek()` | `Peek()` |
| safe remove | check length first | `TryDequeue(out var x)` | `TryPop(out var x)` |
| size | `length` | `Count` | `Count` |

## Typical uses

- `Queue<T>`: work items, BFS traversal, buffering.
- `Stack<T>`: undo history, bracket matching, DFS traversal.

## Gotchas

- `Dequeue`, `Pop` and `Peek` on an empty collection throw `InvalidOperationException`. Use the `Try...` versions or check `Count`.
- `JS shift()` is O(n); `Dequeue()` is O(1).
- For thread-safe versions see `ConcurrentQueue<T>` (not needed for now).

Run it: `dotnet run -- 04`
