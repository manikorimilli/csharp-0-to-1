using System.Diagnostics;

namespace Ep09.Solutions;

public static class S05_Refactor
{
    static async Task<int> LoadUserCountAsync()
    {
        await Task.Delay(300);   // was Thread.Sleep: blocked a thread for nothing
        return 120;
    }

    static async Task<int> GetOrderCountAsync() { await Task.Delay(300); return 45; }
    static async Task<int> GetTicketCountAsync() { await Task.Delay(300); return 7; }

    static async Task<string> BuildDashboardAsync()
    {
        var usersTask = LoadUserCountAsync();     // start all three
        var ordersTask = GetOrderCountAsync();
        var ticketsTask = GetTicketCountAsync();

        await Task.WhenAll(usersTask, ordersTask, ticketsTask);

        // Safe to read .Result here: every task is already complete.
        // (Or: var users = await usersTask; ... which is also instant now.)
        return $"users={usersTask.Result} orders={ordersTask.Result} tickets={ticketsTask.Result}";
    }

    public static async Task Run()
    {
        var sw = Stopwatch.StartNew();
        Console.WriteLine(await BuildDashboardAsync());
        Console.WriteLine($"took ~{sw.ElapsedMilliseconds} ms");
    }
}
