using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RealWorldSample.Core.Models;
using RealWorldSample.Core.Options;
using RealWorldSample.Core.Services;
using RealWorldSample.Tests.Fakes;

namespace RealWorldSample.Tests.Services;

public class TodoServiceCompleteTests
{
    private readonly FakeTodoRepository _repository = new();
    private readonly TodoService _service;

    // The constructor runs before EVERY test (Jest: beforeEach)
    public TodoServiceCompleteTests()
    {
        _service = new TodoService(_repository, Options.Create(new TodoOptions()), NullLogger<TodoService>.Instance);
    }

    [Fact]
    public async Task CompleteAsync_UnknownId_ReturnsFalseAndDoesNotUpdate()
    {
        bool result = await _service.CompleteAsync(99);

        Assert.False(result);
        Assert.Equal(0, _repository.UpdateCalls);
    }

    [Fact]
    public async Task CompleteAsync_ExistingItem_MarksDoneAndSaves()
    {
        var item = await _repository.AddAsync(new TodoItem { Title = "Ship it" });

        bool result = await _service.CompleteAsync(item.Id);

        Assert.True(result);
        Assert.True(item.IsDone);
        Assert.NotNull(item.CompletedAtUtc);
        Assert.Equal(1, _repository.UpdateCalls);
    }

    [Fact]
    public async Task CompleteAsync_CalledTwice_KeepsFirstCompletionTime()
    {
        var item = await _repository.AddAsync(new TodoItem { Title = "Ship it" });
        await _service.CompleteAsync(item.Id);
        var firstCompletion = item.CompletedAtUtc;

        await _service.CompleteAsync(item.Id);

        Assert.Equal(firstCompletion, item.CompletedAtUtc);
    }

    [Theory]
    [InlineData(5, "12345", true)]
    [InlineData(5, "123456", false)]
    [InlineData(10, "  padded  ", true)]   // trimmed before the length check
    public async Task CreateAsync_RespectsMaxTitleLength(int max, string title, bool shouldSucceed)
    {
        var service = new TodoService(_repository,
            Options.Create(new TodoOptions { MaxTitleLength = max }), NullLogger<TodoService>.Instance);

        var exception = await Record.ExceptionAsync(() => service.CreateAsync(title));

        Assert.Equal(shouldSucceed, exception is null);
    }
}
