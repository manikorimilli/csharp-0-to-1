namespace Ep04.Solutions;

public static class S02_PredictOutput
{
    public static void Run()
    {
        string s = "immutable";
        s.ToUpper();
        s.Replace("m", "M");
        Console.WriteLine(s);                           // immutable  (results were discarded)
        Console.WriteLine("abcdef".Substring(2, 3));    // cde        (start 2, LENGTH 3)
        Console.WriteLine("abcdef"[2..3]);              // c          (start 2, END 3 exclusive)

        var d = new Dictionary<string, int> { ["a"] = 1 };
        d["a"] = 2;
        Console.WriteLine(d.TryAdd("a", 3) + " " + d["a"]);   // False 2

        var set = new HashSet<int> { 1, 2, 3 };
        Console.WriteLine(set.Add(2) + " " + set.Count);      // False 3

        var stack = new Stack<int>(new[] { 1, 2, 3 });
        Console.WriteLine(stack.Pop());                        // 3 (items pushed in order 1,2,3)
    }
}
