using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text.Json;
using Fluxor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MP;
using MudBlazor;
using QP.BlazorWebApp.Application.Core.Services;
using QP.BlazorWebApp.Application.Features.Auth.Model;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using QP.BlazorWebApp.Application.Shared.Exceptions;
using static QP.BlazorWebApp.Application.Features.Auth.Store.Actions.AuthActions;

namespace QP.BlazorWebApp.Application.Features.Auth.Store.Effects
{
    public sealed class AuthEffects
    {
        private readonly IMPApi _api;
        private readonly ISnackbar _snackbar;
        private readonly NavigationManager _nav;
        private readonly ProtectedLocalStorage _storage;
        private readonly ITokenService _tokenService;

        public AuthEffects(IMPApi api, ISnackbar snackbar, NavigationManager nav, ProtectedLocalStorage storage, ITokenService tokenService)
        {
            _api = api;
            _snackbar = snackbar;
            _nav = nav;
            _storage = storage;
            _tokenService = tokenService;


        }
        [EffectMethod]
        public async Task HandleLogout(Logout action, IDispatcher dispatcher)
        {
            await _storage.SetAsync("auth", null);
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


                ClaimsPrincipal claims = _tokenService.Decode(response.AccessToken);
                List<string> roles = _tokenService.GetRoles(response.AccessToken);
                long profileId = long.TryParse(claims.FindFirstValue("ProfileId"), out var id) ? id : 0;
                string email = claims.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
                await _storage.SetAsync("auth", new AuthSnapshot
                {

                    Token = response.AccessToken,
                    Email = email,
                    ProfileId = profileId,
                    Roles = roles
                });

                dispatcher.Dispatch(new LoginSuccess(response.AccessToken, email, profileId, response.Roles));
                navigateTo(claims);


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
                ClaimsPrincipal claims = _tokenService.Decode(accessToken);
                string email = claims.FindFirstValue(JwtRegisteredClaimNames.UniqueName);
                long profileId = long.TryParse(claims.FindFirstValue("ProfileId"), out var id) ? id : 0;

                await _storage.SetAsync("auth", new AuthSnapshot
                {

                    Token = accessToken,
                    Email = email,
                    ProfileId = profileId,
                    Roles = roles?.ToList()
                });

                _snackbar.Add("Registro correcto", Severity.Success);
                dispatcher.Dispatch(new RegisterSuccess(accessToken, email, profileId, roles));
                navigateTo(claims);

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
        private void navigateTo(ClaimsPrincipal claims)
        {
            if (claims.IsInRole("Customer"))
            {
                _nav.NavigateTo("/productos");
            }
            else if (claims.IsInRole("Seller"))
            {
                _nav.NavigateTo("/misproductos");


            }
        }
    }
}
