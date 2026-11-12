namespace Ep06.Solutions;

public static class S03_FixBug
{
    class Entity
    {
        public int Id { get; }
        public Entity(int id) => Id = id;
    }

    class Order : Entity
    {
        // Fix 1 (CS0272/CS8852): init-only can't be changed later. Use `set` if it must change.
        public string Note { get; set; } = "";

        // Fix 2 (CS7036): Entity has no parameterless constructor; call base(id).
        public Order(int id) : base(id) { }
    }

    // Fix 3 (logic): a class compares by reference, so the HashSet kept both "sale" tags.
    // A record compares by value.
    record Tag(string Name);

    public static void Run()
    {
        var order = new Order(42) { Note = "fragile" };
        order.Note = "very fragile";
        Console.WriteLine($"{order.Id}: {order.Note}");

        var tags = new HashSet<Tag> { new Tag("sale"), new Tag("sale"), new Tag("new") };
        Console.WriteLine(tags.Count);   // 2
    }
}
