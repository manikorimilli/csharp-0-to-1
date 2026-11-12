// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep08.Examples;
using Ep08.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("Where and Select", Ex01_WhereSelect.Run),
    ["02"] = ("OrderBy and ThenBy", Ex02_OrderBy.Run),
    ["03"] = ("FirstOrDefault, Single, Find", Ex03_FirstOrDefault.Run),
    ["04"] = ("Any, All, Count, Sum and friends", Ex04_Aggregates.Run),
    ["05"] = ("GroupBy", Ex05_GroupBy.Run),
    ["06"] = ("ToList, ToDictionary and other everyday operators", Ex06_Materializing.Run),
    ["07"] = ("Method syntax vs query syntax", Ex07_QuerySyntax.Run),
    ["08"] = ("Deferred execution", Ex08_DeferredExecution.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: sales queries", S04_SalesQueries.Run),
    ["s5"] = ("Solution 5: refactor loops to LINQ", S05_Refactor.Run),
    ["s6"] = ("Solution 6: query syntax join", S06_QueryJoin.Run),
    ["challenge"] = ("Episode challenge: sales report", Challenge.Run),
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
