namespace Ep08;

// Shared, in-memory data used by the examples and solutions.
public record Customer(int Id, string Name, string Country, bool IsVip);
public record Product(int Id, string Name, string Category, decimal Price);
public record OrderLine(int ProductId, int Quantity);
public record Order(int Id, int CustomerId, DateTime Date, List<OrderLine> Lines);

public static class Data
{
    public static readonly List<Customer> Customers =
    [
        new(1, "Ann", "NO", true),
        new(2, "Bob", "US", false),
        new(3, "Cid", "US", true),
        new(4, "Dee", "DE", false),
    ];

    public static readonly List<Product> Products =
    [
        new(1, "Laptop", "Electronics", 1200m),
        new(2, "Mouse", "Electronics", 25m),
        new(3, "Desk", "Furniture", 300m),
        new(4, "Chair", "Furniture", 150m),
        new(5, "Pen", "Office", 2m),
        new(6, "Monitor", "Electronics", 250m),
    ];

    public static readonly List<Order> Orders =
    [
        new(100, 1, new DateTime(2024, 1, 5), [new(1, 1), new(2, 2)]),
        new(101, 2, new DateTime(2024, 1, 9), [new(5, 10)]),
        new(102, 1, new DateTime(2024, 2, 1), [new(3, 1), new(4, 2)]),
        new(103, 3, new DateTime(2024, 2, 14), [new(6, 2), new(2, 1)]),
        new(104, 2, new DateTime(2024, 3, 3), [new(4, 1)]),
    ];
}
