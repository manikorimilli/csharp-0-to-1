namespace Ep03.Solutions;

public static class S05_Refactor
{
    static (bool Ok, string First, string Last) ParseName(string fullName)
    {
        var parts = fullName.Split(' ');
        return parts.Length == 2
            ? (true, parts[0], parts[1])
            : (false, "", "");
    }

    public static void Run()
    {
        var (ok, first, last) = ParseName("Ada Lovelace");
        if (ok) Console.WriteLine($"{last}, {first}");

        var (ok2, _, _) = ParseName("Plato");
        Console.WriteLine($"Plato parsed: {ok2}");
    }
}
