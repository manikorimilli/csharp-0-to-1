namespace Ep01.Solutions;

public static class S02_PredictOutput
{
    public static void Run()
    {
        Console.WriteLine(10 / 4);                  // 2      int division
        Console.WriteLine(10 / 4.0);                // 2.5
        Console.WriteLine("5" + 5);                 // 55     string concat
        Console.WriteLine('a' + 1);                 // 98     char + int = int
        Console.WriteLine((char)('a' + 1));         // b
        Console.WriteLine(0.1 + 0.2 == 0.3);        // False  double precision
        Console.WriteLine(0.1m + 0.2m == 0.3m);     // True   decimal is exact
        Console.WriteLine((int)-3.9);               // -3     cast truncates toward zero
        Console.WriteLine(Math.Round(3.5) + Math.Round(4.5)); // 8  (4 + 4, banker's rounding)
    }
}
