using System.Diagnostics;

namespace Ep07.Solutions;

public static class S01_ConvertCpp
{
    static T ClampValue<T>(T v, T lo, T hi) where T : IComparable<T>
    {
        if (lo.CompareTo(hi) > 0) throw new ArgumentException("lo > hi");
        if (v.CompareTo(lo) < 0) return lo;
        if (v.CompareTo(hi) > 0) return hi;
        return v;
        // (.NET also has Math.Clamp for numbers.)
    }

    sealed class Timer : IDisposable
    {
        private readonly string _label;
        private readonly Stopwatch _watch = Stopwatch.StartNew();

        public Timer(string label)
        {
            _label = label;
            Console.WriteLine($"start {_label}");
        }

        public void Dispose() => Console.WriteLine($"end {_label} ({_watch.ElapsedMilliseconds} ms)");
    }

    static void ForEachSquare(int n, Action<int> callback)
    {
        for (int i = 1; i <= n; i++) callback(i * i);
    }

    public static void Run()
    {
        using var t = new Timer("main");   // C# has no destructors you can rely on: use IDisposable
        Console.WriteLine($"{ClampValue(15, 0, 10)} {ClampValue(2.5, 3.0, 4.0)}");
        ForEachSquare(3, sq => Console.Write($"{sq} "));
        try { ClampValue(1, 5, 0); }
        catch (ArgumentException e) { Console.WriteLine($"\nerror: {e.Message}"); }
    }
}
