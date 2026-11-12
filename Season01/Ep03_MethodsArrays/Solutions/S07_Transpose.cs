namespace Ep03.Solutions;

public static class S07_Transpose
{
    static int[,] Transpose(int[,] m)
    {
        int rows = m.GetLength(0), cols = m.GetLength(1);
        var result = new int[cols, rows];
        for (int r = 0; r < rows; r++)
            for (int c = 0; c < cols; c++)
                result[c, r] = m[r, c];
        return result;
    }

    static void Print(int[,] m)
    {
        for (int r = 0; r < m.GetLength(0); r++)
        {
            for (int c = 0; c < m.GetLength(1); c++)
                Console.Write($"{m[r, c],3}");
            Console.WriteLine();
        }
    }

    public static void Run()
    {
        int[,] m = { { 1, 2, 3 }, { 4, 5, 6 } };
        Print(m);
        Console.WriteLine("transposed:");
        Print(Transpose(m));
    }
}
