namespace Ep05.Examples;

public static class Ex02_StructsVsClasses
{
    // A small, immutable value: good struct candidate.
    readonly struct Temperature
    {
        public double Celsius { get; }
        public Temperature(double celsius) => Celsius = celsius;
        public double Fahrenheit => Celsius * 9 / 5 + 32;
        public override string ToString() => $"{Celsius:F1}°C";
    }

    // An entity with identity and behavior: a class.
    class Thermostat
    {
        public string Room { get; }
        public Temperature Target { get; set; }
        public Thermostat(string room, Temperature target) { Room = room; Target = target; }
    }

    public static void Run()
    {
        var t = new Temperature(21.5);
        Console.WriteLine($"{t} = {t.Fahrenheit:F1}°F");

        var living = new Thermostat("Living room", t);
        var alias = living;                    // same object
        alias.Target = new Temperature(23);
        Console.WriteLine($"{living.Room}: {living.Target}");   // 23.0°C

        // Structs always have a value; default(Temperature) is all zeros, never null.
        Temperature zero = default;
        Console.WriteLine($"default struct: {zero}");

        // Thermostat? could be null; Temperature cannot (without ?).
        Thermostat? none = null;
        Console.WriteLine(none is null);

        // Framework structs you use daily: int, DateTime, TimeSpan, Guid, decimal
        DateTime now = new DateTime(2024, 1, 15);
        DateTime later = now.AddDays(10);      // returns a NEW value
        Console.WriteLine($"{now:yyyy-MM-dd} -> {later:yyyy-MM-dd}");
    }
}
