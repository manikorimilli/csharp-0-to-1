namespace Ep01.Examples;

public static class Ex06_Operators
{
    public static void Run()
    {
        Console.WriteLine(7 / 2);       // 3   int / int = int (JS gives 3.5)
        Console.WriteLine(7 / 2.0);     // 3.5 one double operand makes it double
        Console.WriteLine(7 % 3);       // 1
        Console.WriteLine(Math.Pow(2, 10)); // 1024, there is no ** operator

        // == compares VALUES for strings (unlike Java, where you need .equals)
        string a = "hi";
        string b = string.Concat("h", "i");   // a different string object
        Console.WriteLine(a == b);            // True

        // There is no === in C#. == is already type-safe:
        // Console.WriteLine(1 == "1");       // compile error CS0019

        int x = 5;
        x += 2;
        x++;
        Console.WriteLine(x);                  // 8

        // && || ! need real bools. No truthy/falsy:
        // if (x) { }                          // compile error CS0029
        bool inRange = x > 5 && x < 10;
        Console.WriteLine(inRange);

        // Overflow wraps silently by default...
        int max = int.MaxValue;
        Console.WriteLine(max + 1);            // -2147483648
        // ...unless you ask for checking
        try
        {
            Console.WriteLine(checked(max + 1));
        }
        catch (OverflowException)
        {
            Console.WriteLine("checked() threw OverflowException");
        }

        // String + anything = string (same as JS)
        Console.WriteLine("Total: " + 3 + 4);   // Total: 34
        Console.WriteLine("Total: " + (3 + 4)); // Total: 7
    }
}
