using System.Net.Http.Headers;
using Fluxor;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;

namespace QP.BlazorWebApp.Application.Features.Auth.Handlers
{
    public sealed class FluxorAuthHandler : DelegatingHandler
    {
        private readonly IState<AuthState> _auth;

        public FluxorAuthHandler(IState<AuthState> auth) => _auth = auth;

        protected override Task<HttpResponseMessage> SendAsync(
            HttpRequestMessage request, CancellationToken ct)
        {
            var token = _auth.Value.AccessToken;
            if (!string.IsNullOrWhiteSpace(token))
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
            else
            {
                request.Headers.Authorization = null;
            }

            return base.SendAsync(request, ct);
        }
    }
}
