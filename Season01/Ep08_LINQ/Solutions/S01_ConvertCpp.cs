namespace Ep08.Solutions;

public static class S01_ConvertCpp
{
    record Employee(string Name, string Dept, decimal Salary);

    public static void Run()
    {
        var staff = new List<Employee>
        {
            new("Ann", "IT", 5200m), new("Bob", "HR", 3900m), new("Cid", "IT", 6100m), new("Dee", "Sales", 4500m)
        };

        var itNames = staff.Where(e => e.Dept == "IT").Select(e => e.Name);
        var top = staff.OrderByDescending(e => e.Salary).First();   // or staff.MaxBy(e => e.Salary)
        var total = staff.Sum(e => e.Salary);
        var rich = staff.Count(e => e.Salary > 5000);

        Console.WriteLine($"{string.Join(" ", itNames)} | top: {top.Name} | total: {total} | rich: {rich}");
        // Note: C++ std::sort mutates `staff`; OrderByDescending leaves it untouched.
    }
}
