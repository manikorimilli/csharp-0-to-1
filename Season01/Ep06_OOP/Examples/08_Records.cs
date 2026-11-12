namespace Ep06.Examples;

public static class Ex08_Records
{
    // record: a class designed for DATA. One line gives you:
    //   constructor, init-only properties, value equality, ToString, deconstruction, `with`
    record Person(string Name, int Age);

    // Records can have extra members too
    record Product(string Sku, decimal Price)
    {
        public bool IsExpensive => Price > 100;
    }

    // record struct: same features, but a value type
    readonly record struct Point(int X, int Y);

    public static void Run()
    {
        var a = new Person("Ann", 30);
        var b = new Person("Ann", 30);

        Console.WriteLine(a);                  // Person { Name = Ann, Age = 30 }
        Console.WriteLine(a == b);             // True: compares VALUES (a class would say False)

        // Non-destructive mutation. JS: const older = { ...a, age: 31 };
        var older = a with { Age = 31 };
        Console.WriteLine(older);

        // a.Age = 40;                         // compile error: init-only

        var (name, age) = a;                   // deconstruction
        Console.WriteLine($"{name} {age}");

        var p = new Product("X1", 250m);
        Console.WriteLine($"{p.Sku} expensive? {p.IsExpensive}");

        var pt = new Point(1, 2);
        Console.WriteLine(pt with { Y = 5 });

        // When to use: DTOs, API request/response models, events, value objects.
        // Use a normal class for things with identity and changing state (entities, services).
    }
}
