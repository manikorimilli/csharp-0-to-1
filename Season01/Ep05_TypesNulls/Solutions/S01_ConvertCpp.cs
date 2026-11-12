namespace Ep05.Solutions;

public static class S01_ConvertCpp
{
    enum Color { Red, Green, Blue }
    readonly record struct Point(int X, int Y);       // value type with value equality
    class Person
    {
        public string Name { get; init; } = "";
        public Color Favorite { get; init; }
    }

    static Person? FindPerson(List<Person> people, string name)
    {
        foreach (var p in people)
            if (p.Name == name) return p;
        return null;                                   // instead of nullptr
    }

    public static void Run()
    {
        var a = new Point(1, 2);
        var b = a with { X = 10 };                     // copy with a change (structs copy anyway)
        var people = new List<Person>
        {
            new() { Name = "Ann", Favorite = Color.Blue },
            new() { Name = "Bob", Favorite = Color.Red }
        };
        Person? p = FindPerson(people, "Cid");
        Console.WriteLine($"{a.X} {b.X} {p?.Name ?? "nobody"}");   // 1 10 nobody
    }
}
