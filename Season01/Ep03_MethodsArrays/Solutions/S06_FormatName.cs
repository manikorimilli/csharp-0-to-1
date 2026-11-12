namespace Ep03.Solutions;

public static class S06_FormatName
{
    static string FormatName(string first, string last, string? middle = null,
                             bool lastNameFirst = false, bool upper = false)
    {
        string given = middle is null ? first : $"{first} {middle}";
        string result = lastNameFirst ? $"{last}, {given}" : $"{given} {last}";
        return upper ? result.ToUpper() : result;
    }

    public static void Run()
    {
        Console.WriteLine(FormatName("Ada", "Lovelace"));
        Console.WriteLine(FormatName("Ada", "Lovelace", lastNameFirst: true));
        Console.WriteLine(FormatName("John", "Smith", "Q", upper: true));
    }
}
