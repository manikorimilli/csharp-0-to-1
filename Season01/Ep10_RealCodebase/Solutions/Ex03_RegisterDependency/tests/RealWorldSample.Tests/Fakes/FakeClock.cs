using RealWorldSample.Core.Interfaces;

namespace RealWorldSample.Tests.Fakes;

/// <summary>NEW: a clock the test controls.</summary>
public class FakeClock : IClock
{
    public DateTime UtcNow { get; set; } = new(2024, 1, 15, 9, 0, 0, DateTimeKind.Utc);
}
