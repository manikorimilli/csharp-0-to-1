namespace Ep05.Examples;

public static class Ex07_NullOperators
{
    class Address { public string? City { get; set; } }
    class Person
    {
        public string Name { get; set; } = "";
        public Address? Address { get; set; }
        public List<string>? Tags { get; set; }
    }

    public static void Run()
    {
        var withCity = new Person { Name = "Ann", Address = new Address { City = "Oslo" } };
        var noAddress = new Person { Name = "Bob" };

        // ?.  null-conditional, same as JS optional chaining
        Console.WriteLine(withCity.Address?.City);            // Oslo
        Console.WriteLine(noAddress.Address?.City is null);   // True

        // ??  null-coalescing, same as JS ??
        string city = noAddress.Address?.City ?? "Unknown";
        Console.WriteLine(city);

        // ?. with methods and indexers
        int? tagCount = noAddress.Tags?.Count;                // int? because it may be null
        string? firstTag = noAddress.Tags?[0];
        Console.WriteLine($"{tagCount ?? 0} {firstTag ?? "-"}");

        // ??= assign only if null, same as JS ??=
        noAddress.Tags ??= new List<string>();
        noAddress.Tags.Add("new");
        Console.WriteLine(noAddress.Tags.Count);              // 1

        // ?? throw: guard clause in one line (very common in constructors)
        string name = withCity.Name ?? throw new ArgumentNullException(nameof(withCity.Name));
        Console.WriteLine(name);

        // !  null-forgiving: "I know it's not null, stop warning".
        // No runtime effect. Same as TypeScript's `!`. Use sparingly.
        string sure = withCity.Address!.City!;
        Console.WriteLine(sure.Length);

        // Note: there is no ?. on the left of an assignment before C# 14:
        // noAddress.Address?.City = "X";    // compile error in C# 12
    }
}
