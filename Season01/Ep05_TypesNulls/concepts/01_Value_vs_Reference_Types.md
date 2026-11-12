# 01. Value types vs reference types

**In one line:** value types are copied on assignment (like JS primitives); reference types share one object (like JS objects).

| | Value types | Reference types |
|---|---|---|
| Examples | `int`, `double`, `decimal`, `bool`, `char`, `DateTime`, `Guid`, enums, tuples, **structs** | `string`, arrays, `List<T>`, `Dictionary`, **classes**, records (class) |
| Assignment `b = a` | copies the data | copies the reference |
| Can be `null` | only as `T?` (`int?`) | yes (warnings guide you, see lesson 06) |
| Default | `0`, `false`, all-zero struct | `null` |
| JS analogy | number, boolean | object, array |

```csharp
int a = 1; int b = a; b = 99;            // a is still 1
var l1 = new List<int>(); var l2 = l1;
l2.Add(5);                                // l1.Count is 1 too
```

## Key points

- Method parameters follow the same rule: a method can mutate an object you pass, but not your `int` (unless `ref`, Ep03).
- `string` is a reference type but immutable and compared by value, so it feels like a value type.

## Gotchas

- `==` on two class instances compares **identity** unless the class overrides equality. Records (Ep06) compare by value.
- C++ devs: there are no pointers or `&` in everyday C#. A class variable *is* a reference.

Run it: `dotnet run -- 01`
