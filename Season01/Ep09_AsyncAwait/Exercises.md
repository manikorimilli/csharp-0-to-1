# Ep09 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.
Use `Task.Delay` to simulate slow I/O.

---

## 1. Convert C++ to C#

```cpp
#include <chrono>
#include <future>
#include <iostream>
#include <thread>

int slowSquare(int x) {
    std::this_thread::sleep_for(std::chrono::milliseconds(200));
    return x * x;
}

int main() {
    std::future<int> a = std::async(std::launch::async, slowSquare, 3);
    std::future<int> b = std::async(std::launch::async, slowSquare, 4);
    std::cout << "waiting...\n";
    int sum = a.get() + b.get();
    std::cout << "sum = " << sum << "\n";
}
```

Write the C# version with an `async Task<int> SlowSquareAsync(int x)` using `Task.Delay`, start both, then await both with `Task.WhenAll`.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
static async Task<int> WorkAsync(string name, int ms)
{
    Console.WriteLine($"start {name}");
    await Task.Delay(ms);
    Console.WriteLine($"end {name}");
    return ms;
}

var t1 = WorkAsync("A", 200);
var t2 = WorkAsync("B", 100);
Console.WriteLine("both started");
var first = await Task.WhenAny(t1, t2);
Console.WriteLine($"first: {await first}");
var all = await Task.WhenAll(t1, t2);
Console.WriteLine(all.Sum());
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Three async mistakes. The program should always print `starting`, `saved 3`, then `done`, in that order.

```csharp
LogAsync("starting");
int count = CountAsync().Result;
SaveAsync(count);
Console.WriteLine("done");

static async void LogAsync(string msg) { await Task.Delay(10); Console.WriteLine(msg); }
static async Task<int> CountAsync() { await Task.Delay(10); return 3; }
static async Task SaveAsync(int n) { await Task.Delay(50); Console.WriteLine($"saved {n}"); }
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: parallel price lookup

Write `async Task<decimal> GetPriceAsync(string sku)` that waits a random-ish delay (e.g. `sku.Length * 50` ms)
and throws `KeyNotFoundException` for the sku `"GHOST"`.
Then look up `{ "PEN", "LAMP", "GHOST", "DESK" }` **concurrently** and build a `Dictionary<string, decimal?>`
where failed lookups are `null`. One failing sku must not lose the other results.
Hint: wrap each call in a small `async` lambda with its own try/catch, then `Task.WhenAll`.
Solution: [Solutions/S04_PriceLookup.cs](Solutions/S04_PriceLookup.cs)

---

## 5. Refactor: make it properly async

```csharp
static int LoadUserCount()
{
    Thread.Sleep(300);
    return 120;
}

static string BuildDashboard()
{
    int users = Task.Run(() => LoadUserCount()).Result;
    int orders = GetOrderCountAsync().Result;
    int tickets = GetTicketCountAsync().Result;
    return $"users={users} orders={orders} tickets={tickets}";
}

static async Task<int> GetOrderCountAsync() { await Task.Delay(300); return 45; }
static async Task<int> GetTicketCountAsync() { await Task.Delay(300); return 7; }
```

Make `BuildDashboardAsync` fully async (no `.Result`, no `Thread.Sleep`) and run the three loads concurrently. It should take about 300 ms instead of 900 ms.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: timeout helpers

1. Write `static async Task<T> WithTimeout<T>(Task<T> task, TimeSpan timeout)` using `Task.WhenAny` and `Task.Delay`; throw `TimeoutException` if the delay wins.
2. Write `static async Task<string> DownloadAsync(string url, CancellationToken ct)` that simulates 5 chunks of 100 ms and honors cancellation,
   then call it with a `CancellationTokenSource` that cancels after 250 ms.

Solution: [Solutions/S06_Timeout.cs](Solutions/S06_Timeout.cs)

---

## Episode Challenge: async downloader

Simulate downloading 6 "files" (`file1` to `file6`), each taking `100 * n` ms, where `file4` always fails.

Requirements:
- At most **2 downloads at a time** (`SemaphoreSlim(2)`: `await sem.WaitAsync(ct)` ... `finally { sem.Release(); }`).
- The whole batch is cancelled after 1 second with a `CancellationTokenSource`.
- Each result is a `record DownloadResult(string File, bool Ok, string Message)`: success, failure, or cancelled.
- Use `Task.WhenAll` to collect all results and print a summary such as `4 ok, 1 failed, 1 cancelled` (exact numbers depend on timing).
- No `.Result`, no `async void`.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
