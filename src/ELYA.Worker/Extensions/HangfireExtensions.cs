using Hangfire;
using Hangfire.SqlServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ELYA.Worker.Extensions;

public static class HangfireExtensions
{
    /// <summary>
    /// Sprint 0 placeholder for Hangfire + SQL Server storage.
    /// Enable and configure job servers when background jobs are introduced.
    /// </summary>
    public static IServiceCollection AddHangfirePlaceholder(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        if (string.IsNullOrWhiteSpace(connectionString))
        {
            return services;
        }

        services.AddHangfire(config => config
            .SetDataCompatibilityLevel(CompatibilityLevel.Version_180)
            .UseSimpleAssemblyNameTypeSerializer()
            .UseRecommendedSerializerSettings()
            .UseSqlServerStorage(connectionString, new SqlServerStorageOptions
            {
                SchemaName = "Hangfire",
                PrepareSchemaIfNecessary = true
            }));

        // Sprint 0: do not start Hangfire server or register recurring jobs yet.
        // services.AddHangfireServer();

        return services;
    }
}
