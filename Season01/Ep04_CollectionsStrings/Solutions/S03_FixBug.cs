namespace Ep04.Solutions;

public static class S03_FixBug
{
    public static void Run()
    {
        var prices = new Dictionary<string, decimal> { ["apple"] = 1.2m, ["pear"] = 0.9m };
        var cart = new List<string> { "apple", "kiwi", "pear", "apple" };

        // Bug 1: removing inside foreach throws InvalidOperationException.
        cart.RemoveAll(item => item == "pear");

        decimal total = 0;
        foreach (var item in cart)
        {
            // Bug 2: prices["kiwi"] throws KeyNotFoundException.
            if (prices.TryGetValue(item, out var price))
                total += price;
        }

        // Bug 3: strings are immutable; assign the result.
        string summary = $"total: {total}".ToUpper();
        Console.WriteLine(summary);   // TOTAL: 2.4
    }
}
