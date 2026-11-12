// A file-scoped namespace: everything in this file belongs to Ep06.Billing.
// (Older style wraps the file in `namespace Ep06.Billing { ... }`.)
namespace Ep06.Billing;

public class Invoice
{
    public string Number { get; }
    public decimal Total { get; }
    public Invoice(string number, decimal total) { Number = number; Total = total; }
    public override string ToString() => $"Invoice {Number}: {Total:F2}";
}
