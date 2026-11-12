namespace Ep03.Examples;

public static class Ex06_RefOutIn
{
    // ref: caller's variable is passed by reference and can be changed (C++ int&)
    static void Increment(ref int value) => value++;

    // out: method MUST assign it; used to return extra values (TryParse pattern)
    static bool TryDivide(int a, int b, out int result)
    {
        if (b == 0)
        {
            result = 0;
            return false;
        }
        result = a / b;
        return true;
    }

    // in: read-only reference (C++ const T&). Mostly for big structs; rare in app code.
    static double Length(in (double X, double Y) v) => Math.Sqrt(v.X * v.X + v.Y * v.Y);

    public static void Run()
    {
        int counter = 1;
        Increment(ref counter);          // `ref` is required at the call site too
        Console.WriteLine(counter);      // 2

        if (TryDivide(10, 3, out int q)) // declare the out variable inline
            Console.WriteLine($"10/3 = {q}");
        if (!TryDivide(1, 0, out _))     // `_` discards a value you don't need
            Console.WriteLine("cannot divide by zero");

        Console.WriteLine(Length((3, 4)));   // 5

        // JS has none of these: primitives are always copied, and you return an object
        // { ok, value } instead. In modern C# a tuple return is often nicer than out (lesson 08).
    }
}
