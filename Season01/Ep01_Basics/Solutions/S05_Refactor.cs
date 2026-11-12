namespace Ep01.Solutions;

public static class S05_Refactor
{
    const int ReferenceYear = 2024;

    public static void Run()
    {
        var firstName = "Grace";
        var birthYear = 1906;
        var age = ReferenceYear - birthYear;

        Console.WriteLine($"Name: {firstName}, age in {ReferenceYear}: {age} (born {birthYear})");
        Console.WriteLine($@"Path: C:\Users\{firstName}\Documents");
    }
}
