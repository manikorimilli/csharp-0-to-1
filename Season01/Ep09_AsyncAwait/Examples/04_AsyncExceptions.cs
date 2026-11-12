namespace Ep09.Examples;

public static class Ex04_AsyncExceptions
{
    static async Task<string> LoadAsync(string name, bool fail)
    {
        await Task.Delay(50);
        if (fail) throw new InvalidOperationException($"{name} failed");
        return name;
    }

    public static async Task Run()
    {
        // try/catch around await works exactly like JS async/await
        try
        {
            await LoadAsync("config", fail: true);
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"caught: {ex.Message}");
        }

        // The exception is stored in the Task until someone awaits it.
        // JS: an un-awaited rejected promise -> "unhandled rejection".
        Task<string> t = LoadAsync("background", fail: true);
        await Task.Delay(100);
        Console.WriteLine($"task status: {t.Status}");                 // Faulted, nobody has seen the error yet
        try { await t; } catch (Exception ex) { Console.WriteLine($"observed later: {ex.Message}"); }

        // WhenAll: awaiting throws the FIRST exception; all of them are on the task
        var all = Task.WhenAll(
            LoadAsync("a", fail: true),
            LoadAsync("b", fail: false),
            LoadAsync("c", fail: true));
        try
        {
            await all;
        }
        catch (Exception first)
        {
            Console.WriteLine($"await gave: {first.Message}");
            foreach (var inner in all.Exception!.InnerExceptions)
                Console.WriteLine($"  all errors: {inner.Message}");
        }
        // JS Promise.all also rejects with the first error;
        // Promise.allSettled-style code checks each task's Status instead.
    }
}
