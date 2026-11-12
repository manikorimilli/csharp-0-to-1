using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Models;
using RealWorldSample.Core.Options;

namespace RealWorldSample.Core.Services;

/// <summary>
/// Business rules live here: validation, defaults, what "complete" means.
/// Every dependency arrives through the constructor (constructor injection).
/// The DI container builds this class; nobody calls `new TodoService(...)` in app code.
/// </summary>
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

        // NEW: rule driven by configuration
        var existing = await _repository.GetAllAsync(cancellationToken);
        int open = existing.Count(i => !i.IsDone);
        if (open >= _options.MaxOpenItems)
            throw new InvalidOperationException(
                $"You already have {open} open todos (limit {_options.MaxOpenItems}). Complete some first.");

        var item = new TodoItem { Title = trimmed, CreatedAtUtc = DateTime.UtcNow };
        var saved = await _repository.AddAsync(item, cancellationToken);

        // Structured logging: {TodoId} is a named field, not just text. Do NOT use $"..." here.
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
}
