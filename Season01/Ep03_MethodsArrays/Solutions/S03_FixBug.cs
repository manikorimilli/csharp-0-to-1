namespace Ep03.Solutions;

public static class S03_FixBug
{
    // Logic bug: score was passed by value. Pass by ref (or better: return the new value).
    static void AddPoints(ref int score, int points) { score += points; }

    // Compile error 1: optional parameters must come after required ones.
    static string Label(int value, string unit = "pts") => $"{value} {unit}";

    // Compile error 2: an out parameter must be assigned on every path.
    static bool TryHalf(int n, out int half)
    {
        half = n / 2;
        return n % 2 == 0;
    }

    public static void Run()
    {
        int score = 0;
        AddPoints(ref score, 10);
        Console.WriteLine(Label(value: score));   // 10 pts

        if (TryHalf(8, out var h)) Console.WriteLine(h);   // 4
    }
}
