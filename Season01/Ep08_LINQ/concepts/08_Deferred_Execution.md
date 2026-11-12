# 08. Deferred execution

**In one line:** a LINQ query is a recipe, not a result. It runs each time you enumerate it (`foreach`, `ToList`, `Count`, `First`...).

```csharp
var list = new List<int> { 1, 2, 3 };
var big = list.Where(n => n > 1);    // nothing runs yet
list.Add(4);
Console.WriteLine(big.Count());       // 3: sees the 4, runs the filter now
Console.WriteLine(big.Count());       // runs the filter AGAIN
var snapshot = big.ToList();          // runs once, stores the results
```

## JS comparison

JS array methods are **eager**: `filter` runs immediately and returns an array. LINQ behaves like a JS generator pipeline (`function*` + `yield`). C# has `yield return` for writing your own lazy sequences.

## Why it matters

- **Performance:** enumerating an expensive query twice does the work twice.
- **Correctness:** the query sees changes made to the source after it was defined.
- **Entity Framework:** a query on `dbContext.Orders` becomes SQL and runs only when enumerated. Calling `ToList()` early loads everything into memory; calling it late (or never) may run the SQL several times.

## Which operators run immediately?

- Immediate: `ToList`, `ToArray`, `ToDictionary`, `Count`, `Sum`, `Any`, `First`, `Max`...
- Deferred: `Where`, `Select`, `OrderBy`, `GroupBy`, `Skip`, `Take`, `Distinct`...

## Gotchas

- Side effects inside lambdas (logging, counters) run once per enumeration. Your IDE may warn "Possible multiple enumeration".

Run it: `dotnet run -- 08`
