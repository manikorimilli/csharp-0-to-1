namespace Ep07.Examples;

public static class Ex08_AdvancedPatterns
{
    abstract record Shape;
    record Circle(double Radius) : Shape;
    record Rectangle(double Width, double Height) : Shape;
    record Triangle(double Base, double Height) : Shape;

    record Order(string Status, decimal Total, Customer Customer);
    record Customer(string Country, bool IsVip);

    // Type patterns with deconstruction in a switch expression
    static double Area(Shape shape) => shape switch
    {
        Circle(var r) => Math.PI * r * r,                     // positional pattern
        Rectangle(var w, var h) when w == h => w * w,         // guard
        Rectangle { Width: var w, Height: var h } => w * h,   // property pattern
        Triangle t => 0.5 * t.Base * t.Height,                // type pattern
        _ => throw new ArgumentException("Unknown shape")
    };

    // Nested property patterns: replaces long if/else chains on object graphs
    static decimal Shipping(Order o) => o switch
    {
        { Status: "Cancelled" } => 0m,
        { Customer.IsVip: true } => 0m,                       // extended property pattern (C# 10)
        { Customer.Country: "US", Total: >= 50m } => 0m,
        { Customer.Country: "US" } => 5m,
        { Total: > 200m } => 10m,
        _ => 25m
    };

    // List patterns (C# 11): match on array/list shape. JS has nothing like it.
    static string DescribeArgs(string[] args) => args switch
    {
        [] => "no args",
        ["help"] => "show help",
        ["add", var item] => $"add {item}",
        ["add", var first, .. var rest] => $"add {first} and {rest.Length} more",
        [.., var last] => $"something ending with {last}",   // any non-empty array
    };

    public static void Run()
    {
        Shape[] shapes = { new Circle(1), new Rectangle(2, 2), new Rectangle(2, 5), new Triangle(3, 4) };
        foreach (var s in shapes)
            Console.WriteLine($"{s} -> {Area(s):F2}");

        Console.WriteLine(Shipping(new Order("Paid", 30m, new Customer("US", false))));
        Console.WriteLine(Shipping(new Order("Paid", 30m, new Customer("FR", true))));
        Console.WriteLine(Shipping(new Order("Paid", 300m, new Customer("FR", false))));

        foreach (var a in new[] { new string[0], new[] { "help" }, new[] { "add", "milk" },
                                  new[] { "add", "a", "b", "c" }, new[] { "x", "y", "z" } })
            Console.WriteLine(DescribeArgs(a));

        // `is` with combined patterns
        object value = 42;
        if (value is int n and > 0 and < 100) Console.WriteLine($"{n} is a small positive int");
    }
}
