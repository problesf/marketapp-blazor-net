using System.IdentityModel.Tokens.Jwt;
using Fluxor;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.BootstrapActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Effects
{
	public class BootstrapEffects
	{
		private readonly ProtectedLocalStorage _storage;

		public BootstrapEffects(ProtectedLocalStorage storage)
		{
			_storage = storage;
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
			if (snap?.Token is { Length: > 0 } t && !IsExpired(t))
				dispatcher.Dispatch(new HydrateAuthSuccess(t, snap.Email, snap.Roles));
			else
				dispatcher.Dispatch(new HydrateAuthNone());
		}
		private static bool IsExpired(string jwt)
		{
			try
			{
				var token = new JwtSecurityTokenHandler().ReadJwtToken(jwt);
				return token.ValidTo <= DateTime.UtcNow;
			}
			catch { return true; }
		}
	}
}
