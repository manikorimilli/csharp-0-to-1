# 07. params

**In one line:** `params int[] numbers` is JS rest parameters `...numbers`.

## JS vs C#

```js
function sum(...numbers) { ... }
sum(1, 2, 3);
sum(...arr);
```
```csharp
static int Sum(params int[] numbers) { ... }
Sum(1, 2, 3);
Sum(arr);          // an existing array is passed as-is, no spread operator
Sum();             // empty array, never null
```

## Key points

- Only one `params` parameter, and it must be last.
- You already use it: `Console.WriteLine("{0} {1}", a, b)`, `string.Join(",", a, b, c)`, `Path.Combine("a", "b", "c")`.

## Gotchas

- There is no spread operator in C#. Pass the array itself.

Run it: `dotnet run -- 07`
