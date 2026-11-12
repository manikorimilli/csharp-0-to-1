namespace Ep07.Examples;

// Custom exception: derive from Exception, name ends with "Exception"
public class InsufficientStockException : Exception
{
    public string Sku { get; }
    public InsufficientStockException(string sku, int requested)
        : base($"Not enough stock for {sku} (requested {requested})")
    {
        Sku = sku;
    }
}

public static class Ex01_Exceptions
{
    static void Reserve(string sku, int qty)
    {
        if (qty <= 0) throw new ArgumentOutOfRangeException(nameof(qty), "Quantity must be positive");
        if (qty > 5) throw new InsufficientStockException(sku, qty);
        Console.WriteLine($"Reserved {qty} x {sku}");
    }

    public static void Run()
    {
        foreach (var qty in new[] { 2, 10, -1 })
        {
            try
            {
                Reserve("ABC", qty);
            }
            catch (InsufficientStockException ex)          // most specific first
            {
                Console.WriteLine($"Stock problem for {ex.Sku}: {ex.Message}");
            }
            catch (ArgumentException ex) when (ex.ParamName == "qty")   // exception filter
            {
                Console.WriteLine($"Bad argument: {ex.Message}");
            }
            finally
            {
                Console.WriteLine("  (finally always runs)");
            }
        }

        // Rethrowing: use `throw;` to keep the original stack trace.
        // `throw ex;` resets it (a classic code review comment).
        try
        {
            try { int.Parse("x"); }
            catch (FormatException)
            {
                Console.WriteLine("logging, then rethrowing");
                throw;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"outer caught {ex.GetType().Name}");
        }

        // Wrapping: keep the cause as InnerException (JS: new Error(msg, { cause }))
        try
        {
            try { _ = new Dictionary<string, int>()["missing"]; }
            catch (KeyNotFoundException inner) { throw new InvalidOperationException("Config missing", inner); }
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine($"{ex.Message} <- {ex.InnerException?.GetType().Name}");
        }

        // Differences from JS: you can only throw Exception objects (not strings),
        // and catch blocks pick by TYPE instead of `if (e instanceof X)` inside one catch.
    }
}
