namespace Ep08.Solutions;

public static class S04_SalesQueries
{
    public static void Run()
    {
        var priceById = Data.Products.ToDictionary(p => p.Id, p => p.Price);
        var nameById = Data.Products.ToDictionary(p => p.Id, p => p.Name);

        // 1. Order totals
        var orderTotals = Data.Orders.ToDictionary(
            o => o.Id,
            o => o.Lines.Sum(l => l.Quantity * priceById[l.ProductId]));
        foreach (var (id, total) in orderTotals)
            Console.WriteLine($"Order {id}: {total}");

        // 2. Customers without orders
        var buyerIds = Data.Orders.Select(o => o.CustomerId).ToHashSet();
        var noOrders = Data.Customers.Where(c => !buyerIds.Contains(c.Id)).Select(c => c.Name);
        Console.WriteLine($"No orders: {string.Join(", ", noOrders)}");

        // 3. Top 2 products by quantity sold
        var top2 = Data.Orders
            .SelectMany(o => o.Lines)
            .GroupBy(l => l.ProductId)
            .Select(g => new { Name = nameById[g.Key], Quantity = g.Sum(l => l.Quantity) })
            .OrderByDescending(x => x.Quantity)
            .Take(2);
        Console.WriteLine($"Top 2: {string.Join(", ", top2.Select(x => $"{x.Name} ({x.Quantity})"))}");

        // 4. Any / All
        Console.WriteLine($"Any order > 1000: {orderTotals.Values.Any(t => t > 1000)}");
        Console.WriteLine($"All orders have lines: {Data.Orders.All(o => o.Lines.Any())}");
    }
}
