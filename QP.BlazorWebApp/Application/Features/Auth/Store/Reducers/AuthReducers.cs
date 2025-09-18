using Fluxor;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.BootstrapActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Reducers
{
	public static class AuthReducers
	{
		[ReducerMethod]
		public static AuthState ReduceLogin(AuthState state, Login action)
		{
			return state with { AuthLoading = true };


		}
		[ReducerMethod]
		public static AuthState ReduceLoginSuccess(AuthState state, LoginSuccess action)
		{
			return state with
			{
				AuthLoading = false,
				AccessToken = action.AccessToken,
				Roles = action.Roles,
				IsAuthenticated = true
			};
		}


		[ReducerMethod]
		public static AuthState ReduceLoginError(AuthState state, LoginError action)
		{
			return state with { AuthLoading = false, IsAuthenticated = false };

		}

		[ReducerMethod]
		public static AuthState ReduceRegister(AuthState state, Register action)
		{
			return state with { AuthLoading = true };


		}
		[ReducerMethod]
		public static AuthState ReduceRegisterSuccess(AuthState state, RegisterSuccess action)
		{
			return state with
			{
				AuthLoading = false,
				AccessToken = state.AccessToken,
				Roles = action.Roles,
				IsAuthenticated = true
			};
		}


		[ReducerMethod]
		public static AuthState ReduceCreateProductError(AuthState state, RegisterError action)
		{
			return state with { AuthLoading = false, IsAuthenticated = false };

		}


		[ReducerMethod]
		public static AuthState OnHydrateAuthSuccess(AuthState s, HydrateAuthSuccess a) => s with
		{
			IsAuthenticated = true,
			AccessToken = a.Token,
			Email = a.Email,
			Roles = a.Roles?.ToList()

		};

		[ReducerMethod]
		public static AuthState OnHydrateAuthNone(AuthState _, HydrateAuthNone __) => new();

	}
}
