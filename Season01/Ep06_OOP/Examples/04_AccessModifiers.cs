namespace Ep06.Examples;

public static class Ex04_AccessModifiers
{
    // public    : visible everywhere
    // private   : only inside this type (DEFAULT for members). JS: #field
    // protected : this type and subclasses
    // internal  : anywhere in the same project/assembly (DEFAULT for top-level types)
    // protected internal / private protected: rare combinations

    public class Account
    {
        private decimal _balance;                   // JS: #balance
        protected string Owner { get; }             // subclasses can read it
        internal string BranchCode { get; } = "001"; // same assembly only
        public string Number { get; }

        public Account(string owner, string number)
        {
            Owner = owner;
            Number = number;
        }

        public void Deposit(decimal amount) => _balance += amount;
        public decimal GetBalance() => _balance;
    }

    public class SavingsAccount : Account
    {
        public SavingsAccount(string owner, string number) : base(owner, number) { }

        public string Describe() => $"Savings of {Owner}";   // protected: OK in subclass
        // public decimal Peek() => _balance;                // private: compile error
    }

    public static void Run()
    {
        var acc = new SavingsAccount("Ann", "NO-123");
        acc.Deposit(100);
        Console.WriteLine($"{acc.Number}: {acc.GetBalance()} ({acc.Describe()}, branch {acc.BranchCode})");
        // acc.Owner;      // compile error: protected
        // acc._balance;   // compile error: private

        // Unlike JS #private, C# private is checked at compile time by the compiler,
        // and it is per TYPE: one Account can read another Account's private fields.
    }
}
