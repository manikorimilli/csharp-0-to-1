namespace Ep02.Solutions;

public static class S03_FixBug
{
    public static void Run()
    {
        int[] scores = { 90, 72, 55 };
        for (int i = 0; i < scores.Length; i++)          // fix 1 (crash): < not <=
        {
            int s = scores[i];
            if (s % 2 != 0) Console.WriteLine($"{s} is odd"); // fix 2: condition must be bool
            switch (s)
            {
                case >= 90:
                    Console.WriteLine("A");
                    break;                                 // fix 3: no fall-through allowed
                case >= 70:
                    Console.WriteLine("B");
                    break;
                default:
                    Console.WriteLine("F");
                    break;
            }
        }
        // Even more idiomatic: foreach (var s in scores) and a switch expression.
    }
}
