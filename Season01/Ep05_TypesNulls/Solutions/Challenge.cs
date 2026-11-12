namespace Ep05.Solutions;

public static class Challenge
{
    enum Membership { Free, Plus, Pro }

    class Address
    {
        public string? City { get; set; }
        public string Country { get; set; } = "";
    }

    class User
    {
        public string Name { get; set; } = "";
        public string? Nickname { get; set; }
        public int? Age { get; set; }
        public Address? Address { get; set; }
        public Membership Level { get; set; }
        public List<string>? Tags { get; set; }
    }

    static string Card(User u)
    {
        string nick = u.Nickname is null ? "" : $" \"{u.Nickname}\"";
        string age = u.Age is int a ? $"({a})" : "(age unknown)";
        string place = u.Address switch
        {
            null => "no address",
            { City: null } addr => addr.Country,
            var addr => $"{addr.City}, {addr.Country}"
        };
        string tags = u.Tags is { Count: > 0 } t ? string.Join(", ", t) : "none";
        return $"{u.Name}{nick} {age} - {place} - {u.Level} - tags: {tags}";
    }

    public static void Run()
    {
        var users = new List<User>
        {
            new() { Name = "Ann", Nickname = "annie", Age = 34, Level = Membership.Pro,
                    Address = new Address { City = "Oslo", Country = "Norway" },
                    Tags = new List<string> { "admin", "beta" } },
            new() { Name = "Bob" },
            new() { Name = "Cid", Age = 51, Level = Membership.Plus,
                    Address = new Address { Country = "Chile" }, Tags = new List<string>() }
        };

        foreach (var u in users)
            Console.WriteLine(Card(u));
    }
}
