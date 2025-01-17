using AuthSystem.WebApi.Providers.Ngrok.Models;

namespace AuthSystem.WebApi.Providers.Ngrok
{
    public interface INgrokApiClient
    {
        Task<TunnelResponse> CreateTunnelAsync(
            string projectName,
            Uri address,
            string? doamin,
            CancellationToken cancellationToken);

        Task<TunnelResponse[]> GetTunnelsAsync(CancellationToken cancellationToken);
        Task<bool> IsNgrokReady(CancellationToken cancellationToken);
    }
}