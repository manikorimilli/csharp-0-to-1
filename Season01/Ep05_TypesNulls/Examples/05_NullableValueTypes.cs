namespace Ep05.Examples;

public static class Ex05_NullableValueTypes
{
    // int? means "an int, or no value". Same as Nullable<int>.
    // Typical use: optional numbers from a database, form, or JSON.
    static int? FindIndex(string[] items, string target)
    {
        for (int i = 0; i < items.Length; i++)
            if (items[i] == target) return i;
        return null;
    }

    public static void Run()
    {
        int? maybeAge = null;
        Console.WriteLine(maybeAge.HasValue);           // False
        maybeAge = 30;
        Console.WriteLine(maybeAge.HasValue);           // True
        Console.WriteLine(maybeAge.Value);              // 30 (throws if no value)

        // int? does not convert to int implicitly
        // int age = maybeAge;                          // compile error
        int age = maybeAge ?? 0;                        // provide a fallback
        int age2 = maybeAge.GetValueOrDefault();        // 0 if null
        Console.WriteLine($"{age} {age2}");

        // Arithmetic with null gives null (it "lifts" the operator)
        int? a = 5, b = null;
        Console.WriteLine((a + b) is null);             // True

        // Use with methods that may not find anything
        string[] colors = { "red", "green" };
        int? idx = FindIndex(colors, "blue");
        Console.WriteLine(idx is null ? "not found" : $"found at {idx}");

        if (FindIndex(colors, "green") is int found)    // pattern unwraps the value
            Console.WriteLine($"green at {found}");

        // Other common ones: bool?, DateTime?, decimal?
        DateTime? shippedAt = null;
        Console.WriteLine(shippedAt?.ToString("yyyy-MM-dd") ?? "not shipped");
    }
}
