namespace Ep02.Examples;

public static class Ex07_BreakContinue
{
    public static void Run()
    {
        // continue skips to the next iteration, break leaves the loop. Same as JS.
        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0) continue;
            if (i > 7) break;
            Console.Write($"{i} ");
        }
        Console.WriteLine();

        // No labeled break in C# (JS has `outer: for ...` / `break outer`).
        // Options: a flag, a method with `return`, or (rarely) goto.
        int[,] grid = { { 1, 2 }, { 3, 4 } };
        var found = FindFirst(grid, 3);
        Console.WriteLine($"found 3 at {found}");
    }

    // Extracting a method and using `return` is the idiomatic way to exit nested loops.
    static (int Row, int Col) FindFirst(int[,] grid, int target)
    {
        for (int r = 0; r < grid.GetLength(0); r++)
            for (int c = 0; c < grid.GetLength(1); c++)
                if (grid[r, c] == target)
                    return (r, c);
        return (-1, -1);
    }
}
