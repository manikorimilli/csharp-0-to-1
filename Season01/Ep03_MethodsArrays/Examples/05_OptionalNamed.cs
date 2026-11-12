namespace Ep03.Examples;

public static class Ex05_OptionalNamed
{
    // Optional parameters need a compile-time constant default and come last.
    static string Greet(string name, string greeting = "Hello", bool shout = false)
    {
        var text = $"{greeting}, {name}!";
        return shout ? text.ToUpper() : text;
    }

    public static void Run()
    {
        Console.WriteLine(Greet("Ada"));
        Console.WriteLine(Greet("Ada", "Hi"));

        // Named arguments: skip optional ones and make call sites readable.
        // JS usually fakes this with an options object: greet("Ada", { shout: true })
        Console.WriteLine(Greet("Ada", shout: true));
        Console.WriteLine(Greet(shout: true, name: "Bob", greeting: "Yo"));

        // Named args are great for bools and numbers that are unclear at the call site:
        //   Save(file, true, false)              what do these mean?
        //   Save(file, overwrite: true, backup: false)
    }
}
