namespace Ep02.Examples;

public static class Ex03_SwitchExpressions
{
    // A switch EXPRESSION returns a value. Very common in modern code.
    static string Describe(int httpStatus) => httpStatus switch
    {
        200 => "OK",
        201 or 204 => "Success, little or no body",
        >= 300 and < 400 => "Redirect",                  // relational patterns
        404 => "Not found",
        >= 500 => "Server error",
        _ => "Other"                                       // _ = default
    };

    static decimal ShippingCost(string country, decimal orderTotal) => (country, orderTotal) switch
    {
        ("US", >= 50m) => 0m,           // tuple pattern: match two values at once
        ("US", _) => 5m,
        (_, >= 100m) => 10m,
        _ => 20m
    };

    public static void Run()
    {
        foreach (int code in new[] { 200, 204, 301, 404, 503, 418 })
            Console.WriteLine($"{code} -> {Describe(code)}");

        Console.WriteLine(ShippingCost("US", 60m));   // 0
        Console.WriteLine(ShippingCost("US", 10m));   // 5
        Console.WriteLine(ShippingCost("DE", 150m));  // 10
        Console.WriteLine(ShippingCost("DE", 15m));   // 20

        // JS has no equivalent; you would write a lookup object or if/else chain:
        //   const label = { 200: "OK", 404: "Not found" }[code] ?? "Other";
    }
}
