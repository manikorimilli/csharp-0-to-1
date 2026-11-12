namespace Ep06.Solutions;

public static class S06_Shapes
{
    interface IShape
    {
        string Name { get; }
        double Area();
    }

    abstract class Shape : IShape
    {
        public string Name => GetType().Name;
        public abstract double Area();
        public override string ToString() => $"{Name} area={Area():F2}";
    }

    class Circle(double radius) : Shape
    {
        public override double Area() => Math.PI * radius * radius;
    }

    class Rectangle : Shape
    {
        public double Width { get; }
        public double Height { get; }
        public Rectangle(double width, double height) { Width = width; Height = height; }
        public override double Area() => Width * Height;
    }

    sealed class Square : Rectangle
    {
        public Square(double side) : base(side, side) { }
    }

    public static void Run()
    {
        List<IShape> shapes = [new Circle(1), new Rectangle(2, 3), new Square(2)];
        double total = 0;
        foreach (var s in shapes)
        {
            Console.WriteLine(s);
            total += s.Area();
        }
        Console.WriteLine($"Total area: {total:F2}");
    }
}
