namespace Ep01.Solutions;

public static class S03_FixBug
{
    public static void Run()
    {
        decimal price = 19.99m;      // fix 1: decimal literals need the m suffix
        int quantity = 3;            // fix 2: no implicit string -> int (use int.Parse if it really is text)
        int itemsSold = 5;
        int days = 2;
        double averagePerDay = (double)itemsSold / days;   // fix 3: avoid integer division
        Console.WriteLine($"Total: {price * quantity}, avg/day: {averagePerDay}");
    }
}
