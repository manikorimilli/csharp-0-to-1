// Episode runner (this file uses top-level statements: no class, no Main).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep06.Examples;
using Ep06.Solutions;

var items = new Dictionary<string, (string Title, Action Run)>
{
    ["01"] = ("Classes and constructors", Ex01_ClassesConstructors.Run),
    ["02"] = ("Object initializers", Ex02_ObjectInitializers.Run),
    ["03"] = ("Properties", Ex03_Properties.Run),
    ["04"] = ("Access modifiers", Ex04_AccessModifiers.Run),
    ["05"] = ("static", Ex05_Static.Run),
    ["06"] = ("Inheritance, virtual/override, abstract, sealed", Ex06_Inheritance.Run),
    ["07"] = ("Interfaces", Ex07_Interfaces.Run),
    ["08"] = ("Records", Ex08_Records.Run),
    ["09"] = ("Namespaces", Ex09_Namespaces.Run),
    ["10"] = ("Partial classes", Ex10_PartialClasses.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: BankAccount class", S04_BankAccount.Run),
    ["s5"] = ("Solution 5: refactor class to record", S05_Refactor.Run),
    ["s6"] = ("Solution 6: shapes with interface and abstract class", S06_Shapes.Run),
    ["challenge"] = ("Episode challenge: library system", Challenge.Run),
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
