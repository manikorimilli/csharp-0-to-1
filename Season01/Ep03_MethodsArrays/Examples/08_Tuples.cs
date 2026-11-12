namespace Ep03.Examples;

public static class Ex08_Tuples
{
    // Return several values with a named tuple. JS: return { min, max };
    static (int Min, int Max) MinMax(int[] values)
    {
        int min = values[0], max = values[0];
        foreach (var v in values)
        {
            if (v < min) min = v;
            if (v > max) max = v;
        }
        return (min, max);
    }

    public static void Run()
    {
        var result = MinMax(new[] { 4, 9, 1, 7 });
        Console.WriteLine($"{result.Min}..{result.Max}");   // access by name
        Console.WriteLine(result);                          // (1, 9) tuples print nicely

        // Deconstruction. JS: const { min, max } = minMax(arr);
        var (lo, hi) = MinMax(new[] { 3, 8 });
        Console.WriteLine($"lo={lo}, hi={hi}");

        // Discard what you don't need. JS: const [, second] = arr;
        var (_, onlyMax) = MinMax(new[] { 5, 6 });
        Console.WriteLine(onlyMax);

        // Swap without a temp. JS: [a, b] = [b, a];
        int a = 1, b = 2;
        (a, b) = (b, a);
        Console.WriteLine($"a={a}, b={b}");

        // Tuple literal with names
        var point = (X: 10, Y: 20);
        Console.WriteLine($"point.X = {point.X}");

        // Tuples compare by value
        Console.WriteLine((1, "a") == (1, "a"));   // True

        // Rule of thumb: tuples for small private/local results.
        // For public APIs or data that travels, use a record (Ep06).
    }
}
