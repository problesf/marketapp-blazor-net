using QP.BlazorWebApp.Application.Features.Auth.Store;

namespace QP.BlazorWebApp.Application.Core.Handlers;

public class BearerTokenHandler : DelegatingHandler
{
    private readonly AuthFacade _auth;

    public BearerTokenHandler(AuthFacade auth)
    {
        _auth = auth;
    }

    protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken ct)
    {
        var token = _auth.AccessToken; // <- viene del store (Fluxor)
        if (!string.IsNullOrWhiteSpace(token))
        {
            request.Headers.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
        }

        return base.SendAsync(request, ct);
    }
}