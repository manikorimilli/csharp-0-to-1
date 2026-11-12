using System.Globalization;

namespace Ep01.Examples;

public static class Ex07_CastingParsing
{
    public static void Run()
    {
        // Implicit conversion: only when no data can be lost (widening)
        int i = 42;
        long l = i;
        double d = i;

        // Explicit cast (C-style, like C++/Java): truncates toward zero
        double price = 9.99;
        int whole = (int)price;                 // 9
        Console.WriteLine($"{l} {d} {whole}");

        // Math.Round uses banker's rounding by default!
        Console.WriteLine(Math.Round(2.5));                                 // 2
        Console.WriteLine(Math.Round(2.5, MidpointRounding.AwayFromZero));  // 3

        // Parse: throws FormatException on bad input (JS parseInt returns NaN)
        int n = int.Parse("123");
        Console.WriteLine(n + 1);

        // TryParse: the everyday, safe way. `out int value` declares the variable inline.
        foreach (string text in new[] { "77", "abc", "" })
        {
            if (int.TryParse(text, out int value))
                Console.WriteLine($"'{text}' -> {value}");
            else
                Console.WriteLine($"'{text}' is not a number");
        }

        // Doubles: pass a culture so "3.14" parses the same on every machine
        double pi = double.Parse("3.14", CultureInfo.InvariantCulture);
        Console.WriteLine(pi);

        // To string: every value has ToString()
        string s = 42.ToString();
        Console.WriteLine(s + "!");

        // char <-> int
        char c = 'A';
        int code = c;                 // implicit: 65
        char next = (char)(c + 1);    // explicit back: 'B'
        Console.WriteLine($"{c}={code}, next={next}");
    }
}
