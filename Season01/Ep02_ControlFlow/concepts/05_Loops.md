# 05. for, while, do-while

**In one line:** identical to C++/Java/JS. Use `int` (or `var`) instead of `let`.

```csharp
for (int i = 0; i < 10; i++) { }
for (int lo = 0, hi = 9; lo < hi; lo++, hi--) { }
while (queue.Count > 0) { }
do { attempts++; } while (!ok && attempts < 3);
for (;;) { break; }   // infinite loop, like C++
```

## Key points

- Loop variables are scoped to the loop.
- Arrays use `.Length`, collections use `.Count` (JS uses `.length` for both).

## Gotchas

- `for (int i = 0; i < list.Count; i++) list.RemoveAt(i);` skips elements, same trap as in JS. Loop backwards or use `RemoveAll`.

Run it: `dotnet run -- 05`
