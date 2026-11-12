namespace Ep07.Solutions;

public static class S05StringExtensions
{
    public static string Capitalize(this string s) => s.Length == 0 ? s : char.ToUpper(s[0]) + s[1..];
}

public static class S05_Refactor
{
    record Product(string Name, decimal Price, int Stock);

    static List<Product> Filter(List<Product> products, Func<Product, bool> predicate)
    {
        var result = new List<Product>();
        foreach (var p in products)
            if (predicate(p)) result.Add(p);
        return result;
        // In Ep08 this whole method becomes: products.Where(predicate).ToList()
    }

    public static void Run()
    {
        var products = new List<Product>
        {
            new("laptop", 1200m, 3), new("mouse", 25m, 0), new("monitor", 300m, 0)
        };

        var expensive = Filter(products, p => p.Price > 100);
        var outOfStock = Filter(products, p => p.Stock == 0);

        foreach (var p in expensive) Console.Write($"{p.Name.Capitalize()} ");
        Console.WriteLine();
        foreach (var p in outOfStock) Console.Write($"{p.Name.Capitalize()} ");
        Console.WriteLine();
    }
}
