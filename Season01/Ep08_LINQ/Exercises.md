# Ep08 Exercises

All exercises use the shared data in [SampleData.cs](SampleData.cs) (`Data.Customers`, `Data.Products`, `Data.Orders`).
Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <algorithm>
#include <iostream>
#include <numeric>
#include <string>
#include <vector>

struct Employee { std::string name; std::string dept; double salary; };

int main() {
    std::vector<Employee> staff = {
        {"Ann", "IT", 5200}, {"Bob", "HR", 3900}, {"Cid", "IT", 6100}, {"Dee", "Sales", 4500}};

    std::vector<Employee> it;
    std::copy_if(staff.begin(), staff.end(), std::back_inserter(it),
                 [](const Employee& e) { return e.dept == "IT"; });

    std::vector<std::string> names;
    std::transform(it.begin(), it.end(), std::back_inserter(names),
                   [](const Employee& e) { return e.name; });

    std::sort(staff.begin(), staff.end(),
              [](const Employee& a, const Employee& b) { return a.salary > b.salary; });

    double total = std::accumulate(staff.begin(), staff.end(), 0.0,
                                   [](double s, const Employee& e) { return s + e.salary; });
    auto rich = std::count_if(staff.begin(), staff.end(),
                              [](const Employee& e) { return e.salary > 5000; });

    for (auto& n : names) std::cout << n << " ";
    std::cout << "| top: " << staff[0].name << " | total: " << total << " | rich: " << rich << "\n";
}
```

Write it with a `record Employee` and LINQ (one expression per result).
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
var nums = new List<int> { 5, 1, 4 };
var query = nums.Where(n => n > 2);
nums.Add(10);
Console.WriteLine(string.Join(",", query));

var sorted = nums.OrderBy(n => n % 2).OrderBy(n => n);
Console.WriteLine(string.Join(",", sorted));

Console.WriteLine(nums.FirstOrDefault(n => n > 100));
Console.WriteLine(nums.Skip(1).Take(2).Sum());
Console.WriteLine(nums.Select(n => n * 2).Where(n => n > 5).Count());
Console.WriteLine(new[] { "b", "a", "b", "c" }.Distinct().Count());
Console.WriteLine(Enumerable.Range(1, 4).Aggregate((a, b) => a * b));
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Three runtime/logic bugs.

```csharp
// 1. Should print "none" when no product is in the Toys category, but crashes
var toy = Data.Products.First(p => p.Category == "Toys");
Console.WriteLine(toy.Name);

// 2. Should map each category to its product names, but crashes
var byCategory = Data.Products.ToDictionary(p => p.Category, p => p.Name);

// 3. Should sort by category, then by price (cheapest first) within each category
var sorted = Data.Products.OrderBy(p => p.Category).OrderBy(p => p.Price);
Console.WriteLine(string.Join(", ", sorted.Select(p => p.Name)));
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: sales queries

Using `Data`, write one LINQ expression for each:
1. Order totals: `OrderId -> total price` (sum of quantity x product price; look up products with a dictionary).
2. Names of customers who have **no** orders.
3. The 2 best-selling products by total quantity, with their quantity.
4. Is there any order with a total over 1000? Do all orders have at least one line?

Solution: [Solutions/S04_SalesQueries.cs](Solutions/S04_SalesQueries.cs)

---

## 5. Refactor: loops to LINQ

```csharp
var result = new List<string>();
foreach (var c in Data.Customers)
{
    if (c.Country == "US")
    {
        int count = 0;
        foreach (var o in Data.Orders)
            if (o.CustomerId == c.Id) count++;
        if (count > 0)
            result.Add(c.Name.ToUpper() + " (" + count + ")");
    }
}
result.Sort();

decimal maxPrice = 0;
string maxName = "";
foreach (var p in Data.Products)
{
    if (p.Price > maxPrice) { maxPrice = p.Price; maxName = p.Name; }
}
Console.WriteLine(string.Join(", ", result) + " | " + maxName);
```

Rewrite both parts with LINQ (`Where`, `Select`, `Count`, `OrderBy`, `MaxBy`).
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: query syntax with joins

Using **query syntax**, produce one line per order line:

```
2024-01-05 | #100 | Ann | Laptop x1 = 1200
2024-01-05 | #100 | Ann | Mouse x2 = 50
...
```

Hints: `from o in Data.Orders`, `join c in Data.Customers on ...`, a second `from l in o.Lines`, `join p in Data.Products on ...`, `orderby`, `select`.
Solution: [Solutions/S06_QueryJoin.cs](Solutions/S06_QueryJoin.cs)

---

## Episode Challenge: sales report

Produce this report from `Data` (values computed, not hard-coded):

```
Revenue by month:
  2024-01  ...
  2024-02  ...
Revenue by category:
  Electronics  ...
Best customer: ... (...)
VIP share of revenue: ...%
Products never sold: ...
```

Build a flat `IEnumerable` of sales (order date, customer, product, quantity, amount) once with `SelectMany`,
materialize it with `ToList()`, then answer every section from that list.
Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
