namespace Ep06.Solutions;

public static class S04_BankAccount
{
    class BankAccount
    {
        public static decimal InterestRate { get; set; } = 0.02m;

        private readonly List<string> _history = new();

        public required string Owner { get; init; }
        public decimal Balance { get; private set; }
        public IReadOnlyList<string> History => _history;   // callers can read, not Add

        public void Deposit(decimal amount)
        {
            EnsurePositive(amount);
            Balance += amount;
            _history.Add($"+{amount}");
        }

        public void Withdraw(decimal amount)
        {
            EnsurePositive(amount);
            if (amount > Balance)
                throw new InvalidOperationException($"Insufficient funds: balance {Balance}, requested {amount}");
            Balance -= amount;
            _history.Add($"-{amount}");
        }

        public void ApplyInterest()
        {
            var interest = Math.Round(Balance * InterestRate, 2);
            Balance += interest;
            _history.Add($"+{interest} interest");
        }

        private static void EnsurePositive(decimal amount)
        {
            if (amount <= 0) throw new ArgumentOutOfRangeException(nameof(amount), "Amount must be positive");
        }
    }

    public static void Run()
    {
        var acc = new BankAccount { Owner = "Ann" };
        acc.Deposit(1000m);
        acc.Withdraw(250m);
        acc.ApplyInterest();

        try { acc.Withdraw(5000m); }
        catch (InvalidOperationException ex) { Console.WriteLine(ex.Message); }

        try { acc.Deposit(-5m); }
        catch (ArgumentOutOfRangeException ex) { Console.WriteLine(ex.Message); }

        Console.WriteLine($"{acc.Owner}: {acc.Balance} [{string.Join(", ", acc.History)}]");
    }
}
