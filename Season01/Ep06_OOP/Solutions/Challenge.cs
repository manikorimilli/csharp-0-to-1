namespace Ep06.Solutions;

public static class Challenge
{
    record Book(string Isbn, string Title, string Author);

    abstract class Member(string name)
    {
        public string Name { get; } = name;
        public abstract int MaxLoans { get; }
        public virtual string Describe() => $"{Name} (max {MaxLoans})";
    }

    class Student(string name) : Member(name)
    {
        public override int MaxLoans => 2;
    }

    class Staff(string name) : Member(name)
    {
        public override int MaxLoans => 5;
        public override string Describe() => base.Describe() + " (staff)";
    }

    interface INotifier
    {
        void Notify(Member member, string message);
    }

    class ConsoleNotifier : INotifier
    {
        public void Notify(Member member, string message) => Console.WriteLine($"  -> {member.Name}: {message}");
    }

    class Library
    {
        private readonly INotifier _notifier;
        private readonly Dictionary<string, Book> _catalog = new();
        private readonly Dictionary<string, Member> _loans = new();   // isbn -> borrower

        public Library(INotifier notifier) => _notifier = notifier;

        public void AddBook(Book book) => _catalog[book.Isbn] = book;

        public bool Borrow(Member member, string isbn)
        {
            if (!_catalog.TryGetValue(isbn, out var book))
                return Fail(member, $"Unknown ISBN {isbn}");

            if (_loans.ContainsKey(isbn))
                return Fail(member, $"'{book.Title}' is already lent out");

            int current = 0;
            foreach (var borrower in _loans.Values)
                if (borrower == member) current++;   // reference equality: same member object

            if (current >= member.MaxLoans)
                return Fail(member, $"Loan limit {member.MaxLoans} reached");

            _loans[isbn] = member;
            _notifier.Notify(member, $"You borrowed '{book.Title}' by {book.Author}");
            return true;
        }

        public void Return(string isbn)
        {
            if (_loans.Remove(isbn, out var member))
                _notifier.Notify(member, $"Thanks for returning '{_catalog[isbn].Title}'");
        }

        private bool Fail(Member member, string reason)
        {
            _notifier.Notify(member, reason);
            return false;
        }
    }

    public static void Run()
    {
        var library = new Library(new ConsoleNotifier());
        library.AddBook(new Book("111", "Clean Code", "Robert C. Martin"));
        library.AddBook(new Book("222", "C# in Depth", "Jon Skeet"));
        library.AddBook(new Book("333", "Refactoring", "Martin Fowler"));

        Member ann = new Student("Ann");
        Member bob = new Staff("Bob");
        Console.WriteLine(ann.Describe());
        Console.WriteLine(bob.Describe());

        library.Borrow(ann, "111");
        library.Borrow(ann, "222");
        library.Borrow(ann, "333");   // limit reached
        library.Borrow(bob, "111");   // already lent
        library.Borrow(bob, "999");   // unknown
        library.Return("111");
        library.Borrow(bob, "111");
    }
}
