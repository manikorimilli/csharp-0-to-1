namespace Ep02.Examples;

public static class Ex05_Loops
{
    public static void Run()
    {
        // for: identical to C++/Java/JS (just `int` instead of `let`)
        for (int i = 0; i < 3; i++)
            Console.Write($"{i} ");
        Console.WriteLine();

        // Two variables in one for loop
        for (int lo = 0, hi = 5; lo < hi; lo++, hi--)
            Console.Write($"({lo},{hi}) ");
        Console.WriteLine();

        // while
        int n = 100;
        int steps = 0;
        while (n > 1)
        {
            n /= 2;
            steps++;
        }
        Console.WriteLine($"halved {steps} times");

        // do-while: body runs at least once
        int attempts = 0;
        do
        {
            attempts++;
        } while (attempts < 3);
        Console.WriteLine($"attempts = {attempts}");

        // Loop variable scope: `i` from the first loop is not visible here.
    }
}
