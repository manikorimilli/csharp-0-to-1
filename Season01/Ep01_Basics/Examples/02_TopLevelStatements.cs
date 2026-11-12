namespace Ep01.Examples;

// Before C# 9 every program needed the Java-style shape:
//
//   namespace MyApp;
//   class Program
//   {
//       static void Main(string[] args) { Console.WriteLine("Hi"); }
//   }
//
// Program.cs in this project uses TOP-LEVEL STATEMENTS instead: you just write
// code at the top of one file and the compiler generates Main for you.
// `args` is still available there. Only ONE file per project may do this.
public static class Ex02_TopLevelStatements
{
    // This is what a classic Main looks like. (Named MainLike so the compiler
    // does not see two entry points.)
    static int MainLike(string[] args)
    {
        Console.WriteLine($"Got {args.Length} args: {string.Join(", ", args)}");
        return 0; // exit code, same idea as `return 0;` in C++ main
    }

    public static void Run()
    {
        int exitCode = MainLike(["--verbose", "input.txt"]);
        Console.WriteLine($"Exit code would be {exitCode}");
    }
}
