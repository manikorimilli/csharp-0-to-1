using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;

namespace RealWorldSample.Tests.Fakes;

/// <summary>
/// A hand-written test double. Because TodoService depends on ITodoRepository (an interface),
/// tests can swap in this fake. Many teams use a mocking library instead (Moq, NSubstitute).
/// </summary>
public class FakeTodoRepository : ITodoRepository
{
    public List<TodoItem> Items { get; } = new();
    public int UpdateCalls { get; private set; }

    public Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
        Task.FromResult<IReadOnlyList<TodoItem>>(Items);

    public Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(Items.FirstOrDefault(i => i.Id == id));

    public Task<TodoItem> AddAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        item.Id = Items.Count + 1;
        Items.Add(item);
        return Task.FromResult(item);
    }

    public Task UpdateAsync(TodoItem item, CancellationToken cancellationToken = default)
    {
        UpdateCalls++;
        return Task.CompletedTask;
    }

    public Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default) =>
        Task.FromResult(Items.RemoveAll(i => i.Id == id) > 0);
}
