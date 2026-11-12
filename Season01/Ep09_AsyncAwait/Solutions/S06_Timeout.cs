namespace Ep09.Solutions;

public static class S06_Timeout
{
    static async Task<T> WithTimeout<T>(Task<T> task, TimeSpan timeout)
    {
        var finished = await Task.WhenAny(task, Task.Delay(timeout));
        if (finished != task)
            throw new TimeoutException($"Timed out after {timeout.TotalMilliseconds} ms");
        return await task;   // propagates the task's own exception, if any
        // .NET 6+ has this built in: await task.WaitAsync(timeout);
    }

    static async Task<string> DownloadAsync(string url, CancellationToken ct)
    {
        for (int chunk = 1; chunk <= 5; chunk++)
        {
            await Task.Delay(100, ct);   // throws OperationCanceledException when cancelled
            Console.WriteLine($"  {url}: chunk {chunk}/5");
        }
        return $"{url} complete";
    }

    static async Task<int> SlowAsync(int ms) { await Task.Delay(ms); return ms; }

    public static async Task Run()
    {
        Console.WriteLine(await WithTimeout(SlowAsync(50), TimeSpan.FromMilliseconds(200)));
        try
        {
            await WithTimeout(SlowAsync(500), TimeSpan.FromMilliseconds(100));
        }
        catch (TimeoutException ex)
        {
            Console.WriteLine(ex.Message);
        }

        using var cts = new CancellationTokenSource(TimeSpan.FromMilliseconds(250));
        try
        {
            Console.WriteLine(await DownloadAsync("big.iso", cts.Token));
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("download cancelled");
        }
    }
}
