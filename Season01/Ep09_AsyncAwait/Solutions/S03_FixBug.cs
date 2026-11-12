namespace Ep09.Solutions;

public static class S03_FixBug
{
    // Fix 1: async void -> async Task, so the caller can await it (and see its exceptions).
    static async Task LogAsync(string msg) { await Task.Delay(10); Console.WriteLine(msg); }
    static async Task<int> CountAsync() { await Task.Delay(10); return 3; }
    static async Task SaveAsync(int n) { await Task.Delay(50); Console.WriteLine($"saved {n}"); }

    public static async Task Run()
    {
        await LogAsync("starting");
        int count = await CountAsync();   // Fix 2: await instead of blocking with .Result
        await SaveAsync(count);           // Fix 3: missing await (CS4014): "done" printed first or never saved
        Console.WriteLine("done");
    }
}
