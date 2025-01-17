namespace AuthSystem.WebApi.Providers.Ngrok
{
    public interface INgrokDownloader
    {
        Task DownloadExecutableAsync(CancellationToken cancellationToken);
    }
}