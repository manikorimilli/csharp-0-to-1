namespace Ep07.Examples;

public static class Ex04_Delegates
{
    // A delegate is a typed function reference. In JS functions are already values;
    // in C# the function needs a TYPE. You rarely declare your own: use Func/Action.
    delegate int MathOp(int a, int b);     // custom delegate type (older style)

    static int Add(int a, int b) => a + b;
    static void Log(string msg) => Console.WriteLine($"[log] {msg}");

    // Func<in1, in2, ..., out>: returns a value (LAST type parameter is the return type)
    // Action<in1, in2, ...>:    returns void
    // Predicate<T>:             same as Func<T, bool>
    static int Apply(Func<int, int, int> op, int x, int y) => op(x, y);

    public static void Run()
    {
        MathOp op = Add;                                // method group -> delegate
        Console.WriteLine(op(2, 3));

        Func<int, int, int> multiply = (a, b) => a * b; // lambda -> Func
        Func<string> now = () => "noon";
        Func<int, bool> isEven = n => n % 2 == 0;
        Action<string> logger = Log;
        Action done = () => Console.WriteLine("done!");

        Console.WriteLine(Apply(multiply, 4, 5));       // pass functions around like JS callbacks
        Console.WriteLine(Apply(Add, 4, 5));
        Console.WriteLine($"{now()} {isEven(10)}");
        logger("hello");
        done();

        // Delegates can be null. Invoke safely:
        Action? maybe = null;
        maybe?.Invoke();                                // like JS callback?.()

        // Multicast: += adds more targets (this is how events work)
        Action chain = () => Console.Write("one ");
        chain += () => Console.Write("two ");
        chain();
        Console.WriteLine();

        // Store functions in a dictionary: a typical "strategy table"
        var ops = new Dictionary<string, Func<double, double, double>>
        {
            ["+"] = (a, b) => a + b,
            ["/"] = (a, b) => a / b,
        };
        Console.WriteLine(ops["/"](10, 4));
    }
}
