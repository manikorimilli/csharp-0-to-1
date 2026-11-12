// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep07.Examples;
using Ep07.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("Exceptions", Ex01_Exceptions.Run),
    ["02"] = ("using and IDisposable", Ex02_UsingDisposable.Run),
    ["03"] = ("Generics and constraints", Ex03_Generics.Run),
    ["04"] = ("Delegates, Func, Action", Ex04_Delegates.Run),
    ["05"] = ("Lambdas", Ex05_Lambdas.Run),
    ["06"] = ("Events", Ex06_Events.Run),
    ["07"] = ("Extension methods", Ex07_ExtensionMethods.Run),
    ["08"] = ("Advanced pattern matching", Ex08_AdvancedPatterns.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: generic Result type", S04_Result.Run),
    ["s5"] = ("Solution 5: refactor to Func and extension method", S05_Refactor.Run),
    ["s6"] = ("Solution 6: temperature sensor with event", S06_Sensor.Run),
    ["s7"] = ("Solution 7: classify with patterns", S07_Patterns.Run),
    ["challenge"] = ("Episode challenge: retry pipeline", Challenge.Run),
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
