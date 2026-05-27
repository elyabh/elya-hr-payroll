namespace ELYA.Infrastructure.Notifications;

public interface INotificationService
{
    Task SendAsync(string recipient, string message, CancellationToken cancellationToken = default);
}
