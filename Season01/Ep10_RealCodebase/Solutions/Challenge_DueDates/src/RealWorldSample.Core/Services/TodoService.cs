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
    private readonly TimeProvider _time;   // NEW: built-in .NET 8 clock abstraction

    public TodoService(ITodoRepository repository, IOptions<TodoOptions> options,
                       ILogger<TodoService> logger, TimeProvider time)
    {
        _repository = repository;
        _options = options.Value;
        _logger = logger;
        _time = time;
    }

    private DateTime UtcNow => _time.GetUtcNow().UtcDateTime;

    public Task<IReadOnlyList<TodoItem>> GetAllAsync(CancellationToken cancellationToken = default) =>
        _repository.GetAllAsync(cancellationToken);

    public Task<TodoItem?> GetByIdAsync(int id, CancellationToken cancellationToken = default) =>
        _repository.GetByIdAsync(id, cancellationToken);

    public async Task<TodoItem> CreateAsync(string title, DateTime? dueAtUtc = null, CancellationToken cancellationToken = default)
    {
        var trimmed = title?.Trim() ?? "";
        if (trimmed.Length == 0)
            throw new ArgumentException("Title is required.", nameof(title));
        if (trimmed.Length > _options.MaxTitleLength)
            throw new ArgumentException($"Title must be at most {_options.MaxTitleLength} characters.", nameof(title));

        var now = UtcNow;
        if (dueAtUtc is { } due && due <= now)
            throw new ArgumentException("Due date must be in the future.", nameof(dueAtUtc));

        var item = new TodoItem
        {
            Title = trimmed,
            CreatedAtUtc = now,
            DueAtUtc = dueAtUtc ?? now.AddDays(_options.DefaultDueInDays)
        };
        var saved = await _repository.AddAsync(item, cancellationToken);
        _logger.LogInformation("Created todo {TodoId} due {DueAtUtc}", saved.Id, saved.DueAtUtc);
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

        item.MarkDone(UtcNow);
        await _repository.UpdateAsync(item, cancellationToken);
        return true;
    }

    public async Task<IReadOnlyList<TodoItem>> GetOverdueAsync(CancellationToken cancellationToken = default)
    {
        var now = UtcNow;
        var items = await _repository.GetAllAsync(cancellationToken);
        var overdue = items.Where(i => i.IsOverdue(now)).OrderBy(i => i.DueAtUtc).ToList();
        if (overdue.Count > 0)
            _logger.LogWarning("{OverdueCount} todos are overdue", overdue.Count);
        return overdue;
    }
}
