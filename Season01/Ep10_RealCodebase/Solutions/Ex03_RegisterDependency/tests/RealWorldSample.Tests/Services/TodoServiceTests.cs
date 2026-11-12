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
    private readonly FakeClock _clock = new();   // NEW

    // xUnit creates a NEW instance of this class for every test, so each test gets fresh state
    // (like beforeEach in Jest).
    private TodoService CreateService(int maxTitleLength = 100) =>
        new(_repository,
            Options.Create(new TodoOptions { MaxTitleLength = maxTitleLength }),   // IOptions without config files
            NullLogger<TodoService>.Instance,                                     // logger that does nothing
            _clock);                                                              // NEW: fixed time

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

    [Fact]   // NEW: only possible now that time is injected
    public async Task CreateAsync_SetsCreatedAtFromClock()
    {
        var service = CreateService();

        var item = await service.CreateAsync("Pay rent");

        Assert.Equal(_clock.UtcNow, item.CreatedAtUtc);
    }

    [Fact]
    public async Task CreateAsync_TitleLongerThanConfiguredMax_Throws()
    {
        var service = CreateService(maxTitleLength: 5);

        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync("Too long title"));
    }
}
