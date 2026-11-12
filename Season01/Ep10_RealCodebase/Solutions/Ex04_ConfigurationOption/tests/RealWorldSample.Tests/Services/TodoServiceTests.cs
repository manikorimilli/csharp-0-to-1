using Microsoft.Extensions.Logging.Abstractions;
using Microsoft.Extensions.Options;
using RealWorldSample.Core.Options;
using RealWorldSample.Core.Services;
using RealWorldSample.Tests.Fakes;

namespace RealWorldSample.Tests.Services;

// Test class naming: <ClassUnderTest>Tests. Method naming: Method_Scenario_ExpectedResult.
public class TodoServiceTests
{
    private readonly FakeTodoRepository _repository = new();

    // xUnit creates a NEW instance of this class for every test, so each test gets fresh state
    // (like beforeEach in Jest).
    private TodoService CreateService(int maxTitleLength = 100, int maxOpenItems = 10) =>
        new(_repository,
            Options.Create(new TodoOptions { MaxTitleLength = maxTitleLength, MaxOpenItems = maxOpenItems }),
            NullLogger<TodoService>.Instance);                                    // logger that does nothing

    [Fact]   // a single test case (Jest: test("...", () => {}))
    public async Task CreateAsync_ValidTitle_TrimsAndSaves()
    {
        // Arrange
        var service = CreateService();

        // Act
        var item = await service.CreateAsync("  Buy milk  ");

        // Assert
        Assert.Equal("Buy milk", item.Title);
        Assert.False(item.IsDone);
        Assert.Single(_repository.Items);
    }

    [Theory]   // a parameterized test (Jest: test.each)
    [InlineData("")]
    [InlineData("   ")]
    public async Task CreateAsync_BlankTitle_Throws(string title)
    {
        var service = CreateService();

        var ex = await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync(title));

        Assert.Contains("required", ex.Message);
        Assert.Empty(_repository.Items);
    }

    [Fact]
    public async Task CreateAsync_TitleLongerThanConfiguredMax_Throws()
    {
        var service = CreateService(maxTitleLength: 5);

        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync("Too long title"));
    }

    [Fact]   // NEW
    public async Task CreateAsync_OpenItemLimitReached_Throws()
    {
        var service = CreateService(maxOpenItems: 2);
        await service.CreateAsync("one");
        await service.CreateAsync("two");

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CreateAsync("three"));
        Assert.Equal(2, _repository.Items.Count);
    }
}
