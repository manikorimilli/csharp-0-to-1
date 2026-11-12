namespace Ep06.Examples;

public static class Ex05_Static
{
    class Counter
    {
        // static = belongs to the TYPE, shared by all instances. JS: static count = 0;
        public static int InstancesCreated { get; private set; }

        public int Id { get; }

        public Counter()
        {
            InstancesCreated++;
            Id = InstancesCreated;
        }

        // static method: no `this`, called on the type
        public static Counter Create() => new Counter();
    }

    // static class: cannot be instantiated, only static members.
    // Used for helpers and extension methods. (Math, Console, File are static classes.)
    static class Temperature
    {
        public const double AbsoluteZero = -273.15;   // const is implicitly static
        public static double ToFahrenheit(double c) => c * 9 / 5 + 32;
    }

    public static void Run()
    {
        var a = new Counter();
        var b = Counter.Create();
        Console.WriteLine($"a.Id={a.Id}, b.Id={b.Id}, total={Counter.InstancesCreated}");

        Console.WriteLine(Temperature.ToFahrenheit(100));
        Console.WriteLine(Temperature.AbsoluteZero);

        // `using static` imports static members so you can skip the type name
        // using static System.Math;   ->   Sqrt(16) instead of Math.Sqrt(16)
    }
}
