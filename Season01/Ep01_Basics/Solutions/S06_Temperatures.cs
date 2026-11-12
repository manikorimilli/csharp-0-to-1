namespace Ep01.Solutions;

public static class S06_Temperatures
{
    public static void Run()
    {
        Console.WriteLine($"{"C",4}{"F",8}");
        for (int c = -10; c <= 40; c += 10)
        {
            double f = c * 9.0 / 5 + 32;   // 9.0 forces double math
            Console.WriteLine($"{c,4}{f,8:F1}");
        }
    }
}
