namespace Ep07.Solutions;

public static class S02_PredictOutput
{
    static int Test()
    {
        try { Console.WriteLine("try"); return 1; }
        finally { Console.WriteLine("finally"); }
    }

    public static void Run()
    {
        Console.WriteLine(Test());
        // try / finally / 1   (finally runs before the method actually returns)

        var actions = new List<Action>();
        for (int i = 0; i < 3; i++) actions.Add(() => Console.Write(i));
        foreach (var a in actions) a();
        Console.WriteLine();
        // 333   one shared `i`, captured by reference, is 3 when the lambdas run

        var actions2 = new List<Action>();
        foreach (var j in new[] { 0, 1, 2 }) actions2.Add(() => Console.Write(j));
        foreach (var a in actions2) a();
        Console.WriteLine();
        // 012   foreach gets a fresh variable per iteration

        Func<int, int> f = x => x + 1;
        Func<int, int> g = x => x * 10;
        Console.WriteLine(g(f(2)));
        // 30

        Action? chain = () => Console.Write("A");
        chain += () => Console.Write("B");
        chain += () => Console.Write("C");
        chain -= () => Console.Write("B");   // a NEW lambda instance: nothing matches, nothing removed
        chain?.Invoke();
        Console.WriteLine();
        // ABC   (-= returns Action? because removing the last target gives null, hence ?.Invoke)

        try { throw new ArgumentNullException("x"); }
        catch (ArgumentException e) when (e.ParamName == "y") { Console.WriteLine("filter y"); }
        catch (ArgumentException e) { Console.WriteLine($"caught {e.GetType().Name}"); }
        // caught ArgumentNullException  (filter false; ArgumentNullException IS an ArgumentException)
    }
}
