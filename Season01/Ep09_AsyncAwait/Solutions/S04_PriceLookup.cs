namespace Ep09.Solutions;

public static class S04_PriceLookup
{
    static async Task<decimal> GetPriceAsync(string sku)
    {
        await Task.Delay(sku.Length * 50);
        if (sku == "GHOST") throw new KeyNotFoundException($"Unknown sku {sku}");
        return sku.Length * 9.99m;
    }

    public static async Task Run()
    {
        string[] skus = { "PEN", "LAMP", "GHOST", "DESK" };

        var tasks = skus.Select(async sku =>
        {
            try
            {
                return (Sku: sku, Price: (decimal?)await GetPriceAsync(sku));
            }
            catch (KeyNotFoundException ex)
            {
                Console.WriteLine($"  warning: {ex.Message}");
                return (Sku: sku, Price: (decimal?)null);
            }
        });

        var results = await Task.WhenAll(tasks);
        Dictionary<string, decimal?> prices = results.ToDictionary(r => r.Sku, r => r.Price);

        foreach (var (sku, price) in prices)
            Console.WriteLine($"{sku,-6} {(price is null ? "n/a" : price.Value.ToString("F2"))}");
    }
}
