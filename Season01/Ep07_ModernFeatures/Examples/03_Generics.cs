namespace Ep07.Examples;

public static class Ex03_Generics
{
    // Generic method: T is chosen by the caller (or inferred). Like TypeScript generics,
    // but REAL at runtime (List<int> and List<string> are different types).
    static T FirstOr<T>(List<T> items, T fallback) => items.Count > 0 ? items[0] : fallback;

    // Constraint: T must implement IComparable<T> so we can call CompareTo
    static T Max<T>(T a, T b) where T : IComparable<T> => a.CompareTo(b) >= 0 ? a : b;

    // Generic class
    class Box<T>
    {
        public T Value { get; }
        public Box(T value) => Value = value;
        public Box<TOut> Map<TOut>(Func<T, TOut> f) => new(f(Value));
        public override string ToString() => $"Box({Value})";
    }

    interface IEntity { int Id { get; } }
    record User(int Id, string Name) : IEntity;

    // Common real-world shape: a generic repository constrained to entities
    class InMemoryRepository<T> where T : class, IEntity
    {
        private readonly Dictionary<int, T> _items = new();
        public void Add(T item) => _items[item.Id] = item;
        public T? Find(int id) => _items.GetValueOrDefault(id);
    }

    // new() constraint: T must have a parameterless constructor
    static T Create<T>() where T : new() => new T();

    public static void Run()
    {
        Console.WriteLine(FirstOr(new List<string>(), "none"));
        Console.WriteLine(Max(3, 7));
        Console.WriteLine(Max("apple", "pear"));

        var box = new Box<int>(21);
        Console.WriteLine(box.Map(x => x * 2));
        Console.WriteLine(box.Map(x => $"#{x}"));

        var repo = new InMemoryRepository<User>();
        repo.Add(new User(1, "Ann"));
        Console.WriteLine(repo.Find(1)?.Name ?? "not found");
        Console.WriteLine(repo.Find(2)?.Name ?? "not found");

        var list = Create<List<int>>();
        Console.WriteLine($"created {list.GetType().Name} with {list.Count} items");

        // Constraints you will see: where T : class | struct | new() | SomeBase | ISomething | notnull
    }
}
