namespace Ep05.Examples;

public static class Ex01_ValueVsReference
{
    class Box { public int Value; }        // class  = reference type
    struct Point { public int X; }         // struct = value type

    public static void Run()
    {
        // Value types (int, double, bool, char, decimal, structs, enums, tuples):
        // assignment COPIES the value. Like JS primitives.
        int a = 1;
        int b = a;
        b = 99;
        Console.WriteLine($"a={a}, b={b}");             // a=1, b=99

        var p1 = new Point { X = 1 };
        var p2 = p1;                                    // full copy
        p2.X = 99;
        Console.WriteLine($"p1.X={p1.X}, p2.X={p2.X}"); // 1, 99

        // Reference types (classes, arrays, strings, List, Dictionary...):
        // assignment copies the REFERENCE. Like JS objects.
        var box1 = new Box { Value = 1 };
        var box2 = box1;                                // same object
        box2.Value = 99;
        Console.WriteLine($"box1.Value={box1.Value}");  // 99

        // Same for method parameters
        Bump(a, box1);
        Console.WriteLine($"after Bump: a={a}, box1.Value={box1.Value}");   // a unchanged, box changed

        // == on classes compares references (unless overridden)
        var box3 = new Box { Value = 99 };
        Console.WriteLine($"box1 == box3: {box1 == box3}");   // False, different objects

        // string is a reference type that BEHAVES like a value: immutable + == compares content
        string s1 = "hi", s2 = string.Concat("h", "i");
        Console.WriteLine($"s1 == s2: {s1 == s2}");           // True
    }

    static void Bump(int number, Box box)
    {
        number++;        // changes the local copy only
        box.Value++;     // changes the shared object
    }
}
