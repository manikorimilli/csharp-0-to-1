using System.Collections.Concurrent;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;

namespace RealWorldSample.Infrastructure.Repositories;

/// <summary>
/// Stores todos in memory. A real project would have an EF Core or Dapper repository
/// with the SAME interface, so nothing in Core or Api would change.
/// Registered as a singleton (one shared instance), so it must be thread-safe:
/// ASP.NET handles requests on many threads at once.
/// </summary>
public class InMemoryTodoRepository : ITodoRepository
{
    private readonly ConcurrentDictionary<int, TodoItem> _items = new();
    private int _lastId;

    public Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        IReadOnlyList<TodoItem> items = _items.Values.OrderBy(i => i.Id).ToList();
        return Task.FromResult(items);
    }

    public Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(_items.GetValueOrDefault(id));

    public Task<TodoItem> AddAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        item.Id = Interlocked.Increment(ref _lastId);   // thread-safe ++
        _items[item.Id] = item;
        return Task.FromResult(item);
    }

    public Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        _items[item.Id] = item;
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(_items.TryRemove(id, out _));
}
