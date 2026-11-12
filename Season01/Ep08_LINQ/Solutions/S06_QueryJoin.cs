namespace Ep08.Solutions;

public static class S06_QueryJoin
{
    public static void Run()
    {
        var lines =
            from o in Data.Orders
            join c in Data.Customers on o.CustomerId equals c.Id
            from l in o.Lines                                  // second `from` = SelectMany
            join p in Data.Products on l.ProductId equals p.Id
            orderby o.Date, p.Name
            select $"{o.Date:yyyy-MM-dd} | #{o.Id} | {c.Name} | {p.Name} x{l.Quantity} = {l.Quantity * p.Price}";

        foreach (var line in lines)
            Console.WriteLine(line);
    }
}
