namespace Ep06.Examples;

// `partial` splits one class across several files. The compiler merges them.
// Main real-world use: separating YOUR code from GENERATED code
// (WinForms designers, EF Core scaffolding, source generators, gRPC).
// Here the other half is in 10_PartialClasses.Generated.cs.
public partial class ReportCard
{
    public string Student { get; }
    public ReportCard(string student) => Student = student;

    public string Summary() => $"{Student}: {GradeLabel()}";   // GradeLabel lives in the other file
}

public static class Ex10_PartialClasses
{
    public static void Run()
    {
        var card = new ReportCard("Ann") { Score = 87 };
        Console.WriteLine(card.Summary());
    }
}
