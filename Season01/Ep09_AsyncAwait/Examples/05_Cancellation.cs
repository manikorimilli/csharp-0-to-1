namespace Ep09.Examples;

public static class Ex05_Cancellation
{
    // Convention: CancellationToken is the LAST parameter, often with `= default`
    static async Task<int> ProcessItemsAsync(int count, CancellationToken cancellationToken = default)
    {
        int done = 0;
        for (int i = 0; i < count; i++)
        {
            cancellationToken.ThrowIfCancellationRequested();   // check between steps
            await Task.Delay(100, cancellationToken);            // pass it down to every async call
            done++;
        }
        return done;
    }

    public static async Task Run()
    {
        // JS:  const controller = new AbortController();
        //      fetch(url, { signal: controller.signal });  controller.abort();
        // C#:  using var cts = new CancellationTokenSource();
        //      await DoAsync(cts.Token);                    cts.Cancel();
        using var cts = new CancellationTokenSource();
        cts.CancelAfter(TimeSpan.FromMilliseconds(350));          // auto-cancel (like AbortSignal.timeout)

        try
        {
            int done = await ProcessItemsAsync(10, cts.Token);
            Console.WriteLine($"finished {done}");
        }
        catch (OperationCanceledException)                       // TaskCanceledException derives from it
        {
            Console.WriteLine("cancelled after ~350 ms");
        }

        // Manual cancel
        using var cts2 = new CancellationTokenSource();
        var work = ProcessItemsAsync(10, cts2.Token);
        await Task.Delay(150);
        cts2.Cancel();
        try { await work; }
        catch (OperationCanceledException) { Console.WriteLine("cancelled manually"); }

        // In ASP.NET Core, actions can take a CancellationToken parameter: it fires when
        // the HTTP client disconnects. Pass it to EF Core / HttpClient calls.
        Console.WriteLine($"default token can be cancelled? {CancellationToken.None.CanBeCanceled}");
    }
}
