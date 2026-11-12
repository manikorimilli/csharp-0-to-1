namespace Ep05.Examples;

public static class Ex03_Enums
{
    // An enum is a named set of integer constants. JS has no enum (TypeScript does).
    enum OrderStatus
    {
        Pending,          // 0
        Paid,             // 1
        Shipped,          // 2
        Cancelled = 99    // explicit value
    }

    // [Flags]: combine values with bitwise OR. Values must be powers of two.
    [Flags]
    enum Permission
    {
        None = 0,
        Read = 1,
        Write = 2,
        Delete = 4,
        All = Read | Write | Delete
    }

    public static void Run()
    {
        var status = OrderStatus.Paid;
        Console.WriteLine(status);                 // Paid (prints the NAME)
        Console.WriteLine((int)status);            // 1
        Console.WriteLine((OrderStatus)2);         // Shipped

        // Parse from string (e.g. from JSON or a query string)
        if (Enum.TryParse<OrderStatus>("shipped", ignoreCase: true, out var parsed))
            Console.WriteLine($"parsed: {parsed}");

        // All values
        foreach (var s in Enum.GetValues<OrderStatus>())
            Console.Write($"{s}={(int)s} ");
        Console.WriteLine();

        // Switch expressions on enums are very common
        string label = status switch
        {
            OrderStatus.Pending => "Waiting for payment",
            OrderStatus.Paid => "Preparing",
            OrderStatus.Shipped => "On the way",
            OrderStatus.Cancelled => "Cancelled",
            _ => "Unknown"
        };
        Console.WriteLine(label);

        // Flags
        var perms = Permission.Read | Permission.Write;
        Console.WriteLine(perms);                               // Read, Write
        Console.WriteLine(perms.HasFlag(Permission.Write));     // True
        Console.WriteLine(perms.HasFlag(Permission.Delete));    // False
        perms |= Permission.Delete;
        Console.WriteLine(perms == Permission.All);             // True

        // Gotcha: any int can be cast to an enum, even undefined ones
        var weird = (OrderStatus)42;
        Console.WriteLine($"{weird} defined? {Enum.IsDefined(weird)}");
    }
}
