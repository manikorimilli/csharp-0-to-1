using System.ComponentModel.DataAnnotations;

namespace RealWorldSample.Core.Models;

/// <summary>
/// The JSON body for POST /api/todos: { "title": "Buy milk" }.
/// [Required] is an attribute: ASP.NET reads it and returns 400 automatically when it fails
/// (because the controller has [ApiController]).
/// </summary>
public record CreateTodoRequest([Required] string Title);
