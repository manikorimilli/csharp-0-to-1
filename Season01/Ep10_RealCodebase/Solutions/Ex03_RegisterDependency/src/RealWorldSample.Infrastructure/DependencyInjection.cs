using Microsoft.Extensions.DependencyInjection;
using RealWorldSample.Core.Interfaces;
using RealWorldSample.Infrastructure.Repositories;
using RealWorldSample.Infrastructure.Time;

namespace RealWorldSample.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Singleton = one instance for the whole app lifetime.
        // Needed here because the data lives inside the object.
        // (An EF Core repository would be Scoped, like the DbContext it uses.)
        services.AddSingleton<ITodoRepository, InMemoryTodoRepository>();

        // NEW: stateless and thread-safe, so one shared instance is fine.
        services.AddSingleton<IClock, SystemClock>();
        return services;
    }
}
