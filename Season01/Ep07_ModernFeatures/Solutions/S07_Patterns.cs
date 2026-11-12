namespace Ep07.Solutions;

public static class S07_Patterns
{
    static string Classify(object? input) => input switch
    {
        null => "nothing",
        0 => "zero",
        int n when n < 0 => "negative int",
        int and >= 1 and <= 9 => "small int",
        int => "big int",
        "" => "empty text",
        string s => $"text of {s.Length} chars",
        int[] and [] => "empty array",
        int[] and [var only] => $"one item: {only}",
        int[] and [0, ..] => "starts with 0",
        int[] and [.., var last] => $"array ending in {last}",
        ValueTuple<int, int> { Item1: 0 } or ValueTuple<int, int> { Item2: 0 } => "point on axis",
        ValueTuple<int, int> => "point",
        _ => "unknown"
    };

    public static void Run()
    {
        object?[] inputs =
        {
            null, 0, -5, 7, 1000, "", "hello",
            new int[0], new[] { 4 }, new[] { 0, 1 }, new[] { 1, 2, 3 },
            (0, 5), (2, 3), 3.14
        };
        foreach (var i in inputs)
            Console.WriteLine($"{Show(i),-10} -> {Classify(i)}");
    }

    static string Show(object? o) => o switch
    {
        null => "null",
        int[] arr => $"[{string.Join(",", arr)}]",
        _ => o.ToString() ?? ""
    };
}
