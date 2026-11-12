namespace RealWorldSample.Tests.Fakes;

/// <summary>
/// NEW: a TimeProvider whose "now" the test controls. TimeProvider is an abstract class,
/// so overriding one virtual method is enough. (Package Microsoft.Extensions.TimeProvider.Testing
/// ships a ready-made FakeTimeProvider.)
/// </summary>
public class FixedTimeProvider(DateTimeOffset start) : TimeProvider
{
    private DateTimeOffset _now = start;

    public override DateTimeOffset GetUtcNow() => _now;

    public void Advance(TimeSpan by) => _now = _now.Add(by);
}
