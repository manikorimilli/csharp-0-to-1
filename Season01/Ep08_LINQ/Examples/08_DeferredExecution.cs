namespace Ep08.Examples;

public static class Ex08_DeferredExecution
{
    public static void Run()
    {
        var numbers = new List<int> { 1, 2, 3 };

        // Building a query does NOT run it. It runs when you iterate (foreach, ToList, Count...).
        // JS arrays are eager: filter() runs immediately. This is more like a JS generator.
        var query = numbers.Where(n =>
        {
            Console.WriteLine($"  checking {n}");
            return n > 1;
        });
        Console.WriteLine("query built, nothing checked yet");

        numbers.Add(4);    // the query will see this, because it hasn't run yet

        Console.WriteLine("first enumeration:");
        foreach (var n in query) Console.WriteLine($"  -> {n}");

        Console.WriteLine("Count() runs it AGAIN:");
        Console.WriteLine($"  count = {query.Count()}");

        // Materialize once with ToList() if you will reuse the results
        var snapshot = query.ToList();
        numbers.Add(5);
        Console.WriteLine($"snapshot has {snapshot.Count} items, list now has {numbers.Count}");

        // Short-circuiting: FirstOrDefault/Any stop as soon as they can
        Console.WriteLine("Any(n > 1):");
        Console.WriteLine($"  {query.Any()}");

        // Infinite sequences work because of laziness (yield return = JS generator function*)
        Console.WriteLine(string.Join(",", Naturals().Where(n => n % 7 == 0).Take(3)));

        // Why this matters in real code: with Entity Framework the query is translated to SQL
        // and runs on the database only when enumerated. Calling ToList() too early pulls the
        // whole table into memory.
    }

    static IEnumerable<int> Naturals()
    {
        for (int i = 1; ; i++) yield return i;
    }
}
