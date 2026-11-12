namespace Ep05.Solutions;

public static class S06_Money
{
    readonly struct Money
    {
        public decimal Amount { get; }
        public string Currency { get; }

        public Money(decimal amount, string currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public Money Add(Money other)
        {
            if (other.Currency != Currency)
                throw new InvalidOperationException($"Cannot add {other.Currency} to {Currency}");
            return new Money(Amount + other.Amount, Currency);   // returns a new value
        }

        public override string ToString() => $"{Amount:F2} {Currency}";
    }

    public static void Run()
    {
        var price = new Money(10m, "EUR");
        var copy = price;                       // independent copy
        copy = copy.Add(new Money(2.5m, "EUR"));
        Console.WriteLine($"{price} / {copy}"); // 10.00 EUR / 12.50 EUR

        try
        {
            price.Add(new Money(1m, "USD"));
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}
