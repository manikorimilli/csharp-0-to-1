namespace Ep05.Solutions;

public static class S05_Refactor
{
    class Address { public string? City { get; set; } }
    class Customer { public Address? Address { get; set; } }
    class Order
    {
        public Customer? Customer { get; set; }
        public List<string>? Notes { get; set; }
    }

    static string GetCity(Order? order) => order?.Customer?.Address?.City ?? "N/A";

    static List<string> EnsureNotes(Order order) => order.Notes ??= new List<string>();

    public static void Run()
    {
        var full = new Order { Customer = new Customer { Address = new Address { City = "Lima" } } };
        Console.WriteLine(GetCity(full));         // Lima
        Console.WriteLine(GetCity(new Order()));  // N/A
        Console.WriteLine(GetCity(null));         // N/A

        var o = new Order();
        EnsureNotes(o).Add("gift wrap");
        Console.WriteLine(EnsureNotes(o).Count);  // 1, same list returned the second time
    }
}
