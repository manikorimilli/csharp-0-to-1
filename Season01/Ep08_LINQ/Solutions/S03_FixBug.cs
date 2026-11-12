namespace Ep08.Solutions;

public static class S03_FixBug
{
    public static void Run()
    {
        // Fix 1: First() throws when nothing matches. FirstOrDefault + null handling.
        var toy = Data.Products.FirstOrDefault(p => p.Category == "Toys");
        Console.WriteLine(toy?.Name ?? "none");

        // Fix 2: ToDictionary throws on duplicate keys (two Electronics...). Group first.
        var byCategory = Data.Products
            .GroupBy(p => p.Category)
            .ToDictionary(g => g.Key, g => g.Select(p => p.Name).ToList());
        foreach (var (category, names) in byCategory)
            Console.WriteLine($"{category}: {string.Join(", ", names)}");

        // Fix 3: a second OrderBy discards the first. Use ThenBy for the secondary key.
        var sorted = Data.Products.OrderBy(p => p.Category).ThenBy(p => p.Price);
        Console.WriteLine(string.Join(", ", sorted.Select(p => p.Name)));
    }
}
