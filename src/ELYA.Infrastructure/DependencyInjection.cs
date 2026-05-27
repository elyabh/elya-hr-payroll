using ELYA.Infrastructure.BackgroundJobs;
using ELYA.Infrastructure.Cache;
using ELYA.Infrastructure.Email;
using ELYA.Infrastructure.Notifications;
using ELYA.Infrastructure.Storage;
using Microsoft.Extensions.DependencyInjection;

namespace ELYA.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // Sprint 0: register placeholder implementations when real providers are introduced.
        services.AddSingleton<IEmailService, NoOpEmailService>();
        services.AddSingleton<IStorageService, NoOpStorageService>();
        services.AddSingleton<ICacheService, NoOpCacheService>();
        services.AddSingleton<INotificationService, NoOpNotificationService>();
        services.AddSingleton<IBackgroundJobScheduler, NoOpBackgroundJobScheduler>();

        return services;
    }
}

internal sealed class NoOpEmailService : IEmailService
{
    public Task SendAsync(string to, string subject, string body, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}

internal sealed class NoOpStorageService : IStorageService
{
    public Task<string> UploadAsync(string path, Stream content, CancellationToken cancellationToken = default) =>
        Task.FromResult(path);

    public Task<Stream?> DownloadAsync(string path, CancellationToken cancellationToken = default) =>
        Task.FromResult<Stream?>(null);

    public Task DeleteAsync(string path, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}

internal sealed class NoOpCacheService : ICacheService
{
    public Task<T?> GetAsync<T>(string key, CancellationToken cancellationToken = default) =>
        Task.FromResult<T?>(default);

    public Task SetAsync<T>(string key, T value, TimeSpan? expiry = null, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;

    public Task RemoveAsync(string key, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}

internal sealed class NoOpNotificationService : INotificationService
{
    public Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default) =>
        Task.CompletedTask;
}

internal sealed class NoOpBackgroundJobScheduler : IBackgroundJobScheduler
{
    public string Enqueue<T>(System.Linq.Expressions.Expression<Action<T>> methodCall) => Guid.NewGuid().ToString();

    public string Schedule<T>(System.Linq.Expressions.Expression<Action<T>> methodCall, TimeSpan delay) =>
        Guid.NewGuid().ToString();
}
