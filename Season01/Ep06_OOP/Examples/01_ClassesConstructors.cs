namespace Ep06.Examples;

public static class Ex01_ClassesConstructors
{
    // JS:
    //   class Product {
    //     constructor(name, price) { this.name = name; this.price = price; }
    //     describe() { return `${this.name}: ${this.price}`; }
    //   }
    class Product
    {
        // Fields must be declared (JS creates them on assignment)
        private readonly string _name;     // readonly: only set in constructor
        private decimal _price;

        // Constructor has the class name, no return type
        public Product(string name, decimal price)
        {
            _name = name;
            _price = price;
        }

        // Constructor chaining with `: this(...)`
        public Product(string name) : this(name, 0m) { }

        public string Describe() => $"{_name}: {_price:F2}";
        public void ApplyDiscount(decimal percent) => _price -= _price * percent / 100;
    }

    // Primary constructor (C# 12): parameters are in scope in the whole class body.
    // Very common in newer code for services: class OrderService(IRepo repo) { ... }
    class Greeter(string greeting)
    {
        public string Greet(string name) => $"{greeting}, {name}!";
    }

    public static void Run()
    {
        var p = new Product("Laptop", 1000m);     // `new` is required, like JS
        p.ApplyDiscount(10);
        Console.WriteLine(p.Describe());

        var free = new Product("Sticker");
        Console.WriteLine(free.Describe());

        Product p2 = new("Mouse", 25m);           // target-typed new
        Console.WriteLine(p2.Describe());

        var g = new Greeter("Hello");
        Console.WriteLine(g.Greet("Ada"));

        // No `this.` needed to access members (but you may use it).
        // Printing an object shows its type name unless you override ToString().
        Console.WriteLine(p);
    }
}
