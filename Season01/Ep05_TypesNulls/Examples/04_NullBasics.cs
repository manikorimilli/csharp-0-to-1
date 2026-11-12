namespace Ep05.Examples;

public static class Ex04_NullBasics
{
    class Customer { public string Name = ""; }

    public static void Run()
    {
        // JS has two "nothing" values: null and undefined.
        // C# has ONE: null. There is no undefined:
        //  - locals must be assigned before use (compile error otherwise)
        //  - fields get their default value (0, false, null)
        //  - missing dictionary keys THROW instead of returning undefined
        //  - missing properties are compile errors

        Customer? c = null;                          // reference types can be null
        Console.WriteLine(c is null);                // True

        try
        {
            Console.WriteLine(c!.Name);              // like JS "Cannot read properties of null"
        }
        catch (NullReferenceException)
        {
            Console.WriteLine("NullReferenceException (the C# TypeError)");
        }

        // Value types cannot be null unless you add ? (next lesson)
        int count = 0;
        // int bad = null;                           // compile error
        Console.WriteLine(count);

        // Checking for null: these are all fine, `is null` is the modern style
        c = new Customer { Name = "Ann" };
        if (c != null) Console.WriteLine("!= null");
        if (c is not null) Console.WriteLine("is not null");
        if (c is { Name: var name }) Console.WriteLine($"pattern: {name}");
    }
}
