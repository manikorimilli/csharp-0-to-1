using RealWorldSample.Core.Models;

namespace RealWorldSample.Core.Interfaces;

/// <summary>Business operations the API (or anything else) can call.</summary>
public interface ITodoService
{
    Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TodoItem> CreateAsync(string title, DateTime? dueAtUtc = null, CancellationToken cancellationToken = default);   // CHANGED
    Task<bool> CompleteAsync(int id, CancellationToken cancellationToken = default);
    Task<IReadOnlyList<TodoItem>> GetOverdueAsync(CancellationToken cancellationToken = default);   // NEW
}
