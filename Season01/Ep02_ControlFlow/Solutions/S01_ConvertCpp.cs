namespace Ep02.Solutions;

public static class S01_ConvertCpp
{
    public static void Run()
    {
        var text = "Hello World 2024";
        int vowels = 0, digits = 0, others = 0;

        foreach (var c in text)
        {
            if (char.ToLower(c) is 'a' or 'e' or 'i' or 'o' or 'u') vowels++;
            else if (char.IsDigit(c)) digits++;
            else others++;
        }

        Console.WriteLine($"{vowels} {digits} {others}");   // 3 4 9
    }
}
