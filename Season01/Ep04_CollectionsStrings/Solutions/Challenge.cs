using System.Text;

namespace Ep04.Solutions;

public static class Challenge
{
    public static void Run()
    {
        string text = """
            The quick brown fox jumps over the lazy dog.
            The dog sleeps; the fox runs! Quick, quick.
            """;

        char[] separators = { ' ', '\n', '\r', '.', ',', ';', '!' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);

        var unique = new HashSet<string>(words, StringComparer.OrdinalIgnoreCase);

        var counts = new Dictionary<string, int>();
        string longest = "";
        foreach (var raw in words)
        {
            var w = raw.ToLowerInvariant();
            counts[w] = counts.GetValueOrDefault(w) + 1;
            if (w.Length > longest.Length) longest = w;
        }

        var ranked = new List<KeyValuePair<string, int>>(counts);
        // Sort by count descending, then alphabetically for ties
        ranked.Sort((a, b) => a.Value != b.Value
            ? b.Value.CompareTo(a.Value)
            : string.CompareOrdinal(a.Key, b.Key));

        var sb = new StringBuilder();
        sb.AppendLine($"Words:   {words.Length}");
        sb.AppendLine($"Unique:  {unique.Count}");
        sb.AppendLine("Top 3:");
        for (int i = 0; i < 3 && i < ranked.Count; i++)
            sb.AppendLine($"  {ranked[i].Key,-6} {ranked[i].Value}");
        sb.Append($"Longest: {longest}");

        Console.WriteLine(sb.ToString());
    }
}
