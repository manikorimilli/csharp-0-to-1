namespace Ep07.Examples;

public static class Ex02_UsingDisposable
{
    // IDisposable = "I hold something that must be released": files, sockets,
    // DB connections, timers. Like C++ RAII, or JS try/finally { handle.close() }.
    class TempResource : IDisposable
    {
        private readonly string _name;
        public TempResource(string name) { _name = name; Console.WriteLine($"open {_name}"); }
        public void Use() => Console.WriteLine($"use {_name}");
        public void Dispose() => Console.WriteLine($"dispose {_name}");
    }

    public static void Run()
    {
        // using declaration (C# 8): disposed at the end of the enclosing scope
        {
            using var r1 = new TempResource("A");
            r1.Use();
        }   // A disposed here

        // using statement with a block (older style, still common)
        using (var r2 = new TempResource("B"))
        {
            r2.Use();
        }   // B disposed here, even if an exception is thrown

        // Real example: files
        string path = Path.Combine(Path.GetTempPath(), "csharp-0-to-1-demo.txt");
        using (var writer = new StreamWriter(path))
        {
            writer.WriteLine("hello file");
        }   // flushed and closed
        using var reader = new StreamReader(path);
        Console.WriteLine(reader.ReadLine());

        // (One-liners like File.WriteAllText / File.ReadAllText handle this for you.)
        // `await using` exists for IAsyncDisposable (Ep09).
    }
}
