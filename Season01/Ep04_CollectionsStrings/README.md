# Ep04 Collections and Strings

The collections you will see in every C# file (`List`, `Dictionary`, `HashSet`, `Queue`, `Stack`),
plus string methods and `StringBuilder`. Time: about 2 hours.

## Learning order

| # | Concept | Example | Run |
|---|---|---|---|
| 1 | [List&lt;T&gt; (vs JS Array)](concepts/01_List.md) | [01_List.cs](Examples/01_List.cs) | `dotnet run -- 01` |
| 2 | [Dictionary&lt;TKey,TValue&gt; (vs JS Object/Map)](concepts/02_Dictionary.md) | [02_Dictionary.cs](Examples/02_Dictionary.cs) | `dotnet run -- 02` |
| 3 | [HashSet&lt;T&gt; (vs JS Set)](concepts/03_HashSet.md) | [03_HashSet.cs](Examples/03_HashSet.cs) | `dotnet run -- 03` |
| 4 | [Queue&lt;T&gt; and Stack&lt;T&gt;](concepts/04_Queue_Stack.md) | [04_QueueStack.cs](Examples/04_QueueStack.cs) | `dotnet run -- 04` |
| 5 | [Common string methods](concepts/05_String_Methods.md) | [05_StringMethods.cs](Examples/05_StringMethods.cs) | `dotnet run -- 05` |
| 6 | [StringBuilder and immutability](concepts/06_StringBuilder_Immutability.md) | [06_StringBuilder.cs](Examples/06_StringBuilder.cs) | `dotnet run -- 06` |

Then do the [Exercises](Exercises.md). Solutions are in [Solutions/](Solutions/).

## Checkpoint (end of Day 1)

- What happens on `dict["missing"]`? What do you write instead?
- `Count` or `Length`: which one for `List<T>`, arrays, strings?
- How do you build a 10,000 line string efficiently?
