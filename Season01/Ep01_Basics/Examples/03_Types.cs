namespace Ep01.Examples;

public static class Ex03_Types
{
    // const = compile-time constant. Must be a literal-ish value.
    const double Pi = 3.14159;

    public static void Run()
    {
        int count = 42;               // 32-bit integer. JS only has `number`.
        long big = 9_000_000_000L;    // 64-bit. Underscores are allowed in literals.
        double ratio = 0.1 + 0.2;     // 64-bit float, exactly like a JS number.
        decimal money = 0.1m + 0.2m;  // 128-bit base-10 type for money. Note the `m`.
        bool done = false;            // only true/false, no truthy/falsy
        char grade = 'A';             // single quotes = char
        string name = "Ada";          // double quotes = string

        var inferred = 10;            // var = inferred at COMPILE time; it is an int forever
        // inferred = "ten";          // compile error CS0029: cannot convert string to int

        Console.WriteLine($"int {count}, long {big}");
        Console.WriteLine($"double  0.1+0.2 = {ratio}   == 0.3? {ratio == 0.3}");
        Console.WriteLine($"decimal 0.1+0.2 = {money}   == 0.3? {money == 0.3m}");
        Console.WriteLine($"bool {done}, char {grade}, string {name}");
        Console.WriteLine($"var inferred as: {inferred.GetType().Name}");
        Console.WriteLine($"int range: {int.MinValue} .. {int.MaxValue}");
        Console.WriteLine($"const Pi = {Pi}");

        // Every type has a default value. Locals must be assigned before use though.
        Console.WriteLine($"default(int)={default(int)}, default(bool)={default(bool)}, default(string)={default(string) ?? "null"}");
    }
}
