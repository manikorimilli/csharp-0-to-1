namespace Ep07.Examples;

public static class Ex05_Lambdas
{
    public static void Run()
    {
        // JS arrow functions and C# lambdas look almost identical:
        //   JS:  const square = x => x * x;
        //   C#:  Func<int, int> square = x => x * x;
        Func<int, int> square = x => x * x;
        Func<int, int, int> add = (a, b) => a + b;
        Func<string, string> shout = s =>
        {
            var upper = s.ToUpper();     // block body with return, like JS
            return upper + "!";
        };
        Console.WriteLine($"{square(4)} {add(1, 2)} {shout("hi")}");

        // C# 10: lambdas can have a natural type, so `var` works when types are explicit
        var parse = (string s) => int.Parse(s);
        Console.WriteLine(parse("41") + 1);

        // Explicit types and discards
        Func<int, string, string> fmt = (int n, string unit) => $"{n} {unit}";
        Func<int, int, int> first = (a, _) => a;
        Console.WriteLine($"{fmt(3, "kg")} {first(7, 8)}");

        // Closures capture variables (by reference, like JS)
        int counter = 0;
        Action increment = () => counter++;
        increment();
        increment();
        Console.WriteLine($"counter = {counter}");

        // Lambdas everywhere in the framework: List methods, LINQ (Ep08), ASP.NET endpoints
        var names = new List<string> { "bob", "ann", "cid" };
        names.Sort((a, b) => string.CompareOrdinal(a, b));
        names.ForEach(n => Console.Write($"{n} "));
        Console.WriteLine();
        Console.WriteLine(names.Exists(n => n.StartsWith('c')));

        // `static` lambda: cannot capture, guarantees no hidden allocations
        Func<int, int> twice = static n => n * 2;
        Console.WriteLine(twice(21));
    }
}
