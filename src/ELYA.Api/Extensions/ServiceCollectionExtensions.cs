using ELYA.Api.Tenancy;
using ELYA.Application;
using ELYA.Infrastructure;
using ELYA.Persistence;

namespace ELYA.Api.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApiServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddHttpContextAccessor();
        services.AddScoped<TenantContext>();
        services.AddSingleton<ITenantResolver, TenantResolver>();

        services.AddApplication();
        services.AddPersistence(configuration);
        services.AddInfrastructure();

        services.AddHealthChecks()
            .AddDbContextCheck<ELYA.Persistence.ElyaDbContext>();

        return services;
    }
}
