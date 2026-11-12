# Ep02 Exercises

Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <string>

int main() {
    std::string text = "Hello World 2024";
    int vowels = 0, digits = 0, others = 0;
    for (char c : text) {
        switch (std::tolower(c)) {
            case 'a': case 'e': case 'i': case 'o': case 'u':
                vowels++;
                break;
            default:
                if (std::isdigit(c)) digits++;
                else others++;
        }
    }
    std::cout << vowels << " " << digits << " " << others << std::endl;
}
```

Write the idiomatic C# version. Hints: `foreach`, `char.ToLower`, `char.IsDigit`, an `or` pattern.
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

```csharp
int[] values = { 5, -3, 12, 0, 7, 100 };
foreach (var v in values)
{
    if (v == 0) continue;
    string kind = v switch
    {
        < 0 => "negative",
        < 10 => "small",
        100 => "hundred",
        _ => "big"
    };
    Console.Write($"{kind} ");
    if (v > 50) break;
}
Console.WriteLine();

int i = 10;
do { Console.Write(i); i++; } while (i < 10);
Console.WriteLine();
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

Two compile errors and one runtime crash.

```csharp
int[] scores = { 90, 72, 55 };
for (int i = 0; i <= scores.Length; i++)
{
    int s = scores[i];
    if (s % 2) Console.WriteLine($"{s} is odd");
    switch (s)
    {
        case >= 90:
            Console.WriteLine("A");
        case >= 70:
            Console.WriteLine("B");
            break;
        default:
            Console.WriteLine("F");
            break;
    }
}
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write FizzBuzz with a switch expression

For 1 to 15, print `Fizz` (divisible by 3), `Buzz` (by 5), `FizzBuzz` (both), else the number.
Use **one** switch expression over the tuple `(n % 3, n % 5)`. No if/else.
Solution: [Solutions/S04_FizzBuzz.cs](Solutions/S04_FizzBuzz.cs)

---

## 5. Refactor to a switch expression

```csharp
static string GetDiscountLabel(string tier, int years)
{
    string label;
    if (tier == "gold")
    {
        if (years >= 5) label = "30%";
        else label = "20%";
    }
    else if (tier == "silver")
    {
        label = "10%";
    }
    else
    {
        label = "0%";
    }
    return label;
}
```

Rewrite it as an expression-bodied method (`=>`) using a tuple switch expression.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write: first duplicate

Write `static int? FirstDuplicate(int[] numbers)` that returns the first value that appears a second time
(scanning left to right), or `null` if none. Use nested `for` loops and an early `return` (no collections yet).
`{ 3, 1, 4, 1, 5, 3 }` returns `1` (its second occurrence comes first).
Solution: [Solutions/S06_FirstDuplicate.cs](Solutions/S06_FirstDuplicate.cs)

---

## Episode Challenge: command interpreter

Process this script with a running total that starts at 0:

```csharp
string[] script = { "add 10", "mul 3", "", "sub 4", "oops 1", "print", "div 0", "div 2", "print", "quit", "add 1000" };
```

Rules:
- Split each line into a command and a number (`int.TryParse`).
- Skip empty lines with `continue`; print `Unknown command: oops` for unknown commands.
- `div 0` prints `Cannot divide by zero` and leaves the total unchanged.
- `print` prints the total, `quit` stops processing (`break`), so `add 1000` never runs.
- Use a `switch` statement or switch expression to dispatch commands.

Expected: `Total: 26` then `Total: 13`.
Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
