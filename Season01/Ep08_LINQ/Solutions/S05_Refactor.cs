namespace Ep08.Solutions;

public static class S05_Refactor
{
    public static void Run()
    {
        var result = Data.Customers
            .Where(c => c.Country == "US")
            .Select(c => new { c.Name, Count = Data.Orders.Count(o => o.CustomerId == c.Id) })
            .Where(x => x.Count > 0)
            .Select(x => $"{x.Name.ToUpper()} ({x.Count})")
            .OrderBy(s => s);

        var maxName = Data.Products.MaxBy(p => p.Price)?.Name ?? "";

        Console.WriteLine($"{string.Join(", ", result)} | {maxName}");
    }
}
