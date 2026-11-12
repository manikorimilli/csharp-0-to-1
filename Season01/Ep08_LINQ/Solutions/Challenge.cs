namespace Ep08.Solutions;

public static class Challenge
{
    record Sale(DateTime Date, Customer Customer, Product Product, int Quantity)
    {
        public decimal Amount => Quantity * Product.Price;
    }

    public static void Run()
    {
        var customers = Data.Customers.ToDictionary(c => c.Id);
        var products = Data.Products.ToDictionary(p => p.Id);

        // Flatten once, materialize once
        var sales = Data.Orders
            .SelectMany(o => o.Lines, (o, l) => new Sale(o.Date, customers[o.CustomerId], products[l.ProductId], l.Quantity))
            .ToList();

        Console.WriteLine("Revenue by month:");
        foreach (var m in sales.GroupBy(s => s.Date.ToString("yyyy-MM")).OrderBy(g => g.Key))
            Console.WriteLine($"  {m.Key}  {m.Sum(s => s.Amount),8}");

        Console.WriteLine("Revenue by category:");
        var byCategory = sales
            .GroupBy(s => s.Product.Category)
            .Select(g => (Category: g.Key, Revenue: g.Sum(s => s.Amount)))
            .OrderByDescending(x => x.Revenue);
        foreach (var (category, revenue) in byCategory)
            Console.WriteLine($"  {category,-12} {revenue,8}");

        var best = sales
            .GroupBy(s => s.Customer.Name)
            .Select(g => (Name: g.Key, Revenue: g.Sum(s => s.Amount)))
            .MaxBy(x => x.Revenue);
        Console.WriteLine($"Best customer: {best.Name} ({best.Revenue})");

        decimal total = sales.Sum(s => s.Amount);
        decimal vip = sales.Where(s => s.Customer.IsVip).Sum(s => s.Amount);
        Console.WriteLine($"VIP share of revenue: {vip / total:P1}");

        var soldIds = sales.Select(s => s.Product.Id).ToHashSet();
        var neverSold = Data.Products.Where(p => !soldIds.Contains(p.Id)).Select(p => p.Name);
        Console.WriteLine($"Products never sold: {(neverSold.Any() ? string.Join(", ", neverSold) : "none")}");
    }
}
