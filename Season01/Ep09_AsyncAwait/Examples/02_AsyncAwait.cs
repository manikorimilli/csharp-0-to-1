namespace Ep09.Examples;

public static class Ex02_AsyncAwait
{
    record Order(int Id, decimal Total);

    // `async` + return type Task<T>. Convention: the method name ends in Async.
    // JS: async function getOrderAsync(id) { await sleep(100); return { id, total: 99 }; }
    static async Task<Order> GetOrderAsync(int id)
    {
        await Task.Delay(100);                // simulate a database / HTTP call
        return new Order(id, id * 10m);       // you return a T, the compiler wraps it in Task<T>
    }

    static async Task SendEmailAsync(string to)   // async Task = "returns nothing"
    {
        await Task.Delay(50);
        Console.WriteLine($"  email sent to {to}");
    }

    // Async all the way: callers of async methods are async too
    static async Task<decimal> ProcessAsync(int orderId)
    {
        var order = await GetOrderAsync(orderId);
        await SendEmailAsync("customer@example.com");
        return order.Total;
    }

    public static async Task Run()
    {
        decimal total = await ProcessAsync(7);
        Console.WriteLine($"Processed, total {total}");

        // Async lambdas: Func<Task> / Func<Task<T>>
        Func<int, Task<Order>> loader = async id => await GetOrderAsync(id);
        Console.WriteLine((await loader(3)).Total);

        // Real APIs you'll await all the time:
        //   await httpClient.GetStringAsync(url)
        //   await File.ReadAllTextAsync(path)
        //   await dbContext.Orders.ToListAsync()
        //   await Task.Delay(ms)
        string path = Path.Combine(Path.GetTempPath(), "csharp-0-to-1-async.txt");
        await File.WriteAllTextAsync(path, "async file io");
        Console.WriteLine(await File.ReadAllTextAsync(path));

        // ValueTask<T> also exists (a cheaper Task for hot paths). Treat it like Task when reading code.
    }
}
