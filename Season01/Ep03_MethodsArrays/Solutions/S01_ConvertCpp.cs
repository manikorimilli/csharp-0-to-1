namespace Ep03.Solutions;

public static class S01_ConvertCpp
{
    static void SwapValues(ref int a, ref int b) => (a, b) = (b, a);

    static (int Sum, int Count) SumAndCount(int[] values)
    {
        int sum = 0;
        foreach (var v in values) sum += v;
        return (sum, values.Length);
    }

    public static void Run()
    {
        int x = 1, y = 2;
        SwapValues(ref x, ref y);
        var (sum, count) = SumAndCount([4, 5, 6]);
        Console.WriteLine($"{x}{y} {sum}/{count}");   // 21 15/3

        // Second way: no helper needed, tuple swap inline
        (x, y) = (y, x);
        Console.WriteLine($"{x}{y}");                 // 12
    }
}
