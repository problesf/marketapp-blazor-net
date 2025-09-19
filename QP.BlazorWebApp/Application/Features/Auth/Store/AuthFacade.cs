using Fluxor;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.BootstrapActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store
{
    public class AuthFacade
    {
        private readonly IState<AuthState> _state;
        private readonly IDispatcher _dispatcher;

        public AuthFacade(IState<AuthState> state, IDispatcher dispatcher)
        {
            _state = state;
            _dispatcher = dispatcher;
        }

        public IState<AuthState> State => _state;
        public bool IsHydrated => _state.Value.IsHydrated;
        public long ProfileId => _state.Value.ProfileId;

        public bool IsLoading => _state.Value.AuthLoading;
        public string AccessToken => _state.Value.AccessToken;
        public bool IsAuthenticated => _state.Value.IsAuthenticated;
        public ICollection<string> Roles => _state.Value.Roles;

        public void ReHydrate() => _dispatcher.Dispatch(new HydrateAuthFromStorage());

        public void Login(LoginModel model) => _dispatcher.Dispatch(new Login(model));

        public void Register(RegisterModel model) => _dispatcher.Dispatch(new Register(model));

        public void Logout() => _dispatcher.Dispatch(new Logout());

    }

}
