﻿using AuthSystem.WebApi.Providers.Ngrok.Models;

namespace AuthSystem.WebApi.Providers.Ngrok;

public interface INgrokLifetimeHook
{
    Task OnCreatedAsync(TunnelResponse tunnel, CancellationToken cancellationToken);
    Task OnDestroyedAsync(TunnelResponse tunnel, CancellationToken cancellationToken);
}