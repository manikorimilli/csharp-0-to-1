namespace Ep01.Examples;

public static class Ex05_ConsoleIO
{
    public static void Run()
    {
        Console.Write("What is your name? ");       // no newline (like process.stdout.write)
        string? input = Console.ReadLine();         // returns string? : null when input ends (Ctrl+D)

        // string? means "may be null". The compiler warns if you use it carelessly.
        string name = string.IsNullOrWhiteSpace(input) ? "stranger" : input.Trim();
        Console.WriteLine($"Hello, {name}!");

        Console.Error.WriteLine("This line goes to stderr (console.error)");

        // Composite formatting, the older style you will still see in code bases:
        Console.WriteLine("{0} has {1} letters", name, name.Length);
    }
}
