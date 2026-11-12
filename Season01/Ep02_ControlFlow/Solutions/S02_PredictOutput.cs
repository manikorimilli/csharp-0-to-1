namespace Ep02.Solutions;

public static class S02_PredictOutput
{
    public static void Run()
    {
        int[] values = { 5, -3, 12, 0, 7, 100 };
        foreach (var v in values)
        {
            if (v == 0) continue;
            string kind = v switch
            {
                < 0 => "negative",
                < 10 => "small",
                100 => "hundred",
                _ => "big"
            };
            Console.Write($"{kind} ");
            if (v > 50) break;
        }
        Console.WriteLine();
        // small negative big small hundred
        // 0 is skipped; the loop breaks after 100 (it is the last item anyway).

        int i = 10;
        do { Console.Write(i); i++; } while (i < 10);
        Console.WriteLine();
        // 10   (do-while runs the body once before checking)
    }
}
