using System.ComponentModel.DataAnnotations;

namespace RealWorldSample.Core.Models;

/// <summary>
/// POST /api/todos body: { "title": "Buy milk", "dueAtUtc": "2030-01-31T17:00:00Z" }
/// NEW: optional DueAtUtc (null when the JSON omits it).
/// </summary>
public record CreateTodoRequest([Required] string Title, DateTime? DueAtUtc = null);
