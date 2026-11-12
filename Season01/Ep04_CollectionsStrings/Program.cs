// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep04.Examples;
using Ep04.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("List<T>", Ex01_List.Run),
    ["02"] = ("Dictionary<TKey,TValue>", Ex02_Dictionary.Run),
    ["03"] = ("HashSet<T>", Ex03_HashSet.Run),
    ["04"] = ("Queue<T> and Stack<T>", Ex04_QueueStack.Run),
    ["05"] = ("Common string methods", Ex05_StringMethods.Run),
    ["06"] = ("StringBuilder and immutability", Ex06_StringBuilder.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: balanced brackets", S04_Brackets.Run),
    ["s5"] = ("Solution 5: refactor to idiomatic collections", S05_Refactor.Run),
    ["s6"] = ("Solution 6: slugify", S06_Slugify.Run),
    ["challenge"] = ("Episode challenge: word statistics", Challenge.Run),
};

string key = args.Length > 0 ? args[0].ToLowerInvariant() : "";

if (key == "all")
{
    foreach (var (k, item) in items.Where(i => !i.Key.StartsWith('s') && i.Key != "challenge"))
    {
        Console.WriteLine($"\n===== {k}: {item.Title} =====");
        item.Run();
    }
}
else if (items.TryGetValue(key, out var chosen))
{
    Console.WriteLine($"===== {key}: {chosen.Title} =====");
    chosen.Run();
}
else
{
    Console.WriteLine("Usage: dotnet run -- <key>\n");
    foreach (var (k, item) in items) Console.WriteLine($"  {k,-10} {item.Title}");
}
