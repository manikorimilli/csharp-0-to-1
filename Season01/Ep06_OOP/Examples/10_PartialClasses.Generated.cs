namespace Ep06.Examples;

// Pretend a tool generated this half. Same namespace, same name, both marked partial.
public partial class ReportCard
{
    public int Score { get; set; }

    private string GradeLabel() => Score switch
    {
        >= 90 => "A",
        >= 80 => "B",
        >= 70 => "C",
        _ => "F"
    };
}
