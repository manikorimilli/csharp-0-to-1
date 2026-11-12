namespace Ep05.Solutions;

public static class S02_PredictOutput
{
    enum Size { Small = 1, Medium, Large }
    struct Counter { public int Count; }
    class Holder { public Counter C; }

    public static void Run()
    {
        var c1 = new Counter();
        var c2 = c1;
        c2.Count++;
        var h1 = new Holder();
        var h2 = h1;
        h2.C.Count++;
        int? x = null;
        int? y = 3;
        string? s = null;

        Console.WriteLine($"{c1.Count} {h1.C.Count}");  // 0 1   struct copied; holder shared
        Console.WriteLine(x + y);                       // (empty line) null + 3 = null
        Console.WriteLine((x ?? y) * 2);                // 6
        Console.WriteLine(s?.Length ?? -1);             // -1
        Console.WriteLine((Size)3);                     // Large (Small=1, Medium=2, Large=3)
        Console.WriteLine((int)Size.Medium);            // 2
        Console.WriteLine(x > 0 || x <= 0);             // False  comparisons with null are false
    }
}
