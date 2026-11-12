namespace Ep08.Solutions;

public static class S02_PredictOutput
{
    public static void Run()
    {
        var nums = new List<int> { 5, 1, 4 };
        var query = nums.Where(n => n > 2);
        nums.Add(10);
        Console.WriteLine(string.Join(",", query));
        // 5,4,10   deferred: the query runs after Add

        var sorted = nums.OrderBy(n => n % 2).OrderBy(n => n);
        Console.WriteLine(string.Join(",", sorted));
        // 1,4,5,10 the second OrderBy replaces the first (should have been ThenBy)

        Console.WriteLine(nums.FirstOrDefault(n => n > 100));
        // 0        default(int), not null

        Console.WriteLine(nums.Skip(1).Take(2).Sum());
        // 5        skip 5, take 1 and 4

        Console.WriteLine(nums.Select(n => n * 2).Where(n => n > 5).Count());
        // 3        10, 2, 8, 20 -> 10, 8, 20

        Console.WriteLine(new[] { "b", "a", "b", "c" }.Distinct().Count());
        // 3

        Console.WriteLine(Enumerable.Range(1, 4).Aggregate((a, b) => a * b));
        // 24       1*2*3*4
    }
}
