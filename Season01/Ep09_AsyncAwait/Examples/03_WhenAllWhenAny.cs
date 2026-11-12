using System.Diagnostics;

namespace Ep09.Examples;

public static class Ex03_WhenAllWhenAny
{
    static async Task<int> FetchStockAsync(string sku, int delayMs)
    {
        await Task.Delay(delayMs);
        return sku.Length * 10;
    }

    public static async Task Run()
    {
        var sw = Stopwatch.StartNew();

        // Sequential: ~600 ms total
        int a = await FetchStockAsync("A", 200);
        int b = await FetchStockAsync("BB", 200);
        int c = await FetchStockAsync("CCC", 200);
        Console.WriteLine($"sequential: {a + b + c} in {sw.ElapsedMilliseconds} ms");

        // Concurrent: start all, then await together. ~200 ms total.
        // JS: const [a, b, c] = await Promise.all([f("A"), f("BB"), f("CCC")]);
        sw.Restart();
        int[] results = await Task.WhenAll(
            FetchStockAsync("A", 200),
            FetchStockAsync("BB", 200),
            FetchStockAsync("CCC", 200));
        Console.WriteLine($"WhenAll:    {results.Sum()} in {sw.ElapsedMilliseconds} ms");

        // Common real-world shape: one task per item with LINQ
        sw.Restart();
        string[] skus = { "X", "YY", "ZZZ", "WWWW" };
        var tasks = skus.Select(s => FetchStockAsync(s, 150));
        int[] stock = await Task.WhenAll(tasks);
        Console.WriteLine($"WhenAll over {skus.Length} items: [{string.Join(",", stock)}] in {sw.ElapsedMilliseconds} ms");

        // WhenAny = Promise.race: returns the FIRST task that finishes (the task, not its result)
        sw.Restart();
        var slow = FetchStockAsync("slow", 400);
        var fast = FetchStockAsync("fast!", 100);
        Task<int> winner = await Task.WhenAny(slow, fast);
        Console.WriteLine($"WhenAny: winner is {(winner == fast ? "fast" : "slow")} with {await winner} after {sw.ElapsedMilliseconds} ms");
        await slow;   // the loser keeps running; it is not cancelled automatically

        // Timeout pattern (.NET 6+): task.WaitAsync(TimeSpan) throws TimeoutException
        try
        {
            await FetchStockAsync("too slow", 500).WaitAsync(TimeSpan.FromMilliseconds(100));
        }
        catch (TimeoutException)
        {
            Console.WriteLine("WaitAsync timed out after 100 ms");
        }
    }
}
