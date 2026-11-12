namespace Ep04.Solutions;

public static class S01_ConvertCpp
{
    public static void Run()
    {
        var words = new List<string> { "apple", "pear", "apple", "fig", "pear", "apple" };
        var counts = new Dictionary<string, int>();
        var unique = new HashSet<string>();

        foreach (var w in words)
        {
            counts[w] = counts.GetValueOrDefault(w) + 1;   // no auto-insert like std::map
            unique.Add(w);
        }

        // Dictionary is not sorted. Sort the keys to match std::map's output order.
        var keys = new List<string>(counts.Keys);
        keys.Sort();
        foreach (var key in keys)
            Console.Write($"{key}={counts[key]} ");

        Console.WriteLine($"\nunique: {unique.Count}");
        // (In Ep08 you'd write: foreach (var (w, n) in counts.OrderBy(kv => kv.Key)) ...)
    }
}
