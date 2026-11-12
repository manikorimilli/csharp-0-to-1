namespace Ep08.Examples;

public static class Ex03_FirstOrDefault
{
    public static void Run()
    {
        // JS: products.find(p => p.price > 1000)        -> item or undefined
        // C#: products.FirstOrDefault(p => p.Price > 1000) -> item or null (default)
        Product? pricey = Data.Products.FirstOrDefault(p => p.Price > 1000);
        Console.WriteLine(pricey?.Name ?? "none");

        Product? none = Data.Products.FirstOrDefault(p => p.Price > 99999);
        Console.WriteLine(none?.Name ?? "none");

        // First() THROWS if nothing matches. Use it when "no match" is a bug.
        try { Data.Products.First(p => p.Category == "Toys"); }
        catch (InvalidOperationException) { Console.WriteLine("First() threw: no match"); }

        // Single / SingleOrDefault: expects at most ONE match, throws if there are more.
        // Common for lookups by id.
        var cid = Data.Customers.Single(c => c.Id == 3);
        Console.WriteLine(cid.Name);
        try { Data.Customers.Single(c => c.Country == "US"); }
        catch (InvalidOperationException) { Console.WriteLine("Single() threw: more than one"); }

        // Last / LastOrDefault, ElementAt
        Console.WriteLine(Data.Orders.Last().Id);

        // Gotcha with value types: default(int) is 0, not null
        int[] nums = { 1, 2, 3 };
        Console.WriteLine(nums.FirstOrDefault(n => n > 10));          // 0 (!)
        Console.WriteLine(nums.FirstOrDefault(n => n > 10, -1));      // -1 (custom default, .NET 6+)

        // List<T>.Find also exists (not LINQ, lists only)
        Console.WriteLine(Data.Products.Find(p => p.Id == 2)?.Name);
    }
}
