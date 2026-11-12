namespace Ep08.Examples;

public static class Ex06_Materializing
{
    public static void Run()
    {
        // LINQ operators return IEnumerable<T>: a lazy sequence, not a list.
        // ToList / ToArray / ToDictionary / ToHashSet run the query and store the results.
        List<string> names = Data.Customers.Select(c => c.Name).ToList();
        string[] countries = Data.Customers.Select(c => c.Country).Distinct().ToArray();
        HashSet<string> categories = Data.Products.Select(p => p.Category).ToHashSet();
        Console.WriteLine($"{names.Count} names, countries {string.Join(",", countries)}, {categories.Count} categories");

        // ToDictionary: key selector (+ optional value selector). Throws on duplicate keys!
        Dictionary<int, Product> productById = Data.Products.ToDictionary(p => p.Id);
        Dictionary<string, decimal> priceByName = Data.Products.ToDictionary(p => p.Name, p => p.Price);
        Console.WriteLine($"{productById[3].Name} {priceByName["Pen"]}");

        // Other everyday operators
        var page2 = Data.Products.OrderBy(p => p.Id).Skip(2).Take(2);     // pagination
        Console.WriteLine(string.Join(",", page2.Select(p => p.Name)));

        var distinctCountries = Data.Customers.Select(c => c.Country).Distinct();
        Console.WriteLine(string.Join(",", distinctCountries));

        var uniqueByCountry = Data.Customers.DistinctBy(c => c.Country).Select(c => c.Name);
        Console.WriteLine(string.Join(",", uniqueByCountry));

        var chunks = Enumerable.Range(1, 7).Chunk(3);                       // [1,2,3] [4,5,6] [7]
        Console.WriteLine(string.Join(" ", chunks.Select(c => $"[{string.Join(",", c)}]")));

        var medals = new[] { "gold", "silver", "bronze" };
        var pairs = names.Zip(medals, (n, m) => $"{n}:{m}");        // stops at the shorter one
        Console.WriteLine(string.Join(" ", pairs));

        Console.WriteLine(string.Join(",", Enumerable.Range(1, 5)));        // JS: [...Array(5).keys()]

        // Return types in real code: methods often return IEnumerable<T> or IReadOnlyList<T>.
        // Call ToList() when you need to iterate more than once or need Count/indexing.
    }
}
