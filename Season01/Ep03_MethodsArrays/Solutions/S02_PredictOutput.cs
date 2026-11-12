namespace Ep03.Solutions;

public static class S02_PredictOutput
{
    static void Reset(int[] arr, int n) { arr[0] = 0; n = 0; }
    static string Show(int x) => "int";
    static string Show(long x) => "long";
    static string Show(double x) => "double";
    static string Pad(string s, int width = 6, char fill = '.') => s.PadLeft(width, fill);

    public static void Run()
    {
        int[] data = { 9, 9 };
        int count = 9;
        Reset(data, count);
        Console.WriteLine($"{data[0]} {count}");
        // 0 9   array is a reference type (element changed); int was copied

        Console.WriteLine(Show(5) + " " + Show(5L) + " " + Show(5f));
        // int long double   (float has no exact overload, widens to double)

        Console.WriteLine(Pad("ab") + "|" + Pad("ab", fill: '*') + "|" + Pad("ab", 3));
        // ....ab|****ab|.ab

        int[] copy = data;
        copy[1] = 1;
        Console.WriteLine(data[1]);
        // 1   `copy` points to the same array
    }
}
