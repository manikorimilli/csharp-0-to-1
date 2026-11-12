namespace RealWorldSample.Core.Models;

/// <summary>NEW: summary numbers returned by GET /api/todos/stats.</summary>
public record TodoStats(int Total, int Done, int Pending);
