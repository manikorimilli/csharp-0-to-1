namespace Ep02.Solutions;

public static class S04_FizzBuzz
{
    static string FizzBuzz(int n) => (n % 3, n % 5) switch
    {
        (0, 0) => "FizzBuzz",
        (0, _) => "Fizz",
        (_, 0) => "Buzz",
        _ => n.ToString()
    };

    public static void Run()
    {
        for (int n = 1; n <= 15; n++)
            Console.Write($"{FizzBuzz(n)} ");
        Console.WriteLine();
    }
}
