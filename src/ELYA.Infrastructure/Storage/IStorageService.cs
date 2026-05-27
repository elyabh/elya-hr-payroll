namespace ELYA.Infrastructure.Storage;

public interface IStorageService
{
    Task<string> UploadAsync(string path, Stream content, CancellationToken cancellationToken = default);

    Task<Stream?> DownloadAsync(string path, CancellationToken cancellationToken = default);

    Task DeleteAsync(string path, CancellationToken cancellationToken = default);
}
