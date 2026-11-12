namespace Ep07.Examples;

// Extension methods add methods to EXISTING types without inheriting or editing them.
// Rules: a static class (not nested, not generic), a static method, `this` before the first parameter.
// JS analogy: String.prototype.truncate = function (n) {...}  but scoped, type-checked
// and only visible where the namespace is imported.
public static class StringExtensions
{
    public static string Truncate(this string value, int maxLength) =>
        value.Length <= maxLength ? value : value[..maxLength] + "...";

    public static bool IsBlank(this string? value) => string.IsNullOrWhiteSpace(value);
}

public static class EnumerableExtensions
{
    // Generic extension on an interface: works for List, arrays, HashSet...
    public static string JoinWith<T>(this IEnumerable<T> items, string separator) =>
        string.Join(separator, items);
}

public static class Ex07_ExtensionMethods
{
    public static void Run()
    {
        string title = "Extension methods are everywhere in .NET";
        Console.WriteLine(title.Truncate(20));       // looks like an instance method
        Console.WriteLine(StringExtensions.Truncate(title, 9)); // it is really a static call

        string? missing = null;
        Console.WriteLine(missing.IsBlank());        // works on null (it is a static call)

        Console.WriteLine(new[] { 1, 2, 3 }.JoinWith(" | "));
        Console.WriteLine(new List<string> { "a", "b" }.JoinWith(","));

        // ALL of LINQ (Where, Select, OrderBy...) is extension methods on IEnumerable<T>.
        // ASP.NET setup code too: builder.Services.AddControllers(), app.MapGet(...)
        // If a method "does not exist", you are probably missing a `using` for its namespace.
    }
}
