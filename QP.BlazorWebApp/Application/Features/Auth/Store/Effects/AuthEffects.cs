using System.Text.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Shared.Exceptions;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Effects
{
    public sealed class AuthEffects
    {
        private readonly IMPApi _api;
        private readonly ISnackbar _snackbar;
        private readonly NavigationManager _nav;
        public AuthEffects(IMPApi api, ISnackbar snackbar, NavigationManager nav)
        {
            _api = api;
            _snackbar = snackbar;
            _nav = nav;
        }

        [EffectMethod]
        public async Task HandleLogin(Login action, IDispatcher dispatcher)
        {
            try
            {
                LoginQuery query = new LoginQuery
                {
                    Email = action.Model.Email,
                    Password = action.Model.Password
                };
                var response = await _api.LoginAsync(query);
                _snackbar.Add("Bienvenid@ de nuevo", Severity.Success);
                dispatcher.Dispatch(new LoginSuccess(response.AccessToken, response.Roles));
                _nav.NavigateTo("/productOs");

            }
            catch (ApiException ex)
            {
                ApiErrorDto? error = null;
                try
                {
                    error = JsonSerializer.Deserialize<ApiErrorDto>(ex.Response);
                }
                catch { }

                var msg = error?.Message ?? ex.Message;
                _snackbar.Add(msg, Severity.Error);
                dispatcher.Dispatch(new LoginError(ex.Message));
            }
        }
        [EffectMethod]
        public async Task HandleRegister(Register action, IDispatcher dispatcher)
        {
            try
            {
                RegisterModel model = action.Model;
                string accessToken;
                ICollection<string> roles;
                if (model.UserType == Enum.UserType.Vendedor)
                {
                    RegisterSellerCommand command = new RegisterSellerCommand
                    {
                        Email = model.Email,
                        Password = model.Password1,
                        StoreName = model.StoreName
                    };
                    var response = await _api.SellerAsync(command);
                    accessToken = response.AccessToken;
                    roles = response.Roles;
                }
                else
                {
                    RegisterCustomerCommand command = new RegisterCustomerCommand
                    {
                        Email = model.Email,
                        Password = model.Password1
                    };
                    var response = await _api.CustomerAsync(command);
                    accessToken = response.AccessToken;
                    roles = response.Roles;

                }
                _snackbar.Add("Registro correcto", Severity.Success);
                dispatcher.Dispatch(new RegisterSuccess(accessToken, roles));
                _nav.NavigateTo("/products");

            }
            catch (ApiException ex)
            {
                ApiErrorDto? error = null;
                try
                {
                    error = JsonSerializer.Deserialize<ApiErrorDto>(ex.Response);
                }
                catch { }

                var msg = error?.Message ?? ex.Message;
                _snackbar.Add(msg, Severity.Error);
                dispatcher.Dispatch(new RegisterError(msg));
            }
        }
    }
}
