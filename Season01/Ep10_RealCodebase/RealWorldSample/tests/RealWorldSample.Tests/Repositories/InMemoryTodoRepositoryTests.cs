using RealWorldSample.Core.Models;
using RealWorldSample.Infrastructure.Repositories;

namespace RealWorldSample.Tests.Repositories;

public class InMemoryTodoRepositoryTests
{
    private readonly InMemoryTodoRepository _repository = new();

    [Fact]
    public async Task AddAsync_AssignsIncreasingIds()
    {
        var first = await _repository.AddAsync(new TodoItem { Title = "a" });
        var second = await _repository.AddAsync(new TodoItem { Title = "b" });

        Assert.Equal(1, first.Id);
        Assert.Equal(2, second.Id);
    }

    [Fact]
    public async Task GetByIdAsync_UnknownId_ReturnsNull()
    {
        var result = await _repository.GetByIdAsync(42);

        Assert.Null(result);
    }

    [Fact]
    public async Task DeleteAsync_ExistingItem_RemovesIt()
    {
        var item = await _repository.AddAsync(new TodoItem { Title = "temp" });

        bool deleted = await _repository.DeleteAsync(item.Id);
        var all = await _repository.GetAllAsync();

        Assert.True(deleted);
        Assert.Empty(all);
    }
}
