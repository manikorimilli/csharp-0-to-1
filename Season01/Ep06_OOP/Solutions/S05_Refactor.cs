namespace Ep06.Solutions;

public static class S05_Refactor
{
    record CustomerDto(string Name, string Email, int LoyaltyPoints);

    public static void Run()
    {
        var a = new CustomerDto("Ann", "ann@x.com", 10);
        var b = new CustomerDto("Ann", "ann@x.com", 10);
        Console.WriteLine(a == b);                         // True
        Console.WriteLine(a);                              // CustomerDto { Name = Ann, ... }
        Console.WriteLine(a with { LoyaltyPoints = 50 });  // replaces WithPoints()
    }
}
