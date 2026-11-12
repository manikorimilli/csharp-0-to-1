namespace Ep03.Examples;

public static class Ex02_MultiDimJagged
{
    public static void Run()
    {
        // Multi-dimensional (rectangular) array: one block, [row, col] indexing
        int[,] grid =
        {
            { 1, 2, 3 },
            { 4, 5, 6 }
        };
        Console.WriteLine($"rows={grid.GetLength(0)}, cols={grid.GetLength(1)}, grid[1,2]={grid[1, 2]}");

        for (int r = 0; r < grid.GetLength(0); r++)
        {
            for (int col = 0; col < grid.GetLength(1); col++)
                Console.Write($"{grid[r, col],3}");
            Console.WriteLine();
        }

        // Jagged array: array of arrays, rows can differ in length.
        // This is what a JS array-of-arrays (or C++ vector<vector<int>>) maps to.
        int[][] jagged =
        {
            new[] { 1 },
            new[] { 2, 3 },
            new[] { 4, 5, 6 }
        };
        foreach (int[] row in jagged)
            Console.WriteLine(string.Join(" ", row));
        Console.WriteLine($"jagged[2][1] = {jagged[2][1]}");
    }
}
