namespace RealWorldSample.Core.Options;

/// <summary>
/// Strongly typed settings, bound from the "Todo" section of appsettings.json:
///   "Todo": { "MaxTitleLength": 100, "SeedSampleData": true }
/// Classes like this are injected as IOptions&lt;TodoOptions&gt;.
/// </summary>
public class TodoOptions
{
    public const string SectionName = "Todo";

    public int MaxTitleLength { get; set; } = 100;
    public bool SeedSampleData { get; set; }
    public int DefaultDueInDays { get; set; } = 7;   // NEW: used when no due date is given
}
