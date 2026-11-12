namespace RealWorldSample.Core.Models;

/// <summary>
/// A to-do entry. This is an ENTITY: it has an identity (Id) and state that changes over time,
/// so it is a class (not a record). State changes go through methods like <see cref="MarkDone"/>.
/// </summary>
public class TodoItem
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public bool IsDone { get; private set; }
    public DateTime CreatedAtUtc { get; init; }
    public DateTime? CompletedAtUtc { get; private set; }

    public void MarkDone(DateTime nowUtc)
    {
        if (IsDone) return;
        IsDone = true;
        CompletedAtUtc = nowUtc;
    }
}
