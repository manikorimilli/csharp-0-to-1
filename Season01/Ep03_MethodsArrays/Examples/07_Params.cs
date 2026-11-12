namespace Ep03.Examples;

public static class Ex07_Params
{
    // params: variable number of args, collected into an array.
    // JS: function sum(...numbers) {}
    static int Sum(params int[] numbers)
    {
        int total = 0;
        foreach (var n in numbers) total += n;
        return total;
    }

    // params must be the last parameter
    static string Join(string separator, params string[] parts) => string.Join(separator, parts);

    public static void Run()
    {
        Console.WriteLine(Sum());              // 0
        Console.WriteLine(Sum(1, 2, 3));       // 6

        int[] existing = { 10, 20 };
        Console.WriteLine(Sum(existing));      // pass an array directly (JS: sum(...arr))

        Console.WriteLine(Join("-", "a", "b", "c"));

        // Familiar example: string.Format and Console.WriteLine use params object[]
        Console.WriteLine("{0} + {1} = {2}", 1, 2, 3);
    }
}
