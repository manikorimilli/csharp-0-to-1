namespace Ep08.Examples;

public static class Ex01_WhereSelect
{
    public static void Run()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6 };

        // JS: numbers.filter(n => n % 2 === 0).map(n => n * n)
        // C#: numbers.Where(n => n % 2 == 0).Select(n => n * n)
        var evenSquares = numbers.Where(n => n % 2 == 0).Select(n => n * n);
        Console.WriteLine(string.Join(", ", evenSquares));   // 4, 16, 36

        // On objects
        var cheapNames = Data.Products
            .Where(p => p.Price < 200)
            .Select(p => p.Name);
        Console.WriteLine(string.Join(", ", cheapNames));

        // Select into a new shape: anonymous type (like returning an object literal in JS map)
        var labels = Data.Products
            .Where(p => p.Category == "Electronics")
            .Select(p => new { p.Name, PriceWithTax = p.Price * 1.25m });
        foreach (var x in labels)
            Console.WriteLine($"{x.Name}: {x.PriceWithTax:F2}");

        // Index overloads, like JS (x, i) => ...
        var numbered = Data.Customers.Select((c, i) => $"{i + 1}. {c.Name}");
        Console.WriteLine(string.Join(" | ", numbered));

        // SelectMany flattens (JS flatMap)
        var allLines = Data.Orders.SelectMany(o => o.Lines);
        Console.WriteLine($"Total order lines: {allLines.Count()}");
    }
}
