using RealWorldSample.Core.Models;

namespace RealWorldSample.Core.Interfaces;

/// <summary>Business operations the API (or anything else) can call.</summary>
public interface ITodoService
{
    Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default);
    Task<TodoItem> CreateAsync(string title, CancellationToken cancellationToken = default);
    Task<bool> CompleteAsync(int id, CancellationToken cancellationToken = default);
    Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default);   // NEW
}
