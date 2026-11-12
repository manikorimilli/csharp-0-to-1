namespace Ep04.Solutions;

public static class S05_Refactor
{
    public static void Run()
    {
        var visitors = new List<string> { "ann", "bob", "ann", "cid", "bob" };
        var distinct = new HashSet<string>(visitors);   // O(1) membership, duplicates dropped
        string report = string.Join(";", distinct);

        var roles = new Dictionary<string, string> { ["ann"] = "admin" };
        string role = roles.GetValueOrDefault("bob", "guest");

        Console.WriteLine($"{report} / bob is {role}");
        // Note: HashSet does not promise order. If order matters, use LINQ
        // visitors.Distinct() (Ep08), which keeps first-seen order.
    }
}
