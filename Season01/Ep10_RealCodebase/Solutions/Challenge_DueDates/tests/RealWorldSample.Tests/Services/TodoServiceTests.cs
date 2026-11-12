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
    private readonly FixedTimeProvider _time = new(new DateTimeOffset(2024, 1, 15, 9, 0, 0, TimeSpan.Zero));   // NEW

    // xUnit creates a NEW instance of this class for every test, so each test gets fresh state
    // (like beforeEach in Jest).
    private TodoService CreateService(int maxTitleLength = 100) =>
        new(_repository,
            Options.Create(new TodoOptions { MaxTitleLength = maxTitleLength, DefaultDueInDays = 7 }),
            NullLogger<TodoService>.Instance,
            _time);                                                               // NEW

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
    public async Task CreateAsync_NoDueDate_UsesDefaultFromOptions()
    {
        var service = CreateService();

        var item = await service.CreateAsync("Renew passport");

        Assert.Equal(_time.GetUtcNow().UtcDateTime.AddDays(7), item.DueAtUtc);
    }

    [Fact]   // NEW
    public async Task CreateAsync_DueDateInPast_Throws()
    {
        var service = CreateService();
        var yesterday = _time.GetUtcNow().UtcDateTime.AddDays(-1);

        await Assert.ThrowsAsync<ArgumentException>(() => service.CreateAsync("Too late", yesterday));
    }

    [Fact]   // NEW
    public async Task GetOverdueAsync_ReturnsOnlyOpenItemsPastTheirDueDate()
    {
        var service = CreateService();
        var now = _time.GetUtcNow().UtcDateTime;
        var soon = await service.CreateAsync("soon", now.AddHours(1));
        var later = await service.CreateAsync("later", now.AddDays(3));
        var doneSoon = await service.CreateAsync("done soon", now.AddHours(2));
        await service.CompleteAsync(doneSoon.Id);

        _time.Advance(TimeSpan.FromDays(1));   // jump forward: "soon" and "done soon" are now past due
        var overdue = await service.GetOverdueAsync();

        var only = Assert.Single(overdue);
        Assert.Equal(soon.Id, only.Id);
        Assert.False(later.IsOverdue(_time.GetUtcNow().UtcDateTime));
    }
}
