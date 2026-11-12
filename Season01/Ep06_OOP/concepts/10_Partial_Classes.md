# 10. Partial classes

**In one line:** `partial` lets one class be split across several files; the compiler merges them.

```csharp
// ReportCard.cs           (your code)
public partial class ReportCard
{
    public string Summary() => $"{Student}: {GradeLabel()}";
}

// ReportCard.Generated.cs (tool output)
public partial class ReportCard
{
    public int Score { get; set; }
    private string GradeLabel() => Score >= 90 ? "A" : "B";
}
```

## Where you will see it

- Generated code: WinForms/WPF designers (`Form1.Designer.cs`), EF Core, gRPC, source generators (`[GeneratedRegex]`, `[LoggerMessage]`).
- Occasionally to split a very large class.

## JS comparison

No equivalent. The closest is mixing methods into a prototype from another file.

## Key points

- All parts need `partial`, the same name, the same namespace, and must be in the same project.
- `partial` methods can be declared in one part and implemented in another (used by generators).

## Gotchas

- If you jump to a definition and the class looks incomplete, look for `.g.cs` or `.Designer.cs` files.

Run it: `dotnet run -- 10`
