using System.Text;

namespace Ep04.Examples;

public static class Ex06_StringBuilder
{
    public static void Run()
    {
        // Strings are immutable (same as JS and Java). Methods return NEW strings.
        string name = "ada";
        name.ToUpper();                    // result thrown away!
        Console.WriteLine(name);           // still "ada"
        name = name.ToUpper();             // reassign to keep it
        Console.WriteLine(name);

        // Concatenating in a loop creates a new string every time: O(n^2).
        // StringBuilder is a mutable buffer (Java has the same class).
        var sb = new StringBuilder();
        for (int i = 1; i <= 5; i++)
        {
            sb.Append(i);
            if (i < 5) sb.Append(", ");
        }
        sb.AppendLine();                   // adds a newline
        sb.Append("done");
        sb.Insert(0, "Numbers: ");
        Console.WriteLine(sb.ToString());
        Console.WriteLine($"Length = {sb.Length}");

        // Rule of thumb:
        //  - a few pieces: interpolation $"..." or +
        //  - a list of values: string.Join
        //  - building text in a loop: StringBuilder
        var squares = new List<int>();
        for (int i = 1; i <= 5; i++) squares.Add(i * i);
        Console.WriteLine(string.Join(" ", squares));
    }
}
