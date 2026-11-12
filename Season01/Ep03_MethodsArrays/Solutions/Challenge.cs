namespace Ep03.Solutions;

public static class Challenge
{
    static (double Average, int Best) Summarize(int[] scores)
    {
        int sum = 0, best = int.MinValue;
        foreach (var s in scores)
        {
            sum += s;
            if (s > best) best = s;
        }
        return ((double)sum / scores.Length, best);
    }

    static void AddBonus(int[] scores, params int[] bonusIndexes)
    {
        foreach (var i in bonusIndexes)
            scores[i] = Math.Min(100, scores[i] + 5);   // arrays are references: caller sees this
    }

    static void Report(string name, int[] scores)
    {
        var (avg, best) = Summarize(scores);
        Console.WriteLine($"{name,-5} scores: {string.Join(",", scores),-15} avg: {avg,5:F1}  best: {best}");
    }

    static void Report(string[] names, int[][] scores)
    {
        for (int i = 0; i < names.Length; i++)
            Report(names[i], scores[i]);
    }

    public static void Run()
    {
        string[] students = { "Ann", "Bob", "Cid" };
        int[][] scores = { new[] { 90, 85, 77 }, new[] { 60, 70 }, new[] { 88, 92, 95, 79 } };

        AddBonus(scores[1], 0, 1);
        Report(students, scores);
    }
}
