namespace RealWorldSample.Core.Models;

/// <summary>
/// What the API returns. A DTO (data transfer object) keeps the public JSON shape separate
/// from the internal entity, so the entity can change without breaking clients.
/// Serialized as camelCase JSON: { "id": 1, "title": "...", "isDone": false, ... }
/// </summary>
public record TodoDto(int Id, string Title, bool IsDone, DateTime CreatedAtUtc, DateTime? CompletedAtUtc)
{
    public static TodoDto From(TodoItem item) =>
        new(item.Id, item.Title, item.IsDone, item.CreatedAtUtc, item.CompletedAtUtc);
}
