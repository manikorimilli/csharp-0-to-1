namespace Ep06.Solutions;

public static class S02_PredictOutput
{
    class Base
    {
        public virtual string Virtual() => "Base.Virtual";
        public string NonVirtual() => "Base.NonVirtual";
    }
    class Derived : Base
    {
        public override string Virtual() => "Derived.Virtual";
        public new string NonVirtual() => "Derived.NonVirtual";   // hides, does not override
    }
    class PointClass { public int X { get; set; } }
    record PointRecord(int X);
    class Tracker { public static int Count; public Tracker() => Count++; }

    public static void Run()
    {
        Base b = new Derived();
        Console.WriteLine(b.Virtual());                  // Derived.Virtual   (runtime type wins)
        Console.WriteLine(b.NonVirtual());               // Base.NonVirtual   (compile-time type wins)
        Console.WriteLine(((Derived)b).NonVirtual());    // Derived.NonVirtual

        var p1 = new PointClass { X = 1 };
        var p2 = new PointClass { X = 1 };
        var r1 = new PointRecord(1);
        var r2 = new PointRecord(1);
        Console.WriteLine($"{p1 == p2} {r1 == r2} {r1 with { X = 2 }}");
        // False True PointRecord { X = 2 }

        _ = new Tracker(); _ = new Tracker(); _ = new Tracker();
        Console.WriteLine(Tracker.Count);                // 3
    }
}
