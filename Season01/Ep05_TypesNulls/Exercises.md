# Ep05 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <string>
#include <vector>

enum class Color { Red, Green, Blue };
struct Point { int x; int y; };
struct Person { std::string name; Color favorite; };

Person* findPerson(std::vector<Person>& people, const std::string& name) {
    for (auto& p : people) if (p.name == name) return &p;
    return nullptr;
}

int main() {
    Point a{1, 2};
    Point b = a;
    b.x = 10;
    std::vector<Person> people = {{"Ann", Color::Blue}, {"Bob", Color::Red}};
    Person* p = findPerson(people, "Cid");
    std::cout << a.x << " " << b.x << " " << (p ? p->name : "nobody") << std::endl;
}
```

Write the C# version: an `enum`, a `readonly record struct` or struct for `Point`, a `class` for `Person`,
and return `Person?` instead of a pointer. Use `?.` and `??` when printing.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
var c1 = new Counter();
var c2 = c1;
c2.Count++;
var h1 = new Holder();
var h2 = h1;
h2.C.Count++;
int? x = null;
int? y = 3;
string? s = null;

Console.WriteLine($"{c1.Count} {h1.C.Count}");
Console.WriteLine(x + y);
Console.WriteLine((x ?? y) * 2);
Console.WriteLine(s?.Length ?? -1);
Console.WriteLine((Size)3);
Console.WriteLine((int)Size.Medium);
Console.WriteLine(x > 0 || x <= 0);

enum Size { Small = 1, Medium, Large }
struct Counter { public int Count; }
class Holder { public Counter C; }
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Two compile errors and one `NullReferenceException`.

```csharp
var pixels = new List<Pixel> { new Pixel { X = 1, Y = 1 } };
pixels[0].X = 5;

int? stock = GetStock();
int available = stock;

var profile = new Profile();
Console.WriteLine(profile.Bio.Length);

static int? GetStock() => null;

struct Pixel { public int X; public int Y; }
class Profile { public string? Bio { get; set; } }
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: enums with parsing and flags

1. Write `enum Priority { Low, Normal, High, Critical }` and `static Priority ParsePriority(string? text)`
   that returns the parsed value (case-insensitive) or `Priority.Normal` for null/invalid input.
2. Write a `[Flags] enum Days` (Mon to Sun plus `Weekend` and `Weekdays` combinations) and
   `static bool IsWorkday(Days schedule, Days day)`.

Solution: [Solutions/S04_Enums.cs](Solutions/S04_Enums.cs)

---

## 5. Refactor: modern null handling

```csharp
static string GetCity(Order? order)
{
    if (order != null)
    {
        if (order.Customer != null)
        {
            if (order.Customer.Address != null)
            {
                if (order.Customer.Address.City != null)
                    return order.Customer.Address.City;
            }
        }
    }
    return "N/A";
}

static List<string> EnsureNotes(Order order)
{
    if (order.Notes == null)
        order.Notes = new List<string>();
    return order.Notes;
}
```

Rewrite both as one-liners with `?.`, `??` and `??=`. (Define small `Order`, `Customer`, `Address` classes.)
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: a Money struct

Write a `readonly struct Money` with `decimal Amount` and `string Currency`, a constructor,
an `Add(Money other)` method that throws `InvalidOperationException` when currencies differ,
and `ToString()` returning `"12.50 EUR"`. Show that copying a `Money` cannot change the original.
Solution: [Solutions/S06_Money.cs](Solutions/S06_Money.cs)

---

## Episode Challenge: user profile cards

Model a user with optional data:

- `enum Membership { Free, Plus, Pro }`
- `class Address { string? City; string Country }`
- `class User { string Name; string? Nickname; int? Age; Address? Address; Membership Level; List<string>? Tags }`

Create three users: one with everything, one with only a name, one with an address but no city.
Print a card for each:

```
Ann "annie" (34) - Oslo, Norway - Pro - tags: admin, beta
Bob (age unknown) - no address - Free - tags: none
```

Rules: no `NullReferenceException`, **zero compiler warnings**, no `!` operator.
Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
