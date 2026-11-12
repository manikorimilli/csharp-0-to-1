// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep02.Examples;
using Ep02.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("if / else and ternary", Ex01_IfElse.Run),
    ["02"] = ("switch statement", Ex02_SwitchStatement.Run),
    ["03"] = ("switch expressions", Ex03_SwitchExpressions.Run),
    ["04"] = ("Basic pattern matching", Ex04_PatternMatching.Run),
    ["05"] = ("for, while, do-while", Ex05_Loops.Run),
    ["06"] = ("foreach", Ex06_Foreach.Run),
    ["07"] = ("break and continue", Ex07_BreakContinue.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: FizzBuzz with a switch expression", S04_FizzBuzz.Run),
    ["s5"] = ("Solution 5: refactor to switch expression", S05_Refactor.Run),
    ["s6"] = ("Solution 6: first duplicate", S06_FirstDuplicate.Run),
    ["challenge"] = ("Episode challenge: command interpreter", Challenge.Run),
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
