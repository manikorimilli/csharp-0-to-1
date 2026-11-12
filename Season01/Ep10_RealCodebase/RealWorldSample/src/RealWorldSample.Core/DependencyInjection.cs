using Microsoft.Extensions.DependencyInjection;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Core.Services;

namespace RealWorldSample.Core;

/// <summary>
/// Each layer registers its own services with an extension method, so Program.cs stays short:
///   builder.Services.AddCore();
/// </summary>
public static class DependencyInjection
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // Scoped = one instance per HTTP request. The usual choice for services.
        services.AddScoped<ITodoService, TodoService>();
        return services;
    }
}
