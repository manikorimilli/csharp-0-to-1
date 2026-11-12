# 02. Multi-dimensional and jagged arrays

**In one line:** `int[,]` is a true grid with `[r, c]` indexing; `int[][]` is an array of arrays (what JS gives you).

| | Multi-dimensional `int[,]` | Jagged `int[][]` |
|---|---|---|
| Shape | always rectangular | rows can differ in length |
| Create | `new int[2, 3]` | `new int[2][]` then each row |
| Index | `grid[r, c]` | `jagged[r][c]` |
| Size | `GetLength(0)`, `GetLength(1)` | `jagged.Length`, `jagged[r].Length` |
| JS equivalent | none | `[[1], [2, 3]]` |
| C++ equivalent | `int grid[2][3]` | `vector<vector<int>>` |

```csharp
int[,] grid = { { 1, 2, 3 }, { 4, 5, 6 } };
int[][] jagged = { new[] { 1 }, new[] { 2, 3 } };
```

## Key points

- `.Length` on `int[,]` is the **total** element count (6 above), not the row count.
- In real code bases you will see jagged arrays and `List<List<T>>` more often than `[,]`.

## Gotchas

- `foreach` over an `int[,]` visits every cell row by row, without row/column indexes.

Run it: `dotnet run -- 02`
