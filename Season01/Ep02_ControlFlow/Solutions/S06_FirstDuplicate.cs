namespace Ep02.Solutions;

public static class S06_FirstDuplicate
{
    // int? = "int or null" (Ep05). Returning null means "not found".
    static int? FirstDuplicate(int[] numbers)
    {
        // For each position j, look back for an earlier equal value.
        // The first j that finds one is the earliest "second occurrence".
        for (int j = 1; j < numbers.Length; j++)
        {
            for (int i = 0; i < j; i++)
            {
                if (numbers[i] == numbers[j])
                    return numbers[j];          // early return exits both loops
            }
        }
        return null;
    }

    public static void Run()
    {
        Console.WriteLine(FirstDuplicate(new[] { 3, 1, 4, 1, 5, 3 }));             // 1
        Console.WriteLine(FirstDuplicate(new[] { 1, 2, 3 })?.ToString() ?? "none"); // none
        // (In Ep04 you would use a HashSet<int> for O(n).)
    }
}
