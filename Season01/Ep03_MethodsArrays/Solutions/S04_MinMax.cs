namespace Ep03.Solutions;

public static class S04_MinMax
{
    static (int Min, int Max, double Average) Stats(params int[] values)
    {
        if (values.Length == 0)
            throw new ArgumentException("At least one value is required.", nameof(values));

        int min = values[0], max = values[0], sum = 0;
        foreach (var v in values)
        {
            if (v < min) min = v;
            if (v > max) max = v;
            sum += v;
        }
        return (min, max, (double)sum / values.Length);
    }

    public static void Run()
    {
        var (min, max, avg) = Stats(4, 8, 15, 16, 23, 42);
        Console.WriteLine($"min={min} max={max} avg={avg:F2}");

        int[] existing = { 3, 1, 2 };
        var s = Stats(existing);
        Console.WriteLine(s);   // (1, 3, 2)
    }
}
