namespace Ep04.Solutions;

public static class S04_Brackets
{
    static readonly Dictionary<char, char> Pairs = new() { [')'] = '(', [']'] = '[', ['}'] = '{' };

    static bool IsBalanced(string text)
    {
        var stack = new Stack<char>();
        foreach (char c in text)
        {
            if (c is '(' or '[' or '{')
            {
                stack.Push(c);
            }
            else if (Pairs.TryGetValue(c, out char opener))
            {
                if (!stack.TryPop(out char top) || top != opener)
                    return false;
            }
        }
        return stack.Count == 0;
    }

    public static void Run()
    {
        foreach (var t in new[] { "(a[b]{c})", "(]", "((", "no brackets" })
            Console.WriteLine($"{t,-12} {IsBalanced(t)}");
    }
}
