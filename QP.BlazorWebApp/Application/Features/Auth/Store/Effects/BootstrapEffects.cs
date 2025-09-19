using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Fluxor;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using QP.BlazorWebApp.Application.Core.Services;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.BootstrapActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Effects
{
    public class BootstrapEffects
    {
        private readonly ProtectedLocalStorage _storage;

        private readonly ITokenService _tokenService;


        public BootstrapEffects(ProtectedLocalStorage storage, ITokenService tokenService)
        {
            _storage = storage;
            _tokenService = tokenService;
        }


        [EffectMethod(typeof(StoreInitializedAction))]
        public Task OnStoreInitializated(IDispatcher dispatcher)
        {
            dispatcher.Dispatch(new HydrateAuthFromStorage());
            return Task.CompletedTask;
        }
        [EffectMethod]
        public async Task OnHydrateAuthFromStorage(HydrateAuthFromStorage _, IDispatcher dispatcher)
        {
            var result = await _storage.GetAsync<AuthSnapshot>("auth");
            var snap = result.Success ? result.Value : null;
            ;

            if (snap?.Token is { Length: > 0 } t && !_tokenService.IsExpired(t))
            {
                ClaimsPrincipal claims = _tokenService.Decode(snap?.Token);
                List<string> roles = _tokenService.GetRoles(snap?.Token);
                long profileId = long.TryParse(claims.FindFirstValue("ProfileId"), out var id) ? id : 0;
                string email = claims.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
                dispatcher.Dispatch(new HydrateAuthSuccess(t, email, profileId, roles));

            }
            else
                dispatcher.Dispatch(new HydrateAuthNone());
        }



    }
}
