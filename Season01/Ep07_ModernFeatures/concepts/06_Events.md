# 06. Events (vs JS addEventListener)

**In one line:** an `event` is a delegate that outsiders can only subscribe to (`+=`) and unsubscribe from (`-=`). Only the owning class can raise it.

## JS vs C#

| JS | C# |
|---|---|
| `el.addEventListener("change", h)` | `stock.PriceChanged += h;` |
| `el.removeEventListener("change", h)` | `stock.PriceChanged -= h;` |
| `el.dispatchEvent(new CustomEvent("change", { detail }))` | `PriceChanged?.Invoke(this, args);` (inside the class) |
| `emitter.on("x", h)` (Node) | same idea, typed |

## The standard shape

```csharp
public class PriceChangedEventArgs(decimal oldPrice, decimal newPrice) : EventArgs
{
    public decimal OldPrice { get; } = oldPrice;
    public decimal NewPrice { get; } = newPrice;
}

public class Stock
{
    public event EventHandler<PriceChangedEventArgs>? PriceChanged;

    protected virtual void OnPriceChanged(decimal oldP, decimal newP) =>
        PriceChanged?.Invoke(this, new PriceChangedEventArgs(oldP, newP));
}

stock.PriceChanged += (sender, e) => Console.WriteLine(e.NewPrice);
```

## Key points

- Handler signature is `(object? sender, TEventArgs e)`.
- Always raise with `?.Invoke`: with no subscribers the event is `null`.
- To unsubscribe you need the same delegate instance, so keep a reference instead of using an inline lambda.

## Where you will see it

UI frameworks (WinForms, WPF, MAUI), `INotifyPropertyChanged`, `FileSystemWatcher`, `Timer.Elapsed`.
Web back ends use events less; they use DI, middleware, and message queues instead.

## Gotchas

- A subscriber is kept alive by the publisher's event. Forgetting `-=` on a long-lived publisher is a classic memory leak.

Run it: `dotnet run -- 06`
