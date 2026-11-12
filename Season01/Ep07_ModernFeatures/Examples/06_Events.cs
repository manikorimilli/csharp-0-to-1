namespace Ep07.Examples;

public static class Ex06_Events
{
    // EventArgs carries the event data
    class PriceChangedEventArgs(decimal oldPrice, decimal newPrice) : EventArgs
    {
        public decimal OldPrice { get; } = oldPrice;
        public decimal NewPrice { get; } = newPrice;
    }

    class Stock(string symbol)
    {
        public string Symbol { get; } = symbol;
        private decimal _price;

        // event EventHandler<T>: (object? sender, T args). The standard .NET shape.
        public event EventHandler<PriceChangedEventArgs>? PriceChanged;

        public decimal Price
        {
            get => _price;
            set
            {
                if (value == _price) return;
                var old = _price;
                _price = value;
                PriceChanged?.Invoke(this, new PriceChangedEventArgs(old, value));  // "emit"
            }
        }
    }

    public static void Run()
    {
        var stock = new Stock("ACME");

        // JS: element.addEventListener("change", handler)
        // C#: stock.PriceChanged += handler
        EventHandler<PriceChangedEventArgs> logHandler = (sender, e) =>
            Console.WriteLine($"[log] {((Stock)sender!).Symbol}: {e.OldPrice} -> {e.NewPrice}");

        stock.PriceChanged += logHandler;
        stock.PriceChanged += (_, e) =>
        {
            if (e.NewPrice > e.OldPrice * 1.1m) Console.WriteLine("[alert] jumped more than 10%!");
        };

        stock.Price = 100m;
        stock.Price = 105m;
        stock.Price = 130m;

        // JS: removeEventListener. You need the same delegate instance to unsubscribe.
        stock.PriceChanged -= logHandler;
        stock.Price = 90m;   // only the alert handler runs now (and stays quiet)

        // Outside the class you can only += and -=. You cannot invoke or clear the event.
        // stock.PriceChanged = null;   // compile error
        // Gotcha: an object subscribed to a long-lived publisher's event is kept alive.
        // Unsubscribe when done to avoid memory leaks.
    }
}
