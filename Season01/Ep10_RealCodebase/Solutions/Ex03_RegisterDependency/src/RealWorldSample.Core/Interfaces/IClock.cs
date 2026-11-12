namespace RealWorldSample.Core.Interfaces;

/// <summary>
/// NEW: "what time is it?" as a dependency. Code that calls DateTime.UtcNow directly
/// cannot be tested with a fixed time; code that asks an IClock can.
/// (.NET 8 also ships a built-in abstraction for this: TimeProvider.)
/// </summary>
public interface IClock
{
    DateTime UtcNow { get; }
}
