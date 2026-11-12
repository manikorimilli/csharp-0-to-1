namespace Ep06.Examples;

public static class Ex07_Interfaces
{
    // An interface is a contract: members without implementation.
    // JS has no interfaces (TypeScript does, but only at compile time).
    // Naming: always starts with I.
    interface INotifier
    {
        string Channel { get; }
        void Send(string to, string message);
    }

    interface IHasPriority
    {
        int Priority { get; }
    }

    // A class can implement MANY interfaces (but inherit only ONE class)
    class EmailNotifier : INotifier, IHasPriority
    {
        public string Channel => "email";
        public int Priority => 1;
        public void Send(string to, string message) => Console.WriteLine($"[email to {to}] {message}");
    }

    class SmsNotifier : INotifier
    {
        public string Channel => "sms";
        public void Send(string to, string message) => Console.WriteLine($"[sms to {to}] {message}");
    }

    // Code depends on the interface, not the concrete class. This is the
    // basis of dependency injection (Ep10) and of mocking in tests.
    class AlertService
    {
        private readonly INotifier _notifier;
        public AlertService(INotifier notifier) => _notifier = notifier;
        public void Alert(string user) => _notifier.Send(user, "Something happened");
    }

    public static void Run()
    {
        new AlertService(new EmailNotifier()).Alert("ann@x.com");
        new AlertService(new SmsNotifier()).Alert("+4712345678");

        INotifier n = new EmailNotifier();
        if (n is IHasPriority p) Console.WriteLine($"{n.Channel} priority {p.Priority}");

        // Framework interfaces you will see constantly:
        // IEnumerable<T>, IList<T>, IDisposable, IComparable<T>, ILogger<T>, IConfiguration
        IEnumerable<int> numbers = new List<int> { 1, 2, 3 };   // program to the interface
        Console.WriteLine(numbers.Count());
    }
}
