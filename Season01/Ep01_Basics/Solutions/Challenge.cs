using System.Globalization;

namespace Ep01.Solutions;

public static class Challenge
{
    public static void Run()
    {
        string[] lines = { "Coffee,3.50,2", "Bagel,2.25,abc", "Juice,4.10,1", "Muffin,x,3" };
        decimal total = 0m;

        Console.WriteLine($"{"Item",-10}{"Qty",5}{"Price",10}{"Sum",10}");
        Console.WriteLine(new string('-', 35));

        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            string name = parts[0];

            bool priceOk = decimal.TryParse(parts[1], NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price);
            bool qtyOk = int.TryParse(parts[2], out int qty);

            if (!priceOk || !qtyOk)
            {
                Console.Error.WriteLine($"Skipping invalid line: {line}");
                continue;
            }

            decimal sum = price * qty;
            total += sum;
            Console.WriteLine($"{name,-10}{qty,5}{price,10:F2}{sum,10:F2}");
        }

        Console.WriteLine(new string('-', 35));
        Console.WriteLine($"{"TOTAL",-10}{total,25:F2}");
    }
}
