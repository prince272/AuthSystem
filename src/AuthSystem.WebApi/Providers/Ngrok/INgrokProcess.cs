namespace AuthSystem.WebApi.Providers.Ngrok
{
    public interface INgrokProcess
    {
        Task StartAsync();
        Task StopAsync();
    }
}