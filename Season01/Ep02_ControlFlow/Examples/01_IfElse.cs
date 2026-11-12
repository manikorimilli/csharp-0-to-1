namespace Ep02.Examples;

public static class Ex01_IfElse
{
    public static void Run()
    {
        int temperature = 23;

        // Same shape as JS/Java. The condition MUST be a bool.
        if (temperature > 30)
        {
            Console.WriteLine("Hot");
        }
        else if (temperature > 15)
        {
            Console.WriteLine("Mild");
        }
        else
        {
            Console.WriteLine("Cold");
        }

        // Braces are optional for one statement (style guides usually keep them).
        if (temperature == 23) Console.WriteLine("Exactly 23");

        // Ternary: identical to JS
        string label = temperature >= 20 ? "warm" : "cool";
        Console.WriteLine(label);

        // No truthy/falsy. Be explicit:
        string name = "";
        // if (name) { }                      // compile error
        if (!string.IsNullOrEmpty(name)) Console.WriteLine("has name");
        else Console.WriteLine("empty name");

        int items = 0;
        if (items > 0) Console.WriteLine("has items");   // not `if (items)`
    }
}
