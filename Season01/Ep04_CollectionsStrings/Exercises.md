# Ep04 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <map>
#include <set>
#include <string>
#include <vector>

int main() {
    std::vector<std::string> words = {"apple", "pear", "apple", "fig", "pear", "apple"};
    std::map<std::string, int> counts;
    std::set<std::string> unique;
    for (const auto& w : words) {
        counts[w]++;
        unique.insert(w);
    }
    for (const auto& [word, n] : counts)
        std::cout << word << "=" << n << " ";
    std::cout << "\nunique: " << unique.size() << std::endl;
}
```

Write the C# version with `List<string>`, `Dictionary<string, int>` and `HashSet<string>`.
Note: `std::map` is sorted and `counts[w]++` creates missing keys. Neither is true for `Dictionary`.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
string s = "immutable";
s.ToUpper();
s.Replace("m", "M");
Console.WriteLine(s);
Console.WriteLine("abcdef".Substring(2, 3));
Console.WriteLine("abcdef"[2..3]);

var d = new Dictionary<string, int> { ["a"] = 1 };
d["a"] = 2;
Console.WriteLine(d.TryAdd("a", 3) + " " + d["a"]);

var set = new HashSet<int> { 1, 2, 3 };
Console.WriteLine(set.Add(2) + " " + set.Count);

var stack = new Stack<int>(new[] { 1, 2, 3 });
Console.WriteLine(stack.Pop());
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Three runtime bugs: two exceptions and one silent no-op.

```csharp
var prices = new Dictionary<string, decimal> { ["apple"] = 1.2m, ["pear"] = 0.9m };
var cart = new List<string> { "apple", "kiwi", "pear", "apple" };

foreach (var item in cart)
    if (item == "pear") cart.Remove(item);

decimal total = 0;
foreach (var item in cart)
    total += prices[item];

string summary = $"total: {total}";
summary.ToUpper();
Console.WriteLine(summary);   // expected: TOTAL: 2.4 (kiwi has no price and is skipped)
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: balanced brackets

Write `static bool IsBalanced(string text)` that returns true when every `(`, `[`, `{` is closed in the right order.
Use a `Stack<char>` and a `Dictionary<char, char>` mapping closers to openers.
Test: `"(a[b]{c})"` true, `"(]"` false, `"(("` false, `"no brackets"` true.
Solution: [Solutions/S04_Brackets.cs](Solutions/S04_Brackets.cs)

---

## 5. Refactor: make it idiomatic

```csharp
var visitors = new List<string> { "ann", "bob", "ann", "cid", "bob" };
var distinct = new List<string>();
for (int i = 0; i < visitors.Count; i++)
{
    if (!distinct.Contains(visitors[i])) distinct.Add(visitors[i]);
}

string report = "";
for (int i = 0; i < distinct.Count; i++)
{
    report = report + distinct[i];
    if (i < distinct.Count - 1) report = report + ";";
}

var roles = new Dictionary<string, string> { ["ann"] = "admin" };
string role;
if (roles.ContainsKey("bob")) role = roles["bob"]; else role = "guest";
Console.WriteLine(report + " / bob is " + role);
```

Use a `HashSet`, `string.Join`, `foreach`, and `GetValueOrDefault` (or `TryGetValue`).
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: slugify

Write `static string Slugify(string title)`:
lowercase, letters and digits kept, every run of other characters becomes a single `-`, no leading or trailing `-`.
`"  Hello, World! C# Rocks  "` gives `hello-world-c-rocks`. Use a `StringBuilder` and `char` helpers (no regex).
Solution: [Solutions/S06_Slugify.cs](Solutions/S06_Slugify.cs)

---

## Episode Challenge: word statistics

Given this text:

```csharp
string text = """
    The quick brown fox jumps over the lazy dog.
    The dog sleeps; the fox runs! Quick, quick.
    """;
```

Print:
1. Total word count (split on spaces, newlines and punctuation; use `Split` with a `char[]` and `RemoveEmptyEntries`).
2. Number of unique words, case-insensitive (`HashSet` with a comparer).
3. The 3 most frequent words with counts (a `Dictionary`, then copy to a `List<KeyValuePair<string,int>>` and `Sort` with a lambda; no LINQ yet).
4. The longest word.
5. Build the whole report with a `StringBuilder` and print it once.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
