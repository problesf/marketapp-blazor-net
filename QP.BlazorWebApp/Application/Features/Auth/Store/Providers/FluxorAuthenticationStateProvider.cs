using System.Security.Claims;
using Fluxor;
using Microsoft.AspNetCore.Components.Authorization;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Providers
{
	public class FluxorAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly IState<AuthState> _authState;

		public FluxorAuthenticationStateProvider(IState<AuthState> authState)
		{
			Console.WriteLine("Provider creado");
			_authState = authState;

			_authState.StateChanged += (_, __) => NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
		}

		public override Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var state = _authState.Value;

			if (!state.IsAuthenticated || string.IsNullOrWhiteSpace(state.AccessToken))
			{
				var anonymous = new ClaimsPrincipal(new ClaimsIdentity());
				return Task.FromResult(new AuthenticationState(anonymous));
			}

			var claims = new[]
			{
				new Claim(ClaimTypes.Name, state.Email ?? "user"),
				new Claim("access_token", state.AccessToken),
				new Claim(ClaimTypes.Role, state.Roles.ToString())
			};

			var identity = new ClaimsIdentity(claims, "jwt");
			var user = new ClaimsPrincipal(identity);

			return Task.FromResult(new AuthenticationState(user));
		}
	}
}
