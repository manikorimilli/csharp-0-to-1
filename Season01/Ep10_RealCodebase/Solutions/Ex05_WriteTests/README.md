# Solution 5: write tests

New file: `tests/RealWorldSample.Tests/Services/TodoServiceCompleteTests.cs`

| Test | What it proves |
|---|---|
| `CompleteAsync_UnknownId_ReturnsFalseAndDoesNotUpdate` | 404 path: no write to the repository |
| `CompleteAsync_ExistingItem_MarksDoneAndSaves` | happy path: state change and one `UpdateAsync` call |
| `CompleteAsync_CalledTwice_KeepsFirstCompletionTime` | completing is idempotent |
| `CreateAsync_RespectsMaxTitleLength` (`[Theory]`, 3 cases) | config-driven validation, trimming before the check |

Techniques used:
- The test class constructor as `beforeEach`.
- `FakeTodoRepository.UpdateCalls` to verify an interaction without a mocking library.
- `Record.ExceptionAsync` to get "the exception or null" instead of `Assert.ThrowsAsync` when a theory mixes success and failure cases.

```bash
cd RealWorldSample
dotnet test --filter "FullyQualifiedName~TodoServiceCompleteTests"
```

Apply: `cp -r Solutions/Ex05_WriteTests/tests RealWorldSample/`
