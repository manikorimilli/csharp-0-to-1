using RealWorldSample.Core.Interfaces;

namespace RealWorldSample.Infrastructure.Time;

/// <summary>NEW: the real clock used in production.</summary>
public class SystemClock : IClock
{
    public DateTime UtcNow => DateTime.UtcNow;
}
