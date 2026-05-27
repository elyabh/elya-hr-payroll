namespace ELYA.Infrastructure.BackgroundJobs;

public interface IBackgroundJobScheduler
{
    string Enqueue<T>(System.Linq.Expressions.Expression<Action<T>> methodCall);

    string Schedule<T>(System.Linq.Expressions.Expression<Action<T>> methodCall, TimeSpan delay);
}
