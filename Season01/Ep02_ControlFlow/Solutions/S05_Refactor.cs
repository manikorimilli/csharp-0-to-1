namespace Ep02.Solutions;

public static class S05_Refactor
{
    static string GetDiscountLabel(string tier, int years) => (tier, years) switch
    {
        ("gold", >= 5) => "30%",
        ("gold", _) => "20%",
        ("silver", _) => "10%",
        _ => "0%"
    };

    public static void Run()
    {
        Console.WriteLine(GetDiscountLabel("gold", 6));    // 30%
        Console.WriteLine(GetDiscountLabel("gold", 1));    // 20%
        Console.WriteLine(GetDiscountLabel("silver", 9));  // 10%
        Console.WriteLine(GetDiscountLabel("bronze", 2));  // 0%
    }
}
