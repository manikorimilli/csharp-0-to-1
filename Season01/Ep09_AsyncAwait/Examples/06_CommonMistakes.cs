namespace Ep09.Examples;

public static class Ex06_CommonMistakes
{
    static async Task<int> GetNumberAsync()
    {
        await Task.Delay(50);
        return 42;
    }

    // MISTAKE 1: async void. The caller cannot await it and exceptions crash the process.
    // Only acceptable for UI event handlers (button_Click). Use `async Task` instead.
    //   static async void SaveBad() { ... }
    static async Task SaveGood() => await Task.Delay(10);

    public static async Task Run()
    {
        // MISTAKE 2: blocking on async code with .Result or .Wait().
        // It wastes a thread, wraps errors in AggregateException, and can DEADLOCK
        // in apps with a synchronization context (old ASP.NET, WinForms, WPF).
        //   int n = GetNumberAsync().Result;    // don't
        int n = await GetNumberAsync();          // do
        Console.WriteLine($"awaited {n}");

        // MISTAKE 3: forgetting await. The work runs unobserved, errors are lost.
        // The compiler warns (CS4014) when the result of an async call is ignored.
        //   SaveGood();                         // warning CS4014: not awaited
        await SaveGood();
        Console.WriteLine("saved (awaited)");

        // If you really mean fire-and-forget, discard explicitly and handle errors inside:
        _ = Task.Run(async () =>
        {
            try { await Task.Delay(10); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        });

        // MISTAKE 4: awaiting in a loop when the calls are independent (slow).
        //   foreach (var id in ids) results.Add(await LoadAsync(id));
        // Prefer: await Task.WhenAll(ids.Select(LoadAsync));   (see example 03)

        // MISTAKE 5: Task.Run around I/O. Task.Run moves CPU work to the thread pool.
        // I/O methods (HttpClient, File...Async, EF Core) are already asynchronous.
        int cpuResult = await Task.Run(() => Enumerable.Range(1, 1_000).Sum());   // OK: CPU work
        Console.WriteLine($"cpu result {cpuResult}");

        // MISTAKE 6: mixing sync and async versions. Inside an async method call
        // ReadAllTextAsync, not ReadAllText; SaveChangesAsync, not SaveChanges.

        // Library code note: you may see `.ConfigureAwait(false)` on awaits in libraries.
        // It means "don't resume on the original context". App code in ASP.NET Core does not need it.
    }
}
