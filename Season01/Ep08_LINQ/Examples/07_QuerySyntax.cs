namespace Ep08.Examples;

public static class Ex07_QuerySyntax
{
    public static void Run()
    {
        // Method syntax (most common in modern code)
        var method = Data.Products
            .Where(p => p.Price > 100)
            .OrderBy(p => p.Price)
            .Select(p => p.Name);

        // Query syntax: SQL-like keywords. Compiles to the SAME method calls.
        var query =
            from p in Data.Products
            where p.Price > 100
            orderby p.Price
            select p.Name;

        Console.WriteLine(string.Join(",", method));
        Console.WriteLine(string.Join(",", query));

        // Query syntax shines for joins and `let`
        var orderSummaries =
            from o in Data.Orders
            join c in Data.Customers on o.CustomerId equals c.Id
            let itemCount = o.Lines.Sum(l => l.Quantity)
            where itemCount > 1
            orderby o.Date
            select new { o.Id, Customer = c.Name, itemCount };
        foreach (var s in orderSummaries)
            Console.WriteLine($"Order {s.Id} by {s.Customer}: {s.itemCount} items");

        // The same join in method syntax is noisier:
        var sameJoin = Data.Orders
            .Join(Data.Customers, o => o.CustomerId, c => c.Id, (o, c) => new { o.Id, Customer = c.Name });
        Console.WriteLine(sameJoin.Count());

        // group ... by ... into
        var grouped =
            from p in Data.Products
            group p by p.Category into g
            select new { Category = g.Key, Count = g.Count() };
        foreach (var g in grouped) Console.WriteLine($"{g.Category}: {g.Count}");

        // You can mix: (from ... select ...).ToList()
    }
}
