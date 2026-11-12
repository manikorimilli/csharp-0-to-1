using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;
using RealWorldSample.Core.Options;

namespace RealWorldSample.Core.Services;

public class TodoService : ITodoService
{
    private readonly ITodoRepository _repository;
    private readonly TodoOptions _options;
    private readonly ILogger<TodoService> _logger;

    public TodoService(ITodoRepository repository, IOptions<TodoOptions> options, ILogger<TodoService> logger)
    {
        _repository = repository;
        _options = options.Value;
        _logger = logger;
    }

    public Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
        _repository.GetAllAsync(cancellationToken);

    public Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _repository.GetByIdAsync(id, cancellationToken);

    public async Task<TodoItem> CreateAsync(string title, CancellationToken cancellationToken = default)
    {
        var trimmed = title?.Trim() ?? "";
        if (trimmed.Length == 0)
            throw new ArgumentException("Title is required.", nameof(title));
        if (trimmed.Length > _options.MaxTitleLength)
            throw new ArgumentException($"Title must be at most {_options.MaxTitleLength} characters.", nameof(title));

        var item = new TodoItem { Title = trimmed, CreatedAtUtc = DateTime.UtcNow };
        var saved = await _repository.AddAsync(item, cancellationToken);
        _logger.LogInformation("Created todo {TodoId} with title {Title}", saved.Id, saved.Title);
        return saved;
    }

    public async Task<bool> CompleteAsync(int id, CancellationToken cancellationToken = default)
    {
        var item = await _repository.GetByIdAsync(id, cancellationToken);
        if (item is null)
        {
            _logger.LogWarning("Cannot complete todo {TodoId}: not found", id);
            return false;
        }

        item.MarkDone(DateTime.UtcNow);
        await _repository.UpdateAsync(item, cancellationToken);
        return true;
    }

    // NEW: the repository already supports deletion; the service adds logging (and is where
    // rules like "only the owner may delete" would go).
    public async Task<bool> DeleteAsync(int id, CancellationToken cancellationToken = default)
    {
        bool deleted = await _repository.DeleteAsync(id, cancellationToken);
        if (deleted)
            _logger.LogInformation("Deleted todo {TodoId}", id);
        else
            _logger.LogWarning("Cannot delete todo {TodoId}: not found", id);
        return deleted;
    }
}
