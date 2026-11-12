namespace Ep03.Examples;

public static class Ex01_Arrays
{
    public static void Run()
    {
        // Arrays have a FIXED size and ONE element type. (JS arrays grow and mix types.)
        int[] a = new int[3];               // { 0, 0, 0 } default values
        int[] b = { 1, 2, 3 };              // initializer
        int[] c = new[] { 4, 5, 6 };        // type inferred
        int[] d = [7, 8, 9];                // collection expression (C# 12)
        var names = new string[] { "Ann", "Bob" };

        a[0] = 42;
        Console.WriteLine($"a.Length = {a.Length}, a[0] = {a[0]}");

        // Printing an array prints its TYPE, not its contents (JS prints contents)
        Console.WriteLine(b);                       // System.Int32[]
        Console.WriteLine(string.Join(", ", b));    // 1, 2, 3

        // Index from the end and ranges (like JS .at(-1) and .slice(1, 3))
        Console.WriteLine(c[^1]);                    // 6 (last)
        int[] middle = d[1..3];                      // copy of elements 1 and 2
        Console.WriteLine(string.Join(",", middle)); // 8,9

        // Useful static helpers on Array
        int[] nums = { 5, 2, 9, 1 };
        Array.Sort(nums);                            // in place
        Console.WriteLine(string.Join(",", nums));   // 1,2,5,9
        Console.WriteLine(Array.IndexOf(nums, 9));   // 3
        Array.Reverse(nums);
        Console.WriteLine(string.Join(",", nums));   // 9,5,2,1
        Console.WriteLine(names.Contains("Bob"));    // True (LINQ extension, Ep08)

        // Out of range throws (JS returns undefined)
        try { Console.WriteLine(b[10]); }
        catch (IndexOutOfRangeException) { Console.WriteLine("b[10] -> IndexOutOfRangeException"); }

        // Need to grow? Use List<T> (Ep04). Arrays cannot push.
    }
}
