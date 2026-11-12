namespace Ep04.Examples;

public static class Ex01_List
{
    public static void Run()
    {
        // List<T> is the C# version of a JS array: it grows, but holds ONE type.
        var names = new List<string> { "Ann", "Bob" };   // collection initializer
        List<int> numbers = [3, 1, 2];                   // collection expression (C# 12)
        var empty = new List<string>();                  // or: List<string> empty = new();

        names.Add("Cid");                    // push
        names.AddRange(["Dan", "Eve"]);      // push(...items)
        names.Insert(0, "Zed");              // splice(0, 0, "Zed")
        names.Remove("Bob");                 // remove first match, returns bool
        names.RemoveAt(0);                   // splice(0, 1)

        Console.WriteLine($"Count = {names.Count}");          // .Count, not .Length
        Console.WriteLine(string.Join(", ", names));
        Console.WriteLine(names[0]);                          // index access
        Console.WriteLine(names.Contains("Eve"));             // includes
        Console.WriteLine(names.IndexOf("Cid"));              // indexOf (-1 if missing)

        numbers.Sort();                                        // in place, numeric
        Console.WriteLine(string.Join(",", numbers));

        // Find / FindAll / RemoveAll take lambdas (like JS find/filter)
        string? firstLong = names.Find(n => n.Length > 2);
        List<int> big = numbers.FindAll(n => n >= 2);
        names.RemoveAll(n => n.StartsWith('D'));
        Console.WriteLine($"{firstLong} | {string.Join(",", big)} | {string.Join(",", names)}");

        // foreach works; modifying the list inside foreach throws
        foreach (var n in names) Console.Write($"[{n}]");
        Console.WriteLine();

        Console.WriteLine($"empty.Count = {empty.Count}");
    }
}
