namespace Ep04.Examples;

public static class Ex05_StringMethods
{
    public static void Run()
    {
        string s = "  Hello, World  ";

        // Most JS string methods exist with PascalCase names
        Console.WriteLine($"[{s.Trim()}]");              // trim
        Console.WriteLine(s.Trim().ToUpper());          // toUpperCase
        Console.WriteLine(s.Contains("World"));         // includes
        Console.WriteLine(s.Trim().StartsWith("Hell")); // startsWith
        Console.WriteLine(s.IndexOf('o'));              // indexOf
        Console.WriteLine(s.Replace("World", "C#"));    // replaceAll (Replace replaces ALL)
        Console.WriteLine(s.Trim().Substring(7, 5));    // substring(start, LENGTH) not end!
        Console.WriteLine(s.Trim()[7..12]);             // range: start..end (like slice)
        Console.WriteLine("ab".PadLeft(5, '*'));        // padStart

        // Split and Join
        string csv = "red, green ,blue";
        string[] parts = csv.Split(',', StringSplitOptions.TrimEntries);
        Console.WriteLine(string.Join("|", parts));      // arr.join("|") is a STATIC method

        // Null/empty checks used everywhere
        string? maybe = null;
        Console.WriteLine(string.IsNullOrEmpty(maybe));         // True
        Console.WriteLine(string.IsNullOrWhiteSpace("   "));    // True

        // Comparing ignoring case (prefer this over ToLower() == ToLower())
        Console.WriteLine(string.Equals("Apple", "APPLE", StringComparison.OrdinalIgnoreCase));

        // chars
        foreach (char c in "a1B")
            Console.Write($"{c}:{char.IsLetter(c)}/{char.IsDigit(c)}/{char.IsUpper(c)} ");
        Console.WriteLine();

        // Repeat a char / string
        Console.WriteLine(new string('=', 10));          // "=".repeat(10)
        Console.WriteLine(string.Concat(Enumerable.Repeat("ab", 3)));
    }
}
