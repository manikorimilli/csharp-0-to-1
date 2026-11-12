namespace Ep09.Solutions;

public static class S01_ConvertCpp
{
    static async Task<int> SlowSquareAsync(int x)
    {
        await Task.Delay(200);   // non-blocking, unlike sleep_for
        return x * x;
    }

    public static async Task Run()
    {
        Task<int> a = SlowSquareAsync(3);   // both start immediately (like std::launch::async)
        Task<int> b = SlowSquareAsync(4);
        Console.WriteLine("waiting...");
        int[] results = await Task.WhenAll(a, b);   // instead of a.get() + b.get()
        Console.WriteLine($"sum = {results.Sum()}");
    }
}
