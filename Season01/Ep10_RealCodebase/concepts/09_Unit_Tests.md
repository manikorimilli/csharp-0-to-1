# 09. Unit tests with xUnit

**In one line:** test classes are plain classes, tests are methods marked `[Fact]` or `[Theory]`, and `Assert.*` checks results.

## Jest vs xUnit

| Jest | xUnit |
|---|---|
| `test("adds", () => {...})` | `[Fact] public void Adds() {...}` |
| `test.each([[1], [2]])(...)` | `[Theory] [InlineData(1)] [InlineData(2)]` |
| `expect(x).toBe(3)` | `Assert.Equal(3, x)` (expected first!) |
| `expect(x).toBeNull()` | `Assert.Null(x)` |
| `expect(arr).toHaveLength(1)` | `Assert.Single(list)` |
| `expect(() => f()).toThrow(E)` | `Assert.Throws<E>(() => F())` |
| `await expect(p).rejects.toThrow(E)` | `await Assert.ThrowsAsync<E>(() => FAsync())` |
| `beforeEach` | the test class constructor (a new instance per test) |
| `afterEach` | `IDisposable.Dispose` |
| `jest.fn()` / mocks | hand-written fakes, or Moq / NSubstitute |
| `npm test` | `dotnet test` |

## Shape of a test (Arrange, Act, Assert)

```csharp
[Fact]
public async Task CreateAsync_ValidTitle_TrimsAndSaves()
{
    // Arrange
    var service = new TodoService(new FakeTodoRepository(),
        Options.Create(new TodoOptions()), NullLogger<TodoService>.Instance);

    // Act
    var item = await service.CreateAsync("  Buy milk  ");

    // Assert
    Assert.Equal("Buy milk", item.Title);
}
```

## Running

```bash
dotnet test                                     # all tests
dotnet test --filter "FullyQualifiedName~TodoService"   # subset
dotnet test --logger "console;verbosity=detailed"
```

## Key points

- Async tests return `Task` (never `async void`).
- Test the service through its interfaces: fakes for repositories, `Options.Create(...)` for options, `NullLogger<T>.Instance` for logs.
- Other frameworks you may meet: NUnit (`[Test]`, `[TestCase]`) and MSTest (`[TestMethod]`, `[DataRow]`). Same ideas.
- Integration tests for the whole API use `WebApplicationFactory<Program>` (package `Microsoft.AspNetCore.Mvc.Testing`).
