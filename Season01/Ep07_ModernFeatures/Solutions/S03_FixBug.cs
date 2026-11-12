namespace Ep07.Solutions;

// Fix 2 (CS1106): extension methods must be in a non-nested, non-generic STATIC class.
public static class S03StringHelpers
{
    public static string Shout(this string s) => s.ToUpper() + "!";
}

public static class S03_FixBug
{
    // Fix 1 (CS0019): `>` is not defined for an unconstrained T. Constrain and use CompareTo.
    static T Largest<T>(T[] items) where T : IComparable<T>
    {
        T best = items[0];
        foreach (var item in items)
            if (item.CompareTo(best) > 0) best = item;
        return best;
    }

    class Downloader
    {
        public event EventHandler<string>? Completed;
        // Fix 3 (NullReferenceException): no subscribers means the event is null. Use ?.Invoke
        public void Download(string file) => Completed?.Invoke(this, file);
    }

    public static void Run()
    {
        var d = new Downloader();
        d.Download("file.zip");
        d.Completed += (_, f) => Console.WriteLine($"downloaded {f}");
        d.Download("other.zip");
        Console.WriteLine(Largest(new[] { 3, 9, 4 }));
        Console.WriteLine("hello".Shout());
    }
}
