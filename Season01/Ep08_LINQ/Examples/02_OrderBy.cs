namespace Ep08.Examples;

public static class Ex02_OrderBy
{
    public static void Run()
    {
        // JS: [...products].sort((a, b) => a.price - b.price)   (sort MUTATES in JS)
        // C#: products.OrderBy(p => p.Price)                      (returns a NEW sequence)
        var byPrice = Data.Products.OrderBy(p => p.Price);
        Console.WriteLine(string.Join(", ", byPrice.Select(p => $"{p.Name}({p.Price})")));

        var mostExpensiveFirst = Data.Products.OrderByDescending(p => p.Price).Select(p => p.Name);
        Console.WriteLine(string.Join(", ", mostExpensiveFirst));

        // Multi-key sort: ThenBy / ThenByDescending.
        // JS: sort((a, b) => a.category.localeCompare(b.category) || b.price - a.price)
        var byCategoryThenPrice = Data.Products
            .OrderBy(p => p.Category)
            .ThenByDescending(p => p.Price);
        foreach (var p in byCategoryThenPrice)
            Console.WriteLine($"{p.Category,-12} {p.Name,-8} {p.Price,8}");

        // Gotcha: calling OrderBy twice REPLACES the first sort. Use ThenBy for the second key.
        // .NET 7+: Order() / OrderDescending() for simple values
        int[] scores = { 5, 3, 9 };
        Console.WriteLine(string.Join(",", scores.OrderDescending()));
    }
}
