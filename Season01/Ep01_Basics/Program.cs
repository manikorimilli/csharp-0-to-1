// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep01.Examples;
using Ep01.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("dotnet CLI and project", Ex01_DotnetCli.Run),
    ["02"] = ("Top-level statements vs Main", Ex02_TopLevelStatements.Run),
    ["03"] = ("Types, var, const", Ex03_Types.Run),
    ["04"] = ("Strings: interpolation and raw strings", Ex04_Strings.Run),
    ["05"] = ("Console input and output", Ex05_ConsoleIO.Run),
    ["06"] = ("Operators", Ex06_Operators.Run),
    ["07"] = ("Casting, Parse, TryParse", Ex07_CastingParsing.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: safe age reader", S04_AgeReader.Run),
    ["s5"] = ("Solution 5: refactor", S05_Refactor.Run),
    ["s6"] = ("Solution 6: temperature table", S06_Temperatures.Run),
    ["challenge"] = ("Episode challenge: receipt printer", Challenge.Run),
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
