# Ep01 Exercises

Write your answers in a scratch project (`dotnet new console -o Scratch`) or straight into this one.
Check a solution with `dotnet run -- s1` (s2, s3, ...). Each exercise takes 5 to 15 minutes.

---

## 1. Convert C++ to C#

```cpp
#include <iostream>
#include <string>

int main() {
    const int maxUsers = 3;
    std::string product = "Keyboard";
    double price = 49.5;
    auto inStock = true;
    std::cout << product << " costs " << price << ", in stock: " << inStock << std::endl;
    std::cout << "Max users: " << maxUsers << std::endl;
    return 0;
}
```

Write the idiomatic C# version (top-level statements, interpolation, `var` where obvious, `decimal` for the price).
Solution: [Solutions/S01_ConvertCpp.cs](Solutions/S01_ConvertCpp.cs)

---

## 2. Predict the output

Write down what each line prints, then run it.

```csharp
Console.WriteLine(10 / 4);
Console.WriteLine(10 / 4.0);
Console.WriteLine("5" + 5);
Console.WriteLine('a' + 1);
Console.WriteLine((char)('a' + 1));
Console.WriteLine(0.1 + 0.2 == 0.3);
Console.WriteLine(0.1m + 0.2m == 0.3m);
Console.WriteLine((int)-3.9);
Console.WriteLine(Math.Round(3.5) + Math.Round(4.5));
```

Solution: [Solutions/S02_PredictOutput.cs](Solutions/S02_PredictOutput.cs)

---

## 3. Find and fix the bugs

This code has two compile errors and one logic bug. Fix all three.

```csharp
decimal price = 19.99;
int quantity = "3";
int itemsSold = 5;
int days = 2;
double averagePerDay = itemsSold / days;   // expected 2.5
Console.WriteLine($"Total: {price * quantity}, avg/day: {averagePerDay}");
```

Solution: [Solutions/S03_FixBug.cs](Solutions/S03_FixBug.cs)

---

## 4. Write a safe age reader

Write a method `static string Describe(string? input)` that:
- returns `"Invalid age"` if the input is null, not a number, or negative,
- returns `"Minor"` below 18, `"Adult"` from 18 to 64, `"Senior"` from 65.

Test it with `"17"`, `"30"`, `"70"`, `"abc"`, `"-1"`, `null`. In a real program you would pass `Console.ReadLine()`.
Solution: [Solutions/S04_AgeReader.cs](Solutions/S04_AgeReader.cs)

---

## 5. Refactor: make it idiomatic

```csharp
System.String firstName = "Grace";
System.Int32 birthYear = 1906;
System.Int32 age = 2024 - birthYear;
System.Console.WriteLine("Name: " + firstName + ", age in 2024: " + age.ToString() + " (born " + birthYear.ToString() + ")");
System.Console.WriteLine("Path: " + "C:\\Users\\" + firstName + "\\Documents");
```

Use keywords instead of `System.X` types, `var`/`const` where sensible, interpolation, and a verbatim string for the path.
Solution: [Solutions/S05_Refactor.cs](Solutions/S05_Refactor.cs)

---

## 6. Write a temperature table

Print Celsius values from -10 to 40 in steps of 10 with Fahrenheit (`F = C * 9 / 5 + 32`), aligned in two columns, Fahrenheit with one decimal:

```
   C       F
 -10    14.0
   0    32.0
 ...
```

Watch out for integer division.
Solution: [Solutions/S06_Temperatures.cs](Solutions/S06_Temperatures.cs)

---

## Episode Challenge: receipt printer

You get raw order lines as strings:

```csharp
string[] lines = { "Coffee,3.50,2", "Bagel,2.25,abc", "Juice,4.10,1", "Muffin,x,3" };
```

Write a program that:
1. Splits each line on `,` (`line.Split(',')`).
2. Parses price as `decimal` and quantity as `int` with `TryParse` (use `CultureInfo.InvariantCulture` for the decimal).
3. Skips invalid lines and prints a warning to `Console.Error`.
4. Prints an aligned receipt (name left-aligned, money with 2 decimals) and the total.

Solution: [Solutions/Challenge.cs](Solutions/Challenge.cs)
