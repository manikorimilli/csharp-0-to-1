// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep03.Examples;
using Ep03.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("Arrays", Ex01_Arrays.Run),
    ["02"] = ("Multi-dimensional and jagged arrays", Ex02_MultiDimJagged.Run),
    ["03"] = ("Methods", Ex03_Methods.Run),
    ["04"] = ("Overloading", Ex04_Overloading.Run),
    ["05"] = ("Optional and named arguments", Ex05_OptionalNamed.Run),
    ["06"] = ("ref, out, in", Ex06_RefOutIn.Run),
    ["07"] = ("params", Ex07_Params.Run),
    ["08"] = ("Tuples and deconstruction", Ex08_Tuples.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: MinMax with a tuple", S04_MinMax.Run),
    ["s5"] = ("Solution 5: refactor out params to tuple", S05_Refactor.Run),
    ["s6"] = ("Solution 6: Format with optional args", S06_FormatName.Run),
    ["s7"] = ("Solution 7: matrix transpose", S07_Transpose.Run),
    ["challenge"] = ("Episode challenge: grade book", Challenge.Run),
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
