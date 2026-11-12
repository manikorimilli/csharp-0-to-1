namespace RealWorldSample.Core.Models;

/// <summary>What the API returns. NEW: DueAtUtc.</summary>
public record TodoDto(int Id, string Title, bool IsDone, DateTime CreatedAtUtc, DateTime? CompletedAtUtc, DateTime? DueAtUtc)
{
    public static TodoDto From(TodoItem item) =>
        new(item.Id, item.Title, item.IsDone, item.CreatedAtUtc, item.CompletedAtUtc, item.DueAtUtc);
}
