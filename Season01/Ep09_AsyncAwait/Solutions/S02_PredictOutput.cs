namespace Ep09.Solutions;

public static class S02_PredictOutput
{
    static async Task<int> WorkAsync(string name, int ms)
    {
        Console.WriteLine($"start {name}");   // runs synchronously, before the first await
        await Task.Delay(ms);
        Console.WriteLine($"end {name}");
        return ms;
    }

    public static async Task Run()
    {
        var t1 = WorkAsync("A", 200);
        var t2 = WorkAsync("B", 100);
        Console.WriteLine("both started");
        var first = await Task.WhenAny(t1, t2);
        Console.WriteLine($"first: {await first}");
        var all = await Task.WhenAll(t1, t2);
        Console.WriteLine(all.Sum());
        // start A
        // start B
        // both started
        // end B
        // first: 100
        // end A
        // 300
    }
}
