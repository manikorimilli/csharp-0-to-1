namespace Ep03.Examples;

public static class Ex04_Overloading
{
    // Same name, different parameter lists. JS cannot do this (last definition wins),
    // so JS code checks typeof inside one function instead.
    static string Describe(int n) => $"int {n}";
    static string Describe(double d) => $"double {d}";
    static string Describe(string s) => $"string '{s}'";
    static string Describe(int a, int b) => $"two ints {a},{b}";

    public static void Run()
    {
        Console.WriteLine(Describe(5));
        Console.WriteLine(Describe(5.0));
        Console.WriteLine(Describe("five"));
        Console.WriteLine(Describe(5, 6));

        // You already use overloads all the time:
        Console.WriteLine(42);         // WriteLine(int)
        Console.WriteLine("42");       // WriteLine(string)
        Console.WriteLine(Math.Max(1, 2) + Math.Max(1.5, 2.5)); // Max(int,int) and Max(double,double)
    }
}
