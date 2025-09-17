using Fluxor;
using Fluxor.Blazor.Web.ReduxDevTools;
using MP;
using MudBlazor.Services;
using QP.BlazorWebApp.Application.Core.Data;
using QP.BlazorWebApp.Application.Features.Auth.Store;
using QP.BlazorWebApp.Application.Features.Auth.Store.State;
using QP.BlazorWebApp.Application.Features.Products.Store;
using QP.BlazorWebApp.Application.Features.Products.Store.State;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages(options =>
{
    options.RootDirectory = "/Application/Core/Pages";
});


builder.Services.AddHttpClient("MPApi", c =>
{
    c.BaseAddress = new Uri("https://localhost:7189");
});
builder.Services.AddScoped<IMPApi>(sp =>
{
    var http = sp.GetRequiredService<IHttpClientFactory>().CreateClient("MPApi");
    return new MPApi("https://localhost:7189", http);
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
builder.Services.AddMudServices();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();
builder.Services.AddScoped<ProductsFacade>();
builder.Services.AddScoped<AuthFacade>();
builder.Services.AddMudServices();

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
