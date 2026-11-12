namespace Ep02.Examples;

public static class Ex04_PatternMatching
{
    static string Inspect(object value)
    {
        // `is Type name`: type check + cast in one step (JS: typeof / instanceof, then use)
        if (value is int n)
            return $"int, doubled = {n * 2}";

        if (value is string { Length: 0 })          // property pattern
            return "empty string";

        if (value is string s)
            return $"string of length {s.Length}";

        if (value is null)
            return "null";

        return $"something else: {value.GetType().Name}";
    }

    public static void Run()
    {
        object?[] things = { 21, "", "hello", 3.5, null };
        foreach (var t in things)
            Console.WriteLine(Inspect(t!));    // `!` tells the compiler "trust me" (Ep05)

        // Patterns also read nicely for ranges and lists of values
        int age = 15;
        if (age is >= 13 and <= 19) Console.WriteLine("teenager");

        char c = 'e';
        if (c is 'a' or 'e' or 'i' or 'o' or 'u') Console.WriteLine($"{c} is a vowel");

        string? maybe = null;
        if (maybe is not null) Console.WriteLine("has value");
        else Console.WriteLine("maybe is null");
    }
}
