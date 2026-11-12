namespace Ep06.Solutions;

public static class S01_ConvertCpp
{
    class Employee
    {
        public string Name { get; }
        protected decimal BaseSalary { get; }

        public Employee(string name, decimal baseSalary)
        {
            Name = name;
            BaseSalary = baseSalary;
        }

        public virtual decimal Pay() => BaseSalary;
    }

    class Manager : Employee
    {
        private readonly decimal _bonus;

        public Manager(string name, decimal baseSalary, decimal bonus) : base(name, baseSalary)
            => _bonus = bonus;

        public override decimal Pay() => BaseSalary + _bonus;
    }

    public static void Run()
    {
        var staff = new List<Employee>
        {
            new Employee("Ann", 3000m),
            new Manager("Bob", 4000m, 1500m)
        };
        foreach (var e in staff)
            Console.WriteLine($"{e.Name}: {e.Pay()}");
        // The garbage collector frees memory: no destructor or unique_ptr needed.
    }
}
