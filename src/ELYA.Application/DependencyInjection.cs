using Microsoft.Extensions.DependencyInjection;

namespace ELYA.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        // Sprint 0: application services and MediatR/validators will be registered in future sprints.
        return services;
    }
}
