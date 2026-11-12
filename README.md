# csharp-0-to-1

A 2 to 3 day self-study repo for experienced developers (C++, Java, JavaScript) who need to **read and work in a C# code base**.
It does not teach programming. It shows how the things you already know look in C#, with JavaScript (and some Java and C++) comparisons throughout.

- 1 season, 10 episodes, each a small runnable .NET 8 project
- Short concept notes: syntax, "in JavaScript you would write X, in C# it is Y", gotchas
- Runnable examples, exercises (convert, write, predict, fix, refactor) and solutions
- A final episode with a production-style multi-project Web API to practice reading real code

Start here: [Season 01](Season01/README.md)

---

## 1. Setup

### Install the .NET 8 SDK

| OS | Command |
|---|---|
| Windows | `winget install Microsoft.DotNet.SDK.8` |
| macOS | the installer from the download page below (Homebrew `brew install --cask dotnet-sdk` installs the latest SDK instead) |
| Ubuntu / Debian | `sudo apt-get install -y dotnet-sdk-8.0` |
| Any | download from https://dotnet.microsoft.com/download/dotnet/8.0 |

Check it:

```bash
dotnet --list-sdks
```

You need an `8.0.x` entry. A newer SDK (9, 10) also works as long as the .NET 8 runtime is installed;
otherwise change `<TargetFramework>net8.0</TargetFramework>` in the `.csproj` files to your version.

### Editor

Any of these gives you IntelliSense, "go to definition" and debugging:
- **VS Code** with the **C# Dev Kit** extension (closest to a JS workflow)
- **JetBrains Rider**
- **Visual Studio 2022** (Windows)

---

## 2. How to run

Every episode (Ep01 to Ep09) is one console project with a small menu in `Program.cs`:

```bash
cd Season01/Ep01_Basics
dotnet run                  # list everything in this episode
dotnet run -- 03            # run example 03
dotnet run -- all           # run every example in order
dotnet run -- s2            # run the solution to exercise 2
dotnet run -- challenge     # run the episode challenge solution
```

Arguments after `--` go to the program, not to `dotnet`. The first run restores and builds (a few seconds).
Ep01 example `05` reads a line from the keyboard.

Ep10 is a solution with four projects:

```bash
cd Season01/Ep10_RealCodebase/RealWorldSample
dotnet build
dotnet test
dotnet run --project src/RealWorldSample.Api     # http://localhost:5080/api/todos
```

### Suggested workflow per episode

1. Read the episode `README.md` for the learning order.
2. For each concept: read the note in `concepts/`, then read and run its example.
3. Do the exercises in `Exercises.md`. Write your code in a scratch project (`dotnet new console -o Scratch`) or straight into the episode.
4. Compare with `Solutions/` (`dotnet run -- sN`).
5. Answer the checkpoint questions at the bottom of the episode README.

Repo-wide settings: nullable reference types are enabled everywhere, and the console projects use
`InvariantGlobalization` so number formatting looks the same on every machine.

---

## 3. The 3-day plan (about 7 to 8 hours per day)

### Day 1: syntax and the standard library

| Block | Episode | Time |
|---|---|---|
| Morning | [Ep01 Basics](Season01/Ep01_Basics/README.md) | 2 h |
| Morning | [Ep02 Control Flow](Season01/Ep02_ControlFlow/README.md) | 1.5 h |
| Afternoon | [Ep03 Methods and Arrays](Season01/Ep03_MethodsArrays/README.md) | 2 h |
| Afternoon | [Ep04 Collections and Strings](Season01/Ep04_CollectionsStrings/README.md) | 2 h |

**Checkpoint Day 1.** Without notes, you can:
- create and run a console app with the CLI, and explain `var`, `decimal`, `$""` and `TryParse`;
- write a switch expression with relational and tuple patterns;
- return two values from a method with a tuple and deconstruct them;
- pick between `List`, `Dictionary`, `HashSet` and explain why `dict["missing"]` throws.

### Day 2: the type system and OOP

