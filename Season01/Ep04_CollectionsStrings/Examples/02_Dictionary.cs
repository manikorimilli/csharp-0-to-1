namespace Ep04.Examples;

public static class Ex02_Dictionary
{
    public static void Run()
    {
        // Dictionary<TKey, TValue> = JS Map (or a plain object used as a map)
        var ages = new Dictionary<string, int>
        {
            ["Ann"] = 31,              // index initializer
            ["Bob"] = 25
        };

        ages["Cid"] = 40;              // add or overwrite (map.set)
        ages.Add("Dan", 19);           // add; THROWS if key exists
        bool added = ages.TryAdd("Ann", 99);   // false, no exception, no overwrite
        Console.WriteLine($"TryAdd Ann again: {added}");

        Console.WriteLine(ages["Ann"]);        // get; THROWS KeyNotFoundException if missing

        // Safe lookup: TryGetValue (the everyday pattern)
        if (ages.TryGetValue("Zed", out int zedAge))
            Console.WriteLine(zedAge);
        else
            Console.WriteLine("Zed not found");

        // Or a default value
        Console.WriteLine(ages.GetValueOrDefault("Zed", -1));

        Console.WriteLine(ages.ContainsKey("Bob"));   // map.has
        ages.Remove("Bob");                            // map.delete
        Console.WriteLine($"Count = {ages.Count}");    // map.size

        // Iterate: KeyValuePair, which deconstructs
        foreach (var (name, age) in ages)
            Console.WriteLine($"{name} is {age}");

        // Keys and Values collections
        Console.WriteLine(string.Join(",", ages.Keys));
        Console.WriteLine(ages.Values.Sum());

        // Counting pattern
        var counts = new Dictionary<char, int>();
        foreach (char ch in "banana")
            counts[ch] = counts.GetValueOrDefault(ch) + 1;
        Console.WriteLine(string.Join(" ", counts.Select(kv => $"{kv.Key}:{kv.Value}")));
    }
}
