// Episode runner (top-level statements; `await` works here because the compiler
// generates `static async Task Main`).
//   dotnet run              -> list examples and solutions
//   dotnet run -- 03        -> run example 03
//   dotnet run -- s2        -> run the solution to exercise 2
//   dotnet run -- all       -> run every example
using Ep09.Examples;
using Ep09.Solutions;

var items = new Dictionary<string, (string Title, Func<Task> Run)>
{
    ["01"] = ("Task and Task<T> (vs Promise)", Ex01_Tasks.Run),
    ["02"] = ("async / await", Ex02_AsyncAwait.Run),
    ["03"] = ("Task.WhenAll and Task.WhenAny", Ex03_WhenAllWhenAny.Run),
    ["04"] = ("Exceptions in async code", Ex04_AsyncExceptions.Run),
    ["05"] = ("CancellationToken", Ex05_Cancellation.Run),
    ["06"] = ("Common mistakes", Ex06_CommonMistakes.Run),
    ["s1"] = ("Solution 1: convert C++", S01_ConvertCpp.Run),
    ["s2"] = ("Solution 2: predict the output", S02_PredictOutput.Run),
    ["s3"] = ("Solution 3: fix the bug", S03_FixBug.Run),
    ["s4"] = ("Solution 4: parallel price lookup", S04_PriceLookup.Run),
    ["s5"] = ("Solution 5: refactor sequential awaits", S05_Refactor.Run),
    ["s6"] = ("Solution 6: timeout helper", S06_Timeout.Run),
    ["challenge"] = ("Episode challenge: async downloader", Challenge.Run),
};

string key = args.Length > 0 ? args[0].ToLowerInvariant() : "";

if (key == "all")
{
    foreach (var (k, item) in items.Where(i => !i.Key.StartsWith('s') && i.Key != "challenge"))
    {
        Console.WriteLine($"\n===== {k}: {item.Title} =====");
        await item.Run();
    }
}
else if (items.TryGetValue(key, out var chosen))
{
    Console.WriteLine($"===== {key}: {chosen.Title} =====");
    await chosen.Run();
}
else
{
    Console.WriteLine("Usage: dotnet run -- <key>\n");
    foreach (var (k, item) in items) Console.WriteLine($"  {k,-10} {item.Title}");
}
