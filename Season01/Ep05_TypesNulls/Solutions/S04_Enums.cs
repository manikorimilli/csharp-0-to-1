namespace Ep05.Solutions;

public static class S04_Enums
{
    enum Priority { Low, Normal, High, Critical }

    [Flags]
    enum Days
    {
        None = 0,
        Mon = 1, Tue = 2, Wed = 4, Thu = 8, Fri = 16, Sat = 32, Sun = 64,
        Weekdays = Mon | Tue | Wed | Thu | Fri,
        Weekend = Sat | Sun
    }

    static Priority ParsePriority(string? text) =>
        Enum.TryParse<Priority>(text, ignoreCase: true, out var p) && Enum.IsDefined(p)
            ? p
            : Priority.Normal;

    static bool IsWorkday(Days schedule, Days day) => schedule.HasFlag(day);

    public static void Run()
    {
        foreach (var t in new[] { "high", "CRITICAL", "urgent", null, "7" })
            Console.WriteLine($"{t ?? "null",-9} -> {ParsePriority(t)}");
        // "7" would parse to (Priority)7 without the IsDefined check.

        var mySchedule = Days.Weekdays & ~Days.Fri;   // Mon to Thu
        Console.WriteLine(mySchedule);                          // Mon, Tue, Wed, Thu
        Console.WriteLine(IsWorkday(mySchedule, Days.Wed));     // True
        Console.WriteLine(IsWorkday(mySchedule, Days.Fri));     // False
    }
}
