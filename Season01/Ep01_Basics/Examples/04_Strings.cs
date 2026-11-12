namespace Ep01.Examples;

public static class Ex04_Strings
{
    public static void Run()
    {
        string name = "Ada";
        int age = 36;
        double score = 93.456;

        // $"..." is the JS template literal `...${x}...`
        Console.WriteLine($"Name: {name}, next year: {age + 1}");

        // Format specifier after a colon, alignment after a comma
        Console.WriteLine($"Score: {score:F1}");         // 93.5
        Console.WriteLine($"|{name,-8}|{age,5}|");       // left-pad / right-pad
        Console.WriteLine($"Price: {1234.5m:N2}");       // 1,234.50
        Console.WriteLine($"Literal braces: {{like this}}");

        // Verbatim string: backslashes are literal (handy for Windows paths, regex)
        string path = @"C:\temp\new";
        Console.WriteLine(path);

        // Raw string literal (C# 11): no escaping at all, indentation is trimmed
        // based on the closing """ position.
        string json = """
            {
              "name": "Ada",
              "tags": ["math", "code"]
            }
            """;
        Console.WriteLine(json);

        // Raw + interpolation: $$ means you need {{ }} to interpolate,
        // so single { } stay literal (perfect for JSON).
        string json2 = $$"""{"name": "{{name}}", "age": {{age}}}""";
        Console.WriteLine(json2);

        // Common escapes work as in JS
        Console.WriteLine("Tab:\tNewline:\\n Quote:\"");
    }
}
