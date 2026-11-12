# Ep07 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <functional>
#include <iostream>
#include <stdexcept>
#include <string>

template <typename T>
T clampValue(T v, T lo, T hi) {
    if (lo > hi) throw std::invalid_argument("lo > hi");
    return v < lo ? lo : (v > hi ? hi : v);
}

class Timer {   // RAII: prints elapsed time when it goes out of scope
    std::string label;
public:
    explicit Timer(std::string l) : label(std::move(l)) { std::cout << "start " << label << "\n"; }
    ~Timer() { std::cout << "end " << label << "\n"; }
};

void forEachSquare(int n, const std::function<void(int)>& callback) {
    for (int i = 1; i <= n; ++i) callback(i * i);
}

int main() {
    Timer t("main");
    std::cout << clampValue(15, 0, 10) << " " << clampValue(2.5, 3.0, 4.0) << "\n";
    forEachSquare(3, [](int sq) { std::cout << sq << " "; });
    try { clampValue(1, 5, 0); }
    catch (const std::invalid_argument& e) { std::cout << "\nerror: " << e.what() << "\n"; }
}
```

Use a generic method with an `IComparable<T>` constraint, an `IDisposable` class with `using`, and `Action<int>`.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
static int Test()
{
    try { Console.WriteLine("try"); return 1; }
    finally { Console.WriteLine("finally"); }
}
Console.WriteLine(Test());

var actions = new List<Action>();
for (int i = 0; i < 3; i++) actions.Add(() => Console.Write(i));
foreach (var a in actions) a();
Console.WriteLine();

var actions2 = new List<Action>();
foreach (var j in new[] { 0, 1, 2 }) actions2.Add(() => Console.Write(j));
foreach (var a in actions2) a();
Console.WriteLine();

Func<int, int> f = x => x + 1;
Func<int, int> g = x => x * 10;
Console.WriteLine(g(f(2)));

Action? chain = () => Console.Write("A");
chain += () => Console.Write("B");
chain += () => Console.Write("C");
chain -= () => Console.Write("B");
chain?.Invoke();
Console.WriteLine();

try { throw new ArgumentNullException("x"); }
catch (ArgumentException e) when (e.ParamName == "y") { Console.WriteLine("filter y"); }
catch (ArgumentException e) { Console.WriteLine($"caught {e.GetType().Name}"); }
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Two compile errors and one `NullReferenceException`.

```csharp
var d = new Downloader();
d.Download("file.zip");                      // nobody subscribed yet
Console.WriteLine(Largest(new[] { 3, 9, 4 }));
Console.WriteLine("hello".Shout());

static T Largest<T>(T[] items)
{
    T best = items[0];
    foreach (var item in items)
        if (item > best) best = item;
    return best;
}

class Downloader
{
    public event EventHandler<string>? Completed;
    public void Download(string file) => Completed.Invoke(this, file);
}

class StringHelpers
{
    public static string Shout(this string s) => s.ToUpper() + "!";
}
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: a generic Result type

Write `record Result<T>` that is either a success with a `Value` or a failure with an `Error` string:
- static factories `Result<T>.Ok(T value)` and `Result<T>.Fail(string error)`,
- `Result<TOut> Map<TOut>(Func<T, TOut> f)` (only runs `f` on success),
- `TOut Match<TOut>(Func<T, TOut> onOk, Func<string, TOut> onFail)`.

Use it for `Result<int> ParseAge(string s)` and chain `.Map(age => age >= 18)`.
Solution: [Solutions/S04_Result.cs](Solutions/S04_Result.cs)

---

## 5. Refactor: Func and extension methods

```csharp
static List<Product> GetExpensive(List<Product> products)
{
    var result = new List<Product>();
    foreach (var p in products) if (p.Price > 100) result.Add(p);
    return result;
}
static List<Product> GetOutOfStock(List<Product> products)
{
    var result = new List<Product>();
    foreach (var p in products) if (p.Stock == 0) result.Add(p);
    return result;
}
static class StringUtils
{
    public static string Capitalize(string s) => s.Length == 0 ? s : char.ToUpper(s[0]) + s[1..];
}
// usage: StringUtils.Capitalize(p.Name)
```

Replace the two filters with one `Filter(List<Product>, Func<Product, bool>)` method, and turn `Capitalize` into an extension method.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: a sensor with an event

Write `class TemperatureSensor` with `event EventHandler<ThresholdEventArgs>? ThresholdExceeded`,
a `Threshold` property and a `Record(double value)` method that raises the event when the value is above the threshold.
Subscribe a logger and an alarm handler, record some values, unsubscribe the alarm, and record again.
Solution: [Solutions/S06_Sensor.cs](Solutions/S06_Sensor.cs)

---

## 7. Write: patterns

Write `static string Classify(object? input)` with **one** switch expression that returns:
- `"nothing"` for `null`
- `"zero"`, `"negative int"`, `"small int"` (1 to 9) or `"big int"`
- `"empty text"` for `""`, otherwise `"text of N chars"`
- for an `int[]`: `"empty array"`, `"one item: X"`, `"starts with 0"`, or `"array ending in X"`
- `"point on axis"` for a `(int X, int Y)` tuple where X or Y is 0, otherwise `"point"`
- `"unknown"` for anything else

Solution: [Solutions/S07_Patterns.cs](Solutions/S07_Patterns.cs)

---

## Episode Challenge: retry helper

Build a small retry utility:
1. `class TransientException : Exception` for errors worth retrying.
2. `class RetryPolicy` with `MaxAttempts` and an `event EventHandler<RetryEventArgs>? Retrying` (attempt number + exception).
3. A generic `T Execute<T>(Func<T> action)` that retries **only** `TransientException` (use an exception filter `when`),
   rethrows with `throw;` on the last attempt, and lets other exceptions escape immediately.
4. A `using`-based `TimingScope : IDisposable` that prints how long `Execute` took.
5. An extension method `WithRetry<T>(this Func<T> action, RetryPolicy policy)`.
6. Demo: an operation that fails twice with `TransientException` and then succeeds; one that always fails; one that throws `InvalidOperationException`.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
