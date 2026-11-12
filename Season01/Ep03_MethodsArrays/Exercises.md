# Ep03 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <utility>
#include <vector>

void swapValues(int& a, int& b) { int t = a; a = b; b = t; }

std::pair<int, int> sumAndCount(const std::vector<int>& v) {
    int sum = 0;
    for (int x : v) sum += x;
    return {sum, (int)v.size()};
}

int main() {
    int x = 1, y = 2;
    swapValues(x, y);
    auto [sum, count] = sumAndCount({4, 5, 6});
    std::cout << x << y << " " << sum << "/" << count << std::endl;
}
```

Write the idiomatic C# version (`ref`, a named tuple return, deconstruction). Then write the swap a second way without a helper method.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
static void Reset(int[] arr, int n) { arr[0] = 0; n = 0; }
static string Show(int x) => "int";
static string Show(long x) => "long";
static string Show(double x) => "double";
static string Pad(string s, int width = 6, char fill = '.') => s.PadLeft(width, fill);

int[] data = { 9, 9 };
int count = 9;
Reset(data, count);
Console.WriteLine($"{data[0]} {count}");
Console.WriteLine(Show(5) + " " + Show(5L) + " " + Show(5f));
Console.WriteLine(Pad("ab") + "|" + Pad("ab", fill: '*') + "|" + Pad("ab", 3));
int[] copy = data;
copy[1] = 1;
Console.WriteLine(data[1]);
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Two compile errors and one logic bug (the counter stays 0).

```csharp
static void AddPoints(int score, int points) { score += points; }

static string Label(string unit = "pts", int value) => $"{value} {unit}";

static bool TryHalf(int n, out int half)
{
    if (n % 2 == 0) half = n / 2;
    return n % 2 == 0;
}

int score = 0;
AddPoints(score, 10);
Console.WriteLine(Label(value: score));
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write: statistics with a tuple

Write `static (int Min, int Max, double Average) Stats(params int[] values)`.
Call it as `Stats(4, 8, 15, 16, 23, 42)` and also with an existing array, then deconstruct the result.
Throw `ArgumentException` if no values are passed.
Solution: [Solutions/S04_MinMax.cs](Solutions/S04_MinMax.cs)

---

## 5. Refactor: out parameters to a tuple

```csharp
static void ParseName(string fullName, out string first, out string last, out bool ok)
{
    var parts = fullName.Split(' ');
    if (parts.Length != 2) { first = ""; last = ""; ok = false; return; }
    first = parts[0];
    last = parts[1];
    ok = true;
}
```

Rewrite as an expression-friendly method returning `(bool Ok, string First, string Last)` and use deconstruction at the call site.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: name formatter with optional and named args

Write `FormatName(string first, string last, string? middle = null, bool lastNameFirst = false, bool upper = false)`.
- `FormatName("Ada", "Lovelace")` gives `Ada Lovelace`
- `FormatName("Ada", "Lovelace", lastNameFirst: true)` gives `Lovelace, Ada`
- `FormatName("John", "Smith", "Q", upper: true)` gives `JOHN Q SMITH`

Solution: [Solutions/S06_FormatName.cs](Solutions/S06_FormatName.cs)

---

## 7. Write: transpose a matrix

Write `static int[,] Transpose(int[,] m)` that returns a new matrix where rows become columns,
and a `Print(int[,] m)` helper. Transpose `{ {1,2,3}, {4,5,6} }` into a 3x2 matrix.
Solution: [Solutions/S07_Transpose.cs](Solutions/S07_Transpose.cs)

---

## Episode Challenge: grade book

```csharp
string[] students = { "Ann", "Bob", "Cid" };
int[][] scores = { new[] { 90, 85, 77 }, new[] { 60, 70 }, new[] { 88, 92, 95, 79 } };
```

Write:
1. `static (double Average, int Best) Summarize(int[] scores)`.
2. `static void AddBonus(int[] scores, params int[] bonusIndexes)` that adds 5 points (max 100) to the given positions.
3. Two overloads of `Report`: `Report(string name, int[] scores)` prints one line, `Report(string[] names, int[][] scores)` prints all.
4. Give Bob a bonus on both his scores, then print the report with averages to one decimal.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
