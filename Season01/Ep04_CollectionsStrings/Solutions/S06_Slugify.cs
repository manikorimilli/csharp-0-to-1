using System.Text;

namespace Ep04.Solutions;

public static class S06_Slugify
{
    static string Slugify(string title)
    {
        var sb = new StringBuilder();
        bool pendingDash = false;

        foreach (char c in title)
        {
            if (char.IsLetterOrDigit(c))
            {
                if (pendingDash && sb.Length > 0) sb.Append('-');
                sb.Append(char.ToLowerInvariant(c));
                pendingDash = false;
            }
            else
            {
                pendingDash = true;   // collapse runs, and never start with '-'
            }
        }
        return sb.ToString();
    }

    public static void Run()
    {
        Console.WriteLine(Slugify("  Hello, World! C# Rocks  "));   // hello-world-c-rocks
        Console.WriteLine(Slugify("--Already--slugged--"));          // already-slugged
    }
}
