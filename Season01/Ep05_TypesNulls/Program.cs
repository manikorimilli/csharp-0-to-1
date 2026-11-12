// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep05.Examples;
using Ep05.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("Value types vs reference types", Ex01_ValueVsReference.Run),
    ["02"] = ("Structs vs classes", Ex02_StructsVsClasses.Run),
    ["03"] = ("Enums", Ex03_Enums.Run),
    ["04"] = ("null in C# vs JS null/undefined", Ex04_NullBasics.Run),
    ["05"] = ("Nullable value types (int?)", Ex05_NullableValueTypes.Run),
    ["06"] = ("Nullable reference types (string?)", Ex06_NullableReferenceTypes.Run),
    ["07"] = ("Null operators ?. ?? ??= !", Ex07_NullOperators.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: enum with flags and parsing", S04_Enums.Run),
    ["s5"] = ("Solution 5: refactor null checks", S05_Refactor.Run),
    ["s6"] = ("Solution 6: struct Money", S06_Money.Run),
    ["challenge"] = ("Episode challenge: user profile display", Challenge.Run),
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
