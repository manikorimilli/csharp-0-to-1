namespace Ep06.Examples;

public static class Ex03_Properties
{
    class Employee
    {
        // Auto-property: compiler creates the hidden field. The default in C#.
        public string Name { get; set; } = "";

        // Read-only from outside, writable inside the class
        public int Id { get; private set; }

        // init: can be set only during construction / object initializer
        public string Department { get; init; } = "General";

        // required (C# 11): caller MUST set it in the initializer
        public required string Email { get; init; }

        // Full property with a backing field and validation
        private decimal _salary;
        public decimal Salary
        {
            get => _salary;
            set
            {
                if (value < 0) throw new ArgumentOutOfRangeException(nameof(value));
                _salary = value;               // `value` is the incoming value
            }
        }

        // Computed (get-only, expression-bodied). JS: get annual() { return ... }
        public decimal AnnualSalary => Salary * 12;

        public void AssignId(int id) => Id = id;
    }

    public static void Run()
    {
        var e = new Employee { Name = "Ann", Email = "ann@x.com", Department = "IT", Salary = 5000m };
        e.AssignId(7);
        Console.WriteLine($"{e.Id} {e.Name} {e.Department} {e.AnnualSalary}");

        e.Name = "Annie";              // set
        // e.Id = 9;                   // compile error: setter is private
        // e.Department = "HR";        // compile error: init-only
        // var bad = new Employee();   // compile error: Email is required

        try { e.Salary = -1; }
        catch (ArgumentOutOfRangeException) { Console.WriteLine("negative salary rejected"); }

        // Naming: properties are PascalCase. Fields are _camelCase and private.
        // Properties look like fields to the caller but are really get/set methods.
    }
}
