namespace Ep04.Examples;

public static class Ex03_HashSet
{
    public static void Run()
    {
        // HashSet<T> = JS Set
        var tags = new HashSet<string> { "csharp", "dotnet" };
        bool isNew = tags.Add("linq");        // true
        bool again = tags.Add("csharp");      // false, already there (no exception)
        Console.WriteLine($"{isNew} {again} Count={tags.Count}");
        Console.WriteLine(tags.Contains("linq"));   // set.has, O(1)

        // Set operations (JS needs manual code or the newer Set methods)
        var a = new HashSet<int> { 1, 2, 3, 4 };
        var b = new HashSet<int> { 3, 4, 5 };

        var union = new HashSet<int>(a);
        union.UnionWith(b);                    // modifies `union` in place
        var common = new HashSet<int>(a);
        common.IntersectWith(b);
        var onlyA = new HashSet<int>(a);
        onlyA.ExceptWith(b);

        Console.WriteLine($"union {string.Join(",", union)}");
        Console.WriteLine($"intersect {string.Join(",", common)}");
        Console.WriteLine($"a - b {string.Join(",", onlyA)}");

        // Remove duplicates from a list
        var withDupes = new List<int> { 1, 1, 2, 3, 3 };
        var unique = new HashSet<int>(withDupes);
        Console.WriteLine(string.Join(",", unique));

        // Case-insensitive set: pass a comparer
        var emails = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "A@x.com" };
        Console.WriteLine(emails.Contains("a@X.COM"));   // True
    }
}
