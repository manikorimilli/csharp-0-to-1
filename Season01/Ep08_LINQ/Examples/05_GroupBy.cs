namespace Ep08.Examples;

public static class Ex05_GroupBy
{
    public static void Run()
    {
        // JS: Object.groupBy(products, p => p.category)  (or lodash groupBy)
        // C#: GroupBy returns IGrouping<TKey, TElement>: a Key plus the items
        var byCategory = Data.Products.GroupBy(p => p.Category);
        foreach (var group in byCategory)
            Console.WriteLine($"{group.Key}: {string.Join(", ", group.Select(p => p.Name))}");

        // Most common use: group, then summarize each group
        var summary = Data.Products
            .GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count(),
                Total = g.Sum(p => p.Price),
                Cheapest = g.MinBy(p => p.Price)!.Name
            })
            .OrderByDescending(x => x.Total);
        foreach (var s in summary)
            Console.WriteLine($"{s.Category,-12} count={s.Count} total={s.Total,8} cheapest={s.Cheapest}");

        // Group by a composite key using a tuple or anonymous type
        var byCountryVip = Data.Customers.GroupBy(c => (c.Country, c.IsVip));
        foreach (var g in byCountryVip)
            Console.WriteLine($"{g.Key.Country} vip={g.Key.IsVip}: {g.Count()}");

        // CountBy (.NET 9) does not exist on .NET 8; GroupBy + Count is the way.
        // ToLookup: like GroupBy but executes immediately and supports lookup by key
        var lookup = Data.Products.ToLookup(p => p.Category);
        Console.WriteLine($"Furniture items: {lookup["Furniture"].Count()}, Toys: {lookup["Toys"].Count()}");
    }
}
