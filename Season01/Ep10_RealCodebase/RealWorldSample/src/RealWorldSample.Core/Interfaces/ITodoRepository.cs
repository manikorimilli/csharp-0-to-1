using RealWorldSample.Core.Models;

namespace RealWorldSample.Core.Interfaces;

/// <summary>
/// Storage contract. Core defines WHAT it needs; Infrastructure decides HOW (memory, SQL, ...).
/// Async because a real implementation talks to a database.
/// </summary>
public interface ITodoRepository
{
    Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TodoItem> AddAsync(TodoItem item, CancellationToken cancellationToken = default);
    Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);
}
