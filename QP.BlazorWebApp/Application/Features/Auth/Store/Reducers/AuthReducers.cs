using Fluxor;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;

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
                Roles = action.Roles
            };
        }


        [ReducerMethod]
        public static AuthState ReduceLoginError(AuthState state, LoginError action)
        {
            return state with { AuthLoading = false };

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
                Roles = action.Roles
            };
        }


        [ReducerMethod]
        public static AuthState ReduceCreateProductError(AuthState state, RegisterError action)
        {
            return state with { AuthLoading = false };

        }
    }
}