| Block | Episode | Time |
|---|---|---|
| Morning | [Ep05 Types and Nulls](Season01/Ep05_TypesNulls/README.md) | 2 h |
| Late morning to afternoon | [Ep06 OOP the C# Way](Season01/Ep06_OOP/README.md) | 3 h |
| Afternoon | [Ep07 Modern C# Features](Season01/Ep07_ModernFeatures/README.md) | 2.5 h |

**Checkpoint Day 2.** Without notes, you can:
- explain value vs reference semantics and when `string?` warnings appear;
- write a class with `init`/`required`/computed properties, an interface, and a record;
- read `Func<string, int, bool>` and write a lambda for it;
- write a generic method with a constraint and an extension method;
- explain `throw;` vs `throw ex;` and what `using var` does.

### Day 3: LINQ, async, and real code

| Block | Episode | Time |
|---|---|---|
| Morning | [Ep08 LINQ](Season01/Ep08_LINQ/README.md) | 2.5 h |
| Late morning | [Ep09 Async / Await](Season01/Ep09_AsyncAwait/README.md) | 2 h |
| Afternoon | [Ep10 Reading a Real Codebase](Season01/Ep10_RealCodebase/README.md) | 3 h |

**Checkpoint Day 3.** Without notes, you can:
- translate JS `filter/map/sort/find/reduce` chains into LINQ, and explain deferred execution;
- run independent async calls concurrently with `Task.WhenAll`, pass a `CancellationToken`, and spot `.Result` / `async void`;
- open an unfamiliar ASP.NET Core solution, start at `Program.cs`, and trace a request from controller to service to repository;
- add an endpoint, a service method, a DI registration and a unit test to the sample.

**Done?** Open your team's code base and repeat the [reading guide](Season01/Ep10_RealCodebase/concepts/10_How_To_Read_A_Codebase.md) on it.

---

## 4. C# cheat sheet for JavaScript developers

### Program, types, variables

| JavaScript | C# |
|---|---|
| `node app.js` / `npm start` | `dotnet run` |
| `package.json` | `MyApp.csproj` |
| `npm install x` | `dotnet add package X` |
| `let n = 1` | `int n = 1;` or `var n = 1;` (type fixed at compile time) |
| `const NAME = "x"` | `const string Name = "x";` (literals) / `readonly` field |
| `number` | `int`, `long`, `double`, `decimal` (money, `9.99m`) |
| `"a"` or `'a'` | `"a"` is a `string`, `'a'` is a `char` |
| `` `Hi ${name}` `` | `$"Hi {name}"`, `$"{price:F2}"`, `$"{name,-10}"` |
| multi-line template | `"""` raw string `"""` |
| `===` | `==` (never coerces; strings compare by value) |
| `7 / 2` is `3.5` | `7 / 2` is `3` (int division); `7 / 2.0` is `3.5` |
| `parseInt(s)` | `int.Parse(s)` / `int.TryParse(s, out var n)` |
| `String(x)` | `x.ToString()` |
| `typeof x === "string"` | `x is string s` |
| `console.log(x)` | `Console.WriteLine(x)` |
| `// comment`, `/* */` | same, plus `/// <summary>` doc comments |

### Control flow

| JavaScript | C# |
|---|---|
| `if (items.length)` (truthy) | `if (items.Count > 0)` (must be `bool`) |
| `for (const x of xs)` | `foreach (var x in xs)` |
| `switch` with fall-through | `switch` requires `break`; no fall-through |
| lookup object for values | `var label = code switch { 200 => "OK", >= 500 => "Error", _ => "?" };` |
| `outer: for` + `break outer` | extract a method and `return` |

### Functions

| JavaScript | C# |
|---|---|
| `function add(a, b) { return a + b; }` | `static int Add(int a, int b) => a + b;` |
| `x => x * 2` | `x => x * 2` (type: `Func<int, int>`) |
| `() => console.log("hi")` | `() => Console.WriteLine("hi")` (type: `Action`) |
| `function f(a, b = 2)` | `void F(int a, int b = 2)` |
| `f({ verbose: true })` options object | named args: `F(1, verbose: true)` |
| `function sum(...nums)` | `int Sum(params int[] nums)` |
| `return { min, max }` + destructuring | `return (min, max);` and `var (min, max) = F();` |
| one function, many signatures via `typeof` | overloads: same name, different parameters |
| (none) | `ref` / `out` parameters: `int.TryParse(s, out int n)` |

### Collections

| JavaScript | C# |
|---|---|
| `[1, 2, 3]` growable | `new List<int> { 1, 2, 3 }` or `List<int> xs = [1, 2, 3];` |
| fixed array | `int[] a = new int[3];` |
| `arr.length` | `array.Length`, `list.Count` |
| `arr.push(x)` | `list.Add(x)` |
| `arr.includes(x)` | `list.Contains(x)` |
| `arr.at(-1)` / `slice(1, 3)` | `a[^1]` / `a[1..3]` |
| `new Map()` / object as map | `new Dictionary<string, int>()` |
| `map.get(k)` (undefined if missing) | `dict[k]` **throws**; use `dict.TryGetValue(k, out var v)` |
| `new Set()` | `new HashSet<T>()` |
| `arr.join(", ")` | `string.Join(", ", list)` |

### Objects and classes

| JavaScript | C# |
|---|---|
| `class A extends B` | `class A : B` (one base class, many interfaces) |
| `constructor(x) { this.x = x; }` | `public A(int x) { X = x; }` or `class A(int x)` (primary constructor) |
| `super(x)` / `super.m()` | `: base(x)` / `base.M()` |
| `#private` | `private` (default for members) |
| `get total() {}` | `public decimal Total => ...;` |
| fields created on assignment | `public string Name { get; set; } = "";` declared up front |
| `{ name: "Ann" }` literal | `new Person { Name = "Ann" }` (object initializer) |
| `{ ...p, age: 31 }` | `p with { Age = 31 }` (records) |
| deep-equal helper | `record Person(string Name, int Age);` compares by value |
| every method overridable | only `virtual`/`abstract` methods, overridden with `override` |
| TypeScript `interface` (erased) | `interface IRepo { ... }` (real, nominal, starts with `I`) |
| `import { A } from "./a.js"` | `using MyApp.Models;` (namespaces, not files) |
| `@Decorator()` | `[Attribute]` (metadata read by the framework) |
| monkey-patch a prototype | extension method: `public static int Words(this string s)` |

### Null

| JavaScript | C# |
|---|---|
| `null` and `undefined` | only `null`; unassigned locals do not compile |
| `a?.b?.c` | `a?.B?.C` |
| `x ?? "default"` | `x ?? "default"` |
| `x ??= []` | `x ??= new();` |
| TS `string \| null` | `string?` (warnings with `<Nullable>enable</Nullable>`) |
| TS `x!` | `x!` |
| `number \| null` | `int?` with `.HasValue`, `.Value`, `?? 0` |
| "Cannot read properties of null" | `NullReferenceException` |

### Arrays to LINQ

| JavaScript | C# (`using System.Linq;`) |
|---|---|
| `filter(fn)` | `Where(fn)` |
| `map(fn)` | `Select(fn)` |
| `flatMap(fn)` | `SelectMany(fn)` |
| `find(fn)` | `FirstOrDefault(fn)` |
| `some(fn)` / `every(fn)` | `Any(fn)` / `All(fn)` |
| `reduce((s, x) => s + x.p, 0)` | `Sum(x => x.P)` (or `Aggregate`) |
| `sort((a, b) => a.p - b.p)` | `OrderBy(x => x.P)` then `ThenBy(...)` |
| `slice(0, 5)` | `Take(5)`; paging `Skip(n).Take(m)` |
| `[...new Set(arr)]` | `Distinct()` |
| `Object.groupBy(arr, fn)` | `GroupBy(fn)` |
| eager arrays | lazy queries: add `.ToList()` to run and store |

### Async

| JavaScript | C# |
|---|---|
| `Promise<T>` | `Task<T>` (`Task` for void) |
| `async function f()` | `async Task<T> FAsync()` |
| `await p` | `await t` |
| `Promise.all([...])` | `await Task.WhenAll(...)` |
| `Promise.race([...])` | `await Task.WhenAny(...)` |
| `setTimeout` as a promise | `await Task.Delay(ms)` |
| `AbortController` / `signal` | `CancellationTokenSource` / `CancellationToken` |
| (cannot block) | never `.Result` / `.Wait()`; never `async void` |

### Errors and cleanup

| JavaScript | C# |
|---|---|
| `throw new Error("x")` | `throw new InvalidOperationException("x");` |
| `catch (e) { if (e instanceof X) }` | `catch (X ex) { }` and filters: `catch (X ex) when (cond)` |
| `throw e` (rethrow) | `throw;` (keeps the stack trace) |
| `try { } finally { h.close(); }` | `using var h = Open();` (`IDisposable`) |

### Naming conventions

`PascalCase` for types, methods, properties and constants; `camelCase` for locals and parameters;
`_camelCase` for private fields; `IName` for interfaces; `NameAsync` for async methods; one public type per file, file named after it.
