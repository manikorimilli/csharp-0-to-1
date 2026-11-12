namespace Ep02.Examples;

public static class Ex06_Foreach
{
    public static void Run()
    {
        string[] fruits = { "apple", "banana", "cherry" };

        // JS:   for (const f of fruits) { ... }
        // C#:   foreach (var f in fruits) { ... }      (note: `in`, not `of`)
        foreach (var fruit in fruits)
            Console.WriteLine(fruit);

        // Works on anything enumerable: strings, lists, dictionaries...
        foreach (char ch in "hey")
            Console.Write($"[{ch}]");
        Console.WriteLine();

        // Need the index? Use for, or a counter, or LINQ's Select((x, i) => ...) (Ep08)
        for (int i = 0; i < fruits.Length; i++)
            Console.WriteLine($"{i}: {fruits[i]}");

        // .NET 9 adds Index(); on .NET 8 a common trick is:
        foreach (var (fruit, i) in fruits.Select((f, i) => (f, i)))
            Console.WriteLine($"{i} -> {fruit}");

        // The loop variable is read-only:
        // foreach (var f in fruits) f = "x";   // compile error CS1656
    }
}
