namespace Ep03.Examples;

public static class Ex03_Methods
{
    // [modifiers] returnType Name(parameters) { body }
    static int Add(int a, int b)
    {
        return a + b;
    }

    // Expression-bodied method: like a JS arrow function with an implicit return
    static int Square(int x) => x * x;

    // void = returns nothing
    static void Greet(string name) => Console.WriteLine($"Hi {name}");

    // Static methods are called on the type; instance methods need an object (Ep06)
    public static void Run()
    {
        Console.WriteLine(Add(2, 3));
        Console.WriteLine(Square(7));
        Greet("Ada");

        // Local function: a method declared inside another method (like a nested JS function)
        int Twice(int n) => n * 2;
        Console.WriteLine(Twice(21));

        // `static` local function cannot capture outer variables (avoids accidental closures)
        static bool IsEven(int n) => n % 2 == 0;
        Console.WriteLine(IsEven(4));

        // Recursion works as usual
        Console.WriteLine(Factorial(5));
    }

    static long Factorial(int n) => n <= 1 ? 1 : n * Factorial(n - 1);
}
