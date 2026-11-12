namespace Ep05.Solutions;

public static class S03_FixBug
{
    struct Pixel { public int X; public int Y; }
    class Profile { public string? Bio { get; set; } }

    static int? GetStock() => null;

    public static void Run()
    {
        var pixels = new List<Pixel> { new Pixel { X = 1, Y = 1 } };
        // Fix 1 (CS1612): list[0] returns a COPY of the struct. Replace the whole element.
        var px = pixels[0];
        px.X = 5;
        pixels[0] = px;
        // (Better: make Pixel a readonly record struct and write pixels[0] = pixels[0] with { X = 5 };)

        int? stock = GetStock();
        // Fix 2 (CS0266): int? does not convert to int implicitly.
        int available = stock ?? 0;

        var profile = new Profile();
        // Fix 3 (NullReferenceException, and warning CS8602): Bio may be null.
        Console.WriteLine(profile.Bio?.Length ?? 0);

        Console.WriteLine($"{pixels[0].X} {available}");
    }
}
