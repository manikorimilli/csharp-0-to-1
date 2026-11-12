namespace Ep01.Solutions;

public static class S01_ConvertCpp
{
    public static void Run()
    {
        // In a real Program.cs these lines would sit at the top level, no main() needed.
        const int MaxUsers = 3;
        var product = "Keyboard";
        var price = 49.5m;        // decimal for money
        var inStock = true;

        Console.WriteLine($"{product} costs {price}, in stock: {inStock}");
        Console.WriteLine($"Max users: {MaxUsers}");
        // Note: C++ prints bool as 1, C# prints True.
    }
}
