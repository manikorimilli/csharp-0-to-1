namespace Ep06.Examples;

public static class Ex02_ObjectInitializers
{
    class Address
    {
        public string Street { get; set; } = "";
        public string City { get; set; } = "";
    }

    class Customer
    {
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public Address? Address { get; set; }
        public List<string> Tags { get; set; } = new();
    }

    public static void Run()
    {
        // Object initializer: set properties right after construction.
        // Looks like a JS object literal, but the type is fixed.
        //   JS: const c = { name: "Ann", age: 30, address: { city: "Oslo" } };
        var c = new Customer
        {
            Name = "Ann",
            Age = 30,
            Address = new Address { Street = "Main St 1", City = "Oslo" },
            Tags = { "vip", "newsletter" }     // collection initializer adds to existing list
        };
        Console.WriteLine($"{c.Name}, {c.Age}, {c.Address.City}, {string.Join("/", c.Tags)}");

        // Works with constructor args too
        var list = new List<Customer>
        {
            new() { Name = "Bob" },
            new() { Name = "Cid", Age = 40 }
        };
        Console.WriteLine(list.Count);

        // Anonymous types: quick throwaway objects (common in LINQ, Ep08)
        var point = new { X = 1, Y = 2 };
        Console.WriteLine(point);              // { X = 1, Y = 2 }
    }
}
