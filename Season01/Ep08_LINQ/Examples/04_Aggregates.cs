namespace Ep08.Examples;

public static class Ex04_Aggregates
{
    public static void Run()
    {
        var products = Data.Products;

        // JS some / every
        Console.WriteLine(products.Any(p => p.Price > 1000));       // some
        Console.WriteLine(products.All(p => p.Price > 0));          // every
        Console.WriteLine(products.Any());                          // "is not empty"

        // Count with or without a filter
        Console.WriteLine(products.Count(p => p.Category == "Furniture"));

        // JS reduce for common cases has direct helpers
        Console.WriteLine(products.Sum(p => p.Price));
        Console.WriteLine(products.Average(p => p.Price).ToString("F2"));
        Console.WriteLine(products.Min(p => p.Price));
        Console.WriteLine(products.Max(p => p.Price));

        // MaxBy / MinBy (.NET 6+): the ITEM with the max value, not the value
        Console.WriteLine(products.MaxBy(p => p.Price)?.Name);

        // Aggregate = JS reduce (rarely needed thanks to the helpers above)
        // JS: names.reduce((acc, n) => acc + "-" + n)
        var joined = products.Select(p => p.Name).Aggregate((acc, n) => acc + "-" + n);
        Console.WriteLine(joined);
        var total = products.Aggregate(0m, (acc, p) => acc + p.Price);   // with a seed
        Console.WriteLine(total);

        // Contains
        Console.WriteLine(new[] { "NO", "US" }.Contains("US"));

        // Gotcha: Sum/Average/Max on an EMPTY sequence: Sum gives 0, Average and Max THROW.
        var empty = new List<decimal>();
        Console.WriteLine(empty.Sum());
        Console.WriteLine(empty.DefaultIfEmpty(0).Average());   // safe average
    }
}
