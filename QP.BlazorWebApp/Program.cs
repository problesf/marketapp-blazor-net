using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;
using MP;
using MudBlazor;
using MudBlazor.Services;
using QP.BlazorWebApp.Application.Features.Auth.Handlers;
using QP.BlazorWebApp.Application.Features.Auth.Store;
using QP.BlazorWebApp.Application.Features.Auth.Store.Providers;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using QP.BlazorWebApp.Application.Features.Products.Store;
using QP.BlazorWebApp.Application.Features.Products.Store.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Application/Core/Pages";
});

builder.Services.AddFluxor(o =>
{
    o.ScanAssemblies(
        typeof(Program).Assembly,
        typeof(ProductsState).Assembly,
        typeof(AuthState).Assembly
    );
    o.UseReduxDevTools();
});
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<ProductsFacade>();
builder.Services.AddScoped<AuthFacade>();
builder.Services.AddMudServices(config =>
{
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.PreventDuplicates = false;
    config.SnackbarConfiguration.NewestOnTop = false;
    config.SnackbarConfiguration.ShowCloseIcon = true;
    config.SnackbarConfiguration.VisibleStateDuration = 5000;
    config.SnackbarConfiguration.HideTransitionDuration = 500;
    config.SnackbarConfiguration.ShowTransitionDuration = 500;
});
builder.Services.AddTransient<FluxorAuthHandler>();
builder.Services.AddScoped<AuthenticationStateProvider, FluxorAuthenticationStateProvider>();
builder.Services.AddAuthenticationCore();
builder.Services.AddScoped<ProtectedLocalStorage>();
builder.Services.AddScoped<HttpClient>(sp =>
{
    var inner = new SocketsHttpHandler();

    var authHandler = ActivatorUtilities.CreateInstance<FluxorAuthHandler>(sp);
    authHandler.InnerHandler = inner;

    var client = new HttpClient(authHandler)
    {
        BaseAddress = new Uri("https://localhost:7189")
    };
    return client;
});

builder.Services.AddScoped<IMPApi>(sp =>
{
    var http = sp.GetRequiredService<HttpClient>();
    return new MPApi("https://localhost:7189", http);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();
