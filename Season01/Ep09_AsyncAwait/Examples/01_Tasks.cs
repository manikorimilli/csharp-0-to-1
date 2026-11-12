namespace Ep09.Examples;

public static class Ex01_Tasks
{
    // Task<T> = Promise<T>. Task (no T) = Promise<void>.
    // JS:  function getUser(id) { return new Promise(r => setTimeout(() => r("Ann"), 100)); }
    // ContinueWith is the old .then(). You will rarely write it; `async`/`await` (next lesson) replaced it.
    static Task<string> GetUserName(int id) =>
        Task.Delay(100).ContinueWith(_ => id == 1 ? "Ann" : "Bob");

    static Task SaveAsync() => Task.Delay(50);                        // Promise<void>

    public static async Task Run()
    {
        // Creating a Task starts the work right away (like a Promise, unlike a lazy thunk).
        Task<string> pending = GetUserName(1);
        Console.WriteLine($"Status right after starting: {pending.Status}");

        string name = await pending;                 // JS: const name = await pending;
        Console.WriteLine($"Got {name}, status: {pending.Status}");

        await SaveAsync();
        Console.WriteLine("Saved");

        // Already-completed tasks (JS: Promise.resolve(42))
        Task<int> ready = Task.FromResult(42);
        Console.WriteLine(await ready);
        Task nothing = Task.CompletedTask;           // Promise.resolve()
        await nothing;

        // Task.Delay = await new Promise(r => setTimeout(r, ms))
        var start = DateTime.Now;
        await Task.Delay(TimeSpan.FromMilliseconds(120));
        Console.WriteLine($"Waited ~{(DateTime.Now - start).TotalMilliseconds:F0} ms");

        // Key difference: JS has one thread + an event loop. .NET has a thread pool:
        // after an await, your code may continue on a DIFFERENT thread.
        Console.WriteLine($"Thread now: {Environment.CurrentManagedThreadId}");
    }
}
