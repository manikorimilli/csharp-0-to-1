namespace Ep01.Solutions;

public static class S04_AgeReader
{
    static string Describe(string? input)
    {
        if (!int.TryParse(input, out int age) || age < 0)   // TryParse(null) simply returns false
            return "Invalid age";

        if (age < 18) return "Minor";
        if (age < 65) return "Adult";
        return "Senior";
    }

    public static void Run()
    {
        string?[] samples = { "17", "30", "70", "abc", "-1", null };
        foreach (var s in samples)
            Console.WriteLine($"{s ?? "null",-5} -> {Describe(s)}");

        // Real program: Console.WriteLine(Describe(Console.ReadLine()));
    }
}
