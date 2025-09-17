using Fluxor;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;

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

        public bool IsLoading => _state.Value.AuthLoading;
        public string AccessToken => _state.Value.AccessToken;
        public ICollection<string> Roles => _state.Value.Roles;

        public void Login(LoginModel model) => _dispatcher.Dispatch(new Login(model));

        public void Register(RegisterModel model) => _dispatcher.Dispatch(new Register(model));
    }

}
