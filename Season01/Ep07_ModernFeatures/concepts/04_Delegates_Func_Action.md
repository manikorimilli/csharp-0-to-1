# 04. Delegates, Func and Action

**In one line:** a delegate is a **typed** function reference. Use `Func<...>` for functions that return a value and `Action<...>` for ones that return `void`.

## JS vs C#

| JS | C# |
|---|---|
| `const f = (a, b) => a + b` | `Func<int, int, int> f = (a, b) => a + b;` |
| `const log = msg => console.log(msg)` | `Action<string> log = msg => Console.WriteLine(msg);` |
| `const pred = x => x > 0` | `Func<int, bool> pred = x => x > 0;` (or `Predicate<int>`) |
| `function run(cb) { cb(); }` | `void Run(Action cb) => cb();` |
| `cb?.()` | `cb?.Invoke();` |

## Reading the type

- `Func<int, string>`: takes an `int`, returns a `string`. **The last type is the return type.**
- `Func<bool>`: no parameters, returns `bool`.
- `Action<string, int>`: takes a `string` and an `int`, returns nothing.

## Key points

- A method name can be used where a delegate is expected: `list.ForEach(Console.WriteLine);`
- Custom `delegate` declarations exist (`delegate int MathOp(int a, int b);`) and appear in older code. New code uses `Func`/`Action`.
- Delegates are multicast: `+=` adds targets. Events are built on this.

## Gotchas

- `Func<T>` and `Action` are different types; you cannot pass a `Func<int>` where an `Action` is expected without a lambda wrapper.

Run it: `dotnet run -- 04`
