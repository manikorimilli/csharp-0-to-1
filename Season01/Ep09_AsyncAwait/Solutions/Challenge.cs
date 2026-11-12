using System.Diagnostics;

namespace Ep09.Solutions;

public static class Challenge
{
    record DownloadResult(string File, bool Ok, string Message);

    static async Task<DownloadResult> DownloadAsync(int n, SemaphoreSlim gate, Stopwatch clock, CancellationToken ct)
    {
        string file = $"file{n}";
        try
        {
            await gate.WaitAsync(ct);            // wait for a free slot (or cancellation)
            try
            {
                Console.WriteLine($"  {clock.ElapsedMilliseconds,4} ms  start {file}");
                await Task.Delay(100 * n, ct);
                if (n == 4) throw new IOException("connection reset");
                Console.WriteLine($"  {clock.ElapsedMilliseconds,4} ms  done  {file}");
                return new DownloadResult(file, true, "ok");
            }
            finally
            {
                gate.Release();                  // always free the slot
            }
        }
        catch (OperationCanceledException)
        {
            return new DownloadResult(file, false, "cancelled");
        }
        catch (IOException ex)
        {
            return new DownloadResult(file, false, $"failed: {ex.Message}");
        }
    }

    public static async Task Run()
    {
        using var gate = new SemaphoreSlim(2);                          // max 2 concurrent downloads
        using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(1));
        var clock = Stopwatch.StartNew();

        var tasks = Enumerable.Range(1, 6).Select(n => DownloadAsync(n, gate, clock, cts.Token));
        DownloadResult[] results = await Task.WhenAll(tasks);

        foreach (var r in results)
            Console.WriteLine($"{r.File}: {r.Message}");

        int ok = results.Count(r => r.Ok);
        int failed = results.Count(r => r.Message.StartsWith("failed"));
        int cancelled = results.Count(r => r.Message == "cancelled");
        Console.WriteLine($"{ok} ok, {failed} failed, {cancelled} cancelled");
    }
}
