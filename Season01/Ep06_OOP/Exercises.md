# Ep06 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <string>
#include <vector>
#include <memory>

class Employee {
protected:
    std::string name;
    double baseSalary;
public:
    Employee(std::string n, double s) : name(std::move(n)), baseSalary(s) {}
    virtual ~Employee() = default;
    const std::string& getName() const { return name; }
    virtual double pay() const { return baseSalary; }
};

class Manager : public Employee {
    double bonus;
public:
    Manager(std::string n, double s, double b) : Employee(std::move(n), s), bonus(b) {}
    double pay() const override { return baseSalary + bonus; }
};

int main() {
    std::vector<std::unique_ptr<Employee>> staff;
    staff.push_back(std::make_unique<Employee>("Ann", 3000));
    staff.push_back(std::make_unique<Manager>("Bob", 4000, 1500));
    for (const auto& e : staff) std::cout << e->getName() << ": " << e->pay() << "\n";
}
```

Write the C# version with properties instead of getters, `virtual`/`override`, `: base(...)`, and a `List<Employee>`.
Use `decimal` for money. (No destructors or smart pointers needed.)
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
Base b = new Derived();
Console.WriteLine(b.Virtual());
Console.WriteLine(b.NonVirtual());
Console.WriteLine(((Derived)b).NonVirtual());

var p1 = new PointClass { X = 1 };
var p2 = new PointClass { X = 1 };
var r1 = new PointRecord(1);
var r2 = new PointRecord(1);
Console.WriteLine($"{p1 == p2} {r1 == r2} {r1 with { X = 2 }}");

new Tracker(); new Tracker(); new Tracker();
Console.WriteLine(Tracker.Count);

class Base
{
    public virtual string Virtual() => "Base.Virtual";
    public string NonVirtual() => "Base.NonVirtual";
}
class Derived : Base
{
    public override string Virtual() => "Derived.Virtual";
    public new string NonVirtual() => "Derived.NonVirtual";
}
class PointClass { public int X { get; set; } }
record PointRecord(int X);
class Tracker { public static int Count; public Tracker() => Count++; }
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Two compile errors and one logic bug (the set should contain 2 tags, not 3).

```csharp
var order = new Order(42) { Note = "fragile" };
order.Note = "very fragile";

var tags = new HashSet<Tag> { new Tag("sale"), new Tag("sale"), new Tag("new") };
Console.WriteLine(tags.Count);

class Entity
{
    public int Id { get; }
    public Entity(int id) => Id = id;
}

class Order : Entity
{
    public string Note { get; init; } = "";
    public Order(int id) { }
}

class Tag
{
    public string Name { get; }
    public Tag(string name) => Name = name;
}
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: BankAccount

Write `class BankAccount` with:
- `string Owner` (init), a read-only `decimal Balance` property (private setter),
- `Deposit(decimal amount)` and `Withdraw(decimal amount)` that throw `ArgumentOutOfRangeException` for amounts <= 0
  and `InvalidOperationException` for insufficient funds,
- a `static decimal InterestRate` shared by all accounts and `ApplyInterest()`,
- a history of operations exposed as `IReadOnlyList<string>` (backed by a private `List<string>`).

Solution: [Solutions/S04_BankAccount.cs](Solutions/S04_BankAccount.cs)

---

## 5. Refactor: class to record

```csharp
public class CustomerDto
{
    public string Name { get; }
    public string Email { get; }
    public int LoyaltyPoints { get; }

    public CustomerDto(string name, string email, int loyaltyPoints)
    {
        Name = name;
        Email = email;
        LoyaltyPoints = loyaltyPoints;
    }

    public override bool Equals(object? obj) =>
        obj is CustomerDto o && o.Name == Name && o.Email == Email && o.LoyaltyPoints == LoyaltyPoints;
    public override int GetHashCode() => HashCode.Combine(Name, Email, LoyaltyPoints);
    public override string ToString() =>
        $"CustomerDto {{ Name = {Name}, Email = {Email}, LoyaltyPoints = {LoyaltyPoints} }}";

    public CustomerDto WithPoints(int points) => new CustomerDto(Name, Email, points);
}
```

Replace it with a one-line record and show equality, `ToString`, and `with` still work.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: shapes

- `interface IShape { string Name { get; } double Area(); }`
- `abstract class Shape : IShape` that implements `Name` from `GetType().Name` and overrides `ToString()` to print `"Circle area=3.14"`.
- `Circle(double radius)`, `Rectangle(double w, double h)`, and `sealed class Square : Rectangle`.
- Print all shapes in a `List<IShape>` and the total area.

Solution: [Solutions/S06_Shapes.cs](Solutions/S06_Shapes.cs)

---

## Episode Challenge: mini library

Combine everything:
- `record Book(string Isbn, string Title, string Author)`.
- `abstract class Member` with `Name`, an abstract `MaxLoans` property, and a `virtual string Describe()`.
- `Student` (max 2 loans) and `Staff` (max 5 loans, overrides `Describe` to add `"(staff)"`).
- `interface INotifier { void Notify(Member m, string message); }` with a `ConsoleNotifier`.
- `class Library` with a constructor taking `INotifier`, a private `Dictionary<string, Book>` catalog,
  a private `Dictionary<string, Member>` of current loans by ISBN, and methods
  `AddBook`, `bool Borrow(Member m, string isbn)`, `void Return(string isbn)`.
  Borrow fails (and notifies) if the book is unknown, already lent, or the member is at their limit.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
