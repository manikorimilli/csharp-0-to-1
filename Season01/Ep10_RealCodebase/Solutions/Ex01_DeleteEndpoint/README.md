# Solution 1: add a DELETE endpoint

Changed files (full versions in this folder, same paths as in `RealWorldSample/`):

| File | Change |
|---|---|
| `src/RealWorldSample.Core/Interfaces/ITodoService.cs` | added `Task<bool> DeleteAsync(int id, CancellationToken)` |
| `src/RealWorldSample.Core/Services/TodoService.cs` | implemented it: call the repository, log the outcome |
| `src/RealWorldSample.Api/Controllers/TodosController.cs` | added `[HttpDelete("{id:int}")] Delete(...)` returning `NoContent()` or `NotFound()` |

The repository already had `DeleteAsync`, so Infrastructure did not change.
Notice the direction of work: interface first (the contract), then implementation, then the HTTP edge.

Try it:

```bash
curl -i -X DELETE http://localhost:5080/api/todos/1    # 204
curl -i -X DELETE http://localhost:5080/api/todos/1    # 404
```

Apply this solution to the sample (from the `Ep10_RealCodebase` folder):

```bash
cp -r Solutions/Ex01_DeleteEndpoint/src RealWorldSample/
```
